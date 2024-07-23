using System;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;
using System.Data;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Data.SqlClient;



public partial class SuperAdminBackend_Certificate :Page
{
    DBTrac DBT = new DBTrac();
    //Document document = new Document(iText.Kernel.Geom.PageSize.A4, 80, 50, 30, 65);

    //StringBuilder strData = new StringBuilder(string.Empty);
    //string strASPXpath = Server.MapPath("MyASPX.aspx");
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            LoadData();
        }
        
    }
    protected void LoadData()
    {
        string GetData = "select * from CenterRegistration where id=@id" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", Session["ID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(GetData, Pram);
        lblCenterName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCenterHeadName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
        lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        lblPin.Text=ds.Tables[0].Rows[0]["PinCode"].ToString();
        lblDate2.Text = ds.Tables[0].Rows[0]["RenewalDate"].ToString();
        lblDate1.Text = ds.Tables[0].Rows[0]["VerifyDate"].ToString();
        lblCenterID.Text = ds.Tables[0].Rows[0]["CenterID"].ToString();
        imgStudent.Text = ds.Tables[0].Rows[0]["passportpic"].ToString();
        lblNumber.Text= ds.Tables[0].Rows[0]["PhoneNumber"].ToString();


    }

    protected void saveBarCode(string fName,string Msg)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Msg, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        qrCodeImage.Save(Server.MapPath(ResolveUrl("~/Center-Document/" + fName)), System.Drawing.Imaging.ImageFormat.Png);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
       

        try
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=Certificate.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string imageFilePath = Server.MapPath(".") + "/templateImage/certi.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
            // Page site and margin left, right, top, bottom is defined
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            //Resize image depend upon your need
            //For give the size to image
            jpg.ScaleToFit(842, 1000);
            //If you want to choose image as background then,
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
            //If you want to give absolute/specified fix position to image.
            jpg.SetAbsolutePosition(0, 3);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.NewPage();

            Paragraph vCenterName = new Paragraph(lblCenterName.Text);
            vCenterName.Alignment = Element.ALIGN_CENTER;
            vCenterName.Font = FontFactory.GetFont("Arial", 16);
            vCenterName.IndentationLeft = -140;
            vCenterName.SpacingBefore = 178;

            //BaseFont bfTimes = BaseFont.CreateFont(System., BaseFont.CP1252, false);
            //iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 18, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.RED);
            iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 12, iTextSharp.text.BaseColor.BLACK);
            //iTextSharp.text.html.simpleparser.StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
            //styles.LoadTagStyle("lblCenterHeadName", "text-align", "center");
           
            Paragraph vNumber = new Paragraph(lblCenterHeadName.Text.ToUpper(), arial);
            vNumber.Alignment = Element.ALIGN_CENTER;
            //vNumber.Font = FontFactory.GetFont("Segoe UI", 18.0f, BaseColor.BLACK);
            vNumber.IndentationLeft = -105;
            vNumber.SpacingBefore = 6;
            

            iTextSharp.text.Font arial1 = FontFactory.GetFont("Arial", 10, iTextSharp.text.BaseColor.BLACK);
            
            Paragraph vStudentName = new Paragraph(lblAddress.Text+" ( "+lblPin.Text+" ) ", arial1);
            vStudentName.Alignment = Element.ALIGN_CENTER;
            vStudentName.IndentationLeft = -109;
            vStudentName.SpacingBefore = 6;
            // vStudentName.SpacingAfter = 25;

            Paragraph vDateFrom = new Paragraph("  "+lblDate1.Text + "                                       " + lblDate2.Text);
            vDateFrom.Font = FontFactory.GetFont("Arial", 16);
            vDateFrom.IndentationLeft = 190;
            vDateFrom.SpacingBefore = 12;

            Paragraph vCenterID = new Paragraph(lblCenterID.Text);
            vCenterID.Font = FontFactory.GetFont("Arial", 16);
            vCenterID.IndentationLeft = 250;
            vCenterID.SpacingBefore = 2;

            string imageStuPath = Server.MapPath(ResolveUrl("~/Center-Document/" + imgStudent.Text));
            string imageSignPath = Server.MapPath(ResolveUrl("~/Image/signatureCer.png"));
            iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);
            iTextSharp.text.Image signImage = iTextSharp.text.Image.GetInstance(imageSignPath);
            stuImage.ScaleToFit(100, 80);
            stuImage.SetAbsolutePosition(640, 345);
            stuImage.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
            stuImage.BorderColorBottom = BaseColor.BLACK;
            
            stuImage.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
            stuImage.BorderColorLeft = BaseColor.BLACK;
           
            stuImage.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
            stuImage.BorderColorRight = BaseColor.BLACK;
           
            stuImage.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            stuImage.BorderColorTop = BaseColor.BLACK;
            stuImage.BorderWidthBottom = 12;
            stuImage.BorderWidthLeft = 12;
            stuImage.BorderWidthRight = 12;
            stuImage.BorderWidthTop = 12;
            signImage.ScaleToFit(80, 60);
            signImage.SetAbsolutePosition(620, 165);

            saveBarCode(lblCenterName.Text +"-"+lblCenterID.Text+".png", "http://www.npcvb.com/ViewCenterDetail.aspx?CID="+ Session["ID"].ToString());
            string imageBarPath = Server.MapPath(ResolveUrl("~/Center-Document/" + lblCenterName.Text + "-" + lblCenterID.Text + ".png"));
            iTextSharp.text.Image barImage = iTextSharp.text.Image.GetInstance(imageBarPath);
            barImage.ScaleToFit(80, 60);
            barImage.SetAbsolutePosition(650, 280);

            pdfDoc.Add(jpg);
            pdfDoc.Add(vCenterName);
            pdfDoc.Add(vNumber);
            pdfDoc.Add(vStudentName);
            pdfDoc.Add(stuImage);
            pdfDoc.Add(vDateFrom);
            pdfDoc.Add(vCenterID);
            pdfDoc.Add(signImage);
            pdfDoc.Add(barImage);
            pdfDoc.Close();

            Response.Write(pdfDoc);

            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }
}