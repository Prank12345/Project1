using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_MainExam : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            courseExam();
            LoadData();
        }
    }
    protected void LoadData()
    {
        string strGetData = "select * from MainExam order by ID";
        gvExam.DataSource = DBT.returnDataSet(strGetData);
        gvExam.DataBind();
    }
    protected void courseExam()
    {
        string getdata = "select id,FullCourseName from Courses ";
        DataSet ds = DBT.returnDataSet(getdata);
        ddlCourseMain.DataSource = ds;
        ddlCourseMain.DataMember = ds.Tables[0].TableName;
        ddlCourseMain.DataTextField = "FullCourseName";
        ddlCourseMain.DataValueField = "id";
        ddlCourseMain.DataBind();
        ddlCourseMain.Items.Insert(0, new ListItem("--Select Course--", "0"));
    }
    protected void ddlCourseMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getdata = "select id,Semester from Semesters where CourseID=@CourseID" ;
        List<SqlParameter> PRam = new List<SqlParameter>();
        PRam.Add(new SqlParameter("@CourseID", ddlCourseMain.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,PRam);
        ddlSemester.DataSource = ds;
        ddlSemester.DataMember = ds.Tables[0].TableName;
        ddlSemester.DataTextField = "Semester";
        ddlSemester.DataValueField = "id";
        ddlSemester.DataBind();
        ddlSemester.Items.Insert(0, new ListItem("--Select Semester--", "0"));
    }

    protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubject.ClearSelection();
        //string conditionaldata = "select *from MainExam where CourseID='" + ddlCourseMain.SelectedValue + "' and SemesterName='" + ddlSemester.SelectedValue + "'";

        string getdata = "select PaperCode,Subjects from Semesters where Semester=@Semester and CourseID=@CourseID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Semester", ddlSemester.SelectedItem.Text));
        Pram.Add(new SqlParameter("@CourseID", ddlCourseMain.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,Pram);
        string Subject = ds.Tables[0].Rows[0]["Subjects"].ToString();
        string[] Subjectsplit = Subject.Split(',');
        ddlSubject.DataSource = Subjectsplit;
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("--Select Subject--", "-1"));
    }

    protected void btnAddExam_Click(object sender, EventArgs e)
    {
        string SubjectName = ddlSubject.SelectedItem.Text;
        string ExamType = ddlSubjectType.SelectedValue;
        
        string CourseID = ddlCourseMain.SelectedValue;
        string SemesterName = ddlSemester.SelectedValue;
        Random ren = new Random();
        string ExamID = "Main" + ren.Next(999999);
        string strInsertQry = "insert into MainExam(SubjectName,ExamType,CenterID,CreatedOn,ExamID,CourseID,SemesterName) values(@SubjectName,@ExamType,@CenterID,@CreatedOn,@ExamID,@CourseID,@SemesterName)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@SubjectName", SubjectName));
        Pram.Add(new SqlParameter("@ExamType", ExamType));
        Pram.Add(new SqlParameter("@CenterID", ""));
        Pram.Add(new SqlParameter("@CreatedOn", DateTime.Now.ToShortDateString()));
        Pram.Add(new SqlParameter("@ExamID", ExamID));
        Pram.Add(new SqlParameter("@CourseID", CourseID));
        Pram.Add(new SqlParameter("@SemesterName", SemesterName));
        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        // Response.Redirect("MainExam.aspx");
        LoadData();
        ddlSubject.ClearSelection();
        ddlSubjectType.ClearSelection();
    }

    protected void gvExam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvExam.DataKeys[e.RowIndex].Value.ToString();
        string del = "delete from MainExam where id=@id" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", id));

        DBTrac DBT = new DBTrac();
        DBT.P_ExecuteNonQuery(del,Pram);
        LoadData();
    }

    protected void gvExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlExType");
            DataRowView dr = (DataRowView)e.Row.DataItem;

            string vOld = dr["ExamType"].ToString();


            if (vOld == "Theory")
            {

                ddl.Items.FindByValue("Theory").Selected = true;

            }
            else if (vOld == "Practical")
            {
                ddl.Items.FindByValue("Practical").Selected = true;
            }
           

            // HiddenField field = e.Row.FindControl("HFISActive") as HiddenField;
            //HyperLink btn = e.Row.FindControl("hlAddSub") as HyperLink;
            //HyperLink btnV = e.Row.FindControl("hlAddObj") as HyperLink;
            //Button btnVO = e.Row.FindControl("btnViewObj") as Button;
            //Button btnVS = e.Row.FindControl("btnViewSbj") as Button;
            //if (field.Value == "Subjective")
            //{
            // btn.Visible = true;
            //  btnV.Visible = false;
            //btnVO.Visible = false;
            // btnVS.Visible = true;
            //}
            //else
            //{
            //  btn.Visible = false;
            //  btnV.Visible = true;
            //btnVO.Visible = true;
            // btnVS.Visible = false;
            //}
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvExam.DataKeys[row.RowIndex].Value.ToString();
        hfVID.Value = btnSender.CommandArgument;
        LoadRptVObj();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "OpenView();", true);
    }

    //protected void btnViewSbj_Click(object sender, EventArgs e)
    //{
    //    Button btnSender = (Button)sender;
    //    GridViewRow row = (GridViewRow)btnSender.NamingContainer;
    //    string id = gvExam.DataKeys[row.RowIndex].Value.ToString();
       
    //    hfVSub.Value = btnSender.CommandArgument;
    //    LoadRptVSbj();
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "OpenViewSbj();", true);
    //}
    protected void LoadRptVObj()
    {
        string strGetData = "select * from MainExQuestions where ExamID=@ExamID order by ID desc" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ExamID", hfVID.Value));
        rptQuestion.DataSource = DBT.P_returnDataSet(strGetData,Pram);
        rptQuestion.DataBind();
    }
    //protected void LoadRptVSbj()
    //{
    //    string strGetData = "select * from MainExQuestions where ExamID=" + hfVSub.Value;
    //    rptSbj.DataSource = DBT.returnDataSet(strGetData);
    //    rptSbj.DataBind();
    //}
    
    protected void ddlExType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.NamingContainer;
        string exType = ddl.SelectedValue;
        string id = gvExam.DataKeys[row.RowIndex].Value.ToString();
        if (ddl.SelectedValue == "Theory")
        {
            string updateDisplay = "Update MainExam Set ExamType = @ExamType Where ID = @ID";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", id));
            Pram.Add(new SqlParameter("@ExamType", exType));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, Pram);

            LoadData();

        }
        else if (ddl.SelectedValue == "Practical")
        {
            string updateDisplay = "Update MainExam Set ExamType = @ExamType Where ID = @ID";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", id));
            Pram.Add(new SqlParameter("@ExamType", exType));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, Pram);

            LoadData();

        }
    }
}