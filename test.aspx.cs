using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{    
    Panel pnlTextBox;
    
    protected void Page_PreInit(object sender, EventArgs e)

    {

        //Create a Dynamic Panel

        pnlTextBox = new Panel();

        pnlTextBox.ID = "pnlTextBox";

        // pnlTextBox.BorderWidth = 1;
        
        //pnlTextBox.Width = 1000;

        //this.form1.Controls.Add(pnlTextBox);

        this.div1.Controls.Add(pnlTextBox);

        //Create a LinkDynamic Button to Add TextBoxes

        LinkButton btnAddtxt = new LinkButton();

        btnAddtxt.ID = "btnAddTxt";

        btnAddtxt.Text = "Add TextBox";
        btnAddtxt.CssClass = "btn btn-block btn-success";
        btnAddtxt.Click += new System.EventHandler(btnAdd_Click);

        this.div1.Controls.Add(btnAddtxt);



        //Recreate Controls

        RecreateControls("txtDynamic", "TextBox");

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)

    {

        int cnt = FindOccurence("txtDynamic");

        CreateTextBox("txtDynamic-" + Convert.ToString(cnt + 1));

    }
    private int FindOccurence(string substr)

    {

        string reqstr = Request.Form.ToString();

        return ((reqstr.Length - reqstr.Replace(substr, "").Length)

                          / substr.Length);

    }
    private void CreateTextBox(string ID)

    {

        TextBox txt = new TextBox();

        txt.ID = ID;
        txt.CssClass = "form-control";
        //txt.AutoPostBack = true;

        //txt.TextChanged += new EventHandler(OnTextChanged);

        pnlTextBox.Controls.Add(txt);



        Literal lt = new Literal();

        lt.Text = "<br />";

        pnlTextBox.Controls.Add(lt);

    }
    private void RecreateControls(string ctrlPrefix, string ctrlType)

    {

        string[] ctrls = Request.Form.ToString().Split('&');

        int cnt = FindOccurence(ctrlPrefix);

        if (cnt > 0)

        {

            for (int k = 1; k <= cnt; k++)

            {

                for (int i = 0; i < ctrls.Length; i++)

                {

                    if (ctrls[i].Contains(ctrlPrefix + "-" + k.ToString())

                        && !ctrls[i].Contains("EVENTTARGET"))

                    {

                        string ctrlID = ctrls[i].Split('=')[0];



                        if (ctrlType == "TextBox")

                        {

                            CreateTextBox(ctrlID);

                        }

                        break;

                    }

                }

            }

        }

    }


    protected void btn_Click(object sender, EventArgs e)
    {

    }
}