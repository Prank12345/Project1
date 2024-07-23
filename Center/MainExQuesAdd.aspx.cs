using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_MainExQuesAdd : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = "";
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
        string Option1 = txtop1.Text;
        string Option2 = txtop2.Text;
        string Option3 = txtop3.Text;
        string Option4 = txtop4.Text;
        string CorrectAnswer = rbanswer.SelectedValue;
        string ExamID = Request.QueryString["ID"];

        string strInsertQry = "insert into MainExQuestions(Question,Option1,Option2,Option3,Option4,CorrectAnswer,ExamID,isdisplay) values(@Question,@Option1,@Option2,@Option3,@Option4,@CorrectAnswer,@ExamID,@isdisplay)";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Question", Question));
        Pram.Add(new SqlParameter("@Option1", Option1));
        Pram.Add(new SqlParameter("@Option2", Option2));
        Pram.Add(new SqlParameter("@Option3", Option3));
        Pram.Add(new SqlParameter("@Option4", Option4));
        Pram.Add(new SqlParameter("@CorrectAnswer", CorrectAnswer));
        Pram.Add(new SqlParameter("@ExamID", ExamID));
        Pram.Add(new SqlParameter("@isdisplay", "1"));

        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        LoadData();
        txtquestion.Text = txtop1.Text = txtop2.Text = txtop3.Text = txtop4.Text = "";
        rbanswer.ClearSelection();

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