using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_Downloads : System.Web.UI.Page
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
        string strGetData = "select * from DowloadFile order by ID desc";
        gvDownloads.DataSource = DBT.returnDataSet(strGetData);
        gvDownloads.DataBind();
    }
    protected void gvDownloads_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvDownloads.DataKeys[e.RowIndex].Value.ToString();

        string DeleteCategory = "Delete From DowloadFile Where ID = @ID";
        List<SqlParameter> PRam = new List<SqlParameter>();
        PRam.Add(new SqlParameter("@ID", id));
        DBTrac DBT = new DBTrac();

        DBT.P_ExecuteNonQuery(DeleteCategory,PRam);
        

        LoadData();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string vFileName = txtfileName.Text;
        string vFileUpload = "";
        if(fup.HasFile)
        {
            fup.SaveAs(Server.MapPath("~/Downloads/" + fup.FileName));
            vFileUpload = fup.FileName;
        }
        string strInsertData = "insert into DowloadFile (FileName,UploadFile,IsDisplay) values(@FileName,@UploadFile,@IsDisplay)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@FileName", vFileName));
        Pram.Add(new SqlParameter("@UploadFile", vFileUpload));
        Pram.Add(new SqlParameter("@IsDisplay","1"));
        DBT.P_ExecuteNonQuery(strInsertData, Pram);
        Response.Redirect("Downloads.aspx");
    }
}