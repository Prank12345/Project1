using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdminBackend_EditObQues : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            edit();
        }
    }
    protected void edit()
    {
        string strr = "select * from MainExQuestions where id=@id" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", Request.QueryString["EID"]));
        DataSet ds = DBT.P_returnDataSet(strr,Pram);
        txtquestion.Text = ds.Tables[0].Rows[0]["Question"].ToString();
        txtop1.Text = ds.Tables[0].Rows[0]["Option1"].ToString();
        txtop2.Text = ds.Tables[0].Rows[0]["Option2"].ToString();
        txtop3.Text = ds.Tables[0].Rows[0]["Option3"].ToString();
        txtop4.Text = ds.Tables[0].Rows[0]["Option4"].ToString();
        rbanswer.SelectedValue = ds.Tables[0].Rows[0]["CorrectAnswer"].ToString();
        txtMarks.Text = ds.Tables[0].Rows[0]["Marks"].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Question = txtquestion.Text;
        string Option1 = txtop1.Text;
        string Option2 = txtop2.Text;
        string Option3 = txtop3.Text;
        string Option4 = txtop4.Text;
        string CorrectAnswer = rbanswer.SelectedValue;
        string vmarks = txtMarks.Text;
        string upd = "update MainExQuestions set Question=@Question,Option1=@Option1,Option2=@Option2,Option3=@Option3,Option4=@Option4,CorrectAnswer=@CorrectAnswer,Marks=@Marks where id=@id";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Question", Question));
        Pram.Add(new SqlParameter("@Option1", Option1));
        Pram.Add(new SqlParameter("@Option2", Option2));
        Pram.Add(new SqlParameter("@Option3", Option3));
        Pram.Add(new SqlParameter("@Option4", Option4));
        Pram.Add(new SqlParameter("@CorrectAnswer", CorrectAnswer));
        Pram.Add(new SqlParameter("@Marks", vmarks));
        Pram.Add(new SqlParameter("@id", Request.QueryString["EID"]));
        DBT.P_ExecuteNonQuery(upd, Pram);
        Response.Redirect("MainExam.aspx");
    }
}