using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditCourseType : System.Web.UI.Page
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
        string strGetData= "select * from CourseType where ID=@ID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["CTID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        txtCourse.Text = ds.Tables[0].Rows[0]["CourseType"].ToString();
        lblImageName.Text= ds.Tables[0].Rows[0]["ImageUpload"].ToString();
        imgImage.ImageUrl = "~/CourseTypeImage/" + ds.Tables[0].Rows[0]["ImageUpload"].ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vCourseType = txtCourse.Text;
        string vImageUpload = "";
        Random ren = new Random();
        if (fupImage.HasFile)
        {
            vImageUpload = ren.Next(999999) + fupImage.FileName;
            fupImage.SaveAs(Server.MapPath("~/CourseTypeImage/" + vImageUpload));
        }
        else
        {
            vImageUpload = lblImageName.Text;
        }
        string insertQry = "Update CourseType set CourseType=@CourseType,ImageUpload=@ImageUpload where ID=@ID"; 
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@CourseType", vCourseType));
        Pram.Add(new SqlParameter("@ImageUpload", vImageUpload));
        Pram.Add(new SqlParameter("@ID", Request.QueryString["CTID"].ToString()));
        DBT.P_ExecuteNonQuery(insertQry, Pram);

        Response.Redirect("AddCourseType.aspx");
    }
}