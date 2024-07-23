using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditDistributor : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
        }
    }
    protected void LoadData()
    {
        string GetData = "select * from Distributors where ID=@ID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["DID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(GetData,Pram);
        txtname.Text=ds.Tables[0].Rows[0]["FullName"].ToString();
        txtFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
        txtaddress.Text = ds.Tables[0].Rows[0]["FullAddress"].ToString();
        ddlState.SelectedItem.Text = ds.Tables[0].Rows[0]["State"].ToString();
        ddlIdProof.SelectedItem.Text = ds.Tables[0].Rows[0]["IDProofType"].ToString();
        txtphone.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
        txtemail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
        txtDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
        lblPic.Text = ds.Tables[0].Rows[0]["PassportImage"].ToString();
        lblIDProof.Text = ds.Tables[0].Rows[0]["IDProofImg"].ToString();
        lblCancelled.Text = ds.Tables[0].Rows[0]["CancelledChk"].ToString();
        imgCancelled.ImageUrl = "~/Distributor-Docs/" + ds.Tables[0].Rows[0]["CancelledChk"].ToString();
        imgIdProof.ImageUrl = "~/Distributor-Docs/" + ds.Tables[0].Rows[0]["IDProofImg"].ToString();
        imgPic.ImageUrl = "~/Distributor-Docs/" + ds.Tables[0].Rows[0]["PassportImage"].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string vName = txtname.Text;
        string vFathername = txtFatherName.Text;
        string vAddress = txtaddress.Text;
        string vState = ddlState.SelectedItem.Text;
        string vIdProofType = ddlIdProof.SelectedItem.Text;
        string vPhone = txtphone.Text;
        string vEmail = txtemail.Text;
        string vDOB = txtDOB.Text;
        string vCommission = txtComission.Text;
        Random rem = new Random();
        

        string imgUpload = "";
        if (fuPhoto.HasFile)
        {
            imgUpload = rem.Next(999999) + fuPhoto.FileName;
            fuPhoto.SaveAs(Server.MapPath("~/Distributor-Docs/" + imgUpload));
        }
        else
        {
            imgUpload = lblPic.Text;
        }
        string CancelldChk = "";
        if (fuCancelled.HasFile)
        {
            CancelldChk = rem.Next(999999) + fuPhoto.FileName;
            fuCancelled.SaveAs(Server.MapPath("~/Distributor-Docs/" + CancelldChk));
        }
        else
        {
            CancelldChk = lblCancelled.Text;
        }
        string IDProof = "";
        if (fuAdhaar.HasFile)
        {
            IDProof = rem.Next(999999) + fuPhoto.FileName;
            fuAdhaar.SaveAs(Server.MapPath("~/Distributor-Docs/" + IDProof));
        }
        else
        {
            IDProof = lblIDProof.Text;
        }
        string insertqry = "update Distributors set FullName=@FullName,FatherName=@FatherName,PassportImage=@PassportImage,CancelledChk=@CancelledChk,IDProofType=@IDProofType,IDProofImg=@IDProofImg,DOB=@DOB,FullAddress=@FullAddress,PhoneNumber=@PhoneNumber,EmailID=@EmailID,State=@State,Comission=@Comission where ID=@ID" ;
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
        Pram.Add(new SqlParameter("@Comission", vCommission));
        Pram.Add(new SqlParameter("@ID", Request.QueryString["DID"].ToString()));

        DBT.P_ExecuteNonQuery(insertqry, Pram);
        Response.Redirect("DistributorList.aspx");
    }
}