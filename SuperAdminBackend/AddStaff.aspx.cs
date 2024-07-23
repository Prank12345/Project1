using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_AddStaff : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

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
        Random ren = new Random();
        string vStaffID = "NPCVBAd-" + ren.Next(999999);

        string insertData = "insert into AdminStaff (FullName,Address,StaffID,PhoneNumber,EmailID,UserName,Password,IsDisplay,Qualification,DOB,Gender,MaritalStatus,ManagePopupBanner,StaffManagement,MainSliderImage,SlidingStatement,Gallery,Download,AddFreeTest,CenterVerification,DistributorVerification,VerifyStudent,PendingStudent,CourseType,NewCourse,eWallet,StudentCertification,CenterList,DistributorList,StudentList,Exams,CenterRenewal,ViewCenterQuerries,SendNotification,ChangePassword) values(@FullName,@Address,@StaffID,@PhoneNumber,@EmailID,@UserName,@Password,@IsDisplay,@Qualification,@DOB,@Gender,@MaritalStatus,@ManagePopupBanner,@StaffManagement,@MainSliderImage,@SlidingStatement,@Gallery,@Download,@AddFreeTest,@CenterVerification,@DistributorVerification,@VerifyStudent,@PendingStudent,@CourseType,@NewCourse,@eWallet,@StudentCertification,@CenterList,@DistributorList,@StudentList,@Exams,@CenterRenewal,@ViewCenterQuerries,@SendNotification,@ChangePassword)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@FullName", vName));
        Pram.Add(new SqlParameter("@Address", vAddr));
        Pram.Add(new SqlParameter("@StaffID", vStaffID));
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

        DBT.P_ExecuteNonQuery(insertData, Pram);
        Response.Redirect("ManageStaff.aspx");
    }
}