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


public partial class SuperAdminBackend_DistributorCertificate : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    //Document document = new Document(iText.Kernel.Geom.PageSize.A4, 80, 50, 30, 65);

    //StringBuilder strData = new StringBuilder(string.Empty);
    //string strASPXpath = Server.MapPath("MyASPX.aspx");
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadData();
        }

    }
    protected void LoadData()
    {
        string GetData = "select * from Distributors where id=@id";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", Session["ID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(GetData, Pram);
        lblCenterName.Text = " ";
        lblCenterHeadName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
        lblAddress.Text = ds.Tables[0].Rows[0]["FullAddress"].ToString();
        lblPin.Text = "";
        lblDate1.Text = ds.Tables[0].Rows[0]["JoinDate"].ToString();
        lblDate2.Text = ds.Tables[0].Rows[0]["ValidDate"].ToString();
        if(ds.Tables[0].Rows[0]["JoinDate"].ToString() == " ")
        {
            lblDate1.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["ValidDate"].ToString() == " ")
        {
            lblDate2.Text = " ";
        }
        lblCenterID.Text = ds.Tables[0].Rows[0]["DistributorID"].ToString();
        imgStudent.Text = ds.Tables[0].Rows[0]["PassportImage"].ToString();
        lblNumber.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
    }

    protected void saveBarCode(string fName, string Msg)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Msg, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        qrCodeImage.Save(Server.MapPath(ResolveUrl("~/Distributor-Docs/" + fName)), System.Drawing.Imaging.ImageFormat.Png);
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

            Paragraph vCenterName = new Paragraph("Distributor");
            vCenterName.Alignment = Element.ALIGN_CENTER;
            vCenterName.Font.Size = 20;
            vCenterName.SpacingBefore = 173;
            vCenterName.IndentationLeft = -100;
            iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 12, iTextSharp.text.BaseColor.BLACK);

            Paragraph vNumber = new Paragraph(lblCenterHeadName.Text.ToUpper(), arial);
            vNumber.Alignment = Element.ALIGN_LEFT;
            vNumber.Font.Size = 12;        
            vNumber.IndentationLeft = 185;
            vNumber.SpacingBefore = 7;
            iTextSharp.text.Font arial1 = FontFactory.GetFont("Arial", 10, iTextSharp.text.BaseColor.BLACK);

            Paragraph vStudentName = new Paragraph(lblAddress.Text , arial1);
            vStudentName.Alignment = Element.ALIGN_CENTER;
            vStudentName.IndentationLeft = -109;
            vStudentName.SpacingBefore = 4;
        
            Paragraph vDateFrom = new Paragraph("  " + lblDate1.Text + "                                    " + lblDate2.Text);
            vDateFrom.Font = FontFactory.GetFont("Arial", 16);
            vDateFrom.IndentationLeft = 190;
            vDateFrom.SpacingBefore = 12;

            Paragraph vCenterID = new Paragraph(lblCenterID.Text);
            vCenterID.Font = FontFactory.GetFont("Arial", 16);
            vCenterID.IndentationLeft = 250;
            vCenterID.SpacingBefore = 2;

            string imageStuPath = Server.MapPath(ResolveUrl("~/Distributor-Docs/" + imgStudent.Text));
            string imageSignPath = Server.MapPath(ResolveUrl("~/Image/signatureCer.png"));
            iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);
            iTextSharp.text.Image signImage = iTextSharp.text.Image.GetInstance(imageSignPath);
            stuImage.ScaleToFit(100, 80);
            stuImage.SetAbsolutePosition(650, 345);
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

            saveBarCode(lblCenterName.Text + "-" + lblCenterID.Text + ".png", "http://www.npcvb.com/DistributorDeatils.aspx.aspx?DID=" + Session["ID"].ToString());
            string imageBarPath = Server.MapPath(ResolveUrl("~/Distributor-Docs/" + lblCenterName.Text + "-" + lblCenterID.Text + ".png"));
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