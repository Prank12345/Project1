using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_ManageStaff : System.Web.UI.Page
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
        string Cid = "";
        if (Session["centerid"]!= null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pram);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string strGetData = "select * from CenterStaff where CID=@CID order by ID desc";
        List<SqlParameter> Param = new List<SqlParameter>();
        Param.Add(new SqlParameter("@CID", Cid));
        gvStaff.DataSource = DBT.P_returnDataSet(strGetData,Param);
        gvStaff.DataBind();
    }
    protected void gvStaff_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvStaff.DataKeys[e.RowIndex].Value.ToString();
        string DeleteCategory = "Delete From CenterStaff Where ID = @ID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        DBT.P_ExecuteNonQuery(DeleteCategory,Pram);
        LoadData();
    }

    protected void chkProfile_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update CenterStaff Set MyProfile = @MyProfile Where ID = @ID";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@MyProfile", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay,pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set MyProfile = @MyProfile Where ID = @ID";

            DBTrac DBT = new DBTrac();
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@MyProfile", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBT.P_ExecuteNonQuery(updateDisplay,pram);


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
            string updateDisplay = "Update CenterStaff Set StaffManagement =@StaffManagement Where ID = @ID";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StaffManagement", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay,pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set StaffManagement = @StaffManagement Where ID = @ID";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StaffManagement", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay,pram);


        }
        LoadData();
    }

    protected void chkStudMgmt_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update CenterStaff Set Student = @Student Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Student", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set Student = @Student Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Student", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }

    protected void chkCourses_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            

            string updateDisplay = "Update CenterStaff Set courses = @courses Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@courses", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set courses = @courses Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@courses", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }

    protected void chkTest_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            
            string updateDisplay = "Update CenterStaff Set Test = @Test Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Test", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set Test = @Test Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Test", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }

    protected void chkStuCerReq_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            
            string updateDisplay = "Update CenterStaff Set StudentCertificateReq = @StudentCertificateReq Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StudentCertificateReq", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set StudentCertificateReq = @StudentCertificateReq Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@StudentCertificateReq", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }

    protected void chkSetExam_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            

            string updateDisplay = "Update CenterStaff Set SetMainExam = @SetMainExam Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SetMainExam", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set SetMainExam = @SetMainExam Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SetMainExam", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }

    protected void chkWallet_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
           

            string updateDisplay = "Update CenterStaff Set eWallet = @eWallet Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@eWallet", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set eWallet = @eWallet Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@eWallet", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);

        }
        LoadData();
    }

    protected void chkSendPass_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            

            string updateDisplay = "Update CenterStaff Set SendStudPass = @SendStudPass Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SendStudPass", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set SendStudPass = @SendStudPass Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@SendStudPass", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }
        LoadData();
    }

    protected void chkMyQry_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {           
            string updateDisplay = "Update CenterStaff Set MyQueries = @MyQueries Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@MyQueries", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set MyQueries = @MyQueries Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@MyQueries", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);
        }
        LoadData();
    }

    protected void chkNotif_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
           
            string updateDisplay = "Update CenterStaff Set Notifications = @Notifications Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Notifications", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set Notifications = @Notifications Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@Notifications", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);
        }
        LoadData();
    }

    protected void gvStaff_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string MyProfile = e.Row.Cells[5].Text.ToString();
            string Staff = e.Row.Cells[7].Text.ToString();
            string Student = e.Row.Cells[9].Text.ToString();
            string courses = e.Row.Cells[11].Text.ToString();
            string Test = e.Row.Cells[13].Text.ToString();
            string StudentCertificateReq = e.Row.Cells[15].Text.ToString();
            string SetMainExam = e.Row.Cells[17].Text.ToString();
            string eWallet = e.Row.Cells[19].Text.ToString();
            string SendStudPass = e.Row.Cells[21].Text.ToString();
            string MyQueries = e.Row.Cells[23].Text.ToString();
            string Notifications = e.Row.Cells[25].Text.ToString();
            string InternalMarks = e.Row.Cells[26].Text.ToString();

            CheckBox chkProfile= (CheckBox)e.Row.FindControl("chkProfile");
            CheckBox chkStaff = (CheckBox)e.Row.FindControl("chkStaff");
            CheckBox chkStudMgmt = (CheckBox)e.Row.FindControl("chkStudMgmt");
            CheckBox chkCourses = (CheckBox)e.Row.FindControl("chkCourses");
            CheckBox chkTest = (CheckBox)e.Row.FindControl("chkTest");
            CheckBox chkStuCerReq = (CheckBox)e.Row.FindControl("chkStuCerReq");
            CheckBox chkSetExam = (CheckBox)e.Row.FindControl("chkSetExam");
            CheckBox chkWallet = (CheckBox)e.Row.FindControl("chkWallet");
            CheckBox chkSendPass = (CheckBox)e.Row.FindControl("chkSendPass");
            CheckBox chkMyQry = (CheckBox)e.Row.FindControl("chkMyQry");
            CheckBox chkNotif = (CheckBox)e.Row.FindControl("chkNotif");
            CheckBox chkInternalMarks = (CheckBox)e.Row.FindControl("chkInternalMarks");

            if (MyProfile.CompareTo("0") == 0)
            {
                e.Row.Cells[5].Text = "No";                
                chkProfile.Checked = false;

            }
            else
            {
                e.Row.Cells[5].Text = "Yes";
                chkProfile.Checked = true;
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

            if (Student.CompareTo("0") == 0)
            {
                e.Row.Cells[9].Text = "No";
                chkStudMgmt.Checked = false;

            }
            else
            {
                e.Row.Cells[9].Text = "Yes";
                chkStudMgmt.Checked = true;
            }

            if (courses.CompareTo("0") == 0)
            {
                e.Row.Cells[11].Text = "No";
                chkCourses.Checked = false;

            }
            else
            {
                e.Row.Cells[11].Text = "Yes";
                chkCourses.Checked = true;
            }

            if (Test.CompareTo("0") == 0)
            {
                e.Row.Cells[13].Text = "No";
                chkTest.Checked = false;

            }
            else
            {
                e.Row.Cells[13].Text = "Yes";
                chkTest.Checked = true;
            }

            if (StudentCertificateReq.CompareTo("0") == 0)
            {
                e.Row.Cells[15].Text = "No";
                chkStuCerReq.Checked = false;

            }
            else
            {
                e.Row.Cells[15].Text = "Yes";
                chkStuCerReq.Checked = true;
            }

            if (SetMainExam.CompareTo("0") == 0)
            {
                e.Row.Cells[17].Text = "No";
                chkSetExam.Checked = false;

            }
            else
            {
                e.Row.Cells[17].Text = "Yes";
                chkSetExam.Checked = true;
            }

            if (eWallet.CompareTo("0") == 0)
            {
                e.Row.Cells[19].Text = "No";
                chkWallet.Checked = false;

            }
            else
            {
                e.Row.Cells[19].Text = "Yes";
                chkWallet.Checked = true;
            }

            if (SendStudPass.CompareTo("0") == 0)
            {
                e.Row.Cells[21].Text = "No";
                chkSendPass.Checked = false;

            }
            else
            {
                e.Row.Cells[21].Text = "Yes";
                chkSendPass.Checked = true;
            }

            if (MyQueries.CompareTo("0") == 0)
            {
                e.Row.Cells[23].Text = "No";
                chkMyQry.Checked = false;

            }
            else
            {
                e.Row.Cells[23].Text = "Yes";
                chkMyQry.Checked = true;
            }

            if (Notifications.CompareTo("0") == 0)
            {
                e.Row.Cells[25].Text = "No";
                chkNotif.Checked = false;

            }
            else
            {
                e.Row.Cells[25].Text = "Yes";
                chkNotif.Checked = true;
            }
            if (InternalMarks.CompareTo("0") == 0)
            {
                e.Row.Cells[27].Text = "No";
                chkInternalMarks.Checked = false;

            }
            else
            {
                e.Row.Cells[27].Text = "Yes";
                chkInternalMarks.Checked = true;
            }

        }
    }

    protected void chkInternalMarks_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvStaff.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            
            string updateDisplay = "Update CenterStaff Set InternalMarks = @InternalMarks Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@InternalMarks", "1"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);
        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterStaff Set InternalMarks = @InternalMarks Where ID = @ID";

            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@InternalMarks", "0"));
            pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, pram);
        }
        LoadData();
    }
}