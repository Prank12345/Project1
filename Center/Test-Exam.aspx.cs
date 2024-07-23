using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Center_Test_Exam : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {            
            Exam();
            course();            
        }
    }
    protected void Exam()
    {
        DBTrac DBT = new DBTrac();
        string CenterID = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            CenterID = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = " + Session["StaffID"].ToString();
            DataSet dsStLogin = DBT.returnDataSet(strGetStaffData);
            CenterID = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string str= "select * from ExamList where CenterID=" + CenterID;
        gvtestexam.DataSource = DBT.returnDataSet(str);
        gvtestexam.DataBind();
    }
    protected void course()
    {
        string getdata = "select id,FullCourseName from Courses ";
        DataSet ds = DBT.returnDataSet(getdata);
        ddlcourse.DataSource = ds;
        ddlcourse.DataMember = ds.Tables[0].TableName;
        ddlcourse.DataTextField = "FullCourseName";
        ddlcourse.DataValueField = "id";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("--Select Course--", "0"));


    }

    protected void tbnadd_Click(object sender, EventArgs e)
    {
        string ExamName = txtexmname.Text;
        string ExamType = "Test";
        string CenterID = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            CenterID = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = " + Session["StaffID"].ToString();
            DataSet dsStLogin = DBT.returnDataSet(strGetStaffData);
            CenterID = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
       
        string CourseID = ddlcourse.SelectedValue;
        Random ren = new Random();
        string ExamID = "NPCVB" + ren.Next(999999);

        string strInsertQry = "insert into ExamList (ExamName,ExamType,CenterID,CreatedOn,ExamID,CourseID) values(@ExamName,@ExamType,@CenterID,@CreatedOn,@ExamID,@CourseID)";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ExamName", ExamName));
        Pram.Add(new SqlParameter("@ExamType", ExamType));
        Pram.Add(new SqlParameter("@CenterID", CenterID));
        Pram.Add(new SqlParameter("@CreatedOn",DateTime.Now.ToShortDateString()));
        Pram.Add(new SqlParameter("@ExamID", ExamID));
        Pram.Add(new SqlParameter("@CourseID", CourseID));
        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        Exam();
    }

    protected void gvtestexam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id=gvtestexam.DataKeys[e.RowIndex].Value.ToString();
        string del = "delete from ExamList where id=" + id;
        DBTrac DBT = new DBTrac();
        DBT.executeNonQuery(del);
        Exam();
    }  
}