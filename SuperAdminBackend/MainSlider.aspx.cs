using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_MainSlider : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSlider();
    }

    private void LoadSlider()
    {
        string strGetData = "select * from MainSlider order by ID desc";
        gvMainSlider.DataSource = DBT.returnDataSet(strGetData);
        gvMainSlider.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Image1 = "";
        string Image2 = "";
        string Image3 = "";
        string Image4 = "";
        string Image5 = "";
        if (fupUloadImage.HasFile)
        {
            fupUloadImage.SaveAs(Server.MapPath("~/MainSlider/" + fupUloadImage.FileName));
            Image1 = fupUloadImage.FileName;
        }
        if (fupUloadImage.HasFile)
        {
            fupImage2.SaveAs(Server.MapPath("~/MainSlider/" + fupImage2.FileName));
            Image2 = fupImage2.FileName;
        }
        if (fupUloadImage.HasFile)
        {
            fupImage3.SaveAs(Server.MapPath("~/MainSlider/" + fupImage3.FileName));
            Image3 = fupImage3.FileName;
        }
        if (fupUloadImage.HasFile)
        {
            fupImage4.SaveAs(Server.MapPath("~/MainSlider/" + fupImage4.FileName));
            Image4 = fupImage4.FileName;
        }
        if (fupUloadImage.HasFile)
        {
            fupImage5.SaveAs(Server.MapPath("~/MainSlider/" + fupImage5.FileName));
            Image5 = fupImage5.FileName;
        }
        string strInsertData = "insert into MainSlider(Image1,Image2,Image3,Image4,Image5,IsDisplay) values(@Image1,@Image2,@Image3,@Image4,@Image5,@IsDisplay) ";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Image1", Image1));
        Pram.Add(new SqlParameter("@Image2", Image2));
        Pram.Add(new SqlParameter("@Image3", Image3));
        Pram.Add(new SqlParameter("@Image4", Image4));
        Pram.Add(new SqlParameter("@Image5", Image5));
        Pram.Add(new SqlParameter("@IsDisplay", "1"));
        DBT.P_ExecuteNonQuery(strInsertData, Pram);
        LoadSlider();
    }

    protected void gvMainSlider_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvMainSlider.DataKeys[e.RowIndex].Value.ToString();
        string DeleteCategory = "Delete From MainSlider Where ID = @ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        DBT.P_ExecuteNonQuery(DeleteCategory,Pram);
        LoadSlider();
    }
}