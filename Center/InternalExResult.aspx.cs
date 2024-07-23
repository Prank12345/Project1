using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_InternalExResult : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadStudent();
            // LoadExam();
            //LoadCourse();
            loadStudent();
        }
    }
    //protected void LoadCourse()
    //{
    //    string GetData = "select * from Courses";
    //    DataSet ds = DBT.returnDataSet(GetData);
    //    ddlCourse.DataSource = ds;
    //    ddlCourse.DataMember = ds.Tables[0].TableName;
    //    ddlCourse.DataTextField = "ShortName";
    //    ddlCourse.DataValueField = "ID";
    //    ddlCourse.DataBind();
    //    ddlCourse.Items.Insert(0, new ListItem("--Select Course--", "0"));
    //}
    protected void loadStudent()
    {
        string CenterID = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            CenterID = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pr);
            CenterID = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string strGetData = "select * from AddStudent where Cid=@Cid";
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@Cid", CenterID));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pr1);
        ddlStudent.DataSource = ds;
        ddlStudent.DataMember = ds.Tables[0].TableName;
        ddlStudent.DataTextField = "StudentID";
        ddlStudent.DataValueField = "id";
        ddlStudent.DataBind();
        ddlStudent.Items.Insert(0, new ListItem("--Select Student--", "0"));
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ID", ddlSubject.SelectedValue));
        string selectCourse = DBT.P_returnOneValue("select CourseID from MainExam where ID=@ID",pr );
        
        string SemID = DBT.P_returnOneValue("select SemID from SetMainExam where EListid=@ID",pr);
        txtSem.Text = SemID;
        txtExMaxMarks.Text = "70";
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@ExamID", ddlSubject.SelectedValue));
        pr1.Add(new SqlParameter("@StuID", ddlStudent.SelectedValue));
        string GetMarks = DBT.P_returnOneValue("select ObtainedMarks from Result where ExamID=@ExamID and StuID=@StuID",pr1);
        txtMarksExObt.Text = GetMarks;
    }

    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@id", ddlStudent.SelectedValue));
        string getCouseID = DBT.P_returnOneValue("select Course from AddStudent where id=@id",Pr);
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@CourseID", getCouseID));
        string getdata = "select * from Semesters where CourseID=@CourseID" ;
        DataSet dsn = DBT.P_returnDataSet(getdata,Pr1);
        ddlSemster.DataSource = dsn;
        ddlSemster.DataMember = dsn.Tables[0].TableName;
        ddlSemster.DataTextField = "Semester";
        ddlSemster.DataValueField = "ID";
        ddlSemster.DataBind();
        ddlSemster.Items.Insert(0, new ListItem("--Select Semester--", "0"));

        string GetData = "select * from AddStudent where Id=@Id";
        List<SqlParameter> Pr2 = new List<SqlParameter>();
        Pr2.Add(new SqlParameter("@Id", ddlStudent.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(GetData,Pr2);
        txtstuname.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        imgStudentImg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
        string CourseID = "";
        CourseID = ds.Tables[0].Rows[0]["Course"].ToString();
        List<SqlParameter> Pr3 = new List<SqlParameter>();
        Pr3.Add(new SqlParameter("@Id", CourseID));
        string GetCourseName = DBT.P_returnOneValue("select FullCourseName from Courses where id=@id",Pr3);
        txtcourse.Text = GetCourseName;
        
        
    }
    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string vMArksObtained = txtmarks.Text;
        string vstudentID = ddlStudent.SelectedValue;
        string vSemID = txtSem.Text;
        string vExamID = ddlSubject.SelectedValue;

        string Grade = "";

        string TotalMarksObtained = "";
        int tempInMark = Convert.ToInt32(vMArksObtained);
        int temExMark = Convert.ToInt32(txtMarksExObt.Text);
        int tot = temExMark + tempInMark;
        TotalMarksObtained = Convert.ToString(tot);

        if (tot >= 40)
        {
            Grade = "P";
        }
        
        else
        {
            Grade = "F";
        }
        string InsertRes = "Update Result set InternalMaxMarks=@InternalMaxMarks,InternalObtainedMarks=@InternalObtainedMarks,TotMaxMarks=@TotMaxMarks,TotMarksObtained=@TotMarksObtained,MinMarks=@MinMarks,Grade=@Grade where ExamID=@ExamID and StuID=@StuID";
        List<SqlParameter> Param = new List<SqlParameter>();
        Param.Add(new SqlParameter("@InternalMaxMarks", "30"));
        Param.Add(new SqlParameter("@InternalObtainedMarks", vMArksObtained));
        Param.Add(new SqlParameter("@TotMaxMarks", "100"));
        Param.Add(new SqlParameter("@TotMarksObtained", TotalMarksObtained));
        Param.Add(new SqlParameter("@MinMarks", "40"));
        Param.Add(new SqlParameter("@Grade", Grade));
        Param.Add(new SqlParameter("@ExamID", ddlSubject.SelectedValue));
        Param.Add(new SqlParameter("@StuID", ddlStudent.SelectedValue));

        DBT.P_returnDataSet(InsertRes, Param);
        Response.Write("<script>alert('Internal Marks Added To Your Student');</script>");
    }

  
    protected void ddlSemster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getdata = "select * from MainExam me join SetMainExam sme on me.ID=sme.EListid where me.ExamType=@ExamType and SemID=@SemID and sme.Sid=@Sid";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ExamType", "Theory"));
        Pram.Add(new SqlParameter("@SemID", ddlSemster.SelectedValue));
        Pram.Add(new SqlParameter("@Sid", ddlStudent.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,Pram);
        ddlSubject.DataSource = ds;
        ddlSubject.DataMember = ds.Tables[0].TableName;
        ddlSubject.DataTextField = "SubjectName";
        ddlSubject.DataValueField = "EListid";
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("--Select Exam--", "0"));

        
    }
}