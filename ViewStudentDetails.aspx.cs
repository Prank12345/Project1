using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ViewStudentDetails : System.Web.UI.Page
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
        string strGetData = "select * from AddStudent where StudentID=@StudentID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@StudentID", Request.QueryString["SID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData,pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            imgImageStudent.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            lblSName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString().ToUpper();
            lblStuID.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
            lblSesion.Text = ds.Tables[0].Rows[0]["SessionFrom"].ToString() + " - " + ds.Tables[0].Rows[0]["SessionTo"].ToString();
            lblMomName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
            lblDadName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            string vCID = ds.Tables[0].Rows[0]["CID"].ToString();
            string strGetDataCenter = "select * from CenterRegistration where Id=" + vCID;
            DataSet dsCenter = DBT.returnDataSet(strGetDataCenter);
           

            lblCName.Text = dsCenter.Tables[0].Rows[0]["InstituteName"].ToString();
            lblCAddress.Text = dsCenter.Tables[0].Rows[0]["Address"].ToString();
            //lblCDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
            //lblCCity.Text = ds.Tables[0].Rows[0]["City"].ToString();

        }
    }
}