using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_CourseManagement : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
            LoadDropdown();
        }
    }

    protected void LoadData()
    {
        string GetData = "select * from Courses order by ID desc";
        gvCenter.DataSource = DBT.returnDataSet(GetData);
        gvCenter.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vCourseType = ddlCourseType.SelectedValue;
        string vCourseFullName = txtCourseName.Text;
        string vShortName = txtShortName.Text;
        string vCourseDetail = txtcoursedetails.Text;
        string vDuration = txtDuration.Text+"-"+ddldurationType.SelectedItem.Text;
        string vEligibility = txtEligibility.Text;
        string vRegFeesUniv = txtRegFees.Text;
        //string vRegFeesColg = txtColgRegFees.Text;
        string vProgFeesUniv = txtProgFees.Text;
        //string vProgFeesColg = txtColgProgFees.Text;
        string vInstructionMode = txtInstructionMode.Text;
        string vMedium = ddlLang.SelectedItem.Text;
        string vCourseAttendant = txtAttendant.Text;
        string vCourseCode = "";
        Random ren = new Random();

        vCourseCode = "NPCVB" + ren.Next(999999);
        string insertQry = "insert into Courses (FullCourseName,ShortName,CourseDetail,CourseCode,Duration,Eligibility,RegFeesUniv,ProgFeesUniv,InstructionMode,Medium,ExamAttendant,CTID) Values (@FullCourseName,@ShortName,@CourseDetail,@CourseCode,@Duration,@Eligibility,@RegFeesUniv,@ProgFeesUniv,@InstructionMode,@Medium,@ExamAttendant,@CTID)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@FullCourseName", vCourseFullName));
        Pram.Add(new SqlParameter("@ShortName", vShortName));
        Pram.Add(new SqlParameter("@CourseDetail", vCourseDetail));
        Pram.Add(new SqlParameter("@CourseCode", vCourseCode));
        Pram.Add(new SqlParameter("@Duration", vDuration));
        Pram.Add(new SqlParameter("@Eligibility", vEligibility));
        Pram.Add(new SqlParameter("@RegFeesUniv", vRegFeesUniv));
       // Pram.Add(new SqlParameter("@RegFeesColg", vRegFeesColg));
        Pram.Add(new SqlParameter("@ProgFeesUniv", vProgFeesUniv));
        //Pram.Add(new SqlParameter("@ProgFeesColg", vProgFeesColg));
        Pram.Add(new SqlParameter("@InstructionMode", vInstructionMode));
        Pram.Add(new SqlParameter("@Medium", vMedium));
        Pram.Add(new SqlParameter("@ExamAttendant", vCourseAttendant));
        Pram.Add(new SqlParameter("@CTID", vCourseType));
        DBT.P_ExecuteNonQuery(insertQry, Pram);
        
        Response.Redirect("CourseManagement.aspx");
    }

    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvCenter.DataKeys[e.RowIndex].Value.ToString();

        string DeleteCourse = "Delete From Courses Where ID = @id";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        string DeleteSemester = "Delete From Semesters Where CourseID = @id";
        DBTrac DBT = new DBTrac();

        DBT.P_ExecuteNonQuery(DeleteCourse,pram);
        DBT.P_ExecuteNonQuery(DeleteSemester,pram);
        LoadData();
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
    protected void btnView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet("select * from Semesters where CourseID=@id",pram);
        rptSems.DataSource = ds;
        rptSems.DataBind();
        //lblID.Text = ds.Tables[0].Rows[0]["Semester"].ToString();
        //lblShow.Text = ds.Tables[0].Rows[0]["Subjects"].ToString();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "Modalsubject();", true);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string SearchKey = txtSearch.Text;
        string GetData = "select * from Courses where FullCourseName like '%'+ @SearchKey + '%' or ShortName like '%' + @SearchKey + '%' or CourseCode like '%'+ @SearchKey + '%'";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@SearchKey", SearchKey));
        DataSet ds = DBT.P_returnDataSet(GetData,pram);
        if(ds.Tables[0].Rows.Count>0)
        {
            gvCenter.Visible = true;
            lblMsg.Visible = false;
            gvCenter.DataSource = DBT.P_returnDataSet(GetData,pram);
            gvCenter.DataBind();
        }
       else
        {
            gvCenter.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No Record Found";
        }
    }
}