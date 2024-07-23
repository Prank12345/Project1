using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Center_EditCourse : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        str = Request.QueryString["id"].ToString();
        if(!IsPostBack)
        {
            edit();
        }
    }
    protected void edit()
    {
        string strr = "select * from AddCourse where id=" + str;
        DataSet ds = DBT.returnDataSet(strr);
        txtcourse.Text = ds.Tables[0].Rows[0]["Course"].ToString();
        txtdetails.Text = ds.Tables[0].Rows[0]["DetailsOfCourse"].ToString();
        txtsubject.Text = ds.Tables[0].Rows[0]["Subject1"].ToString();
        txtsubject1.Text = ds.Tables[0].Rows[0]["Subject2"].ToString();
        txtsubject2.Text = ds.Tables[0].Rows[0]["Subject3"].ToString();
        txtsubject3.Text = ds.Tables[0].Rows[0]["Subject4"].ToString();
        txtsubject4.Text = ds.Tables[0].Rows[0]["Subject5"].ToString();
        txtsubject5.Text = ds.Tables[0].Rows[0]["Subject6"].ToString();
        txtsubject6.Text= ds.Tables[0].Rows[0]["Subject7"].ToString();
        txtsubject7.Text= ds.Tables[0].Rows[0]["Subject8"].ToString();
        txtsubject8.Text= ds.Tables[0].Rows[0]["Subject9"].ToString();
        txtsubject9.Text= ds.Tables[0].Rows[0]["Subject10"].ToString();
        txtsubject10.Text= ds.Tables[0].Rows[0]["Subject11"].ToString();
        txtsubject11.Text= ds.Tables[0].Rows[0]["Subject12"].ToString();
    }

    protected void btnupdatecourse_Click(object sender, EventArgs e)
    {
        string Course = txtcourse.Text;
        string DetailsOfCourse = txtdetails.Text;
        string Subject1 = txtsubject.Text;
        string Subject2 = txtsubject1.Text;
        string Subject3 = txtsubject2.Text;
        string Subject4 = txtsubject3.Text;
        string Subject5 = txtsubject4.Text;
        string Subject6 = txtsubject5.Text;
        string Subject7 = txtsubject6.Text;
        string Subject8 = txtsubject7.Text;
        string Subject9 = txtsubject8.Text;
        string Subject10 = txtsubject9.Text;
        string Subject11 = txtsubject10.Text;
        string Subject12 = txtsubject11.Text;

        string upd = "update AddCourse set Course=@Course,DetailsOfCourse=@DetailsOfCourse,Subject1=@Subject1,Subject2=@Subject2,Subject3=@Subject3,Subject4=@Subject4,Subject5=@Subject5,Subject6=@Subject6,Subject7=@Subject7,Subject8=@Subject8,Subject9=@Subject9,Subject10=@Subject10,Subject11=@Subject11,Subject12=@Subject12 where id=" + str;

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Course", Course));
        Pram.Add(new SqlParameter("@DetailsOfCourse", DetailsOfCourse));
        Pram.Add(new SqlParameter("@Subject1", Subject1));
        Pram.Add(new SqlParameter("@Subject2", Subject2));
        Pram.Add(new SqlParameter("@Subject3", Subject3));
        Pram.Add(new SqlParameter("@Subject4", Subject4));
        Pram.Add(new SqlParameter("@Subject5", Subject5));
        Pram.Add(new SqlParameter("@Subject6", Subject6));
        Pram.Add(new SqlParameter("@Subject7", Subject7));
        Pram.Add(new SqlParameter("@Subject8", Subject8));
        Pram.Add(new SqlParameter("@Subject9", Subject9));
        Pram.Add(new SqlParameter("@Subject10", Subject10));
        Pram.Add(new SqlParameter("@Subject11", Subject11));
        Pram.Add(new SqlParameter("@Subject12", Subject12));


        DBT.P_ExecuteNonQuery(upd, Pram);

        Response.Redirect("ManageCourse.aspx");
    }

    protected void btnupdatecourse_Click1(object sender, EventArgs e)
    {

    }
}