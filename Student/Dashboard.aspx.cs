using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Dashboard : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
            LoadDatapdf();
        }
    }
    protected void LoadData()
    {
        if (Session["SID"] != null)
        {
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ID", Session["SID"].ToString()));
            string strGetCenter = DBT.P_returnOneValue("select StudentID from AddStudent where ID=@ID",pram);
           
            string GetCourseID = DBT.P_returnOneValue("select Course from AddStudent where id=@ID", pram);
            List<SqlParameter> prm = new List<SqlParameter>();
            prm.Add(new SqlParameter("@CourseID", GetCourseID));
            string str = "select count(ID) from ExamList where ExamType='Test'and CourseID=@CourseID";
            string countTest = DBT.P_returnOneValue(str,prm);
            lblTest.Text = countTest;

            //string course = "select count(ID) from Courses";
            //string countcourse = DBT.returnOneValue(course);
            //lblcourse.Text = countcourse;
            
            string Notification = "select count(ID) from NotificationLog where isRead=@isRead and CenterID=@CenterID";
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@isRead", "0"));
            Param.Add(new SqlParameter("@CenterID", strGetCenter));
            string countNotif = DBT.P_returnOneValue(Notification,Param);
            lblNotif.Text = countNotif;
        }
        else
        {
            Response.Redirect("~/StudentLogin.aspx");
        }
    }
    protected void LoadDatapdf()
    {
        string stGetData = "select * from AddStudent where ID=@ID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@ID", Session["SID"].ToString()));
        //string id = Session["ID"].ToString();
        DataSet ds = DBT.P_returnDataSet(stGetData,pram);
        hfStudentID.Value = ds.Tables[0].Rows[0]["StudentID"].ToString();
        lblStudentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();

        hfDate1.Value = ds.Tables[0].Rows[0]["SessionFrom"].ToString();
        hfDate2.Value = ds.Tables[0].Rows[0]["SessionTo"].ToString();
        string vCourseID = ds.Tables[0].Rows[0]["Course"].ToString();

        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@ID", vCourseID));
        string strGetDataCourse = "select ShortName from Courses where Id=@ID";
        string vCourseName = DBT.P_returnOneValue(strGetDataCourse,prm);

        hfCourse.Value = vCourseName;
        hfImageName.Value = ds.Tables[0].Rows[0]["StudentImage"].ToString();
        string vCID = ds.Tables[0].Rows[0]["CID"].ToString();

        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@ID", vCID));
        string strGetDataCenter = "select * from CenterRegistration where Id=@ID" ;
        DataSet dsCenter = DBT.P_returnDataSet(strGetDataCenter,param);
        hfCenterAddr.Value = dsCenter.Tables[0].Rows[0]["Address"].ToString();
        hfCenterName.Value= dsCenter.Tables[0].Rows[0]["InstituteName"].ToString();
    }
    protected void saveBarCode(string fName, string Msg)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Msg, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(20);
        qrCodeImage.Save(Server.MapPath(ResolveUrl("~/StudentBarcode/" + fName)), System.Drawing.Imaging.ImageFormat.Png);
    }
    protected void lnkbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=ICard.pdf");

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
            pdfDoc.Open();
            pdfDoc.NewPage();

            Paragraph vstudentName = new Paragraph(lblStudentName.Text.ToUpper());
            vstudentName.Alignment = Element.ALIGN_LEFT;
            vstudentName.Font.Size = 8;
            // vstudentName.Font = FontFactory.GetFont("Arial", 8);
            vstudentName.IndentationLeft = 276;
            vstudentName.SpacingBefore = 178;

            Paragraph vStudentID = new Paragraph(hfStudentID.Value);
            vStudentID.Alignment = Element.ALIGN_LEFT;
            vStudentID.Font.Size = 8;
            // vstudentName.Font = FontFactory.GetFont("Arial", 8);
            vStudentID.IndentationLeft = 280;
            vStudentID.SpacingBefore = 8;

            //iTextSharp.text.Font arial1 = FontFactory.GetFont("Arial", 10, iTextSharp.text.BaseColor.BLACK);

            Paragraph vDateFrom = new Paragraph(hfDate1.Value + " TO " + hfDate2.Value);
            vDateFrom.Alignment = Element.ALIGN_LEFT;
            vDateFrom.Font.Size = 8;
            //vDateFrom.Font = FontFactory.GetFont("Arial", 16);
            vDateFrom.IndentationLeft = 251;
            vDateFrom.SpacingBefore = 8;

            Paragraph vCourse = new Paragraph(hfCourse.Value);
            vCourse.Alignment = Element.ALIGN_LEFT;
            vCourse.Font.Size = 10;
            //vNumber.Font = FontFactory.GetFont("Segoe UI", 18.0f, BaseColor.BLACK);
            vCourse.IndentationLeft = 248;
            vCourse.SpacingBefore = 6;
            vCourse.IndentationRight = 165;

            Paragraph vCenterName = new Paragraph("   " + hfCenterName.Value + ", " + hfCenterAddr.Value);
            vCenterName.Alignment = Element.ALIGN_LEFT;
            vCenterName.Font.Size = 8;
            vCenterName.IndentationLeft = 190;
            vCenterName.SpacingBefore = 22;
            vCenterName.IndentationRight = 105;



            string imageStuPath = Server.MapPath(ResolveUrl("~/Student-Image/" + hfImageName.Value));
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
            stuImage.BorderWidthBottom = 3;
            stuImage.BorderWidthLeft = 3;
            stuImage.BorderWidthRight = 3;
            stuImage.BorderWidthTop = 3;

            saveBarCode(lblStudentName.Text + "_" + hfStudentID.Value + ".png", "http://www.npcvb.com/ViewStudentDetails.aspx?SID=" + hfStudentID.Value);
            string imageBarPath = Server.MapPath(ResolveUrl("~/StudentBarcode/" + lblStudentName.Text + "_" + hfStudentID.Value + ".png"));
            iTextSharp.text.Image barImage = iTextSharp.text.Image.GetInstance(imageBarPath);
            barImage.ScaleToFit(60, 40);
            barImage.SetAbsolutePosition(400, 570);

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