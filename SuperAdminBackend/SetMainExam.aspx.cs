using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_SetMainExam : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            exam();
            Student();
            LoadGv();
          
        }
    }
    protected void exam()
    {
        string GetData = "select * from Courses";
        DataSet ds = DBT.returnDataSet(GetData);
        ddlCourse.DataSource = ds;
        ddlCourse.DataMember = ds.Tables[0].TableName;
        ddlCourse.DataTextField = "ShortName";
        ddlCourse.DataValueField = "ID";
        ddlCourse.DataBind();
        ddlCourse.Items.Insert(0, new ListItem("--Select Course--", "0"));
    }
    protected void Student()
    {
        string getdata = "select id,StudentName from AddStudent ";
        DataSet ds = DBT.returnDataSet(getdata);
        gvStudents.DataSource = ds;
        gvStudents.DataBind();

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getdata = "select * from Semesters where CourseID=@CourseID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@CourseID", ddlCourse.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,Pram);
        ddlSemster.DataSource = ds;
        ddlSemster.DataMember = ds.Tables[0].TableName;
        ddlSemster.DataTextField = "Semester";
        ddlSemster.DataValueField = "ID";
        ddlSemster.DataBind();
        ddlSemster.Items.Insert(0, new ListItem("--Select Exam--", "0"));
    }

    protected void ddlSemster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getdata = "select id,SubjectName from MainExam where SemesterName=@SemesterName" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@SemesterName", ddlSemster.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,Pram);
        ddlmainexam.DataSource = ds;
        ddlmainexam.DataMember = ds.Tables[0].TableName;
        ddlmainexam.DataTextField = "SubjectName";
        ddlmainexam.DataValueField = "id";
        ddlmainexam.DataBind();
        ddlmainexam.Items.Insert(0, new ListItem("--Select Maine Exam--", "0"));
    }

    protected void btnaddexam_Click(object sender, EventArgs e)
    {
        string EListid = ddlmainexam.SelectedValue;
        string ExamMode = ddlexammode.SelectedItem.Text;
      
        string EXDate = txtExDate.Text;
        foreach (GridViewRow row in gvStudents.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

            if (chkSelect.Checked == true)
            {
                string selectid = gvStudents.DataKeys[row.RowIndex].Value.ToString();
                string insrtquery = "insert into SetMainExam (EListid,ExamMode,Sid,isdisplay,DateOfExam)values(@EListid,@ExamMode,@Sid,@isdisplay,@DateOfExam)";

                List<SqlParameter> Pram = new List<SqlParameter>();
                Pram.Add(new SqlParameter("@EListid", EListid));
                Pram.Add(new SqlParameter("@ExamMode", ExamMode));
                Pram.Add(new SqlParameter("@Sid", selectid));
                Pram.Add(new SqlParameter("@DateOfExam", EXDate));
                Pram.Add(new SqlParameter("@isdisplay", "1"));

                DBT.P_ExecuteNonQuery(insrtquery, Pram);
            }
        }
        Response.Redirect("SetMainExam.aspx");
    }
    protected void LoadGv()
    {
        string strGetData = "select * from SetMainExam sme join MainExam em on sme.EListid=em.id join AddStudent ast on sme.[Sid]=ast.id";
        gvCenter.DataSource = DBT.returnDataSet(strGetData);
        gvCenter.DataBind();
    }

    protected void lbPop_Click(object sender, EventArgs e)
    {
       
    }
  
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelect = (CheckBox)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)chkSelect.NamingContainer; // get the GridViewRow that contains the linkbutton         
        int idChk = row.RowIndex;
    }
}