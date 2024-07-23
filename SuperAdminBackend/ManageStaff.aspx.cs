using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_ManageStaff : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void LoadData()
    {
        
        string strGetData = "select * from AdminStaff order by ID desc";
        gvStaff.DataSource = DBT.returnDataSet(strGetData);
        gvStaff.DataBind();
    }
    protected void gvStaff_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvStaff.DataKeys[e.RowIndex].Value.ToString();
        string DeleteCategory = "Delete From AdminStaff Where ID = " + id;
        DBT.executeNonQuery(DeleteCategory);
        LoadData();
    }

    
    protected void gvStaff_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Banner = e.Row.Cells[5].Text.ToString();
            string Staff = e.Row.Cells[7].Text.ToString();
            string MainSlider = e.Row.Cells[9].Text.ToString();
            string SlidStatement = e.Row.Cells[11].Text.ToString();
            string Gallery = e.Row.Cells[13].Text.ToString();
            string Download = e.Row.Cells[15].Text.ToString();
            string AddFreeTest = e.Row.Cells[17].Text.ToString();
            string CenterVerify = e.Row.Cells[19].Text.ToString();
            string DistributorVerification = e.Row.Cells[21].Text.ToString();
            string VerifyStudent = e.Row.Cells[23].Text.ToString();
            string PendingStudent = e.Row.Cells[25].Text.ToString();
            string CourseType = e.Row.Cells[27].Text.ToString();
            string NewCourse = e.Row.Cells[29].Text.ToString();
            string eWallet = e.Row.Cells[31].Text.ToString();
            string StudentCertification = e.Row.Cells[33].Text.ToString();
            string CenterList = e.Row.Cells[35].Text.ToString();
            string DistributorList = e.Row.Cells[37].Text.ToString();
            string StudentList = e.Row.Cells[39].Text.ToString();
            string Exams = e.Row.Cells[41].Text.ToString();
            string CenterRenewal = e.Row.Cells[43].Text.ToString();
            string ViewCenterQuerries = e.Row.Cells[45].Text.ToString();
            string SendNotification = e.Row.Cells[47].Text.ToString();
            string ChangePassword = e.Row.Cells[49].Text.ToString();
                       
            CheckBox chkBanner = (CheckBox)e.Row.FindControl("chkBanner");
            CheckBox chkStaff = (CheckBox)e.Row.FindControl("chkStaff");
            CheckBox chkMainSlider = (CheckBox)e.Row.FindControl("chkMainSlider");
            CheckBox chkSlidStatement = (CheckBox)e.Row.FindControl("chkSlidStatement");
            CheckBox chkGallery = (CheckBox)e.Row.FindControl("chkGallery");
            CheckBox chkDownload = (CheckBox)e.Row.FindControl("chkDownload");
            CheckBox chkAddFreeTest = (CheckBox)e.Row.FindControl("chkAddFreeTest");
            CheckBox chkCenterVerify = (CheckBox)e.Row.FindControl("chkCenterVerify");
            CheckBox chkDistributorVerification = (CheckBox)e.Row.FindControl("chkDistributorVerification");
            CheckBox chkVerifyStudent = (CheckBox)e.Row.FindControl("chkVerifyStudent");
            CheckBox chkPendingStudent = (CheckBox)e.Row.FindControl("chkPendingStudent");
            CheckBox chkCourseType = (CheckBox)e.Row.FindControl("chkCourseType");
            CheckBox chkNewCourse = (CheckBox)e.Row.FindControl("chkNewCourse");
            CheckBox chkeWallet = (CheckBox)e.Row.FindControl("chkeWallet");
            CheckBox chkStudentCertification = (CheckBox)e.Row.FindControl("chkStudentCertification");
            CheckBox chkCenterList = (CheckBox)e.Row.FindControl("chkCenterList");
            CheckBox chkDistributorList = (CheckBox)e.Row.FindControl("chkDistributorList");
            CheckBox chkStudentList = (CheckBox)e.Row.FindControl("chkStudentList");
            CheckBox chkExams = (CheckBox)e.Row.FindControl("chkExams");
            CheckBox chkCenterRenew = (CheckBox)e.Row.FindControl("chkCenterRenew");
            CheckBox chkViewCenterQuerries = (CheckBox)e.Row.FindControl("chkViewCenterQuerries");
            CheckBox chkSendNotification = (CheckBox)e.Row.FindControl("chkSendNotification");
            CheckBox chkChangePassword = (CheckBox)e.Row.FindControl("chkChangePassword");

            if (Banner.CompareTo("0") == 0)
            {
                e.Row.Cells[5].Text = "No";
                chkBanner.Checked = false;

            }
            else
            {
                e.Row.Cells[5].Text = "Yes";
                chkBanner.Checked = true;
            }

            if (Staff.CompareTo("0") == 0)
            {
                e.Row.Cells[7].Text = "No";
                chkStaff.Checked = false;

            }
            else
            {
                e.Row.Cells[7].Text = "Yes";
                chkStaff.Checked = true;
            }

            if (MainSlider.CompareTo("0") == 0)
            {
                e.Row.Cells[9].Text = "No";
                chkMainSlider.Checked = false;

            }
            else
            {
                e.Row.Cells[9].Text = "Yes";
                chkMainSlider.Checked = true;
            }

            if (SlidStatement.CompareTo("0") == 0)
            {
                e.Row.Cells[11].Text = "No";
                chkSlidStatement.Checked = false;

            }
            else
            {
                e.Row.Cells[11].Text = "Yes";
                chkSlidStatement.Checked = true;
            }

            if (Gallery.CompareTo("0") == 0)
            {
                e.Row.Cells[13].Text = "No";
                chkGallery.Checked = false;

            }
            else
            {
                e.Row.Cells[13].Text = "Yes";
                chkGallery.Checked = true;
            }

            if (Download.CompareTo("0") == 0)
            {
                e.Row.Cells[15].Text = "No";
                chkDownload.Checked = false;

            }
            else
            {
                e.Row.Cells[15].Text = "Yes";
                chkDownload.Checked = true;
            }

            if (AddFreeTest.CompareTo("0") == 0)
            {
                e.Row.Cells[17].Text = "No";
                chkAddFreeTest.Checked = false;

            }
            else
            {
                e.Row.Cells[17].Text = "Yes";
                chkAddFreeTest.Checked = true;
            }

            if (CenterVerify.CompareTo("0") == 0)
            {
                e.Row.Cells[19].Text = "No";
                chkCenterVerify.Checked = false;

            }
            else
            {
                e.Row.Cells[19].Text = "Yes";
                chkCenterVerify.Checked = true;
            }

            if (DistributorVerification.CompareTo("0") == 0)
            {
                e.Row.Cells[21].Text = "No";
                chkDistributorVerification.Checked = false;

            }
            else
            {
                e.Row.Cells[21].Text = "Yes";
                chkDistributorVerification.Checked = true;
            }

            if (VerifyStudent.CompareTo("0") == 0)
            {
                e.Row.Cells[23].Text = "No";
                chkVerifyStudent.Checked = false;

            }
            else
            {
                e.Row.Cells[23].Text = "Yes";
                chkVerifyStudent.Checked = true;
            }

            if (PendingStudent.CompareTo("0") == 0)
            {
                e.Row.Cells[25].Text = "No";
                chkPendingStudent.Checked = false;

            }
            else
            {
                e.Row.Cells[25].Text = "Yes";
                chkPendingStudent.Checked = true;
            }
            if (CourseType.CompareTo("0") == 0)
            {
                e.Row.Cells[27].Text = "No";
                chkCourseType.Checked = false;

            }
            else
            {
                e.Row.Cells[27].Text = "Yes";
                chkCourseType.Checked = true;
            }

            if (NewCourse.CompareTo("0") == 0)
            {
                e.Row.Cells[29].Text = "No";
                chkNewCourse.Checked = false;

            }
            else
            {
                e.Row.Cells[29].Text = "Yes";
                chkNewCourse.Checked = true;
            }

            if (eWallet.CompareTo("0") == 0)
            {
                e.Row.Cells[31].Text = "No";
                chkeWallet.Checked = false;

            }
            else
            {
                e.Row.Cells[31].Text = "Yes";
                chkeWallet.Checked = true;
            }
            if (StudentCertification.CompareTo("0") == 0)
            {
                e.Row.Cells[33].Text = "No";
                chkStudentCertification.Checked = false;
            }
            else
            {
                e.Row.Cells[33].Text = "Yes";
                chkStudentCertification.Checked = true;
            }
            if (CenterList.CompareTo("0") == 0)
            {
                e.Row.Cells[35].Text = "No";
                chkCenterList.Checked = false;

            }
            else
            {
                e.Row.Cells[35].Text = "Yes";
                chkCenterList.Checked = true;
            }

            if (DistributorList.CompareTo("0") == 0)
            {
                e.Row.Cells[37].Text = "No";
                chkDistributorList.Checked = false;

            }
            else
            {
                e.Row.Cells[37].Text = "Yes";
                chkDistributorList.Checked = true;
            }
            if (StudentList.CompareTo("0") == 0)
            {
                e.Row.Cells[39].Text = "No";
                chkStudentList.Checked = false;

            }
            else
            {
                e.Row.Cells[39].Text = "Yes";
                chkStudentList.Checked = true;
            }
            if (Exams.CompareTo("0") == 0)
            {
                e.Row.Cells[41].Text = "No";
                chkExams.Checked = false;
            }
            else
            {
                e.Row.Cells[41].Text = "Yes";
                chkExams.Checked = true;
            }
            if (CenterRenewal.CompareTo("0") == 0)
            {
                e.Row.Cells[43].Text = "No";
                chkCenterRenew.Checked = false;
            }
            else
            {
                e.Row.Cells[43].Text = "Yes";
                chkCenterRenew.Checked = true;
            }
            if (ViewCenterQuerries.CompareTo("0") == 0)
            {
                e.Row.Cells[45].Text = "No";
                chkViewCenterQuerries.Checked = false;
            }
            else
            {
                e.Row.Cells[45].Text = "Yes";
                chkViewCenterQuerries.Checked = true;
            }
            if (SendNotification.CompareTo("0") == 0)
            {
                e.Row.Cells[47].Text = "No";
                chkSendNotification.Checked = false;
            }
            else
            {
                e.Row.Cells[47].Text = "Yes";
                chkSendNotification.Checked = true;
            }
            if (ChangePassword.CompareTo("0") == 0)
            {
                e.Row.Cells[49].Text = "No";
                chkChangePassword.Checked = false;
            }
            else
            {
                e.Row.Cells[49].Text = "Yes";
                chkChangePassword.Checked = true;
            }
        }
    }

    protected void chkBanner_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set ManagePopupBanner = @ManagePopupBanner Where ID = @ID";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ManagePopupBanner", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set ManagePopupBanner = @ManagePopupBanner Where ID = @ID";

            DBTrac DBT = new DBTrac();
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ManagePopupBanner", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }
    protected void chkStaff_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set StaffManagement =@StaffManagement Where ID = @ID";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StaffManagement", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set StaffManagement = @StaffManagement Where ID = @ID";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StaffManagement", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }
    protected void chkMainSlider_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set MainSliderImage = @MainSliderImage Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StaffManagement", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set MainSliderImage = @MainSliderImage Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StaffManagement", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }




    protected void chkSlidStatement_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set SlidingStatement = @SlidingStatement Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SlidingStatement", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set SlidingStatement = @SlidingStatement Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SlidingStatement", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkGallery_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set Gallery = @Gallery Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Gallery", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set Gallery = @Gallery Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Gallery", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkDownload_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set Download = @Download Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Download", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set Download = @Download Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Download", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkAddFreeTest_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set AddFreeTest = @AddFreeTest Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@AddFreeTest", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set AddFreeTest = @AddFreeTest Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@AddFreeTest", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkCenterVerify_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set CenterVerification = @CenterVerification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CenterVerification", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set CenterVerification = @CenterVerification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CenterVerification", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkDistributorVerification_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set DistributorVerification = @DistributorVerification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@DistributorVerification", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set DistributorVerification = @DistributorVerification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@DistributorVerification", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkVerifyStudent_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set VerifyStudent = @VerifyStudent Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@VerifyStudent", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set VerifyStudent = @VerifyStudent Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@VerifyStudent", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }


    protected void chkPendingStudent_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set PendingStudent = @PendingStudent Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@PendingStudent", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set PendingStudent = @PendingStudent Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@PendingStudent", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkCourseType_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set CourseType = @CourseType Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CourseType", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set CourseType = @CourseType Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CourseType", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkNewCourse_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set NewCourse = @NewCourse Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@NewCourse", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set NewCourse = @NewCourse Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@NewCourse", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkeWallet_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set eWallet = @eWallet Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@eWallet", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set eWallet = @eWallet Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@eWallet", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkStudentCertification_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set StudentCertification = @StudentCertification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StudentCertification", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set StudentCertification = @StudentCertification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StudentCertification", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkCenterList_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set CenterList = @CenterList Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CenterList", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set CenterList = @CenterList Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CenterList", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkDistributorList_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set DistributorList = @DistributorList Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@DistributorList", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set DistributorList = @DistributorList Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@DistributorList", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkStudentList_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set StudentList = @StudentList Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StudentList", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set StudentList = @StudentList Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StudentList", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkExams_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set Exams = @Exams Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Exams", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set Exams = @Exams Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Exams", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkViewCenterQuerries_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set ViewCenterQuerries = @ViewCenterQuerries Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ViewCenterQuerries", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set ViewCenterQuerries = @ViewCenterQuerries Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ViewCenterQuerries", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkSendNotification_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set SendNotification = @SendNotification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SendNotification", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set SendNotification = @SendNotification Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SendNotification", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkChangePassword_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set ChangePassword = @ChangePassword Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ChangePassword", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set ChangePassword = @ChangePassword Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ChangePassword", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkCenterRenew_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update AdminStaff Set CenterRenewal = @CenterRenewal Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CenterRenewal", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update AdminStaff Set CenterRenewal = @CenterRenewal Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CenterRenewal", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }
}