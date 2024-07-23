using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Distributor_Dashboard : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCount();
        }
    }
    protected void LoadCount()
    {
        string GetCenters = "select Count(ID) from CenterRegistration where distId=@distId" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@distId", Session["DID"].ToString()));
        string Count = DBT.P_returnOneValue(GetCenters,Pram);
        lblcenter.Text = Count;
       
    }
}