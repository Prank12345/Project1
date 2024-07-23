using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_EditStaff : System.Web.UI.Page
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
        string strGetData = "select * from CenterStaff where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["SID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        txtsname.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

        txtemail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
        txtphone.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
        txtUsername.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
        txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
        txtQual.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
        txtdob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
        rbgender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
        //rbgender.Items.FindByValue(ds.Tables[0].Rows[0]["Gender"].ToString()).Selected = true; 
        ddlMarital.SelectedItem.Text = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();

        rblProfile.Items.FindByValue(ds.Tables[0].Rows[0]["MyProfile"].ToString()).Selected = true;
        rblStaffMgmt.Items.FindByValue(ds.Tables[0].Rows[0]["StaffManagement"].ToString()).Selected = true;
        rblStudMgmt.Items.FindByValue(ds.Tables[0].Rows[0]["Student"].ToString()).Selected = true;
        rblCourses.Items.FindByValue(ds.Tables[0].Rows[0]["courses"].ToString()).Selected = true; 
        rblTest.Items.FindByValue(ds.Tables[0].Rows[0]["Test"].ToString()).Selected = true;
        rblStudCertiReq.Items.FindByValue(ds.Tables[0].Rows[0]["StudentCertificateReq"].ToString()).Selected = true;
        rblSetExam.Items.FindByValue(ds.Tables[0].Rows[0]["SetMainExam"].ToString()).Selected = true;
        rblEWallet.Items.FindByValue(ds.Tables[0].Rows[0]["eWallet"].ToString()).Selected = true;
        rblStuPass.Items.FindByValue(ds.Tables[0].Rows[0]["SendStudPass"].ToString()).Selected = true;
        rblMyQry.Items.FindByValue(ds.Tables[0].Rows[0]["MyQueries"].ToString()).Selected = true;
        rblNotif.Items.FindByValue(ds.Tables[0].Rows[0]["Notifications"].ToString()).Selected = true;
        rblIntrnalMarks.Items.FindByValue(ds.Tables[0].Rows[0]["InternalMarks"].ToString()).Selected = true;

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string vName = txtsname.Text;
        string vAddr = txtaddress.Text;
        
        string vEmailID = txtemail.Text;
        string vPhone = txtphone.Text;
        string vUserName = txtUsername.Text;
        string vPass = txtPassword.Text;
        string vqual = txtQual.Text;
        string vDob = txtdob.Text;
        string vGender = rbgender.SelectedValue;
        string vMaritalStat = ddlMarital.SelectedItem.Text;

        string vMyProf = rblProfile.SelectedValue;
        string vStaffMgmt = rblStaffMgmt.SelectedValue;
        string vStud = rblStudMgmt.SelectedValue;
        string vCourse = rblCourses.SelectedValue;
        string vTest = rblTest.SelectedValue;
        string vStudCertiReq = rblStudCertiReq.SelectedValue;
        string vSetMainExam = rblSetExam.SelectedValue;
        string vEWallet = rblEWallet.SelectedValue;
        string vSendStudPass = rblStuPass.SelectedValue;
        string vMyquery = rblMyQry.SelectedValue;
        string vNotif = rblNotif.SelectedValue;
        string vInternal = rblIntrnalMarks.SelectedValue;

        string insertData = "Update CenterStaff set FullName=@FullName,Address=@Address,PhoneNumber=@PhoneNumber,EmailID=@EmailID,UserName=@UserName,Password=@Password,Qualification=@Qualification,DOB=@DOB,Gender=@Gender,MaritalStatus=@MaritalStatus,MyProfile=@MyProfile,StaffManagement=@StaffManagement,Student=@Student,courses=@courses,Test=@Test,StudentCertificateReq=@StudentCertificateReq,SetMainExam=@SetMainExam,eWallet=@eWallet,SendStudPass=@SendStudPass,MyQueries=@MyQueries,Notifications=@Notifications,InternalMarks=@InternalMarks where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@FullName", vName));
        Pram.Add(new SqlParameter("@Address", vAddr));
      
        Pram.Add(new SqlParameter("@PhoneNumber", vPhone));
        Pram.Add(new SqlParameter("@EmailID", vEmailID));
        Pram.Add(new SqlParameter("@UserName", vUserName));
        Pram.Add(new SqlParameter("@Password", vPass));
       
        Pram.Add(new SqlParameter("@Qualification", vqual));
        Pram.Add(new SqlParameter("@DOB", vDob));
        Pram.Add(new SqlParameter("@Gender", vGender));
        Pram.Add(new SqlParameter("@MaritalStatus", vMaritalStat));
        Pram.Add(new SqlParameter("@MyProfile", vMyProf));
        Pram.Add(new SqlParameter("@StaffManagement", vStaffMgmt));
        Pram.Add(new SqlParameter("@Student", vStud));
        Pram.Add(new SqlParameter("@courses", vCourse));
        Pram.Add(new SqlParameter("@Test", vTest));
        Pram.Add(new SqlParameter("@StudentCertificateReq", vStudCertiReq));
        Pram.Add(new SqlParameter("@SetMainExam", vSetMainExam));
        Pram.Add(new SqlParameter("@eWallet", vEWallet));
        Pram.Add(new SqlParameter("@SendStudPass", vSendStudPass));
        Pram.Add(new SqlParameter("@MyQueries", vMyquery));
        Pram.Add(new SqlParameter("@Notifications", vNotif));
        Pram.Add(new SqlParameter("@InternalMarks", vInternal));
        Pram.Add(new SqlParameter("@ID", Request.QueryString["SID"].ToString()));

        DBT.P_ExecuteNonQuery(insertData, Pram);
        Response.Redirect("ManageStaff.aspx");
    }
}