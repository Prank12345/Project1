using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditSemester : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static int tTxt = 0;
    static string oldCourse = "";
    static string CoID = "";
    static string Code = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Code = "";
            tTxt = 0;
            oldCourse = "";
            LoadData();
        }
        loadTXT();
    }

    protected void loadTXT()
    {
        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
        List<string> keysddl = Request.Form.AllKeys.Where(key => key.Contains("ddlDynamic")).ToList();
        // List<string> kays = Request.Form.AllKeys.Where(key => key.Contains("lblDynamic")).ToList();
        string[] splitsubject = oldCourse.Split(',');
       // string[] codeSplit = Code.Split(',');

        tTxt = splitsubject.Length;

        
        for (int i=0; i<keys.Count;i++)
        { 
            if(i < tTxt)
            {
                DropDownList ddl = new DropDownList();
                TextBox txt = new TextBox();
                Literal lt = new Literal();
                Literal lt1 = new Literal();
                txt.ID = "txtDynamic" + i;
                ddl.ID = "ddlDynamic" + i;
                txt.CssClass = "form-control";
                ddl.CssClass = "form-control";
                txt.Text = splitsubject[i].ToString();
                string getSems = "select * from Semesters where CourseID=" + CoID;
                DataSet dssem = DBT.returnDataSet(getSems);

                ddl.ID = "ddlDynamic" + i;
                ddl.CssClass = "form-control";
                ddl.DataSource = dssem;
                ddl.DataMember = dssem.Tables[0].TableName;
                ddl.DataTextField = "Semester";
                ddl.DataValueField = "ID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--Select Semester--", "0"));
                txt.EnableViewState = true;
                div3.Controls.Add(ddl);
                div1.Controls.Add(txt);
                lt.Text = "<br />";
                lt1.Text = "<br />";
                div1.Controls.Add(lt);
                div3.Controls.Add(lt1);
            }
            else
            {
                DropDownList ddl = new DropDownList();
                TextBox txt = new TextBox();
                Literal lt = new Literal();
                Literal lt1 = new Literal();
                txt.ID = "txtDynamic" + i;
                ddl.ID = "ddlDynamic" + i;
                string getSems = "select * from Semesters where CourseID=" + CoID;
                DataSet dssem = DBT.returnDataSet(getSems);

                ddl.ID = "ddlDynamic" + i;
                ddl.CssClass = "form-control";
                ddl.DataSource = dssem;
                ddl.DataMember = dssem.Tables[0].TableName;
                ddl.DataTextField = "Semester";
                ddl.DataValueField = "ID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--Select Semester--", "0"));
                txt.CssClass = "form-control";
                ddl.CssClass = "form-control";
                txt.EnableViewState = true;
                div3.Controls.Add(ddl);
                div1.Controls.Add(txt);
                lt.Text = "<br />";
                lt1.Text = "<br />";
                div1.Controls.Add(lt);
                div3.Controls.Add(lt1);
            }
        }


    }
    //protected void loadddl(int i)
    //{
    //    DropDownList ddl = new DropDownList();
    //    Literal lt1 = new Literal();
    //    string getSems = "select * from Semesters where CourseID=" + CoID;
    //    DataSet dssem = DBT.returnDataSet(getSems);
        
    //        ddl.ID = "ddlDynamic" + i;
    //        ddl.CssClass = "form-control";
    //        ddl.DataSource = dssem;
    //        ddl.DataMember = dssem.Tables[0].TableName;
    //        ddl.DataTextField = "Semester";
    //        ddl.DataValueField = "ID";
    //        ddl.DataBind();
    //        ddl.Items.Insert(0, new ListItem("--Select Semester--", "0"));
    //        div3.Controls.Add(ddl);
    //        lt1.Text = "<br />";
    //        div3.Controls.Add(lt1);

        
       
    //}

    protected void LoadData()
    {
        string strGetData = "select * from Semesters where ID=" + Request.QueryString["CID"].ToString();
        DataSet ds = DBT.returnDataSet(strGetData);
        txtSemName.Text = ds.Tables[0].Rows[0]["Semester"].ToString();
        txtExamFees.Text = ds.Tables[0].Rows[0]["ExamFees"].ToString();
        Code = ds.Tables[0].Rows[0]["PaperCode"].ToString();
      string CourseID = ds.Tables[0].Rows[0]["CourseID"].ToString();
        CoID = CourseID;
        
        string subjects = ds.Tables[0].Rows[0]["Subjects"].ToString();
        oldCourse = subjects;

        string[] splitsubject = oldCourse.Split(',');
        tTxt = splitsubject.Length;
      
        for (int i = 0; i < tTxt; i++)
        {
            TextBox txt = new TextBox();
            DropDownList ddl = new DropDownList();
            Literal lt = new Literal();
            Literal lt1 = new Literal();
            txt.ID = "txtDynamic" + i.ToString();
            ddl.ID = "ddlDynamic" + i.ToString();
            txt.CssClass = "form-control";
          ddl.CssClass= "form-control";
            
            txt.Text = splitsubject[i];
            string getSems = "select * from Semesters where CourseID=" + CoID;
            DataSet dssem = DBT.returnDataSet(getSems);

            ddl.ID = "ddlDynamic" + i;
            ddl.CssClass = "form-control";
            ddl.DataSource = dssem;
            ddl.DataMember = dssem.Tables[0].TableName;
            ddl.DataTextField = "Semester";
            ddl.DataValueField = "ID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select Semester--", "0"));
            ddl.EnableViewState = true;
            txt.EnableViewState = true;
            div3.Controls.Add(ddl);
            lt.Text = "<br />";
            lt1.Text = "<br />";
            div1.Controls.Add(txt);
            
            div1.Controls.Add(lt);
            div3.Controls.Add(lt1);

        }
    }

    protected void AddTextBox(object sender, EventArgs e)
    {
        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
        List<string> keysddl = Request.Form.AllKeys.Where(key => key.Contains("ddlDynamic")).ToList();
        int index = div1.Controls.OfType<TextBox>().ToList().Count + 1;
        int index1 = div3.Controls.OfType<DropDownList>().ToList().Count + 1;
        TextBox txt = new TextBox();
        DropDownList ddl = new DropDownList();
        Literal lt = new Literal();
        Literal lt1 = new Literal();
        txt.ID = "txtDynamic" + index;
        txt.CssClass = "form-control";
        ddl.ID = "ddlDynamic" + index1;
        ddl.CssClass = "form-control";
        txt.EnableViewState = true;
        ddl.EnableViewState = true;
        div1.Controls.Add(txt);
        div3.Controls.Add(ddl);
        lt.Text = "<br />";
        lt1.Text = "<br />";
        div1.Controls.Add(lt);
        div3.Controls.Add(lt1);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string vExamFees = txtExamFees.Text;
        string Semester = txtSemName.Text;
        string IsDisplay = "1";
        string Subject = "";
        string PaperCode = "";
        Random ren = new Random();

        // string c;
        //string format = "";
        // string[] splitcode = Code.Split(',');
        //int count = splitcode.Length;
        //for (int i = 0; i < count; i++)
        //{
        //    format = "sub" + ren.Next(999999);
        //    c = splitcode[i];
        //    PaperCode = PaperCode + "," + c;
        //}
        //PaperCode = PaperCode.Remove(0, 1).ToString();

        //foreach (TextBox txt in div1.Controls.OfType<TextBox>())
        //{
        //    Subject = oldCourse + "," + txt.Text;

        //}
        //PaperCode = PaperCode + "," + "Sub" + ren.Next(999999);
        //PaperCode = Code + PaperCode;
        //foreach(Label lbl in div3.Controls.OfType<Label>())
        //{
        //    lbl.Text = Code;

        //    PaperCode=lbl.Text =lbl.Text+","+ "Sub" + ren.Next(999999);
        //}
        foreach (TextBox tb in div1.Controls.OfType<TextBox>())
        {
            Subject = Subject + "," + tb.Text;
            PaperCode = PaperCode + "," + "Sub" + ren.Next(999999);
        }
        PaperCode = PaperCode.Remove(0, 1).ToString();
        Subject = Subject.Remove(0, 1).ToString();
        
        string strInsertQry = "update Semesters set Semester=@Semester,Subjects=@Subjects,PaperCode=@PaperCode,isDisplay=@isDisplay,ExamFees=@ExamFees where ID=" + Request.QueryString["CID"].ToString();
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Semester", Semester));
        Pram.Add(new SqlParameter("@Subjects", Subject));
        Pram.Add(new SqlParameter("@isDisplay", IsDisplay));
        Pram.Add(new SqlParameter("@ExamFees", vExamFees));
        Pram.Add(new SqlParameter("@PaperCode", PaperCode));
        DBT.P_ExecuteNonQuery(strInsertQry, Pram);
        Response.Redirect("CourseManagement.aspx");
    }

    protected void btnRemove_Click1(object sender, EventArgs e)
    {
        int lastTxt = div1.Controls.OfType<TextBox>().ToList().Count - 1;
        int lastddl = div3.Controls.OfType<DropDownList>().ToList().Count - 1;
        TextBox txtB = (TextBox)div1.FindControl("txtDynamic" + lastTxt);
        DropDownList ddlB = (DropDownList)div3.FindControl("ddlDynamic" + lastddl);
        div1.Controls.Remove(txtB);
        div3.Controls.Remove(ddlB);
    }
}