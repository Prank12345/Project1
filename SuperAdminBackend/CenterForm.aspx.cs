using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Data.SqlClient;

public partial class SuperAdminBackend_CenterForm : System.Web.UI.Page
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
        string strGetData = "select * from CenterRegistration where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["ID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);

        lblCenterID.Text = ds.Tables[0].Rows[0]["CenterID"].ToString();
        lblCenterName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCenterHeadName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
        lblCenterHeadPhoto.Text = ds.Tables[0].Rows[0]["passportpic"].ToString();
        lblSign.Text = ds.Tables[0].Rows[0]["Signature"].ToString();
        
        lblAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        lblState.Text = ds.Tables[0].Rows[0]["State"].ToString();
        lblPinCode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();        
        lblNumber.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
        lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
        lblStaff.Text = ds.Tables[0].Rows[0]["Staffs"].ToString();
        lblComp.Text = ds.Tables[0].Rows[0]["TotalPC"].ToString();

        lblDate.Text = ds.Tables[0].Rows[0]["RegisDate"].ToString();
        //lblSign.Text = ds.Tables[0].Rows[0]["Signature"].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=CenterForm" + lblCenterID.Text + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            pdfDoc.NewPage();

            Paragraph vMainName = new Paragraph("National Paramedical Council And Vocational Board Skill Development");
            vMainName.Alignment = Element.ALIGN_LEFT;
            vMainName.Font.Size = 15;
            vMainName.Font.SetStyle(Font.BOLD);
            vMainName.SpacingBefore = 8;

            Paragraph vFrReqForm = new Paragraph("Franchise Request Form");
            vFrReqForm.Alignment = Element.ALIGN_CENTER;
            vFrReqForm.Font.Size = 12;
            vFrReqForm.Font.SetStyle(Font.BOLD);
            vFrReqForm.SpacingBefore = 18;

            Paragraph vTo = new Paragraph("To,");
            vTo.Alignment = Element.ALIGN_LEFT;
            vTo.Font.Size = 10;
            vTo.SpacingBefore = 20;

            Paragraph vName = new Paragraph("National Paramedical Council And Vocational Board Skill Development");
            vName.Alignment = Element.ALIGN_LEFT;
            vName.Font.Size = 10;
            vName.SpacingBefore = 5;
            vName.IndentationLeft = 8;

            Paragraph vAdr = new Paragraph("Haridwar Uttarakhand");
            vAdr.Alignment = Element.ALIGN_LEFT;
            vAdr.Font.Size = 10;
            vAdr.SpacingBefore = 5;
            vAdr.IndentationLeft = 8;

            Paragraph vSub = new Paragraph("Subject: New Franchise Request");
            vSub.Alignment = Element.ALIGN_LEFT;
            vSub.Font.Size = 10;
            vSub.SpacingBefore = 8;

            Paragraph vDear = new Paragraph("Dear Sir,");
            vDear.Alignment = Element.ALIGN_LEFT;
            vDear.Font.Size = 10;
            vDear.SpacingBefore = 8;

            Paragraph vReq = new Paragraph("I/We am/are interested to affiliate our institute with your NPCVB. Our details are mentioned below : ");
            vReq.Alignment = Element.ALIGN_LEFT;
            vReq.Font.Size = 10;
            vReq.SpacingBefore = 8;

            Paragraph vinfo = new Paragraph("Information About Institute & Head/Owner");
            vinfo.Alignment = Element.ALIGN_LEFT;
            vinfo.Font.Size = 10;
            vinfo.SpacingBefore = 20;
            vinfo.Font.SetStyle(Font.BOLD);          

            Paragraph vCenterName = new Paragraph("Center Name: "+lblCenterName.Text);
            vCenterName.Alignment = Element.ALIGN_LEFT;
            vCenterName.Font.Size = 10;            
            vCenterName.SpacingBefore = 10;

            Paragraph vCenterHeadName = new Paragraph("Center Head Name: " + lblCenterHeadName.Text);
            vCenterHeadName.Alignment = Element.ALIGN_LEFT;
            vCenterHeadName.Font.Size = 10;
            vCenterHeadName.SpacingBefore = 8;

            Paragraph vAddress = new Paragraph("Address: " + lblAddress.Text);
            vAddress.Alignment = Element.ALIGN_LEFT;
            vAddress.Font.Size = 10;            
            vAddress.SpacingBefore = 6;
            vAddress.IndentationRight = 120;

            Paragraph vState = new Paragraph("State : " + lblState.Text);
            vState.Alignment = Element.ALIGN_LEFT;
            vState.Font.Size = 10;
            vState.SpacingBefore = 6;

            Paragraph vPinCode = new Paragraph("Pin Code: " + lblPinCode.Text);
            vPinCode.Alignment = Element.ALIGN_LEFT;
            vPinCode.Font.Size = 10;
            vPinCode.IndentationLeft = 200;
            vPinCode.SpacingBefore = -16;

            Paragraph VPhone = new Paragraph("Phone Number: " + lblNumber.Text);
            VPhone.Alignment = Element.ALIGN_LEFT;
            VPhone.Font.Size = 10;
            VPhone.SpacingBefore = 8;
            //VPhone.IndentationLeft = 200;           

            Paragraph vEmail = new Paragraph("Email-ID: " + lblEmail.Text);
            vEmail.Alignment = Element.ALIGN_LEFT;
            vEmail.Font.Size = 10;
            vEmail.IndentationLeft = 200;
            vEmail.SpacingBefore = -17;           

            Paragraph vWork = new Paragraph("Information About Building And Infrastructure");
            vWork.Alignment = Element.ALIGN_LEFT;
            vWork.Font.SetStyle(Font.BOLD);
            vWork.Font.Size = 10;
            vWork.SpacingBefore = 20;

            Paragraph vComp = new Paragraph("Number of Computers: " + lblComp.Text + "   |   No. of staff members: " + lblStaff.Text);
            vComp.Alignment = Element.ALIGN_LEFT;           
            vComp.Font.Size = 10;
            vComp.SpacingBefore = 8;

            Paragraph Vcontnt = new Paragraph("1.	I/We on the behalf of above said centre confirm that. 2. I/We affilation from “ NPCVB Skill Development” for my/our institute/centre/firm/company/ngo to run the NPCVB SKILL DEVELOPMENT Computer/Paramedical/Yoga and naturopathy/management/vocational and many other education & training program and I/We am/are fully satisfied from the NPCVB.3. I/We am/are authorized for every responsibility and liability of my/our institute.4. I/We will not give any guarantee or promise to any student to give or get any job.5. All admission/examination documents collected from the NPCVB/students will be kept safety/confidentially by me/us and it is my responsibility for its timely distribution in the centre or sent to the NPCVB.6. I/We shall abide by present rule and regulations and directions of the NPCVB and those, which are inforce  time to time.7. I/We have read and understood and accept the rules and regulations of the NPCVB and agree to abide by them. If I/We violate any rule and regulations of the NPCVB. The NPCVB will authorized to cancel the affiliation and I/We will liable to bear all expenses of the NPCVB and students.8. I/We understand that, all course are for self-help and self employment purpose.9. I/We know NPCVB is an autonomous body Associate with Yugal Educational Hub which is registered under sec.8 (non-profit educational institute) of act 2013 of MCA Govt. of india.10. In case of any misshaping/accident with any student in my premises/centre, NPCVB will not be held responsiable for the same.11. All disputes are subject to haridwar uttrakhand jurisdiction only.12. I/We will never collect any kind of payment from any one on behalf of NPCVB.13. I/We will never issue any document/letter/certificate to any one on behalf of NPCVB. By signing here I/We hereby confirm that all information provided by me/us is true in all means & if needed I/We will provide supporting documents. I/We also confirm that I/We understand and accept all the terms and conditions written below and published on NPCVB,s website (www.npcvb.com). I/We shall be bound by ");
            Vcontnt.Alignment = Element.ALIGN_LEFT;
            Vcontnt.Font.Size = 10;
            Vcontnt.SpacingBefore = 30;

            Paragraph vna = new Paragraph("Auth. Signatory's Name in Capital Letters "+ lblCenterHeadName.Text.ToUpper());
            vna.Alignment = Element.ALIGN_LEFT;
            vna.Font.Size = 10;
            vna.SpacingBefore = 35;

            Paragraph Vdate = new Paragraph("Dated: "+ lblDate.Text);
            Vdate.Alignment = Element.ALIGN_LEFT;
            Vdate.Font.Size = 10;
            Vdate.SpacingBefore = 55;

            Paragraph Vsss = new Paragraph("Signature & Stamp");
            Vsss.Alignment = Element.ALIGN_LEFT;
            Vsss.Font.Size = 10;
            Vsss.SpacingBefore = -13;
            Vsss.IndentationLeft = 400;

            Paragraph VSEND = new Paragraph("Send this dully filled form along with demand draft in favour of National Paramedical Council And Vocational Board payable at ROORKEE by post/courier to NATIONAL PARAMEDICAL COUNCIL AND VOCATIONAL BOARD SKILL DEVELOPMENT Green Park Colony Near Rampur Chungi Roorkee, Distt Haridwar 247667 (Uttarakhand)");
            VSEND.Alignment = Element.ALIGN_LEFT;
            VSEND.Font.Size = 10;
            VSEND.SpacingBefore = 40;

            string imagesign = Server.MapPath(ResolveUrl("~/Center-Document/" + lblSign.Text));
            iTextSharp.text.Image cenSign = iTextSharp.text.Image.GetInstance(imagesign);
            cenSign.ScaleToFit(92, 185);
            cenSign.SetAbsolutePosition(461, 730);

            string imageStuPath = Server.MapPath(ResolveUrl("~/Center-Document/" + lblCenterHeadPhoto.Text));
            iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);
            stuImage.ScaleToFit(92, 185);
            stuImage.SetAbsolutePosition(481, 450);
            stuImage.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
            stuImage.BorderColorBottom = BaseColor.BLACK;

            stuImage.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
            stuImage.BorderColorLeft = BaseColor.BLACK;

            stuImage.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
            stuImage.BorderColorRight = BaseColor.BLACK;

            stuImage.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            stuImage.BorderColorTop = BaseColor.BLACK;
            stuImage.BorderWidthBottom = 2;
            stuImage.BorderWidthLeft = 2;
            stuImage.BorderWidthRight = 2;
            stuImage.BorderWidthTop = 2;

            pdfDoc.Add(vMainName);
            pdfDoc.Add(vFrReqForm);
            pdfDoc.Add(vTo);
            pdfDoc.Add(vName);
            pdfDoc.Add(vAdr);
            pdfDoc.Add(vSub);
            pdfDoc.Add(vDear);
            pdfDoc.Add(vReq);
            pdfDoc.Add(vinfo);
            pdfDoc.Add(vCenterName);
            pdfDoc.Add(vCenterHeadName);
            pdfDoc.Add(stuImage);
            pdfDoc.Add(vAddress);
            pdfDoc.Add(vState);
            pdfDoc.Add(vPinCode);
            pdfDoc.Add(VPhone);
            pdfDoc.Add(vEmail);
            
            pdfDoc.Add(vWork);

            pdfDoc.Add(vComp);
            pdfDoc.Add(Vcontnt);
            pdfDoc.Add(vna);
            pdfDoc.Add(Vdate);
            pdfDoc.Add(Vsss);
            pdfDoc.Add(cenSign);
            pdfDoc.Add(VSEND);

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