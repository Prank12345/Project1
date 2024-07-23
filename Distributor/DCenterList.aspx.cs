using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Distributor_DCenterList : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    protected void LoadData()
    {
        if(Session["DID"]!=null)
        {
           
            string strGetData = "select * from CenterRegistration where DistID=@DistID" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@DistID", Session["DID"].ToString()));
            gvCenter.DataSource = DBT.P_returnDataSet(strGetData,Pram);
            gvCenter.DataBind();
        }
        
        else
        {
            Response.Redirect("~/DistributorLogin.aspx");
        }
    }

    protected void hlView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
       
        string getstudent = "select* from AddStudent where Cid=@Cid" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Cid", id));
        gvstudent.DataSource = DBT.P_returnDataSet(getstudent,Pram);
        gvstudent.DataBind();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openMod();", true);
    }
}