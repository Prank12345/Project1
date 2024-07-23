using iTextSharp.text;
using System.IO;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

public partial class SuperAdminBackend_StudentList : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadGvCenter();
            loadCount();
        }
    }
    protected void loadCount()
    {
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@isrequest", "1"));
        List<SqlParameter> pr2 = new List<SqlParameter>();
        pr2.Add(new SqlParameter("@isrequest", "0"));
        List<SqlParameter> pr3 = new List<SqlParameter>();
        pr3.Add(new SqlParameter("@isrequest", "2"));
        string strGetCount = DBT.P_returnOneValue("select Count(ID) from AddStudent where isRequest=@isrequest",pr1);
        lblVerified.Text = strGetCount;
        string strGetCount1 = DBT.P_returnOneValue("select Count(ID) from AddStudent where isRequest=@isrequest",pr2);
        lblVerification.Text = strGetCount1;
        string strGetCount2 = DBT.P_returnOneValue("select Count(ID) from AddStudent where isrequest=@isrequest",pr3);
        lblRejected.Text = strGetCount2;
    }
    protected void LoadGvCenter()
    {
        string strGetData = "select * from AddStudent order by id desc";
        gvCenter.DataSource = DBT.returnDataSet(strGetData);
        gvCenter.DataBind();
    }
    protected void lbAll_Click(object sender, EventArgs e)
    {
        LoadGvCenter();
    }
    protected void lbSearch_Click(object sender, EventArgs e)
    {
        string VsearchName = txtSearch.Text;
        string strGetData = "select * from AddStudent where StudentName like '%'+ @StudentName + '%'";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@StudentName", VsearchName));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetData, pram);
        gvCenter.DataBind();
    }
    protected void lbVerify_Click(object sender, EventArgs e)
    {
        string strGetCount = "select * from AddStudent where isRequest=@isrequest";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@isrequest", "0"));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetCount,pram);
        gvCenter.DataBind();
    }

    protected void lbVerified_Click(object sender, EventArgs e)
    {
        string strGetCount = "select * from AddStudent where isRequest=@isRequest";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@isrequest", "1"));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetCount,pram);
        gvCenter.DataBind();
    }
    protected void lbRejected_Click(object sender, EventArgs e)
    {
        string strGetCount = "select * from AddStudent where isrequest=@isrequest";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@isrequest", "2"));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetCount,pram);
        gvCenter.DataBind();
    }
    protected void btnStudentID_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;

        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        string strGetData = "select * from AddStudent where id = @id" ;
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet(strGetData,pram);

        lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        lblStuID.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openMod();", true);
    }

    protected void btnCourse_Click(object sender, EventArgs e)
    {
        
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        string IDD = DBT.P_returnOneValue("select Course from AddStudent where id = @id",pram);
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@id", IDD));
        DataSet ds = DBT.P_returnDataSet("select * from Courses where Id=@id" , param);
        lblCName.Text = ds.Tables[0].Rows[0]["FullCourseName"].ToString();

        DataSet sm = DBT.P_returnDataSet("select * from Semesters where CourseID=@id" ,param);
        rptSems.DataSource = sm;
        rptSems.DataBind();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openCourse();", true);
    }

    protected void btnCenterID_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        string ID = DBT.P_returnOneValue("select Cid from AddStudent where id = @id" ,pram);
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@id", ID));
        DataSet ds = DBT.P_returnDataSet("select * from CenterRegistration where Id=@id" ,param);
        lblCenterName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCAddr.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openCenter();", true);
    }

    protected void lnkbtnCenterLogin_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;

        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        Session["SID"] = id;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../Student/Dashboard.aspx', '_blank');", true);
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Session["StudentID"] = lblStuID.Text;
        Response.Redirect("StudentIcard.aspx");
    }

    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvCenter.DataKeys[e.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        string DeleteCategory = "Delete From AddStudent Where ID = @id";
        
        DBTrac DBT = new DBTrac();
       
        DBT.P_ExecuteNonQuery(DeleteCategory,pram);
        LoadGvCenter();
    }

    protected void btnpdf_Click(object sender, EventArgs e)
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvCenter.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=StudentList-" + DateTime.Now.ToShortDateString() + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=StudentList-" + DateTime.Now.ToShortDateString() + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        StringWriter StringWriter = new System.IO.StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

        gvCenter.RenderControl(HtmlTextWriter);
        Response.Write(StringWriter.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}