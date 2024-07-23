using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CenterLogin : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string email = txtemail.Text;
        string pass = txtpass.Text;
        string strGetData= "select * From CenterRegistration where  Email=@Email and Password=@Password and IsLogin=@IsLogin";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@Email", email));
        pram.Add(new SqlParameter("@Password", pass));
        pram.Add(new SqlParameter("@IsLogin", "1"));
        DataSet dsLogin = DBT.P_returnDataSet(strGetData,pram);
        if (dsLogin.Tables[0].Rows.Count > 0)
        {
            Session["centerid"] = null;
            Session["StaffID"] = null;
            Session["centerid"] = dsLogin.Tables[0].Rows[0]["id"].ToString();
            Response.Redirect("Center/Dashboard.aspx");
        }
        else
        {
           
            string strGetStaffData = "select * From CenterStaff where  UserName=@Email and Password=@Password";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Email", email));
            param.Add(new SqlParameter("@Password", pass));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData, param);
            if (dsStLogin.Tables[0].Rows.Count>0)
            {
                Session["StaffID"] = null;
                Session["centerid"] = null;
                Session["StaffID"] = dsStLogin.Tables[0].Rows[0]["id"].ToString();
                Response.Redirect("Center/Dashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Wrong Username or Password');</script>");
            }

        }

    }
}