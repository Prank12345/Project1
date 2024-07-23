using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_AddStaff : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string vName = txtsname.Text;
        string vAddr = txtaddress.Text;

        string vStaffID = "";

        string vEmailID = txtemail.Text;
        string vPhone = txtphone.Text;
        string vUserName = txtUsername.Text;
        string vPass = txtPassword.Text;
        string vqual = txtQual.Text;
        string vDob = txtdob.Text;
        string vGender = rbgender.SelectedValue;
        string vMaritalStat = ddlMarital.SelectedItem.Text;

        string vMyProf = rblProfile.SelectedValue;
        string vStaffMgmt =rblStaffMgmt.SelectedValue;
        string vStud =rblStudMgmt.SelectedValue;
        string vCourse =rblCourses.SelectedValue;
        string vTest =rblTest.SelectedValue;
        string vStudCertiReq = rblStudCertiReq.SelectedValue;
        string vSetMainExam =rblSetExam.SelectedValue;
        string vEWallet =rblEWallet.SelectedValue;
        string vSendStudPass =rblStuPass.SelectedValue;
        string vMyquery =rblMyQry.SelectedValue;
        string vNotif =rblNotif.SelectedValue;
        string vInternal = rblIntrnalMarks.SelectedValue;
       
        string vCid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            vCid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = " + Session["StaffID"].ToString();
            DataSet dsStLogin = DBT.returnDataSet(strGetStaffData);
            vCid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string insertData = "insert into CenterStaff (FullName,Address,StaffID,PhoneNumber,EmailID,UserName,Password,IsDisplay,Qualification,DOB,Gender,MaritalStatus,MyProfile,StaffManagement,Student,courses,Test,StudentCertificateReq,SetMainExam,eWallet,SendStudPass,MyQueries,Notifications,CID,InternalMarks) values(@FullName,@Address,@StaffID,@PhoneNumber,@EmailID,@UserName,@Password,@IsDisplay,@Qualification,@DOB,@Gender,@MaritalStatus,@MyProfile,@StaffManagement,@Student,@courses,@Test,@StudentCertificateReq,@SetMainExam,@eWallet,@SendStudPass,@MyQueries,@Notifications,@CID,@InternalMarks)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@FullName", vName));
        Pram.Add(new SqlParameter("@Address", vAddr));
        Pram.Add(new SqlParameter("@StaffID", vStaffID));
        Pram.Add(new SqlParameter("@PhoneNumber",vPhone ));
        Pram.Add(new SqlParameter("@EmailID", vEmailID));
        Pram.Add(new SqlParameter("@UserName",vUserName ));
        Pram.Add(new SqlParameter("@Password", vPass));
        Pram.Add(new SqlParameter("@IsDisplay","1" ));
        Pram.Add(new SqlParameter("@Qualification",vqual ));
        Pram.Add(new SqlParameter("@DOB", vDob));
        Pram.Add(new SqlParameter("@Gender", vGender));
        Pram.Add(new SqlParameter("@MaritalStatus",vMaritalStat));
        Pram.Add(new SqlParameter("@MyProfile",vMyProf));
        Pram.Add(new SqlParameter("@StaffManagement",vStaffMgmt));
        Pram.Add(new SqlParameter("@Student",vStud));
        Pram.Add(new SqlParameter("@courses",vCourse));
        Pram.Add(new SqlParameter("@Test",vTest));
        Pram.Add(new SqlParameter("@StudentCertificateReq",vStudCertiReq));
        Pram.Add(new SqlParameter("@SetMainExam",vSetMainExam));
        Pram.Add(new SqlParameter("@eWallet",vEWallet));
        Pram.Add(new SqlParameter("@SendStudPass",vSendStudPass));
        Pram.Add(new SqlParameter("@MyQueries",vMyquery));
        Pram.Add(new SqlParameter("@Notifications",vNotif));
        Pram.Add(new SqlParameter("@CID", vCid));
        Pram.Add(new SqlParameter("@InternalMarks", vInternal));

        DBT.P_ExecuteNonQuery(insertData, Pram);
        Response.Redirect("ManageStaff.aspx");
    }
}