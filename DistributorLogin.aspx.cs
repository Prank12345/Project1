using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class DistributorLogin : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string email = txtemail.Text;
        string pass = txtpass.Text;
        string strGetData = "select * From Distributors where  EmailID=@EmailID and Password=@Password and IsRequest=@IsRequest and IsLogin=@IsLogin";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@EmailID", email));
        Pram.Add(new SqlParameter("@Password", pass));
        Pram.Add(new SqlParameter("@IsRequest", "1"));
        Pram.Add(new SqlParameter("@IsLogin", "1"));
        DataSet dsLogin = DBT.P_returnDataSet(strGetData,Pram);
        if (dsLogin.Tables[0].Rows.Count > 0)
        {
            Session["DID"] = null;
            Session["DID"] = dsLogin.Tables[0].Rows[0]["id"].ToString();
            Response.Redirect("Distributor/Dashboard.aspx");
        }
        else
        {
            Response.Write("<script>alert(Wrong Username Or Password);</script>");
        }

    }
}