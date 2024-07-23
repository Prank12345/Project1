using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_GalleryImage : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadGallery();
        }
    }

    private void LoadGallery()
    {
        string strGetData = "select * from GalleryImage order by ID";
        gvGallery.DataSource = DBT.returnDataSet(strGetData);
        gvGallery.DataBind();

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Image = "";
        if(fupUloadImage.HasFile)
        {
            fupUloadImage.SaveAs(Server.MapPath("~/GalleryImage/" + fupUloadImage.FileName));
            Image = fupUloadImage.FileName;
        }
        string strInsertData = "insert into GalleryImage(GalleryImage,IsDisplay) values(@GalleryImage,@IsDisplay) ";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@GalleryImage", Image));
        Pram.Add(new SqlParameter("@IsDisplay", "1"));
        DBT.P_ExecuteNonQuery(strInsertData, Pram);
        LoadGallery();
    }

    protected void gvGallery_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvGallery.DataKeys[e.RowIndex].Value.ToString();
        string DeleteCategory = "Delete From GalleryImage Where ID = @ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        DBT.P_ExecuteNonQuery(DeleteCategory,Pram);
        LoadGallery();
    }
}