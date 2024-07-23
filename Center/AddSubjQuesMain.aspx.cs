using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_AddSubjQuesMain : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    protected void LoadData()
    {
        DBTrac DBT = new DBTrac();
        string str = "select * from MainExQuestions where ExamID=" + Request.QueryString["ID"].ToString();
        gvaddquestion.DataSource = DBT.returnDataSet(str);
        gvaddquestion.DataBind();
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string Question = txtquestion.Text;

        string CorrectAnswer = txtAnswer.Text;
        string ExamID = Request.QueryString["ID"];

        string strInsertQry = "insert into MainExQuestions(Question,CorrectAnswer,ExamID,isdisplay) values(@Question,@CorrectAnswer,@ExamID,@isdisplay)";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Question", Question));

        Pram.Add(new SqlParameter("@CorrectAnswer", CorrectAnswer));
        Pram.Add(new SqlParameter("@ExamID", ExamID));
        Pram.Add(new SqlParameter("@isdisplay", "1"));

        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        LoadData();
        txtAnswer.Text = txtquestion.Text = "";
    }

    protected void gvaddquestion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvaddquestion.DataKeys[e.RowIndex].Value.ToString();
        string del = "delete from MainExQuestions where id=" + id;
        DBTrac DBT = new DBTrac();
        DBT.executeNonQuery(del);
        LoadData();
    }
}