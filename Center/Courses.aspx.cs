using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Center_Courses : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    protected void btnaddcourse_Click(object sender, EventArgs e)
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
        string Cid = Session["centerid"].ToString();

        string strInsertQry = "insert into AddCourse(Course,DetailsOfCourse,Subject1,Subject2,Subject3,Subject4,Subject5,Subject6,Subject7,Subject8,Subject9,Subject10,Subject11,Subject12,isRequest,Cid,isdisplay) values(@Course,@DetailsOfCourse,@Subject1,@Subject2,@Subject3,@Subject4,@Subject5,@Subject6,@Subject7,@Subject8,@Subject9,@Subject10,@Subject11,@Subject12,@isRequest,@Cid,@isdisplay)";

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
        Pram.Add(new SqlParameter("@isRequest", "0"));
        Pram.Add(new SqlParameter("@Cid", Cid));
        Pram.Add(new SqlParameter("@isdisplay", "1"));


        DBT.P_ExecuteNonQuery(strInsertQry, Pram);

        Response.Redirect("ManageCourse.aspx");
    }
}