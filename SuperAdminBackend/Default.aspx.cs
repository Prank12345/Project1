using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_Default : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static int tTxt = 0;
    static string oldCourse = "";

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
            tTxt = 0;
            oldCourse = "";

            LoadData();
        }
        loadTXT();
    }
    protected void LoadData()
    {
        string strGetData = "select * from AddCourse where ID=4";
        DataSet ds = DBT.returnDataSet(strGetData);
        
        string subjects = ds.Tables[0].Rows[0]["Subject2"].ToString();
        oldCourse = subjects;
    }
    protected void loadTXT()
    {
        string[] splitsubject = oldCourse.Split(',');
        tTxt = splitsubject.Length;

        for (int i = 0; i < tTxt; i++)
        {
            TextBox txt = new TextBox();
            Literal lt = new Literal();
            txt.ID = "txtDynamic" + i.ToString();
            txt.CssClass = "form-control";
            txt.Text = splitsubject[i];
            div1.Controls.Add(txt);
            lt.Text = "<br />";
            div1.Controls.Add(lt);
        }

        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
     
        foreach (string key in keys)
        {
            this.CreateTextBox("txtDynamic" + tTxt);
            tTxt++;
           
        }
    }

    protected void AddTextBox(object sender, EventArgs e)
    {
        int index = div1.Controls.OfType<TextBox>().ToList().Count + 1;
        this.CreateTextBox("txtDynamic" + index);

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        
        foreach (TextBox textBox in div1.Controls.OfType<TextBox>())
        {
            TextBox txtB = (TextBox)FindControl(textBox.ID);
            div1.Controls.Remove(txtB);
        }
    }
}