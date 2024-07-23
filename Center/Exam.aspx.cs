using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_Exam : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            courseExam();
            LoadData();
        }
    }
    protected void LoadData()
    {
        string strGetData = "select * from MainExam";
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
        string getdata = "select id,Semester from Semesters where CourseID=@CourseID";
        List<SqlParameter> PR = new List<SqlParameter>();
        PR.Add(new SqlParameter("@CourseID", ddlCourseMain.SelectedValue));
        DataSet ds = DBT.returnDataSet(getdata);
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
        string getdata = "select id,Subjects from Semesters where Semester=@Semester and CourseID=@CourseID";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@CourseID", ddlCourseMain.SelectedValue));
        Pr.Add(new SqlParameter("@Semester", ddlSemester.SelectedItem.Text));
        DataSet ds = DBT.returnDataSet(getdata);
        string Subject = ds.Tables[0].Rows[0]["Subjects"].ToString();
        string[] Subjectsplit = Subject.Split(',');
        ddlSubject.DataSource = Subjectsplit;
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("--Select Subject--", "-1"));
    }

    protected void btnAddExam_Click(object sender, EventArgs e)
    {
        string SubjectName = ddlSubject.SelectedItem.Text;
        string ExamType = rblType.SelectedValue;
        string CenterID = Session["centerid"].ToString();
        string CourseID = ddlCourseMain.SelectedValue;
        string SemesterName = ddlSemester.SelectedItem.Text;
        Random ren = new Random();
        string ExamID = "Main" + ren.Next(999999);
        string strInsertQry = "insert into MainExam(SubjectName,ExamType,CenterID,CreatedOn,ExamID,CourseID,SemesterName) values(@SubjectName,@ExamType,@CenterID,@CreatedOn,@ExamID,@CourseID,@SemesterName)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@SubjectName", SubjectName));
        Pram.Add(new SqlParameter("@ExamType", ExamType));
        Pram.Add(new SqlParameter("@CenterID", CenterID));
        Pram.Add(new SqlParameter("@CreatedOn", DateTime.Now.ToShortDateString()));
        Pram.Add(new SqlParameter("@ExamID", ExamID));
        Pram.Add(new SqlParameter("@CourseID", CourseID));
        Pram.Add(new SqlParameter("@SemesterName", SemesterName));
        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        Response.Redirect("Exam.aspx");       
    }

    protected void gvExam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvExam.DataKeys[e.RowIndex].Value.ToString();
        string del = "delete from MainExam where id=@id";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", id));
        DBTrac DBT = new DBTrac();
        DBT.P_ExecuteNonQuery(del,Pram);
        LoadData();
    }

    protected void gvExam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField field = e.Row.FindControl("HFISActive") as HiddenField;
            HyperLink btn = e.Row.FindControl("hlAddSub") as HyperLink;
            HyperLink btnV = e.Row.FindControl("hlAddObj") as HyperLink;
            if(field.Value== "Subjective")
            {
                btn.Visible = true;
                btnV.Visible = false;
            }
            else
            {
                btn.Visible = false;
                btnV.Visible = true;
            }
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvExam.DataKeys[row.RowIndex].Value.ToString();
        hfVID.Value = btnSender.CommandArgument;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "OpenView();", true);
    }       
}