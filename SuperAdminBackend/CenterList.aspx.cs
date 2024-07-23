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

public partial class SuperAdminBackend_CenterList : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGvCenter();
            loadCount();
        }
    }
    protected void loadCount()
    {
        string strqry1 = "select Count(ID) from CenterRegistration where isrequest=@isrequest";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@isrequest", "1"));
        string strGetCount = DBT.P_returnOneValue(strqry1,Pram);
        lblVerified.Text = strGetCount;

        string strqry2 = "select Count(ID) from CenterRegistration where isrequest=@isrequest";
        List<SqlParameter> Pram1 = new List<SqlParameter>();
        Pram1.Add(new SqlParameter("@isrequest", "0"));
        string strGetCount1 = DBT.P_returnOneValue(strqry2, Pram1);
        lblVerification.Text = strGetCount1;

        string strqry3 = "select Count(ID) from CenterRegistration where isrequest=@isrequest";
        List<SqlParameter> Pram2 = new List<SqlParameter>();
        Pram2.Add(new SqlParameter("@isrequest", "2"));
        string strGetCount2 = DBT.P_returnOneValue(strqry3, Pram2);
        lblRejected.Text = strGetCount2;
    }
    protected void LoadGvCenter()
    {
        string strGetData = "select * from CenterRegistration order by id desc";
        gvCenter.DataSource = DBT.returnDataSet(strGetData);
        gvCenter.DataBind();
    }
    protected void lbAll_Click(object sender, EventArgs e)
    {
        LoadGvCenter();
    }
    protected void lbVerify_Click(object sender, EventArgs e)
    {
        string strqry1 = "select * from CenterRegistration where isrequest=@isrequest order by ID desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@isrequest", "0"));
        
        gvCenter.DataSource = DBT.P_returnDataSet(strqry1, Pram);
        gvCenter.DataBind();
    }

    protected void lbVerified_Click(object sender, EventArgs e)
    {
        string strqry1 = "select * from CenterRegistration where isrequest=@isrequest order by ID desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@isrequest", "1"));

        gvCenter.DataSource = DBT.P_returnDataSet(strqry1, Pram);
        gvCenter.DataBind();
    }
    protected void lbRejected_Click(object sender, EventArgs e)
    {
        string strqry1 = "select * from CenterRegistration where isrequest=@isrequest order by ID desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@isrequest", "2"));

        gvCenter.DataSource = DBT.P_returnDataSet(strqry1, Pram);
        gvCenter.DataBind();
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
                    Response.AddHeader("content-disposition", "attachment;filename=CenterList-" + DateTime.Now.ToShortDateString() + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=CenterList-" + DateTime.Now.ToShortDateString() + ".xls");
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string VsearchName = txtSearch.Text;
        string strGetData = "select * from CenterRegistration where InstituteName like @InstituteName  order by ID desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@InstituteName", VsearchName));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetData, Pram);
        gvCenter.DataBind();
        txtSearch.Text = "";
    }

    protected void hlView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        //string ID = DBT.returnOneValue("select Cid from AddStudent where id = " + id);

        string qry = "select * from CenterRegistration where Id=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        DataSet ds = DBT.P_returnDataSet(qry,Pram);

        lblCenName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCenterID.Text = ds.Tables[0].Rows[0]["CenterID"].ToString();
        lblHeadName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
        lblDetails.Text = "Address:" + ds.Tables[0].Rows[0]["Address"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode"].ToString() + "<br/>" + "Total PCs= " + ds.Tables[0].Rows[0]["TotalPC"].ToString() + " , Staff= " + ds.Tables[0].Rows[0]["Staffs"].ToString();
        lblQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
        imgqual.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["Marksheet"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openMod();", true);
    }

    protected void hlResendEmail_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        string qry = "select * from CenterRegistration where Id=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        DataSet ds = DBT.P_returnDataSet(qry, Pram);
        SendMail(ds.Tables[0].Rows[0]["Email"].ToString(), "NPCVBSkillDevelopment", id);
    }
    protected void SendMail(string to, string site, string id)
    {
        string from = "noreply@npcvb.com"; //Replace this with your own correct Gmail Address

        MailMessage mail = new MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "Message From Website", System.Text.Encoding.UTF8);
        mail.Subject = "Your Center ID and password" + site;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = contact(id);
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "9ly6kJ7?");

        client.Port = 25; // Gmail works on this port
        client.Host = "mail.npcvb.com";
        client.EnableSsl = false; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);

            // Response.Write("<script>alert('Thanks for your message. We will revert back to you soon.');</script>");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try 
    }


    public string contact(string id)
    {
        string qry = "select * from CenterRegistration where Id=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        DataSet ds = DBT.P_returnDataSet(qry, Pram);
        string returnString = "<table style='width:100%; border:1px solid black; '>";
        returnString = returnString + "<tr style='background-color:#003a6a;'>";
        returnString = returnString + "<td style='width:40%; padding-right:5px; padding-left:5px; text-align:center;'><h3 style='color:white;'>NATIONAL PARAMEDICAL COUNCILAND VOCATIONAL BOARD SKILL DEVELOPMENT</ h3 ></td>";
        returnString = returnString + "<td style='width:20%; text-align:center; padding-top:5px; background-color:#c7d0fe;'><img src='http://www.npcvb.com/Image/nlogo.png' style='width:100px'/></td>";
        returnString = returnString + "<td style='width:40%; padding-left:5px; text-align:center'><h2 style='color:white;'> राष्ट्रीय पैरामेडिकल काउंसिल एंड वोकेशनल बोर्ड कौशल विकास </h2></td> ";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table align='center'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/NationalHumanRightsCommission.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/ISO9001-2015.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/NationalComissionForWomen.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/QRO.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/wcd.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/nspfb.png' style='width:80px;'/></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + " <hr />";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table style='width:100%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='text-align:center; padding-left:40px;'><h2>Welcome To NPCVB skill Development</h2></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding-left:200px;'>";
        returnString = returnString + "<p style='color:red;padding-left:200px; font-family:Arial;'>Hi, <b>" + ds.Tables[0].Rows[0]["PersonName"].ToString() + "(" + ds.Tables[0].Rows[0]["CenterID"].ToString() + ")" + "</b></p>";
        returnString = returnString + "<p style='color:black; font-family:Arial;'>You Are All Set Now You Can Register Your Students With Us And We Can Grow Together</p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='text-align:center;'> <p style='color:white; font-family:Arial; border:solid 1px black; padding:10px; margin-left:300px; margin-right:300px; background-color:#690319;color:yellow;'>Your Login Details To Use your Dashboard</p></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style=''>";
        returnString = returnString + "<table align='center' style='border:solid 1px lightgray; width:32%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'> <span style='padding:5px; padding-right:50px;'> center-ID </span></td>";
        returnString = returnString + "<td style='padding:5px;border-bottom:1px solid lightgray;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["CenterID"].ToString() + "</span></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Login ID</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["Email"].ToString() + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Password</span></td>";
        returnString = returnString + "<td style='padding:5px;border-top:1px solid lightgray;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["Password"].ToString() + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr style='padding-top:30px;'><td colspan='3'><a href='http://www.npcvb.com/CenterLogin.aspx' style='color:white; font-family:Arial; border:solid 1px #3bcefe; padding:10px; margin-left:400px;margin-right:400px; background-color:#0ac3c8;text-decoration:none;'>Click Here To Login </a></td></tr>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='padding-left:10px;'>";
        returnString = returnString + "<p style='color:lightgray;'> Warm Rewards </p>";
        returnString = returnString + "<p style='color:gray;'> Verification Team </p>";
        returnString = returnString + "<p style='color:gray;'> NPCVB SKILL DEVELOPMENT Pvt Ltd</p>";
        returnString = returnString + "<p style='color:gray'> P - 7017830092 | E - Info@npcvb.com </p>";
        returnString = returnString + "<hr/>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='text-align:center;'>";

        returnString = returnString + "<table align='center'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td>";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/ministryofCorporateAffairs.png' style='width:100px;'/>";
        returnString = returnString + "</td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/ministryofLabourEmployment.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MinistryOfSkillDevelopment.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MinistryOfYouthAffairsAndSports.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MHA.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/msme.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MEIT.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/DigitalIndia.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/Ayush.png' style='width:100px;'/></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + " </td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr style='color:white; background-color:#003a6a; '>";
        returnString = returnString + "<td colspan='3' style='text-align:center; padding:20px; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:12px;'>";
        returnString = returnString + "<p style='text-align:justify;'> Save Paper !Save Trees!Before printing, think about the environment.</p> ";
        returnString = returnString + "<p style='text-align:justify;'> The information in this e - mail and any attachments is confidential and may be legally privileged.It is intended solely for the addressee or addressees.If you are not an intended recipient, please delete the message and any attachments and notify the sender of misdelivery.Any use or disclosure of the contents of either is unauthorized and may be unlawful.All liability for viruses is excluded to the fullest extent permitted by law.Any views expressed in this message are those of the individual sender, except where the sender states them, with requisite authority, to be those of the specific NPCVB SKILL DEVELOPMENT Pvt Ltd. </p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='text-align:center; padding:10px; color:white; background-color:#003a6a;'>";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/facebooklogo.png' width='40px' height='40px' />";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/insta.png' width='40px' height='40px' />";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/twitter.png' width='40px' height='40px' />";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        return returnString;
    }

    protected void hlDeActivate_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();

        string qry = "select * from CenterRegistration where Id=@ID";
        List<SqlParameter> Param = new List<SqlParameter>();
        Param.Add(new SqlParameter("@ID", id));
        DataSet ds = DBT.P_returnDataSet(qry, Param);

        if (ds.Tables[0].Rows[0]["IsLogin"].ToString() == "0")
        {
            string vIsLogin = "1";
            string update = "update CenterRegistration set IsLogin=@IsLogin where id=@id";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@IsLogin", vIsLogin));
            Pram.Add(new SqlParameter("@id", id));
            DBT.P_ExecuteNonQuery(update, Pram);
            LoadGvCenter();
        }
        else if (ds.Tables[0].Rows[0]["IsLogin"].ToString() == "1")
        {
            string vIsLogin = "0";
            string update = "update CenterRegistration set IsLogin=@IsLogin where id=@id" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@IsLogin", vIsLogin));
            Pram.Add(new SqlParameter("@id", id));
            DBT.P_ExecuteNonQuery(update, Pram);
            LoadGvCenter();
        }
    }   
    static string vImage = "";    
    protected void gvCenter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField field = e.Row.FindControl("HFISActive") as HiddenField;
            Button btn = e.Row.FindControl("hlDeActivate") as Button;

            string Display = e.Row.Cells[3].Text.ToString();
            string Show = e.Row.Cells[5].Text.ToString();
           
            if (Display.CompareTo("0") == 0)
            {
                e.Row.Cells[3].Text = "Not Granted";

                CheckBox ch = (CheckBox)e.Row.FindControl("chkAdd");
                ch.Checked = false;

            }
            else
            {
                e.Row.Cells[3].Text = "Granted";
                CheckBox ch = (CheckBox)e.Row.FindControl("chkAdd");
                ch.Checked = true;

            }
            if(Show.CompareTo("0")==0)
            {
                e.Row.Cells[5].Text = "No";
                CheckBox chk = (CheckBox)e.Row.FindControl("chkShow");
                chk.Checked = false;
            }
            else
            {
                e.Row.Cells[5].Text = "Yes";
                CheckBox chk = (CheckBox)e.Row.FindControl("chkShow");
                chk.Checked = true;
            }
            if (field.Value == "1")
            {
                btn.Text = "Deactive";
                btn.CssClass = "btn btn-danger";

            }
            else
            {
                btn.Text = "Active";
                btn.CssClass = "btn btn-success";

            }
        }

    }

    protected void lbCertificate_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        Session["ID"] = id;
        Response.Redirect("Certificate.aspx");
        //string GetData = "select * from CenterRegistration where id=" + id;
        //DataSet ds = DBT.returnDataSet(GetData);
        //string CenterName = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        //string HeadName = ds.Tables[0].Rows[0]["PersonName"].ToString();
        //string Date2 = ds.Tables[0].Rows[0]["RenewalDate"].ToString();
        //string Date1 = ds.Tables[0].Rows[0]["VerifyDate"].ToString();
        //string centerID= ds.Tables[0].Rows[0]["CenterID"].ToString();
        //string ImageName = ds.Tables[0].Rows[0]["passportpic"].ToString();
        //try
        //{
        //    Response.ContentType = "application/pdf";

        //    Response.AddHeader("content-disposition", "attachment;filename=Certificate.pdf");

        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    string imageFilePath = Server.MapPath(".") + "/templateImage/usmanbhaicertificate.jpg";
        //    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
        //    // Page site and margin left, right, top, bottom is defined
        //    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
        //    pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
        //    //Resize image depend upon your need
        //    //For give the size to image
        //    jpg.ScaleToFit(842, 1000);
        //    //If you want to choose image as background then,
        //    jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
        //    //If you want to give absolute/specified fix position to image.
        //    jpg.SetAbsolutePosition(0, 3);

        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    pdfDoc.NewPage();

        //    Paragraph vCenterName = new Paragraph(CenterName);
        //    vCenterName.Font = FontFactory.GetFont("Arial Black", 16);
        //    vCenterName.IndentationLeft = 100;
        //    vCenterName.SpacingBefore = 179;

        //    Paragraph vStudentName = new Paragraph(HeadName);
        //    vStudentName.Font = FontFactory.GetFont("Arial Black", 16);
        //    vStudentName.IndentationLeft = 150;
        //    vStudentName.SpacingBefore = 20;
        //    // vStudentName.SpacingAfter = 25;
        //    Paragraph vDateFrom = new Paragraph(Date1 + "                                          " + Date2);
        //    vDateFrom.Font = FontFactory.GetFont("Arial Black", 16);
        //    vDateFrom.IndentationLeft = 200;
        //    vDateFrom.SpacingBefore = 14;

        //    Paragraph vCenterID = new Paragraph(centerID);
        //    vCenterID.Font = FontFactory.GetFont("Arial Black", 16);
        //    vCenterID.IndentationLeft = 250;


        //    string imageStuPath = Server.MapPath(ResolveUrl("~/Center-Document/" + ImageName));
        //    string imageSignPath = Server.MapPath(ResolveUrl("~/Image/signature.jpg"));
        //    iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);
        //    iTextSharp.text.Image signImage = iTextSharp.text.Image.GetInstance(imageSignPath);
        //    stuImage.ScaleToFit(100, 80);
        //    stuImage.SetAbsolutePosition(640, 345);
        //    signImage.ScaleToFit(80, 60);
        //    signImage.SetAbsolutePosition(620, 165);

        //    pdfDoc.Add(jpg);
        //    pdfDoc.Add(vCenterName);
        //    pdfDoc.Add(vStudentName);
        //    pdfDoc.Add(stuImage);
        //    pdfDoc.Add(vDateFrom);
        //    pdfDoc.Add(vCenterID);
        //    pdfDoc.Add(signImage);
        //    pdfDoc.Close();

        //    Response.Write(pdfDoc);

        //    Response.End();
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}

    }

    protected void lnkbtnCenterLogin_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;

        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
            Session["centerid"] = null;
            Session["centerid"] = id;
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../Center/Dashboard.aspx', '_blank');", true);      
    }

    protected void chkAdd_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update CenterRegistration Set IsActiveBackDate = 1 Where ID = @ID";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay,Pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterRegistration Set IsActiveBackDate = 0 Where ID = @ID";

            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, Pram);


        }
        LoadGvCenter();
    }

    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;

        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update CenterRegistration Set IsShowPerformer = 1 Where ID = @ID";

            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, Pram);


        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterRegistration Set IsShowPerformer = 0 Where ID = @ID";

            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay, Pram);


        }
        LoadGvCenter();
    }

    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBTrac DBT = new DBTrac();
        string id = gvCenter.DataKeys[e.RowIndex].Value.ToString();

        string DeleteCategory = "Delete From CenterRegistration Where ID = @ID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        string CenterID=DBT.P_returnOneValue( "select CenterID from CenterRegistration Where ID = @ID",Pram);
        string updateStudent = "update AddStudent set Cid=0,isDirect=1,IsRequest=0 where Cid=@ID";
        string DeleteWallet= "delete LatestAmtAdmCen where CenterID=@CenterID";
        List<SqlParameter> pp = new List<SqlParameter>();
        pp.Add(new SqlParameter("@CenterID", CenterID));
        DBT.P_ExecuteNonQuery(updateStudent,Pram);
        DBT.P_ExecuteNonQuery(DeleteWallet,pp);
        DBT.P_ExecuteNonQuery(DeleteCategory,Pram);
        LoadGvCenter();
    }
}