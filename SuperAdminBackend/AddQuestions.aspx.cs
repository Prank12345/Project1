using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_AddQuestions : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Question();
        }
    }
    protected void Question()
    {
        DBTrac DBT = new DBTrac();
        string str = "select * from FreeTestQuestion where ExamID=" + Request.QueryString["ID"].ToString();
        gvaddquestion.DataSource = DBT.returnDataSet(str);
        gvaddquestion.DataBind();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string Question = txtquestion.Text;
        string Option1 = txtop1.Text;
        string Option2 = txtop2.Text;
        string Option3 = txtop3.Text;
        string Option4 = txtop4.Text;
        string CorrectAnswer = rbanswer.SelectedValue;
        string ExamID = Request.QueryString["ID"].ToString();

        string strInsertQry = "insert into FreeTestQuestion(Question,Option1,Option2,Option3,Option4,CorrectAnswer,ExamID) values(@Question,@Option1,@Option2,@Option3,@Option4,@CorrectAnswer,@ExamID)";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Question", Question));
        Pram.Add(new SqlParameter("@Option1", Option1));
        Pram.Add(new SqlParameter("@Option2", Option2));
        Pram.Add(new SqlParameter("@Option3", Option3));
        Pram.Add(new SqlParameter("@Option4", Option4));
        Pram.Add(new SqlParameter("@CorrectAnswer", CorrectAnswer));
        Pram.Add(new SqlParameter("@ExamID", ExamID));

        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        Response.Redirect("AddFreeTest.aspx");
    }

    protected void gvaddquestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvaddquestion.DataKeys[e.RowIndex].Value.ToString();
       
        string DeleteTest = "Delete From FreeTestQuestion Where id = " + id;
      
        DBT.executeNonQuery(DeleteTest);
        Question();
    }
}