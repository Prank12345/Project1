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
using QRCoder;
using System.Drawing;

public partial class Center_ManageStudent : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            student();
            Showbtn();
        }
    }
    protected void Showbtn()
    {
        string Cid = "";
        if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> PRam = new List<SqlParameter>();
            PRam.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,PRam);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
           
        }

        else if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }
        if (Cid != null)
        {
            string str = "select * from CenterRegistration where IsActiveBackDate=@IsActiveBackDate and ID=@ID";
            List<SqlParameter> PRam = new List<SqlParameter>();
            PRam.Add(new SqlParameter("@IsActiveBackDate", "1"));
            PRam.Add(new SqlParameter("@ID",Cid));
            DataSet ds = DBT.P_returnDataSet(str,PRam);
            if(ds.Tables[0].Rows.Count>0)
            {
                hlOldStudent.Visible = true;
            }
            else
            {
                hlOldStudent.Visible = false;
            }
           
        }
        else
        {
            Response.Redirect("~/CenterLogin.aspx");
        }
       
    }
    protected void student()
    {
        string Cid = "";
        if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pram);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();           
        }

        else if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }
        if (Cid != null)
        {
            string str = "select * from AddStudent where Cid=@Cid order by ID desc";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@Cid", Cid));
            gvstudent.DataSource = DBT.P_returnDataSet(str,Pr);
            gvstudent.DataBind();
        }
        else
        {
            Response.Redirect("~/CenterLogin.aspx");
        }
    }

    protected void gvstudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void gvstudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            string display = e.Row.Cells[5].Text.ToString();
            HyperLink btn= e.Row.FindControl("btnGenerate") as HyperLink;
            Button btnFee = e.Row.FindControl("btnFeesPay") as Button;
            if (display=="1")
            {
                e.Row.Cells[5].Text = "verified";
                btn.Visible = true;
                btnFee.Visible = true;
                 
            }
            else if(display == "0")
            {
                e.Row.Cells[5].Text = "Pending For Approval";
                btn.Visible = false;
                btnFee.Visible = false;
            }
            else 
            {
                e.Row.Cells[5].Text = "Rejected";
                btn.Visible = false;
                btnFee.Visible = false;
            }
        }
    }
    protected void lnkbtnCenterLogin_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;

        string id = gvstudent.DataKeys[row.RowIndex].Value.ToString();
        Session["SID"] = id;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../Student/Dashboard.aspx', '_blank');", true);
    }   

    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelect = (CheckBox)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)chkSelect.NamingContainer; // get the GridViewRow that contains the linkbutton         
        int idChk = row.RowIndex;
    }

    protected void btnAddFees_Click(object sender, EventArgs e)
    {
        string vNarration = txtTranDesc.Text;
        string vAmount = txtAmt.Text;
        string getData = "select * from AddStudent where ID=@ID";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ID", hfID.Value));
        DataSet ds = DBT.P_returnDataSet(getData,Pr);
        
        string vCourseID = ds.Tables[0].Rows[0]["Course"].ToString();
        Random ren = new Random();
        string invoce =Convert.ToString(ren.Next(999999));
        string invDate = txtDate.Text;
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.returnDataSet(strGetStaffData);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        //string EXDate = txtExDate.Text;
        foreach (GridViewRow row in gvSems.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

            if (chkSelect.Checked == true)
            {
                string selectid = gvSems.DataKeys[row.RowIndex].Value.ToString();
                string insrtquery = "insert into FeesReceipt (Narration,Amount,SID,CID,CourseID,isdisplay,InvoiceNumber,InvoiceDate,SemID)values(@Narration,@Amount,@SID,@CID,@CourseID,@isdisplay,@InvoiceNumber,@InvoiceDate,@SemID)";

                List<SqlParameter> Pram = new List<SqlParameter>();
                Pram.Add(new SqlParameter("@Narration", vNarration));
                Pram.Add(new SqlParameter("@Amount", vAmount));
                Pram.Add(new SqlParameter("@SID", hfID.Value));
                Pram.Add(new SqlParameter("@CID", Cid));
                Pram.Add(new SqlParameter("@CourseID", vCourseID));
                Pram.Add(new SqlParameter("@InvoiceNumber", invoce));
                Pram.Add(new SqlParameter("@isdisplay", "1"));
                Pram.Add(new SqlParameter("@InvoiceDate", invDate));
                Pram.Add(new SqlParameter("@SemID", selectid));

                DBT.P_ExecuteNonQuery(insrtquery, Pram);
            }
        }
        Response.Redirect("ManageStudent.aspx");
    }
    protected void loadgvsem()
    {
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ID", hfID.Value));
        string CourseID = DBT.P_returnOneValue("select Course from AddStudent where ID=@ID",Pr);
        string strgetddata = "select * from Semesters where CourseID=@CourseID";
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@CourseID", CourseID));
        gvSems.DataSource = DBT.P_returnDataSet(strgetddata,Pr1);
        gvSems.DataBind();
    }
    protected void btnFeesPay_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvstudent.DataKeys[row.RowIndex].Value.ToString();       
        hfID.Value = id;
        loadgvsem();
        LoadgvTransaction();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openFeesModal();", true);
    }
    protected void LoadgvTransaction()
    {
        string strGetData = "select * from FeesReceipt fr join Semesters s on fr.SemID=s.ID where SID=@SID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@SID",hfID.Value));
        gvTransact.DataSource = DBT.P_returnDataSet(strGetData,Pram);
        gvTransact.DataBind();
    }

    protected void btnGenerate_Click1(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvTransact.DataKeys[row.RowIndex].Value.ToString();
        Session["ID"] = id;
        Response.Redirect("~/Center/feesReceipt.aspx");
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvstudent.RenderControl(hw);
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

        gvstudent.RenderControl(HtmlTextWriter);
        Response.Write(StringWriter.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}