using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_AddCourse : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    private void CreateTextBox(string id)
    {
        TextBox txt = new TextBox();
        txt.ID = id;

        txt.CssClass = "form-control";
        div1.Controls.Add(txt);

        Literal lt = new Literal();
        lt.Text = "<br />";
        div1.Controls.Add(lt);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
        int i = 1;
        foreach (string key in keys)
        {
            this.CreateTextBox("txtDynamic" + i);
            i++;
        }
    }
    protected void AddTextBox(object sender, EventArgs e)
    {
        int index = div1.Controls.OfType<TextBox>().ToList().Count + 1;
        this.CreateTextBox("txtDynamic" + index);
    }
    protected void btnaddcourse_Click(object sender, EventArgs e)
    {
        //string message = "";
        //foreach (TextBox textBox in div1.Controls.OfType<TextBox>())
        //{
        //    message += textBox.ID + ": " + textBox.Text + "\\n";
        //}
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
        string Course = txtcourse.Text;
        string DetailsOfCourse = txtdetails.Text;
        string Subject1 = txtSubject1.Text;
        string Subject2 = "";
        foreach (TextBox txt in div1.Controls.OfType<TextBox>())
        {
            Subject2 = Subject2 + "," + txt.Text;
        }
        Subject2 = Subject2.Remove(0, 1).ToString();
        string vCourseFees = txtFees.Text;
        string strInsertQry = "insert into AddCourse(Course,DetailsOfCourse,Subject1,Subject2,isRequest,isdisplay,CourseFees) values(@Course,@DetailsOfCourse,@Subject1,@Subject2,@isRequest,@isdisplay,@CourseFees)";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Course", Course));
        Pram.Add(new SqlParameter("@DetailsOfCourse", DetailsOfCourse));
        Pram.Add(new SqlParameter("@Subject1", Subject1));
        Pram.Add(new SqlParameter("@Subject2", Subject2));

        Pram.Add(new SqlParameter("@isRequest", "1"));

        Pram.Add(new SqlParameter("@isdisplay", "1"));
        Pram.Add(new SqlParameter("@CourseFees", vCourseFees));


        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        Response.Redirect("ManageCourse.aspx");
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int lastTxt = div1.Controls.OfType<TextBox>().ToList().Count;
        TextBox txtB = (TextBox)FindControl("ctl00$ContentPlaceHolder1$txtDynamic" + lastTxt);
        div1.Controls.Remove(txtB);
    }
}