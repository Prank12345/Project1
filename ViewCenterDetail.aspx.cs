using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ViewCenterDetail : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
        }
    }

    protected void LoadData()
    {
        string strGetData = "select* from CenterRegistration where Id=@ID" ;
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@ID", Request.QueryString["CID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData,pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString().ToUpper();
            lblCAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblCHeadName.Text= ds.Tables[0].Rows[0]["PersonName"].ToString();
            lblCState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            imgCenterHeadImg.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["passportpic"].ToString();
            lblCenterID.Text = ds.Tables[0].Rows[0]["CenterID"].ToString();          
        }
    }
}