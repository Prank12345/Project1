using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditSubQues : System.Web.UI.Page
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
        string strr = "select * from MainExQuestions where id=" + Request.QueryString["EID"];
        DataSet ds = DBT.returnDataSet(strr);
        txtquestion.Text = ds.Tables[0].Rows[0]["Question"].ToString();

        txtAnswer.Text = ds.Tables[0].Rows[0]["CorrectAnswer"].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Question = txtquestion.Text;
        string CorrectAnswer = txtAnswer.Text;

        string upd = "update MainExQuestions set Question=@Question,CorrectAnswer=@CorrectAnswer where id=" + Request.QueryString["EID"];

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Question", Question));

        Pram.Add(new SqlParameter("@CorrectAnswer", CorrectAnswer));
        DBT.P_ExecuteNonQuery(upd, Pram);
        Response.Redirect("MainExam.aspx");
    }
}