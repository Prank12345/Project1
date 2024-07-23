using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class AdminLogin : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignin_Click(object sender, EventArgs e)
    {
        string vUsername = txtUserName.Text;
        string vPassword = txtPass.Text;
        string strGetData = "select * from AdminLogin where Username=@Username and Password=@Password";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Username",vUsername));
        Pram.Add(new SqlParameter("@Password", vPassword));

        DataSet dsLogin = DBT.P_returnDataSet(strGetData,Pram);
        if (dsLogin.Tables[0].Rows.Count > 0)
        {
            Session["StaffID"] = null;
            Session["Admin"] = null;
            Session["Admin"] = "Admin";
            Response.Redirect("SuperAdminBackend/Dashboard.aspx");
        }
        else
        {
            string strGetStaffData = "select * From AdminStaff where  UserName=@Email and Password=@Password";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Email", vUsername));
            param.Add(new SqlParameter("@Password", vPassword));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData, param);
            if (dsStLogin.Tables[0].Rows.Count > 0)
            {
                Session["Admin"] = null;
                Session["StaffID"] = null;
                Session["StaffID"] = dsStLogin.Tables[0].Rows[0]["id"].ToString();
                Response.Redirect("SuperAdminBackend/Dashboard.aspx");
            }
            else
            {
                lblMsg.Text = "Wrong Credentials";
            }
            
        }
    }
}