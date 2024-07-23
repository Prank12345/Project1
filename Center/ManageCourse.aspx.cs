using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_AddCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Course();
        }
    }
    protected void Course()
    {
        DBTrac DBT = new DBTrac();
        string str = "select * from Courses order by ID desc";
        gvcourse.DataSource = DBT.returnDataSet(str);
        gvcourse.DataBind();
    }


    protected void gvcourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {        
        Course();
    }
}