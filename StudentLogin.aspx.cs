using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class StudentLogin : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignin_Click(object sender, EventArgs e)
    {
        string vUsername = txtUserName.Text;
        string vPassword = txtPass.Text;
       
        string strGetData = "select * from AddStudent where StudentEmail=@StudentEmail and Password=@Password";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentEmail", vUsername));
        Pram.Add(new SqlParameter("@Password", vPassword));
        DataSet dsLogin = DBT.P_returnDataSet(strGetData,Pram);
        if (dsLogin.Tables[0].Rows.Count > 0)
        {
            Session["SID"] = null;
            Session["SID"] = dsLogin.Tables[0].Rows[0]["ID"].ToString();
            Response.Redirect("Student/Dashboard.aspx");
        }
        else
        {
            lblMsg.Text = "Wrong Credentials";
        }
    }
}