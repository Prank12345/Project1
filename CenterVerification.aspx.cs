using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CenterVerification : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string VsearchID = txtCenterID.Text;
        string strGetData = "select * from CenterRegistration where CenterID =@CenterID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@CenterID", VsearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData,pram);
        if(ds.Tables[0].Rows.Count>0)
        {
            lblCName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
            lblCAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            lblCHeadName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
            lblCState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            //lblCDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
            //lblCCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            lblCenerID.Text= ds.Tables[0].Rows[0]["CenterID"].ToString();
            img.ImageUrl= "~/Center-Document/" + ds.Tables[0].Rows[0]["passportpic"].ToString();
            divShow.Visible = true;
        }
        else
        {
            Response.Write("<script>alert('No Data Found')</script>");
        }
    }
}