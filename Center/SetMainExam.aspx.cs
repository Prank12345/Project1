using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Center_SetMainExam : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           // exam();
            Student();
            LoadGv();
           // LoadData();
        }
    }
    protected void exam()
    {
        string selectid = "";
        string selectCID = "";
        foreach (GridViewRow row in gvStudents.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
            
            if (chkSelect.Checked == true)
            {
                if(selectCID == "")
                {
                    selectid = gvStudents.DataKeys[row.RowIndex].Value.ToString();
                    List<SqlParameter> Pr = new List<SqlParameter>();
                    Pr.Add(new SqlParameter("@id", selectid));
                    selectCID = DBT.P_returnOneValue("select Course from AddStudent where id=@id",Pr);
                    List<SqlParameter> Pr1 = new List<SqlParameter>();
                    Pr1.Add(new SqlParameter("@id", selectCID));
                    string GetData = "select * from Courses where id=@id" ;

                    DataSet ds = DBT.P_returnDataSet(GetData,Pr1);
                    ddlCourse.DataSource = ds;
                    ddlCourse.DataMember = ds.Tables[0].TableName;
                    ddlCourse.DataTextField = "ShortName";
                    ddlCourse.DataValueField = "ID";
                    ddlCourse.DataBind();
                    ddlCourse.Items.Insert(0, new ListItem("--Select Course--", "0"));
                }                
            }                       
        }
        
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getdata = "select * from Semesters where CourseID=@CourseID" ;
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@CourseID", ddlCourse.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,pr);
        ddlSemster.DataSource = ds;
        ddlSemster.DataMember = ds.Tables[0].TableName;
        ddlSemster.DataTextField = "Semester";
        ddlSemster.DataValueField = "ID";
        ddlSemster.DataBind();
        ddlSemster.Items.Insert(0, new ListItem("--Select Semester--", "0"));
    }

    protected void ddlSemster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getdata = "select id,SubjectName from MainExam where SemesterName=@SemesterName" ;
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@SemesterName", ddlSemster.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,pr);
        ddlmainexam.DataSource = ds;
        ddlmainexam.DataMember = ds.Tables[0].TableName;
        ddlmainexam.DataTextField = "SubjectName";
        ddlmainexam.DataValueField = "id";
        ddlmainexam.DataBind();
        ddlmainexam.Items.Insert(0, new ListItem("--Select Maine Exam--", "0"));
    }
    protected void Student()
    {
        string CenterID = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            CenterID = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> pr = new List<SqlParameter>();
            pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,pr);
            CenterID = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string getdata = "select id,StudentName from AddStudent where Cid=@Cid";
        List<SqlParameter> PR = new List<SqlParameter>();
        PR.Add(new SqlParameter("@Cid", CenterID));
        DataSet ds = DBT.P_returnDataSet(getdata,PR);
        gvStudents.DataSource = ds;
        gvStudents.DataBind();
            
    }


    protected void btnaddexam_Click(object sender, EventArgs e)
    {
        string EListid = ddlmainexam.SelectedValue;
        string getData = "select * from MainExam where ID=@ID";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ID", EListid));
        DataSet ds = DBT.P_returnDataSet(getData, pr);
        string semID = ds.Tables[0].Rows[0]["SemesterName"].ToString();
        string ExamMode = ddlexammode.SelectedItem.Text;

        DateTime oDate = Convert.ToDateTime(txtExDate.Text);
        string VDate = oDate.ToString("yyyy/MM/dd");

        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> pr1 = new List<SqlParameter>();
            pr1.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData, pr1);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }

        foreach (GridViewRow row in gvStudents.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

            if (chkSelect.Checked == true)
            {
                string selectid = gvStudents.DataKeys[row.RowIndex].Value.ToString();

                string insrtquery = "insert into SetMainExam (EListid,ExamMode,Sid,Cid,isdisplay,IsExamGiven,SemID,DateOfExam,Duration)values(@EListid,@ExamMode,@Sid,@Cid,@isdisplay,@IsExamGiven,@SemID,@DateOfExam,@Duration)";

                List<SqlParameter> Pram = new List<SqlParameter>();
                Pram.Add(new SqlParameter("@EListid", EListid));
                Pram.Add(new SqlParameter("@ExamMode", ExamMode));
                Pram.Add(new SqlParameter("@Sid", selectid));
                Pram.Add(new SqlParameter("@Cid", Cid));
                Pram.Add(new SqlParameter("@IsExamGiven", "0"));
                Pram.Add(new SqlParameter("@isdisplay", "1"));
                Pram.Add(new SqlParameter("@SemID", semID));
                Pram.Add(new SqlParameter("@DateOfExam", VDate));
                Pram.Add(new SqlParameter("@Duration", "1"));

                DBT.P_ExecuteNonQuery(insrtquery, Pram);

            }
        }
        LoadGv();
        ddlmainexam.ClearSelection();
        ddlexammode.ClearSelection();
        txtExDate.Text = "";
    }
    protected void LoadGv()
    {
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> pr = new List<SqlParameter>();
            pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,pr);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string strGetData = "select * from SetMainExam sme join MainExam em on sme.EListid=em.id join AddStudent ast on sme.[Sid]=ast.id where sme.cid=@cid";
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@cid", Cid));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetData,pr1);
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
        
        exam();


    }

    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvCenter.DataKeys[e.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@Id",id));
        
        string DeleteSME = "Delete From SetMainExam Where ID = @Id";
        DBTrac DBT = new DBTrac();
        DBT.P_ExecuteNonQuery(DeleteSME,pram);      
        LoadGv();
    }
}