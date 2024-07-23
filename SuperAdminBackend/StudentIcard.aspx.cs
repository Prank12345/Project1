using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class SuperAdminBackend_StudentIcard : System.Web.UI.Page
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
        string stGetData = "select * from AddStudent where StudentID=@StudentID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@StudentID", Session["StudentID"]));
        //string id = Session["ID"].ToString();
        DataSet ds = DBT.P_returnDataSet(stGetData,pram);
        lblStudentID.Text = Session["StudentID"].ToString();
        lblStudentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
       
        lblDate1.Text = ds.Tables[0].Rows[0]["SessionFrom"].ToString();
        lblDate2.Text = ds.Tables[0].Rows[0]["SessionTo"].ToString();
        string vCourseID = ds.Tables[0].Rows[0]["Course"].ToString();
        string strGetDataCourse = "select ShortName from Courses where Id=@ID" ;
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ID", vCourseID));
        string vCourseName = DBT.P_returnOneValue(strGetDataCourse,Pr);

        lblCourse.Text = vCourseName;
        imgStudentImg.Text = ds.Tables[0].Rows[0]["StudentImage"].ToString();
        string vCID = ds.Tables[0].Rows[0]["CID"].ToString();
        string strGetDataCenter = "select * from CenterRegistration where Id=@ID";
        List<SqlParameter> sqp = new List<SqlParameter>();
        sqp.Add(new SqlParameter("@ID", vCID));
        DataSet dsCenter = DBT.P_returnDataSet(strGetDataCenter,sqp);
        lblCenterAddress.Text = dsCenter.Tables[0].Rows[0]["Address"].ToString();
        lblCenterName.Text = dsCenter.Tables[0].Rows[0]["InstituteName"].ToString();
    }

    protected void saveBarCode(string fName, string Msg)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Msg, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        qrCodeImage.Save(Server.MapPath(ResolveUrl("~/StudentBarcode/" + fName)), System.Drawing.Imaging.ImageFormat.Png);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=Icard" + lblStudentID.Text + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string imageFilePath = Server.MapPath(".") + "/templateImage/4.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
            // Page site and margin left, right, top, bottom is defined
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
           // pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            //Resize image depend upon your need
            //For give the size to image
            jpg.ScaleToFit(300, 400);
            //If you want to choose image as background then,
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
            //If you want to give absolute/specified fix position to image.
            jpg.SetAbsolutePosition(150, 500);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("pdfs/Icard" + lblStudentID.Text + ".pdf"), FileMode.Create));
            pdfDoc.Open();
            pdfDoc.NewPage();

            string vCertificatename = "Icard" + lblStudentID.Text + ".pdf";

            string updatestudent = "update AddStudent set ICard=@ICard where StudentID=@StudentID";
            List<SqlParameter> sqp = new List<SqlParameter>();
            sqp.Add(new SqlParameter("@ICard", vCertificatename));
            sqp.Add(new SqlParameter("@StudentID", Session["StudentID"].ToString()));
            DBT.P_ExecuteNonQuery(updatestudent, sqp);

            Paragraph vstudentName = new Paragraph(lblStudentName.Text.ToUpper());
            vstudentName.Alignment = Element.ALIGN_LEFT;
            vstudentName.Font.Size = 8;
            // vstudentName.Font = FontFactory.GetFont("Arial", 8);
            vstudentName.IndentationLeft = 276;
            vstudentName.SpacingBefore = 178;

            Paragraph vStudentID = new Paragraph(lblStudentID.Text);
            vStudentID.Alignment = Element.ALIGN_LEFT;
            vStudentID.Font.Size = 8;
            // vstudentName.Font = FontFactory.GetFont("Arial", 8);
            vStudentID.IndentationLeft = 280;
            vStudentID.SpacingBefore = 8;

            //iTextSharp.text.Font arial1 = FontFactory.GetFont("Arial", 10, iTextSharp.text.BaseColor.BLACK);

            Paragraph vDateFrom = new Paragraph(lblDate1.Text + " TO " + lblDate2.Text);
            vDateFrom.Alignment = Element.ALIGN_LEFT;
            vDateFrom.Font.Size = 8;
            //vDateFrom.Font = FontFactory.GetFont("Arial", 16);
            vDateFrom.IndentationLeft = 251;
            vDateFrom.SpacingBefore = 8;

            Paragraph vCourse = new Paragraph(lblCourse.Text);
            vCourse.Alignment = Element.ALIGN_LEFT;
            vCourse.Font.Size = 10;
            //vNumber.Font = FontFactory.GetFont("Segoe UI", 18.0f, BaseColor.BLACK);
            vCourse.IndentationLeft = 248;
            vCourse.SpacingBefore = 6;
            vCourse.IndentationRight = 165;

            Paragraph vCenterName = new Paragraph("   "+lblCenterName.Text+", "+lblCenterAddress.Text);
            vCenterName.Alignment = Element.ALIGN_LEFT;
            vCenterName.Font.Size = 8;
            vCenterName.IndentationLeft = 190;
            vCenterName.SpacingBefore = 22;
            vCenterName.IndentationRight = 105;
            
            

            string imageStuPath = Server.MapPath(ResolveUrl("~/Student-Image/" + imgStudentImg.Text));          
            iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);          
            stuImage.ScaleToFit(62, 145);
            stuImage.SetAbsolutePosition(171, 557);
            stuImage.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
            stuImage.BorderColorBottom = BaseColor.BLACK;

            stuImage.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
            stuImage.BorderColorLeft = BaseColor.BLACK;

            stuImage.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
            stuImage.BorderColorRight = BaseColor.BLACK;

            stuImage.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            stuImage.BorderColorTop = BaseColor.BLACK;
            stuImage.BorderWidthBottom =3;
            stuImage.BorderWidthLeft = 3;
            stuImage.BorderWidthRight = 3;
            stuImage.BorderWidthTop = 3;
            
            saveBarCode(lblStudentName.Text + "_" + Session["StudentID"].ToString() + ".png", "http://www.npcvb.com/ViewStudentDetails.aspx?SID=" + Session["StudentID"].ToString());
            string imageBarPath = Server.MapPath(ResolveUrl("~/StudentBarcode/"+ lblStudentName.Text+ "_" + Session["StudentID"].ToString() + ".png"));
            iTextSharp.text.Image barImage = iTextSharp.text.Image.GetInstance(imageBarPath);
            barImage.ScaleToFit(60, 40);
            barImage.SetAbsolutePosition(400,570);

            pdfDoc.Add(jpg);
            pdfDoc.Add(stuImage);
            pdfDoc.Add(vstudentName);
            pdfDoc.Add(vStudentID);
            pdfDoc.Add(vDateFrom);
            pdfDoc.Add(vCourse);
            pdfDoc.Add(vCenterName);            
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