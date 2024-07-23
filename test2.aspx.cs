using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test2 : System.Web.UI.Page
{
    
    private void CreateTextBox(string id)
    {
        TextBox txt = new TextBox();
        txt.ID = id;
        pnlTextBoxes.Controls.Add(txt);

        Literal lt = new Literal();
        lt.Text = "<br />";
        pnlTextBoxes.Controls.Add(lt);
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
        int i = 1;
        foreach (string key in keys)
        {
            this.CreateTextBox("txtDynamic" + i);
            i++;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AddTextBox(object sender, EventArgs e)
    {
        int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
        this.CreateTextBox("txtDynamic" + index);
    }
    protected void GetTextBoxValues(object sender, EventArgs e)
    {
        string message = "";
        foreach (TextBox textBox in pnlTextBoxes.Controls.OfType<TextBox>())
        {
            message += textBox.ID + ": " + textBox.Text + "\\n";
        }
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
    }
}