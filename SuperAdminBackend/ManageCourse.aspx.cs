using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_ManageCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGvCenter();
            //loadCount();
        }
    }
    DBTrac DBT = new DBTrac();
    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvCenter.DataKeys[e.RowIndex].Value.ToString();
        string DeleteCategory = "Delete From AddCourse Where id = " + id;
        DBT.executeNonQuery(DeleteCategory);
        LoadGvCenter();
    }
   
    protected void LoadGvCenter()
    {
        string strGetData = "select * from AddCourse order by id desc";
        gvCenter.DataSource = DBT.returnDataSet(strGetData);
        gvCenter.DataBind();
    }

    protected void gvCenter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }
    
}