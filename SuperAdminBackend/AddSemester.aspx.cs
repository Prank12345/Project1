using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_AddSemester : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            LoadText();
           
        }
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
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int lastTxt = div1.Controls.OfType<TextBox>().ToList().Count;
        TextBox txtB = (TextBox)FindControl("ctl00$ContentPlaceHolder1$txtDynamic" + lastTxt);
        div1.Controls.Remove(txtB);
    }
    
    protected void LoadText()
    {
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@CourseID", Session["Sem"].ToString()));
        string count = DBT.P_returnOneValue("select count(ID) from Semesters where CourseID = @CourseID",Pr);        
        int num = Convert.ToInt32(count) + 1;
        txtSemName.Text = "Semester" + (num).ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string CourseID = Session["Sem"].ToString();
        string PaperCode = "";
        string vExamFees = txtExamFees.Text;
        string Semester = txtSemName.Text;
        string IsDisplay = "1";
        Random ren = new Random();
       
        string Subject = "";
        foreach (TextBox txt in div1.Controls.OfType<TextBox>())
        {
            Subject = Subject + "," + txt.Text;
            PaperCode =PaperCode + ","+ "Sub" + ren.Next(999999);
        }
        Subject = Subject.Remove(0, 1).ToString();
        PaperCode = PaperCode.Remove(0, 1).ToString();
        string Insertqry = "insert into Semesters (Semester,PaperCode,Subjects,isDisplay,CourseID,ExamFees) values(@Semester,@PaperCode,@Subjects,@isDisplay,@CourseID,@ExamFees)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Semester",Semester));
        Pram.Add(new SqlParameter("@PaperCode", PaperCode));
        Pram.Add(new SqlParameter("@Subjects", Subject));
        Pram.Add(new SqlParameter("@isDisplay", IsDisplay));
        Pram.Add(new SqlParameter("@CourseID", CourseID));
        Pram.Add(new SqlParameter("@ExamFees", vExamFees));
        DBT.P_ExecuteNonQuery(Insertqry, Pram);
        Response.Redirect("CourseManagement.aspx");
    }

   
}