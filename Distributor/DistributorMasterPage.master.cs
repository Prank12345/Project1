using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Distributor_DistributorMasterPage : System.Web.UI.MasterPage
{
    string id = "";
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            loadname();
        }

    }
    protected void loadname()
    {
        if (Session["DID"] != null)
        {

            string str = "select * from Distributors where id=@id" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@id", Session["DID"].ToString()));
            DataSet ds = DBT.P_returnDataSet(str,Pram);
            lblname.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
            imgCenterHead.ImageUrl = "~/Distributor-Docs/" + ds.Tables[0].Rows[0]["PassportImage"].ToString();
        }        
        else
        {
          
            Session["DID"] = null;
            Response.Redirect("~/DistributorLogin.aspx");

        }
    }
    protected void logout_click(object sender, EventArgs e)
    {
       
        Session["DID"] = null;      
        Response.Redirect("~/DistributorLogin.aspx");
    }

    protected void lbLogout_Click(object sender, EventArgs e)
    {
       
        Session["DID"] = null;
        Response.Redirect("~/DistributorLogin.aspx");
    }
}
