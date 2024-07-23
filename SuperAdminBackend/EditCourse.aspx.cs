using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditCourse : System.Web.UI.Page
{
    DBTrac DBT =new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDropdown();
            LoadData();
        }
    }
    protected void LoadData()
    {
        string GetData = "select * from Courses where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["CID"]));
        DataSet ds = DBT.P_returnDataSet(GetData,Pram);
        txtCourseName.Text=ds.Tables[0].Rows[0]["FullCourseName"].ToString();
        txtShortName.Text= ds.Tables[0].Rows[0]["ShortName"].ToString(); 
        txtcoursedetails.Text= ds.Tables[0].Rows[0]["CourseDetail"].ToString();
        string Duration= ds.Tables[0].Rows[0]["Duration"].ToString();
        string[] splitDuration = Duration.Split('-');
        txtDuration.Text = splitDuration[0];
        ddldurationType.SelectedItem.Text = splitDuration[1];
        txtEligibility.Text= ds.Tables[0].Rows[0]["Eligibility"].ToString(); 
        txtRegFees.Text= ds.Tables[0].Rows[0]["RegFeesUniv"].ToString(); 
        //txtColgRegFees.Text= ds.Tables[0].Rows[0]["RegFeesColg"].ToString(); 
        txtProgFees.Text= ds.Tables[0].Rows[0]["ProgFeesUniv"].ToString(); 
        //txtColgProgFees.Text= ds.Tables[0].Rows[0]["ProgFeesColg"].ToString();
        txtInstructionMode.Text= ds.Tables[0].Rows[0]["InstructionMode"].ToString();
        ddlLang.SelectedItem.Text= ds.Tables[0].Rows[0]["Medium"].ToString();
        txtAttendant.Text = ds.Tables[0].Rows[0]["ExamAttendant"].ToString();
        ddlCourseType.SelectedValue = ds.Tables[0].Rows[0]["CTID"].ToString();
        //ddlCourseType.Items.FindByValue(ds.Tables[0].Rows[0]["CTID"].ToString()).Selected=true;
    }
    protected void LoadDropdown()
    {
        string strGetData = "select * from CourseType";
        DataSet ds = DBT.returnDataSet(strGetData);
        ddlCourseType.DataSource = ds;
        ddlCourseType.DataMember = ds.Tables[0].TableName;
        ddlCourseType.DataTextField = "CourseType";
        ddlCourseType.DataValueField = "id";
        ddlCourseType.DataBind();
        ddlCourseType.Items.Insert(0, new ListItem("--Select Course Type--", "0"));
    }

    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        string vCourseType = ddlCourseType.SelectedValue;
        string vCourseFullName = txtCourseName.Text;
        string vShortName = txtShortName.Text;
        string vCourseDetail = txtcoursedetails.Text;
        string vDuration = txtDuration.Text + "-" + ddldurationType.SelectedItem.Text;
        string vEligibility = txtEligibility.Text;
        string vRegFeesUniv = txtRegFees.Text;
        //string vRegFeesColg = txtColgRegFees.Text;
        string vProgFeesUniv = txtProgFees.Text;
        //string vProgFeesColg = txtColgProgFees.Text;
        string vInstructionMode = txtInstructionMode.Text;
        string vMedium = ddlLang.SelectedItem.Text;
        string vExamAttendant = txtAttendant.Text;
        string UpdateQry = "Update Courses set FullCourseName=@FullCourseName,ShortName=@ShortName,CourseDetail=@CourseDetail,Duration=@Duration,Eligibility=@Eligibility,RegFeesUniv=@RegFeesUniv,ProgFeesUniv=@ProgFeesUniv,InstructionMode=@InstructionMode,Medium=@Medium,ExamAttendant=@ExamAttendant,CTID=@CTID where ID=@ID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@FullCourseName", vCourseFullName));
        Pram.Add(new SqlParameter("@ShortName", vShortName));
        Pram.Add(new SqlParameter("@CourseDetail", vCourseDetail));
        Pram.Add(new SqlParameter("@ExamAttendant", vExamAttendant));
        Pram.Add(new SqlParameter("@Duration", vDuration));
        Pram.Add(new SqlParameter("@Eligibility", vEligibility));
        Pram.Add(new SqlParameter("@RegFeesUniv", vRegFeesUniv));
       
        Pram.Add(new SqlParameter("@ProgFeesUniv", vProgFeesUniv));
       
        Pram.Add(new SqlParameter("@InstructionMode", vInstructionMode));
        Pram.Add(new SqlParameter("@Medium", vMedium));
        Pram.Add(new SqlParameter("@CTID", vCourseType));
        Pram.Add(new SqlParameter("@ID", Request.QueryString["CID"]));
        DBT.P_ExecuteNonQuery(UpdateQry, Pram);

        //string update="delete MainExam f"
        Response.Redirect("CourseManagement.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CourseManagement.aspx");
    }
}