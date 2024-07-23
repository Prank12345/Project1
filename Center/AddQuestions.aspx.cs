using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Center_AddQuistions : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = "";
        if(!IsPostBack)
        {
            Question();
        }
    }
    protected void Question()
    {
        DBTrac DBT = new DBTrac();
        string str = "select * from Questions where ExamID=@ExamID";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ExamID", Request.QueryString["ID"].ToString()));
        gvaddquestion.DataSource = DBT.P_returnDataSet(str,Pr);
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

        string strInsertQry = "insert into Questions(Question,Option1,Option2,Option3,Option4,CorrectAnswer,ExamID) values(@Question,@Option1,@Option2,@Option3,@Option4,@CorrectAnswer,@ExamID)";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Question", Question));
        Pram.Add(new SqlParameter("@Option1", Option1));
        Pram.Add(new SqlParameter("@Option2", Option2));
        Pram.Add(new SqlParameter("@Option3", Option3));
        Pram.Add(new SqlParameter("@Option4", Option4));
        Pram.Add(new SqlParameter("@CorrectAnswer", CorrectAnswer));
        Pram.Add(new SqlParameter("@ExamID", ExamID));


        DBT.P_ExecuteNonQuery(strInsertQry, Pram);

        Response.Redirect("Test-Exam.aspx");

    }

    protected void gvaddquestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id= gvaddquestion.DataKeys[e.RowIndex].Value.ToString();
        string del = "delete from Questions where id=@id";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@id", id));
        DBTrac DBT = new DBTrac();
        DBT.P_ExecuteNonQuery(del,Pr);
        Question();
    }
    
    
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string Question = txtquestion.Text;
        string Option1 = txtop1.Text;
        string Option2 = txtop2.Text;
        string Option3 = txtop3.Text;
        string Option4 = txtop4.Text;
        string CorrectAnswer = rbanswer.SelectedValue;

        string upd = "update Questions set Question=@Question,Option1=@Option1,Option2=@Option2,Option3=@Option3,Option4=@Option4,CorrectAnswer=@CorrectAnswer where id=@id" ;

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Question", Question));
        Pram.Add(new SqlParameter("@Option1", Option1));
        Pram.Add(new SqlParameter("@Option2", Option2));
        Pram.Add(new SqlParameter("@Option3", Option3));
        Pram.Add(new SqlParameter("@Option4", Option4));
        Pram.Add(new SqlParameter("@CorrectAnswer", CorrectAnswer));
        Pram.Add(new SqlParameter("@id", id));
        DBT.P_ExecuteNonQuery(upd, Pram);

        Response.Redirect("AddQuestions.aspx");
    }

   
}