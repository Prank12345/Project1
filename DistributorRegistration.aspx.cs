using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class DistributorRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
        //    string vValidDate = DateTime.Now.AddYears(2).ToShortDateString();
        //}
    }
    DBTrac DBT = new DBTrac();
    protected void btnregister_Click(object sender, EventArgs e)
    {
        string vName = txtname.Text;
        string vFathername = txtFatherName.Text;
        string vAddress = txtaddress.Text;
        string vState = ddlState.SelectedItem.Text;
        string vIdProofType = ddlIdProof.SelectedItem.Text;
        string vPhone = txtphone.Text;
        string vEmail = txtemail.Text;
        string vDOB = txtDOB.Text;
        string vValidDate = DateTime.Now.AddYears(2).ToShortDateString();
        Random rem = new Random();
        string distributorID = "NPCVB-D" + rem.Next(999999);

        string imgUpload = "";
        if (fuPhoto.HasFile)
        {
            imgUpload = rem.Next(999999) + fuPhoto.FileName;
            fuPhoto.SaveAs(Server.MapPath("~/Distributor-Docs/" + imgUpload));
        }
        string CancelldChk = "";
        if (fuCancelled.HasFile)
        {
            CancelldChk = rem.Next(999999) + fuPhoto.FileName;
            fuCancelled.SaveAs(Server.MapPath("~/Distributor-Docs/" + CancelldChk));
        }

        string IDProof = "";
        if (fuAdhaar.HasFile)
        {
            IDProof = rem.Next(999999) + fuPhoto.FileName;
            fuAdhaar.SaveAs(Server.MapPath("~/Distributor-Docs/" + IDProof));
        }
        string ChkData = "select * from Distributors where EmailID=@EmailID or PhoneNumber=@PhoneNumber";
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@EmailID", txtemail.Text));
        prm.Add(new SqlParameter("@PhoneNumber", txtphone.Text));
        DataSet ds = DBT.P_returnDataSet(ChkData,prm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('EmailID and Mobile Number Has Been Already Registered....');</script>");
        }
        else
        {
            string insertqry = "insert into Distributors (FullName,FatherName,PassportImage,CancelledChk,IDProofType,IDProofImg,DOB,FullAddress,PhoneNumber,EmailID,State,IsDisplay,IsRequest,Password,DistributorID,Comission,JoinDate,ValidDate,IsLogin) values(@FullName,@FatherName,@PassportImage,@CancelledChk,@IDProofType,@IDProofImg,@DOB,@FullAddress,@PhoneNumber,@EmailID,@State,@IsDisplay,@IsRequest,@Password,@DistributorID,@Comission,@JoinDate,@ValidDate,@IsLogin)";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@FullName", vName));
            Pram.Add(new SqlParameter("@FatherName", vFathername));
            Pram.Add(new SqlParameter("@PassportImage", imgUpload));
            Pram.Add(new SqlParameter("@CancelledChk", CancelldChk));
            Pram.Add(new SqlParameter("@IDProofType", vIdProofType));
            Pram.Add(new SqlParameter("@IDProofImg", IDProof));
            Pram.Add(new SqlParameter("@DOB", vDOB));
            Pram.Add(new SqlParameter("@FullAddress", vAddress));
            Pram.Add(new SqlParameter("@PhoneNumber", vPhone));
            Pram.Add(new SqlParameter("@EmailID", vEmail));
            Pram.Add(new SqlParameter("@State", vState));
            Pram.Add(new SqlParameter("@IsDisplay", "1"));
            Pram.Add(new SqlParameter("@IsRequest", "0"));
            Pram.Add(new SqlParameter("@Password", "test"));
            Pram.Add(new SqlParameter("@DistributorID", distributorID));
            Pram.Add(new SqlParameter("@Comission", "0"));
            Pram.Add(new SqlParameter("@JoinDate", DateTime.Today.ToShortDateString()));
            Pram.Add(new SqlParameter("@ValidDate", vValidDate));
            Pram.Add(new SqlParameter("@IsLogin", "1"));

            DBT.P_ExecuteNonQuery(insertqry, Pram);
            string id = "select Max(ID) from Distributors";
            string str = DBT.returnOneValue(id);
            string strInsert = "insert into DistributorWallet (DistributorID,Amount,DID) values(@DistributorID,@Amount,@DID)";
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@DistributorID", distributorID));
            Param.Add(new SqlParameter("@DID", str));
            Param.Add(new SqlParameter("@Amount", "0.00"));
            DBT.P_ExecuteNonQuery(strInsert, Param);

            Response.Write("<script language='javascript'>window.alert('Your online Application Form has been succesfully Recieved wait for further information');window.location='Default.aspx';</script>");
        }
    }
}