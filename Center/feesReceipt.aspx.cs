using System;
using System.Web.UI;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class Center_feesReceipt : System.Web.UI.Page
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
        string stGetData = "select * from FeesReceipt where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Session["ID"].ToString()));
        //string id = Session["ID"].ToString();
        DataSet ds = DBT.P_returnDataSet(stGetData,Pram);

        lblAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();

        int temp = Convert.ToInt32(lblAmount.Text);
        string words = ConvertNumbertoWords(temp);
        lblAmtWords.Text = words;

        lblNarration.Text = ds.Tables[0].Rows[0]["Narration"].ToString();
        lblInvoiceNum.Text = ds.Tables[0].Rows[0]["InvoiceNumber"].ToString();
        lblInvoiceDate.Text = ds.Tables[0].Rows[0]["InvoiceDate"].ToString();
        string StudentID = ds.Tables[0].Rows[0]["SID"].ToString();
        string vCID = ds.Tables[0].Rows[0]["CID"].ToString();

        
        string strGetDataCourse = "select * from AddStudent where Id=@ID" ;
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ID", StudentID));

        DataSet dsCourse = DBT.P_returnDataSet(strGetDataCourse,Pr);
        lblStudentDetails.Text = dsCourse.Tables[0].Rows[0]["StudentName"].ToString()+","+ dsCourse.Tables[0].Rows[0]["Address"].ToString();

       
        string strGetDataCenter = "select CenterID from CenterRegistration where Id=@ID" ;
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@ID", vCID));
        string Vcenter = DBT.P_returnOneValue(strGetDataCenter,Pram);
        lblCenterID.Text = Vcenter;
    }
    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";

        if ((number / 1000000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000000) + " Billion ";
            number %= 1000000000;
        }

        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " Crore ";
            number %= 10000000;
        }

        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=FeesReceipt.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string imageFilePath = Server.MapPath(".") + "/templateImage/FEERECEIPT.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
            
            Document pdfDoc = new Document();
           
            jpg.ScaleAbsolute(600, 850);
           
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
           
            jpg.SetAbsolutePosition(-10, -25);

           // PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            PdfWriter PdfWrtr = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.NewPage();


            PdfContentByte cbVStuDet = PdfWrtr.DirectContent;
            ColumnText ctVstuDet = new ColumnText(cbVStuDet);
            Phrase myTextVStuDet = new Phrase(lblStudentDetails.Text);
            ctVstuDet.SetSimpleColumn(myTextVStuDet, 23, 40, 290, 730,15, Element.ALIGN_LEFT);
            ctVstuDet.Go();

            PdfContentByte cbVInvNo = PdfWrtr.DirectContent;
            ColumnText ctVInvNo = new ColumnText(cbVInvNo);
            Phrase myTextVInvNo = new Phrase(lblInvoiceNum.Text);
            ctVInvNo.SetSimpleColumn(myTextVInvNo, 750, 120, 460, 759, 25, Element.ALIGN_LEFT);
            ctVInvNo.Go();

            PdfContentByte cbVInvdt = PdfWrtr.DirectContent;
            ColumnText ctVInvdt = new ColumnText(cbVInvdt);
            Phrase myTextVInvdt = new Phrase(lblInvoiceDate.Text);
            ctVInvdt.SetSimpleColumn(myTextVInvdt, 720, 100, 440, 734, 25, Element.ALIGN_LEFT);
            ctVInvdt.Go();

            PdfContentByte cbVCID = PdfWrtr.DirectContent;
            ColumnText ctVCID = new ColumnText(cbVCID);
            Phrase myTextVCID = new Phrase(lblCenterID.Text);
            ctVCID.SetSimpleColumn(myTextVCID, 720, 90, 415, 712, 25, Element.ALIGN_LEFT);
            ctVCID.Go();

            PdfContentByte cbvSr = PdfWrtr.DirectContent;
            ColumnText ctvSr = new ColumnText(cbvSr);
            Phrase myTextvSr = new Phrase("1");
            ctvSr.SetSimpleColumn(myTextvSr, 60, 80, 400, 630, 25, Element.ALIGN_LEFT);
            ctvSr.Go();

            PdfContentByte cbvNr = PdfWrtr.DirectContent;
            ColumnText ctvNr = new ColumnText(cbvNr);
            Phrase myTextvNr = new Phrase(lblNarration.Text);
            ctvNr.SetSimpleColumn(myTextvNr, 120, 100, 450, 625, 12, Element.ALIGN_LEFT);
            ctvNr.Go();

            PdfContentByte cbvAmt = PdfWrtr.DirectContent;
            ColumnText ctvAmt = new ColumnText(cbvAmt);
            Phrase myTextvAmt = new Phrase(lblAmount.Text + "/-");
            ctvAmt.SetSimpleColumn(myTextvAmt, 830, 160, 490, 630, 25, Element.ALIGN_LEFT);
            ctvAmt.Go();

            PdfContentByte cbvTotAmt = PdfWrtr.DirectContent;
            ColumnText ctvTotAmt = new ColumnText(cbvTotAmt);
            Phrase myTextvTotAmt = new Phrase(lblAmount.Text + "/-");
            ctvTotAmt.SetSimpleColumn(myTextvTotAmt, 830, 160, 490, 595, 25, Element.ALIGN_LEFT);
            ctvTotAmt.Go();


            PdfContentByte cbvAmtWords = PdfWrtr.DirectContent;
            ColumnText ctvAmtWords = new ColumnText(cbvAmtWords);
            Phrase myTextvAmtWords = new Phrase(lblAmtWords.Text.ToLower() + " only");
            myTextvAmtWords.Font.Size = 8;
            ctvAmtWords.SetSimpleColumn(myTextvAmtWords, 325, 100, 490, 557, 15, Element.ALIGN_LEFT);
            ctvAmtWords.Go();

            PdfContentByte cbVStuDet1 = PdfWrtr.DirectContent;
            ColumnText ctVstuDet1 = new ColumnText(cbVStuDet1);
            Phrase myTextVStuDet1 = new Phrase(lblStudentDetails.Text);
            ctVstuDet1.SetSimpleColumn(myTextVStuDet1, 23, 80, 290, 330, 15, Element.ALIGN_LEFT);
            ctVstuDet1.Go();

            PdfContentByte cbVInvNo1 = PdfWrtr.DirectContent;
            ColumnText ctVInvNo1 = new ColumnText(cbVInvNo1);
            Phrase myTextVInvNo1 = new Phrase(lblInvoiceNum.Text);
            ctVInvNo1.SetSimpleColumn(myTextVInvNo1, 750, 120, 460, 354, 25, Element.ALIGN_LEFT);
            ctVInvNo1.Go();

            PdfContentByte cbVInvdt1 = PdfWrtr.DirectContent;
            ColumnText ctVInvdt1 = new ColumnText(cbVInvdt1);
            Phrase myTextVInvdt1 = new Phrase(lblInvoiceDate.Text);
            ctVInvdt1.SetSimpleColumn(myTextVInvdt1, 720, 100, 440, 332, 25, Element.ALIGN_LEFT);
            ctVInvdt1.Go();

            PdfContentByte cbVCID1 = PdfWrtr.DirectContent;
            ColumnText ctVCID1 = new ColumnText(cbVCID1);
            Phrase myTextVCID1 = new Phrase(lblCenterID.Text);
            ctVCID1.SetSimpleColumn(myTextVCID1, 720, 90, 415, 310, 25, Element.ALIGN_LEFT);
            ctVCID1.Go();

            PdfContentByte cbvSr1 = PdfWrtr.DirectContent;
            ColumnText ctvSr1 = new ColumnText(cbvSr1);
            Phrase myTextvSr1 = new Phrase("1");
            ctvSr1.SetSimpleColumn(myTextvSr1, 60, 80, 400, 230, 25, Element.ALIGN_LEFT);
            ctvSr1.Go();

            PdfContentByte cbvNr1 = PdfWrtr.DirectContent;
            ColumnText ctvNr1 = new ColumnText(cbvNr1);
            Phrase myTextvNr1 = new Phrase(lblNarration.Text);
            ctvNr1.SetSimpleColumn(myTextvNr1, 120, 100, 450, 220, 12, Element.ALIGN_LEFT);
            ctvNr1.Go();

            PdfContentByte cbvAmt1 = PdfWrtr.DirectContent;
            ColumnText ctvAmt1 = new ColumnText(cbvAmt1);
            Phrase myTextvAmt1 = new Phrase(lblAmount.Text + "/-");
            ctvAmt1.SetSimpleColumn(myTextvAmt1, 830, 160, 490, 230, 25, Element.ALIGN_LEFT);
            ctvAmt1.Go();

            PdfContentByte cbvTotAmt1 = PdfWrtr.DirectContent;
            ColumnText ctvTotAmt1 = new ColumnText(cbvTotAmt1);
            Phrase myTextvTotAmt1 = new Phrase(lblAmount.Text + "/-");
            ctvTotAmt1.SetSimpleColumn(myTextvTotAmt1, 830, 160, 490, 190, 25, Element.ALIGN_LEFT);
            ctvTotAmt1.Go();


            PdfContentByte cbvAmtWords1 = PdfWrtr.DirectContent;
            ColumnText ctvAmtWords1 = new ColumnText(cbvAmtWords1);
            Phrase myTextvAmtWords1 = new Phrase(lblAmtWords.Text.ToLower() + " only");
            myTextvAmtWords1.Font.Size = 10;
            ctvAmtWords1.SetSimpleColumn(myTextvAmtWords1, 325, 100, 490, 160, 15, Element.ALIGN_LEFT);
            ctvAmtWords1.Go();




            pdfDoc.Add(jpg);
            

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