using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_PendingCenterAllocation : System.Web.UI.Page
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

    }

    protected void LoadGvCenter()
    {
        string strGetData = "select * from AddStudent where Cid=0 and isDirect=1 order by id desc";
        gvCenter.DataSource = DBT.returnDataSet(strGetData);
        gvCenter.DataBind();
    }



    protected void gvCenter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string Display = e.Row.Cells[0].Text.ToString();
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlcenters");
            DataRowView dr = (DataRowView)e.Row.DataItem;
            string strtGetData = "select * from CenterRegistration where isrequest=1";
            DataSet ds = DBT.returnDataSet(strtGetData);
            ddl.DataSource = ds;
            ddl.DataMember = ds.Tables[0].TableName;
            ddl.DataTextField = "InstituteName";
            ddl.DataValueField = "id";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select Center--", "0"));
        }
    }

    
    protected void ddlcenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.NamingContainer;

        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        string updateStudent = "update AddStudent set Cid='" + ddl.SelectedValue + "', isDirect=0 where id=" + id;
        DBT.executeNonQuery(updateStudent);
        Response.Redirect("ManageStudent.aspx");
    }
}