using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_AddCourseType : System.Web.UI.Page
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
        string GetData = "select * from CourseType order by ID desc";
        gvCenter.DataSource = DBT.returnDataSet(GetData);
        gvCenter.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vCourseType = txtCourse.Text;
        string vImageUpload = "";
        Random ren=new Random() ;
        if(fupImage.HasFile)
        {
            vImageUpload = ren.Next(999999)+ fupImage.FileName;
            fupImage.SaveAs(Server.MapPath("~/CourseTypeImage/" + vImageUpload));
        }
        
        string insertQry = "insert into CourseType (CourseType,IsDisplay,ImageUpload) Values (@CourseType,@IsDisplay,@ImageUpload)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@CourseType", vCourseType));
        Pram.Add(new SqlParameter("@ImageUpload", vImageUpload));
        Pram.Add(new SqlParameter("@IsDisplay", "1"));
        DBT.P_ExecuteNonQuery(insertQry, Pram);

        Response.Redirect("AddCourseType.aspx");
    }

    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBTrac DBT = new DBTrac();
        string id = gvCenter.DataKeys[e.RowIndex].Value.ToString();
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@id", id));
        string DeleteType = "Delete From CourseType where ID=@id";

       // string CID = DBT.P_returnOneValue("select ID From Courses where CTID=@id",pr);
        string DeleteCourse = "Delete From Courses Where CTID = @id";
        //string DeleteSemester = "Delete From Semesters Where CourseID = @CourseID" ;
        //List<SqlParameter> pr1 = new List<SqlParameter>();
        //pr.Add(new SqlParameter("@CourseID", CID));
        DBT.P_ExecuteNonQuery(DeleteType,pr);
        DBT.P_ExecuteNonQuery(DeleteCourse,pr);
       // DBT.P_ExecuteNonQuery(DeleteSemester,pr);
        LoadData();
    }

   

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string SearchKey = txtSearch.Text;
        string GetData = "select * from CourseType where CourseType like '%'+ @CourseType +'%' order by ID desc";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@CourseType", SearchKey));
        DataSet ds = DBT.P_returnDataSet(GetData,pr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvCenter.Visible = true;
            lblMsg.Visible = false;
            gvCenter.DataSource = DBT.returnDataSet(GetData);
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