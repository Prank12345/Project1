using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Data.SqlClient;

public partial class Center_StudentForm : System.Web.UI.Page
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
        string strGetData = "select * from AddStudent where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["ID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        lblStudentID.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
        lblStudentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        lblFname.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
        lblMName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
        lblDate1.Text = ds.Tables[0].Rows[0]["SessionFrom"].ToString();
        lblDate2.Text = ds.Tables[0].Rows[0]["SessionTo"].ToString();
        lblMEdium.Text = ds.Tables[0].Rows[0]["LangMed"].ToString();
        lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
        lblGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
        lblAadhar.Text = ds.Tables[0].Rows[0]["IDNumber"].ToString();
        lblMobile.Text = ds.Tables[0].Rows[0]["StudentPhone"].ToString();
        lblCaste.Text = ds.Tables[0].Rows[0]["CasteCategory"].ToString();
        //lblCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
        lblEmail.Text = ds.Tables[0].Rows[0]["StudentEmail"].ToString();
        lblFJob.Text = ds.Tables[0].Rows[0]["FatherOccupation"].ToString();

        lblOM10.Text = ds.Tables[0].Rows[0]["Marks10"].ToString();
        lblOM12.Text = ds.Tables[0].Rows[0]["Marks12"].ToString();
        lblOMGrads.Text = ds.Tables[0].Rows[0]["MarksGrad"].ToString();
        lblOth.Text = ds.Tables[0].Rows[0]["MarksPG"].ToString();
        if(ds.Tables[0].Rows[0]["Marks10"].ToString() == "")
        {
            lblOM10.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["Marks12"].ToString() == "")
        {
            lblOM12.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["MarksGrad"].ToString() == "")
        {
            lblOMGrads.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["MarksPG"].ToString() == "")
        {
            lblOth.Text = " ";
        }

        lblGr10.Text = ds.Tables[0].Rows[0]["Percent10"].ToString();
        lblGr12.Text = ds.Tables[0].Rows[0]["Percent12"].ToString();
        lblGrGrads.Text = ds.Tables[0].Rows[0]["PercentGrad"].ToString();
        lblGroth.Text = ds.Tables[0].Rows[0]["PercentPG"].ToString();

        if (ds.Tables[0].Rows[0]["Percent10"].ToString() == "")
        {
            lblGr10.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["Percent12"].ToString() == "")
        {
            lblGr12.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["PercentGrad"].ToString() == "")
        {
            lblGrGrads.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["PercentPG"].ToString() == "")
        {
            lblGroth.Text = " ";
        }

        lblPass10.Text = ds.Tables[0].Rows[0]["Pass10"].ToString();
        lblPass12.Text = ds.Tables[0].Rows[0]["Pass12"].ToString();
        lblPassGrads.Text = ds.Tables[0].Rows[0]["PassGrad"].ToString();
        lblPassOth.Text = ds.Tables[0].Rows[0]["PassPG"].ToString();

        if (ds.Tables[0].Rows[0]["Pass10"].ToString() == "")
        {
            lblPass10.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["Pass12"].ToString() == "")
        {
            lblPass12.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["PassGrad"].ToString() == "")
        {
            lblPassGrads.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["PassPG"].ToString() == "")
        {
            lblPassOth.Text = " ";
        }

        lblBoard10.Text = ds.Tables[0].Rows[0]["Board10"].ToString();
        lblBoard12.Text = ds.Tables[0].Rows[0]["Board12"].ToString();
        lblBoard1Grads.Text = ds.Tables[0].Rows[0]["BoardGrad"].ToString();
        lblBoardOth.Text = ds.Tables[0].Rows[0]["BoardPG"].ToString();

        if (ds.Tables[0].Rows[0]["Board10"].ToString() == "")
        {
            lblBoard10.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["Board12"].ToString() == "")
        {
            lblBoard12.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["BoardGrad"].ToString() == "")
        {
            lblBoard1Grads.Text = " ";
        }
        if (ds.Tables[0].Rows[0]["BoardPG"].ToString() == "")
        {
            lblBoardOth.Text = " ";
        }

        if (ds.Tables[0].Rows[0]["FatherHusbandName"].ToString()=="")
        {
            lblFname.Text = " ";
        }
        if(ds.Tables[0].Rows[0]["FatherOccupation"].ToString()=="")
        {
            lblFJob.Text = " ";
        }
        if(ds.Tables[0].Rows[0]["Category"].ToString()== "--Select--")
        {
            lblCategoryBPL.Text = " ";
            lblCategoryPH.Text = " ";
        }
        else if(ds.Tables[0].Rows[0]["Category"].ToString() == "BPL")
        {
            lblCategoryBPL.Text = ds.Tables[0].Rows[0]["Category"].ToString(); 
            lblCategoryPH.Text = " ";
        }
        else
        {
            lblCategoryBPL.Text = " ";
            lblCategoryPH.Text = ds.Tables[0].Rows[0]["Category"].ToString();
        }
        
        string vCourseID = ds.Tables[0].Rows[0]["Course"].ToString();
        string strGetDataCourse = "select * from Courses where Id=@ID";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ID", vCourseID));
        DataSet dsCourse = DBT.P_returnDataSet(strGetDataCourse, Pr);

        lblCourse.Text = dsCourse.Tables[0].Rows[0]["FullCourseName"].ToString();
        lblCode.Text= dsCourse.Tables[0].Rows[0]["CourseCode"].ToString();

        string[] splitDuration = dsCourse.Tables[0].Rows[0]["Duration"].ToString().Split('-');

        lblDuration.Text = splitDuration[0];
        lblTime.Text = splitDuration[1];
        string CTID = dsCourse.Tables[0].Rows[0]["CTID"].ToString();
        List<SqlParameter> prne = new List<SqlParameter>();
        prne.Add(new SqlParameter("@ID", CTID));
        string StrGetcourseType =DBT.P_returnOneValue("select CourseType from CourseType where ID=@ID", prne);
        lblCourseType.Text = StrGetcourseType;
        imgStudentImg.Text = ds.Tables[0].Rows[0]["StudentImage"].ToString();
        string vCID = ds.Tables[0].Rows[0]["CID"].ToString();
        string strGetDataCenter = "select * from CenterRegistration where Id=@ID";
        List<SqlParameter> sqp = new List<SqlParameter>();
        sqp.Add(new SqlParameter("@ID", vCID));
        DataSet dsCenter = DBT.P_returnDataSet(strGetDataCenter, sqp);
       
        lblCenterName.Text = dsCenter.Tables[0].Rows[0]["InstituteName"].ToString();
        lblSign.Text = dsCenter.Tables[0].Rows[0]["Signature"].ToString();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=StudentForm" + lblStudentID.Text + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string imageFilePath = Server.MapPath(".") + "/templateImage/StudentForm.jpeg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);

            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();

            pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());       
            jpg.ScaleToFit(1000, 590);       
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;           
            jpg.SetAbsolutePosition(200, 0);           
           
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
           
            pdfDoc.Open();
            pdfDoc.NewPage();            

            Paragraph vDateFrom = new Paragraph(lblDate1.Text +" To " + lblDate2.Text);
            vDateFrom.Alignment = Element.ALIGN_LEFT;
            vDateFrom.Font.Size = 9;
            vDateFrom.IndentationLeft =277;
            vDateFrom.SpacingBefore =78;

            Paragraph vApplicationDate = new Paragraph(lblDate1.Text);
            vApplicationDate.Alignment = Element.ALIGN_LEFT;
            vApplicationDate.Font.Size = 9;
            vApplicationDate.IndentationLeft = 277;
            vApplicationDate.SpacingBefore = 18;

            Paragraph vCOurseType = new Paragraph( lblCourseType.Text);
            vCOurseType.Alignment = Element.ALIGN_LEFT;
            vCOurseType.Font.Size = 8;
            vCOurseType.SpacingBefore = 5;
            vCOurseType.IndentationLeft = 277;

            Paragraph vCourse = new Paragraph(lblCourse.Text);
            vCourse.Alignment = Element.ALIGN_LEFT;
            vCourse.Font.Size = 8;
            vCourse.IndentationLeft = 277;
            vCourse.SpacingBefore = 3;

            Paragraph vCode = new Paragraph(lblCode.Text);
            vCode.Alignment = Element.ALIGN_LEFT;
            vCode.Font.Size = 9;            
            vCode.SpacingBefore = 3;
            vCode.IndentationLeft = 277;

            Paragraph vDuration = new Paragraph( lblDuration.Text);
            vDuration.Alignment = Element.ALIGN_LEFT;
            vDuration.Font.Size = 9;
            vDuration.SpacingBefore = 5;

            if(lblTime.Text== "Months")
            {
                vDuration.IndentationLeft = 340;
            }
            else
            {
                vDuration.IndentationLeft = 277;
            }

            Paragraph vMedium = new Paragraph( lblMEdium.Text);
            vMedium.Alignment = Element.ALIGN_LEFT;
            vMedium.Font.Size = 9;
            vMedium.SpacingBefore = -15;
            vMedium.IndentationLeft = 430;

            Paragraph VCenterName = new Paragraph(lblCenterName.Text);
            VCenterName.Alignment = Element.ALIGN_LEFT;
            VCenterName.Font.Size = 9;
            VCenterName.SpacingBefore = 4;
            VCenterName.IndentationLeft = 277;

            Paragraph vstudentName = new Paragraph(lblStudentName.Text);
            vstudentName.Alignment = Element.ALIGN_LEFT;
            vstudentName.Font.Size = 9;
            vstudentName.SpacingBefore = 14;
            vstudentName.IndentationLeft = 277;

            Paragraph vFatherName = new Paragraph(lblFname.Text);
            vFatherName.Alignment = Element.ALIGN_LEFT;
            vFatherName.Font.Size = 9;          
            vFatherName.SpacingBefore = 5;
            vFatherName.IndentationLeft = 277;

            Paragraph vMotherName = new Paragraph(lblMName.Text);
            vMotherName.Alignment = Element.ALIGN_LEFT;
            vMotherName.Font.Size = 9;          
            vMotherName.SpacingBefore = 3;
            vMotherName.IndentationLeft = 277;

            Paragraph vDOB = new Paragraph(lblDOB.Text);
            vDOB.Alignment = Element.ALIGN_LEFT;
            vDOB.Font.Size = 9;           
            vDOB.SpacingBefore = 3;
            vDOB.IndentationLeft = 277;

            Paragraph vPhone = new Paragraph(lblMobile.Text);
            vPhone.Alignment = Element.ALIGN_LEFT;
            vPhone.Font.Size = 9;            
            vPhone.SpacingBefore = 3;
            vPhone.IndentationLeft = 277;
            if(lblGender.Text== "Male")
            {
                lblGender.Text = "M";
            }
            else if(lblGender.Text== "Female")
            {
                lblGender.Text = "F";
            }
            else if (lblGender.Text == "Others")
            {
                lblGender.Text = "Y";
            }
            else
            {
                lblGender.Text = " ";
            }
            Paragraph vGender = new Paragraph(lblGender.Text);
            vGender.Alignment = Element.ALIGN_LEFT;
            vGender.Font.Size = 9;

            if (lblGender.Text == "M")
            {
                vGender.IndentationLeft = 470;
            }
            else if (lblGender.Text == "F")
            {
                vGender.IndentationLeft = 510;
            }
            else
            {
                vGender.IndentationLeft = 550;
            }

            
            vGender.SpacingBefore = -14;

            Paragraph vFatherOcc = new Paragraph(lblFJob.Text);
            vFatherOcc.Alignment = Element.ALIGN_LEFT;
            vFatherOcc.Font.Size = 9;           
            vFatherOcc.SpacingBefore =4;
            vFatherOcc.IndentationLeft = 277;

            Paragraph vEmail = new Paragraph(lblEmail.Text);
            vEmail.Alignment = Element.ALIGN_LEFT;
            vEmail.Font.Size = 9;
             vEmail.IndentationLeft = 445;
            vEmail.SpacingBefore = -14;

            Paragraph vCaste = new Paragraph(lblCaste.Text);
            vCaste.Alignment = Element.ALIGN_LEFT;
            vCaste.Font.Size = 9;            
            vCaste.SpacingBefore = 2;
            vCaste.IndentationLeft = 275;
           
            Paragraph vCategory = new Paragraph(lblCategoryBPL.Text);
            vCategory.Alignment = Element.ALIGN_LEFT;
            vCategory.Font.Size = 9;
            vCategory.IndentationLeft = 510;

            vCategory.SpacingBefore = -13;

            Paragraph vAdhar = new Paragraph(lblAadhar.Text);
            vAdhar.Alignment = Element.ALIGN_LEFT;
            vAdhar.Font.Size = 9;
            vAdhar.SpacingBefore = 2;
            vAdhar.IndentationLeft = 275;

            Paragraph vCategoryPH = new Paragraph(lblCategoryPH.Text);
            vCategoryPH.Alignment = Element.ALIGN_LEFT;
            vCategoryPH.Font.Size = 9;
            vCategoryPH.IndentationLeft = 510;
            vCategoryPH.SpacingBefore = -13;

            Paragraph vAddressName = new Paragraph(lblAddress.Text);
            vAddressName.Alignment = Element.ALIGN_LEFT;
            vAddressName.Font.Size = 9;
            
            vAddressName.IndentationLeft = 275;
            vAddressName.IndentationRight = 350;

            Paragraph vNAtionality = new Paragraph("Indian");
            vNAtionality.Alignment = Element.ALIGN_LEFT;
            vNAtionality.Font.Size = 9;
            
            vNAtionality.IndentationLeft = 510;

                     
             
            Paragraph vMarks10 = new Paragraph(lblOM10.Text + "                " + lblGr10.Text + "               " + lblPass10.Text + "                 " + lblBoard10.Text);
            vMarks10.Alignment = Element.ALIGN_LEFT;
            vMarks10.Font.Size = 6;
           
            vMarks10.IndentationLeft = 340;
            
            Paragraph vMarks12 = new Paragraph(lblOM12.Text + "                " + lblGr12.Text + "               " + lblPass12.Text + "                 " + lblBoard12.Text);
            vMarks12.Alignment = Element.ALIGN_LEFT;
            vMarks12.Font.Size = 6;
           
            vMarks12.IndentationLeft = 340;
            
              
            Paragraph vMarksGrads = new Paragraph(lblOMGrads.Text + "                " + lblGrGrads.Text + "               " + lblPassGrads.Text + "                 " + lblBoard1Grads.Text);
            vMarksGrads.Alignment = Element.ALIGN_LEFT;
            vMarksGrads.Font.Size = 6;
           
            vMarksGrads.IndentationLeft =340;

            

            Paragraph vgrOth = new Paragraph(lblOth.Text + "                " + lblGroth.Text + "               " + lblPassOth.Text + "                 " + lblBoardOth.Text);
            vgrOth.Alignment = Element.ALIGN_LEFT;   
            vgrOth.Font.Size = 6;
           
            vgrOth.IndentationLeft = 340;            

            Paragraph vDate = new Paragraph(lblDate1.Text);
            vDate.Alignment = Element.ALIGN_LEFT;
            vDate.Font.Size = 8;
            vDate.IndentationLeft = 220;
            

            if (lblAddress.Text.Length >= 31)
            {
                vAddressName.SpacingBefore = -1;
                vNAtionality.SpacingBefore = -18;
                vMarks10.SpacingBefore = 55;
                vMarks12.SpacingBefore = 2;
                vMarksGrads.SpacingBefore = 5;
                vgrOth.SpacingBefore = 2;
                vDate.SpacingBefore = 40;
            }
            else
            {
                vAddressName.SpacingBefore = 1;
                vNAtionality.SpacingBefore = -10;
                vMarks10.SpacingBefore = 58;
                vMarks12.SpacingBefore = 2;
                vMarksGrads.SpacingBefore = 5;
                vgrOth.SpacingBefore = 2;
                vDate.SpacingBefore = 40;
            }

            string imageStuPath = Server.MapPath(ResolveUrl("~/Student-Image/" + imgStudentImg.Text));
            iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);
            stuImage.ScaleToFit(65, 174);
            stuImage.SetAbsolutePosition(542, 420);
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

            string imageAuthSign = Server.MapPath(ResolveUrl("~/Center-Document/" + lblSign.Text));
            iTextSharp.text.Image imgSign = iTextSharp.text.Image.GetInstance(imageAuthSign);
            imgSign.ScaleToFit(45, 74);
            imgSign.SetAbsolutePosition(530, 20);

            pdfDoc.Add(jpg);            
            pdfDoc.Add(vDateFrom);
            pdfDoc.Add(vApplicationDate);
            pdfDoc.Add(vCOurseType);
            pdfDoc.Add(stuImage);
            pdfDoc.Add(vCourse);
            pdfDoc.Add(vCode);
            pdfDoc.Add(vDuration);
            pdfDoc.Add(vMedium);
            pdfDoc.Add(VCenterName);
            pdfDoc.Add(vstudentName);
            pdfDoc.Add(vFatherName);
            pdfDoc.Add(vMotherName);
            pdfDoc.Add(vDOB);
            pdfDoc.Add(vPhone);
            pdfDoc.Add(vGender);
            pdfDoc.Add(vFatherOcc);
            pdfDoc.Add(vEmail);
            pdfDoc.Add(vCaste);
            pdfDoc.Add(vCategory);
            pdfDoc.Add(vAdhar);
            
            pdfDoc.Add(vCategoryPH);
            pdfDoc.Add(vAddressName);
            pdfDoc.Add(vNAtionality);

            pdfDoc.Add(vMarks10);
            pdfDoc.Add(vMarks12);
            pdfDoc.Add(vMarksGrads);
            pdfDoc.Add(vgrOth);
            pdfDoc.Add(vDate);
            pdfDoc.Add(imgSign);
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