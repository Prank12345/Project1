using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_CenterEdit : System.Web.UI.Page
{
    static string id = "";
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["ID"].ToString();
        if(!IsPostBack)
        {
            loadData();
        }
    }

    protected void loadData()
    {
        string strGetData = "select * from CenterRegistration where id=@id";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet(strGetData,pram);
        hfID.Value = ds.Tables[0].Rows[0]["CenterID"].ToString();
        txtname.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
        txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
        txtinstit.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        txtpcs.Text = ds.Tables[0].Rows[0]["TotalPC"].ToString();
        ddlState.SelectedItem.Text = ds.Tables[0].Rows[0]["State"].ToString();
        txtpin.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
        txtQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
        txtstaff.Text = ds.Tables[0].Rows[0]["Staffs"].ToString();
        txtTotalPracticalLab.Text = ds.Tables[0].Rows[0]["TotNumPracticalLab"].ToString();
        txtTotalTheoryRoom.Text = ds.Tables[0].Rows[0]["TotNumTheoryRoom"].ToString();
        txtWorkExp.Text = ds.Tables[0].Rows[0]["WorkExp"].ToString();

        lblAadhar.Text = ds.Tables[0].Rows[0]["AadharCard"].ToString();
        lblLab.Text = ds.Tables[0].Rows[0]["LabPicture"].ToString();
        lblMarksheet.Text = ds.Tables[0].Rows[0]["Marksheet"].ToString();
        lblOffice.Text = ds.Tables[0].Rows[0]["OfficePic"].ToString();
        lblPic.Text = ds.Tables[0].Rows[0]["passportpic"].ToString();
        lblRoom.Text = ds.Tables[0].Rows[0]["TheoryRoomPic"].ToString();
        lblSign.Text = ds.Tables[0].Rows[0]["Signature"].ToString();

        imgAadhar.ImageUrl= "~/Center-Document/" + ds.Tables[0].Rows[0]["AadharCard"].ToString();
        imgLab.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["LabPicture"].ToString();
        imgMarksheet.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["Marksheet"].ToString();
        imgOffice.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["OfficePic"].ToString();
        imgPic.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["passportpic"].ToString();
        imgRoom.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["TheoryRoomPic"].ToString();
        imgSign.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["Signature"].ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string PersonName = txtname.Text;
        string Email = txtemail.Text;
        string InstituteName = txtinstit.Text;
        string Address = txtaddress.Text;
        string PinCode = txtpin.Text;
        string TotalPC = txtpcs.Text;
        string Staffs = txtstaff.Text;
        //string PhoneNumber = txtphone.Text;
        string VtotLab = txtTotalPracticalLab.Text;
        string vTotRoom = txtTotalTheoryRoom.Text;
        string vOffice = rblOffice.SelectedValue;
        string vToilet = rblToilet.Text;
        string vQual = txtQualification.Text;
        string vWorkExp = txtWorkExp.Text;
        string vPerform = txtPerform.Text;
        string AadharCard = "";
        string State = ddlState.SelectedItem.Text;
        if (fuAdhaar.HasFile)
        {
            AadharCard =hfID.Value+ fuAdhaar.FileName;
            fuAdhaar.SaveAs(Server.MapPath("~/Center-Document/" + AadharCard));
            
        }
        else
        {
            AadharCard = lblAadhar.Text;
        }
        string Marksheet = "";
        if (fuMarsht.HasFile)
        {
            Marksheet =hfID.Value+ fuMarsht.FileName;
            fuMarsht.SaveAs(Server.MapPath("~/Center-Document/" + Marksheet));
            
        }
        else
        {
            Marksheet = lblMarksheet.Text;
        }
        string passportpic = "";
        if (fuPhoto.HasFile)
        {
            passportpic =hfID.Value+ fuPhoto.FileName;
            fuPhoto.SaveAs(Server.MapPath("~/Center-Document/" + passportpic));
            
        }
        else
        {
            passportpic = lblPic.Text;
        }
        string Signature = "";
        if (fuSign.HasFile)
        {
            Signature =hfID.Value+ fuSign.FileName;
            fuSign.SaveAs(Server.MapPath("~/Center-Document/" + Signature));
            
        }
        else
        {
            Signature = lblSign.Text;
        }
        string vLab = "";
        if (fuLab.HasFile)
        {
            vLab =hfID.Value+ fuLab.FileName;
            fuLab.SaveAs(Server.MapPath("~/Center-Document/" + vLab));
            
        }
        else
        {
            vLab = lblLab.Text;
        }
        string vRoom = "";
        if (fuRoom.HasFile)
        {
            vRoom =hfID.Value+ fuRoom.FileName;
            fuRoom.SaveAs(Server.MapPath("~/Center-Document/" + vRoom));
            
        }
        else
        {
            vRoom = lblRoom.Text;
        }
        string vOfficePic = "";
        if (fuOffice.HasFile)
        {
            vOfficePic =hfID.Value+ fuOffice.FileName;
            fuOffice.SaveAs(Server.MapPath("~/Center-Document/" + vOfficePic));
            
        }
        else
        {
            vOfficePic = lblOffice.Text;
        }
        string strUpdate = "Update CenterRegistration set PersonName=@PersonName,Email=@Email,InstituteName=@InstituteName,Address=@Address,State=@State,PinCode=@PinCode,TotalPC=@TotalPC,Staffs=@Staffs,AadharCard=@AadharCard,Marksheet=@Marksheet,passportpic=@passportpic,Signature=@Signature,TotNumPracticalLab=@TotNumPracticalLab,TotNumTheoryRoom=@TotNumTheoryRoom,LabPicture=@LabPicture,TheoryRoomPic=@TheoryRoomPic,IsOffice=@IsOffice,OfficePic=@OfficePic,Toilet=@Toilet,Qualification=@Qualification,WorkExp=@WorkExp,PlaceOrder=@PlaceOrder where id=@id";

        List<SqlParameter> Pram = new List<SqlParameter>();
        
        Pram.Add(new SqlParameter("@PersonName", PersonName));
        Pram.Add(new SqlParameter("@Email", Email));
        Pram.Add(new SqlParameter("@InstituteName", InstituteName));
        Pram.Add(new SqlParameter("@Address", Address));
        Pram.Add(new SqlParameter("@State", State));
        //Pram.Add(new SqlParameter("@District", District));
        //Pram.Add(new SqlParameter("@City", City));
        Pram.Add(new SqlParameter("@Pincode", PinCode));
        Pram.Add(new SqlParameter("@TotalPC", TotalPC));
        Pram.Add(new SqlParameter("@Staffs", Staffs));
        //Pram.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
      
        Pram.Add(new SqlParameter("@isrequest", "0"));
        Pram.Add(new SqlParameter("@AadharCard", AadharCard));
        Pram.Add(new SqlParameter("@Marksheet", Marksheet));
        Pram.Add(new SqlParameter("@passportpic", passportpic));
        Pram.Add(new SqlParameter("@Signature", Signature));
      
        Pram.Add(new SqlParameter("@TotNumPracticalLab", VtotLab));
        Pram.Add(new SqlParameter("@TotNumTheoryRoom", vTotRoom));
        Pram.Add(new SqlParameter("@LabPicture", vLab));
        Pram.Add(new SqlParameter("@TheoryRoomPic", vRoom));
        Pram.Add(new SqlParameter("@IsOffice", vOffice));
        Pram.Add(new SqlParameter("@OfficePic", vOfficePic));
        Pram.Add(new SqlParameter("@Toilet", vToilet));
        Pram.Add(new SqlParameter("@Qualification", vQual));
        Pram.Add(new SqlParameter("@WorkExp", vWorkExp));
        Pram.Add(new SqlParameter("@PlaceOrder", vPerform));
        Pram.Add(new SqlParameter("@id", Request.QueryString["ID"].ToString()));
        DBT.P_ExecuteNonQuery(strUpdate, Pram);
        Response.Redirect("CenterList.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CenterList.aspx");
    }
}