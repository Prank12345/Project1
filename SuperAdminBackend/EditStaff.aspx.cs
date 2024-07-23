using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditStaff : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loadData();
        }
    }
    protected void loadData()
    {
        string vID = Request.QueryString["SID"].ToString();
        string strGetData = "select * from AdminStaff where ID=@ID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@ID", vID));
        DataSet ds = DBT.P_returnDataSet(strGetData, pram);
        txtsname.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

        txtemail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
        txtphone.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
        txtUsername.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
        txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
        txtQual.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
        txtdob.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
        rbgender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
        ddlMarital.SelectedItem.Text = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();

        rblPopUp.Items.FindByValue(ds.Tables[0].Rows[0]["ManagePopupBanner"].ToString()).Selected = true;
        rblStaffMgmt.Items.FindByValue(ds.Tables[0].Rows[0]["StaffManagement"].ToString()).Selected = true;
        rblMainSliderImage.Items.FindByValue(ds.Tables[0].Rows[0]["MainSliderImage"].ToString()).Selected = true;
        rblSlidingStatement.Items.FindByValue(ds.Tables[0].Rows[0]["SlidingStatement"].ToString()).Selected = true;
        rblGallery.Items.FindByValue(ds.Tables[0].Rows[0]["Gallery"].ToString()).Selected = true;
        rblDownload.Items.FindByValue(ds.Tables[0].Rows[0]["Download"].ToString()).Selected = true;
        rblAddFreeTest.Items.FindByValue(ds.Tables[0].Rows[0]["AddFreeTest"].ToString()).Selected = true;
        rblCenterVerification.Items.FindByValue(ds.Tables[0].Rows[0]["CenterVerification"].ToString()).Selected = true;
        rblDistributorVerification.Items.FindByValue(ds.Tables[0].Rows[0]["DistributorVerification"].ToString()).Selected = true;
        rblVerifyStudent.Items.FindByValue(ds.Tables[0].Rows[0]["VerifyStudent"].ToString()).Selected = true;
        rblPendingStudent.Items.FindByValue(ds.Tables[0].Rows[0]["PendingStudent"].ToString()).Selected = true;
        rblCourseType.Items.FindByValue(ds.Tables[0].Rows[0]["CourseType"].ToString()).Selected = true;

        rblNewCourse.Items.FindByValue(ds.Tables[0].Rows[0]["NewCourse"].ToString()).Selected = true;
        rbleWallet.Items.FindByValue(ds.Tables[0].Rows[0]["eWallet"].ToString()).Selected = true;
        rblStudentCertification.Items.FindByValue(ds.Tables[0].Rows[0]["StudentCertification"].ToString()).Selected = true;
        rblCenterList.Items.FindByValue(ds.Tables[0].Rows[0]["CenterList"].ToString()).Selected = true;
        rblDistributorList.Items.FindByValue(ds.Tables[0].Rows[0]["DistributorList"].ToString()).Selected = true;
        rblStudentList.Items.FindByValue(ds.Tables[0].Rows[0]["StudentList"].ToString()).Selected = true;
        rblExams.Items.FindByValue(ds.Tables[0].Rows[0]["Exams"].ToString()).Selected = true;
        rblCenterRenewal.Items.FindByValue(ds.Tables[0].Rows[0]["CenterRenewal"].ToString()).Selected = true;
        rblViewCenterQuerries.Items.FindByValue(ds.Tables[0].Rows[0]["ViewCenterQuerries"].ToString()).Selected = true;
        rblSendNotification.Items.FindByValue(ds.Tables[0].Rows[0]["SendNotification"].ToString()).Selected = true;
        rblChangePassword.Items.FindByValue(ds.Tables[0].Rows[0]["ChangePassword"].ToString()).Selected = true;
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
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

        string vPopup = rblPopUp.SelectedValue;
        string vStaffManagement = rblStaffMgmt.SelectedValue;
        string vMainSliderImage = rblMainSliderImage.SelectedValue;
        string vSlidingStatement = rblSlidingStatement.SelectedValue;
        string vGallery = rblGallery.SelectedValue;
        string vDownload = rblDownload.SelectedValue;
        string vAddFreeTest = rblAddFreeTest.SelectedValue;
        string vCenterVerification = rblCenterVerification.SelectedValue;
        string vDistributorVerification = rblDistributorVerification.SelectedValue;
        string vVerifyStudent = rblVerifyStudent.SelectedValue;
        string vPendingStudent = rblPendingStudent.SelectedValue;
        string vCourseType = rblCourseType.SelectedValue;
        string vNewCourse = rblNewCourse.SelectedValue;
        string veWallet = rbleWallet.SelectedValue;
        string vStudentCertification = rblStudentCertification.SelectedValue;
        string vCenterList = rblCenterList.SelectedValue;
        string vDistributorList = rblDistributorList.SelectedValue;
        string vStudentList = rblStudentList.SelectedValue;
        string vExams = rblExams.SelectedValue;
        string vCenterRenewal = rblCenterRenewal.SelectedValue;
        string vViewCenterQuerries = rblViewCenterQuerries.SelectedValue;
        string vSendNotification = rblSendNotification.SelectedValue;
        string vChangePassword = rblChangePassword.SelectedValue;
        string vID = Request.QueryString["SID"].ToString();

        string insertData = "Update AdminStaff set FullName=@FullName,Address=@Address,PhoneNumber=@PhoneNumber,EmailID=@EmailID,UserName=@UserName,Password=@Password,IsDisplay=@IsDisplay,Qualification=@Qualification,DOB=@DOB,Gender=@Gender,MaritalStatus=@MaritalStatus,ManagePopupBanner=@ManagePopupBanner,StaffManagement=@StaffManagement,MainSliderImage=@MainSliderImage,SlidingStatement=@SlidingStatement,Gallery=@Gallery,Download=@Download,AddFreeTest=@AddFreeTest,CenterVerification=@CenterVerification,DistributorVerification=@DistributorVerification,VerifyStudent=@VerifyStudent,PendingStudent=@PendingStudent,CourseType=@CourseType,NewCourse=@NewCourse,eWallet=@eWallet,StudentCertification=@StudentCertification,CenterList=@CenterList,DistributorList=@DistributorList,StudentList=@StudentList,Exams=@Exams,CenterRenewal=@CenterRenewal,ViewCenterQuerries=@ViewCenterQuerries,SendNotification=@SendNotification,ChangePassword=@ChangePassword where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@FullName", vName));
        Pram.Add(new SqlParameter("@Address", vAddr));
       
        Pram.Add(new SqlParameter("@PhoneNumber", vPhone));
        Pram.Add(new SqlParameter("@EmailID", vEmailID));
        Pram.Add(new SqlParameter("@UserName", vUserName));
        Pram.Add(new SqlParameter("@Password", vPass));
        Pram.Add(new SqlParameter("@IsDisplay", "1"));
        Pram.Add(new SqlParameter("@Qualification", vqual));
        Pram.Add(new SqlParameter("@DOB", vDob));
        Pram.Add(new SqlParameter("@Gender", vGender));
        Pram.Add(new SqlParameter("@MaritalStatus", vMaritalStat));
        Pram.Add(new SqlParameter("@ManagePopupBanner", vPopup));
        Pram.Add(new SqlParameter("@StaffManagement", vStaffManagement));
        Pram.Add(new SqlParameter("@MainSliderImage", vMainSliderImage));
        Pram.Add(new SqlParameter("@SlidingStatement", vSlidingStatement));
        Pram.Add(new SqlParameter("@Gallery", vGallery));
        Pram.Add(new SqlParameter("@Download", vDownload));
        Pram.Add(new SqlParameter("@AddFreeTest", vAddFreeTest));
        Pram.Add(new SqlParameter("@CenterVerification", vCenterVerification));
        Pram.Add(new SqlParameter("@DistributorVerification", vDistributorVerification));
        Pram.Add(new SqlParameter("@VerifyStudent", vVerifyStudent));
        Pram.Add(new SqlParameter("@PendingStudent", vPendingStudent));
        Pram.Add(new SqlParameter("@CourseType", vCourseType));
        Pram.Add(new SqlParameter("@NewCourse", vNewCourse));
        Pram.Add(new SqlParameter("@eWallet", veWallet));
        Pram.Add(new SqlParameter("@StudentCertification", vStudentCertification));
        Pram.Add(new SqlParameter("@CenterList", vCenterList));
        Pram.Add(new SqlParameter("@DistributorList", vDistributorList));
        Pram.Add(new SqlParameter("@StudentList", vStudentList));
        Pram.Add(new SqlParameter("@Exams", vExams));
        Pram.Add(new SqlParameter("@CenterRenewal", vCenterRenewal));
        Pram.Add(new SqlParameter("@ViewCenterQuerries", vViewCenterQuerries));
        Pram.Add(new SqlParameter("@SendNotification", vSendNotification));
        Pram.Add(new SqlParameter("@ChangePassword", vChangePassword));

        Pram.Add(new SqlParameter("@ID",vID));

        DBT.P_ExecuteNonQuery(insertData, Pram);
        Response.Redirect("ManageStaff.aspx");
    }
}