using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_ManageSemester : System.Web.UI.Page
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
        string GetData = "select * from Semesters where CourseID=@CourseID order by ID desc";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@CourseID", Request.QueryString["Sem"]));
        gvSemester.DataSource = DBT.P_returnDataSet(GetData, pr);
        gvSemester.DataBind();
    }
    protected void gvSemester_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBTrac DBT = new DBTrac();
        string id = gvSemester.DataKeys[e.RowIndex].Value.ToString();
        string DeleteSemester = "Delete From Semesters Where ID = @ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        string Deletexam = "delete from MainExam where SemesterName=@ID";
        string DeleteResult = "delete from Result where SemID=@ID";
        string DeleteFullResult = "delete from SemesterResult where SemID=@ID";
        DBT.P_ExecuteNonQuery(DeleteFullResult, Pram);
        DBT.P_ExecuteNonQuery(DeleteResult, Pram);
        DBT.P_ExecuteNonQuery(Deletexam, Pram);
        DBT.P_ExecuteNonQuery(DeleteSemester, Pram);
        LoadData();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["Sem"] = Request.QueryString["Sem"].ToString();
        Response.Redirect("AddSemester.aspx");
    }
}