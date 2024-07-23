using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditTeam : System.Web.UI.Page
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
        string strGetData = "select * from AwesomeTeam where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["TID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        txtCourse.Text = ds.Tables[0].Rows[0]["TeamName"].ToString();
        txtDesig.Text = ds.Tables[0].Rows[0]["TeamDesig"].ToString();
        lblImageName.Text = ds.Tables[0].Rows[0]["ImageUpload"].ToString();
        imgImage.ImageUrl = "~/images/" + ds.Tables[0].Rows[0]["ImageUpload"].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string vCourseType = txtCourse.Text;
        string vDesignation = txtDesig.Text;
        string vImageUpload = "";
        Random ren = new Random();
        if (fupImage.HasFile)
        {
            vImageUpload = ren.Next(999999) + fupImage.FileName;
            fupImage.SaveAs(Server.MapPath("~/images/" + vImageUpload));
        }
        else
        {
            vImageUpload = lblImageName.Text;
        }
        string insertQry = "Update AwesomeTeam set TeamName=@TeamName,TeamDesig=@TeamDesig,ImageUpload=@ImageUpload where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@TeamName", vCourseType));
        Pram.Add(new SqlParameter("@TeamDesig", vDesignation));
        Pram.Add(new SqlParameter("@ImageUpload", vImageUpload));
        Pram.Add(new SqlParameter("@IsDisplay", "1"));
        Pram.Add(new SqlParameter("@ID", Request.QueryString["TID"].ToString()));
        DBT.P_ExecuteNonQuery(insertQry, Pram);

        Response.Redirect("ManageTeam.aspx");
    }
}