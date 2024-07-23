using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DistributorDeatils : System.Web.UI.Page
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
        string strGetData = "select* from CenterRegistration where Id=@ID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@ID", Session["ID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData, pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //lblCName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString().ToUpper();
            lblCAddress.Text = ds.Tables[0].Rows[0]["FullAddress"].ToString();
            lblCHeadName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
            lblCState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            imgDistributorImg.ImageUrl = "~/Distributor-Docs/" + ds.Tables[0].Rows[0]["PassportImage"].ToString();
            lblCenterID.Text = ds.Tables[0].Rows[0]["DistributorID"].ToString();
        }
    }
}