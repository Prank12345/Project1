using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_ManageTeam : System.Web.UI.Page
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
        string GetData = "select * from AwesomeTeam order by ID desc";
        gvCenter.DataSource = DBT.returnDataSet(GetData);
        gvCenter.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vCourseType = txtCourse.Text;
        string vDesignation = txtDesig.Text;
        string vImageUpload = "";
        Random ren = new Random();
        if (fupImage.HasFile)
        {
            vImageUpload = ren.Next(999999)+fupImage.FileName;
            fupImage.SaveAs(Server.MapPath("~/images/" + vImageUpload));
        }

        string insertQry = "insert into AwesomeTeam (TeamName,TeamDesig,IsDisplay,ImageUpload) Values (@TeamName,@TeamDesig,@IsDisplay,@ImageUpload)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@TeamName", vCourseType));
        Pram.Add(new SqlParameter("@TeamDesig", vDesignation));
        Pram.Add(new SqlParameter("@ImageUpload", vImageUpload));
        Pram.Add(new SqlParameter("@IsDisplay", "1"));
        DBT.P_ExecuteNonQuery(insertQry, Pram);

        Response.Redirect("ManageTeam.aspx");
    }

    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBTrac DBT = new DBTrac();
        string id = gvCenter.DataKeys[e.RowIndex].Value.ToString();
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@id", id));
        string DeleteType = "Delete From AwesomeTeam where ID=@id";
        
        DBT.P_ExecuteNonQuery(DeleteType, pr);
       
        LoadData();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string SearchKey = txtSearch.Text;
        string GetData = "select * from AwesomeTeam where TeamName like '%'+ @TeamName +'%' order by ID desc";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@TeamName", SearchKey));
        DataSet ds = DBT.P_returnDataSet(GetData, pr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvCenter.Visible = true;
            lblMsg.Visible = false;
            gvCenter.DataSource = ds;
            gvCenter.DataBind();
        }
        else
        {
            gvCenter.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No Record Found";
        }
    }
}