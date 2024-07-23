using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_AddFreeTest : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadFreeTest();
        }
    }
    protected void LoadFreeTest()
    {
        DBTrac DBT = new DBTrac();
        string str = "select * from ExamList where ExamType=@ExamType";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ExamType", "Free Test"));
        gvtestexam.DataSource = DBT.P_returnDataSet(str,pr);
        gvtestexam.DataBind();
    }

    protected void tbnadd_Click(object sender, EventArgs e)
    {
        string ExamName = txtexmname.Text;
        string ExamType = ddlexamtype.SelectedItem.Text; 
      
        Random ren = new Random();
        string ExamID = "test" + ren.Next(999999);

        string strInsertQry = "insert into ExamList (ExamName,ExamType,CreatedOn,ExamID) values(@ExamName,@ExamType,@CreatedOn,@ExamID)";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ExamName", ExamName));
        Pram.Add(new SqlParameter("@ExamType", ExamType));
       
        Pram.Add(new SqlParameter("@CreatedOn", DateTime.Now.ToShortDateString()));
        Pram.Add(new SqlParameter("@ExamID", ExamID));
       
        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        LoadFreeTest();
        txtexmname.Text = "";
        ddlexamtype.SelectedValue = "0";
    }

    protected void gvtestexam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvtestexam.DataKeys[e.RowIndex].Value.ToString();
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ID", id));
        string DeleteCategory = "Delete From ExamList Where ID = @ID" ;
        string DeleteTest = "Delete From FreeTestQuestion Where ExamID = @ID";
        DBT.P_ExecuteNonQuery(DeleteCategory,pr);
        DBT.P_ExecuteNonQuery(DeleteTest,pr);
        LoadFreeTest();
    }
}