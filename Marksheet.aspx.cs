using System;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;
using System.Data;
using QRCoder;
using System.Collections.Generic;
using System.Drawing;
using System.Data.SqlClient;
public partial class Marksheet : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string vDOB = txtDate.Text;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        Pram.Add(new SqlParameter("@DateOfBirth", vDOB));

        string strGetData = "select * from AddStudent ast join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID and DateOfBirth=@DateOfBirth";
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            divShow.Visible = true;
           

            string strAllSemResult = "select * from SemesterResult sr join AddStudent ast on sr.stuID=ast.ID where StudentID=@StudentID";
            DataSet dsAllSemRes = DBT.P_returnDataSet(strAllSemResult,Pram);
            string dtd = "";
            int count = dsAllSemRes.Tables[0].Rows.Count;
            if (count == 0)
            {
                btnSem1.Visible = false;
                lblShow.Visible = true;
            }
            else if (count == 1)
            {
                dtd = dsAllSemRes.Tables[0].Rows[0]["PrintDate"].ToString();
                btnSem1.Visible = true;
                btnSem2.Visible = false;
                btnSem3.Visible = false;
                btnSem4.Visible = false;
                btnSem5.Visible = false;
                btnSem6.Visible = false;
                lblShow.Visible = false;
            }
            else if (count == 2)
            {
                dtd = dsAllSemRes.Tables[0].Rows[0]["PrintDate"].ToString();
                btnSem1.Visible = true;
                btnSem2.Visible = true;
                btnSem3.Visible = false;
                btnSem4.Visible = false;
                btnSem5.Visible = false;
                btnSem6.Visible = false;
                lblShow.Visible = false;
            }
            else if (count == 3)
            {
                dtd = dsAllSemRes.Tables[0].Rows[0]["PrintDate"].ToString();
                btnSem1.Visible = true;
                btnSem2.Visible = true;
                btnSem3.Visible = true;
                btnSem4.Visible = false;
                btnSem5.Visible = false;
                btnSem6.Visible = false;
                lblShow.Visible = false;
            }
            else if (count == 4)
            {
                dtd = dsAllSemRes.Tables[0].Rows[0]["PrintDate"].ToString();
                btnSem1.Visible = true;
                btnSem2.Visible = true;
                btnSem3.Visible = true;
                btnSem4.Visible = true;
                btnSem5.Visible = false;
                btnSem6.Visible = false;
                lblShow.Visible = false;
            }
            else if (count == 5)
            {
                dtd = dsAllSemRes.Tables[0].Rows[0]["PrintDate"].ToString();
                btnSem1.Visible = true;
                btnSem2.Visible = true;
                btnSem3.Visible = true;
                btnSem4.Visible = true;
                btnSem5.Visible = true;
                btnSem6.Visible = false;
                lblShow.Visible = false;
            }
            else if(count==6)
            {
                dtd = dsAllSemRes.Tables[0].Rows[0]["PrintDate"].ToString();
                btnSem1.Visible = true;
                btnSem2.Visible = true;
                btnSem3.Visible = true;
                btnSem4.Visible = true;
                btnSem5.Visible = true;
                btnSem6.Visible = true;
                lblShow.Visible = false;
            }
            else if(count>6)
            {
                Response.Write("<script>alert('System Error!!!!!!');</script>");
            }
        }
    }
   
    protected void btnSem1_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string strGetData = "select * from AddStudent ast join CenterRegistration cr on ast.Cid=cr.id join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        string ID = ds.Tables[0].Rows[0]["ID"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            div1.Visible = true;
            imgStudentImg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            lblSems.Text = "Semester 1";
            
            string strgetSubDet = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@StuID", ID));
            Pr.Add(new SqlParameter("@ExamType", "Theory"));
            Pr.Add(new SqlParameter("@Semester", "Semester1"));
            DataSet dsSub = DBT.P_returnDataSet(strgetSubDet, Pr);
           
               rptMarks.DataSource = dsSub;
                rptMarks.DataBind();
            

           

            string strgetSubDet1 = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@StuID", ID));
            Pr1.Add(new SqlParameter("@ExamType", "Practical"));
            Pr1.Add(new SqlParameter("@Semester", "Semester1"));
            DataSet dsSub1 = DBT.P_returnDataSet(strgetSubDet1, Pr1);
            
                rptPrac.DataSource = dsSub1;
                rptPrac.DataBind();
            string GetSemID = dsSub.Tables[0].Rows[0]["SemID"].ToString();
            string GettotalResult = "select * from SemesterResult where StuID=@StuID and SemID=@SemID";
            List<SqlParameter> prn = new List<SqlParameter>();
            prn.Add(new SqlParameter("@StuID", ID));
            prn.Add(new SqlParameter("@SemID", GetSemID));
            DataSet DSN = DBT.P_returnDataSet(GettotalResult, prn);
            lblMarks.Text = DSN.Tables[0].Rows[0]["TotalMarks"].ToString();
            string mark = lblMarks.Text;
            int temp = Convert.ToInt32(mark);
            lblMarksWords.Text= ConvertNumbertoWords(temp);
            DateTime dd = Convert.ToDateTime(DSN.Tables[0].Rows[0]["PrintDate"].ToString());
            lblDate.Text = dd.ToString("dd-MM-yyyy");
            int cc = dsSub.Tables[0].Rows.Count;
            int cc1= dsSub1.Tables[0].Rows.Count;
            int totCount = cc + cc1;
            int totalmarks = cc * 100;
            double avg = (temp) / totCount;
            if (avg > 40)
            {
                lblRes.Text = "Pass";
                im.Visible = true;
                imf.Visible = false;
            }
            else
            {
                lblRes.Text = "Fail";
                im.Visible = false;
                imf.Visible = true;
            }


        }
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }
    }

    protected void btnSem2_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string strGetData = "select * from AddStudent ast join CenterRegistration cr on ast.Cid=cr.id join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));

        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        string ID = ds.Tables[0].Rows[0]["ID"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            div1.Visible = true;
            imgStudentImg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            lblSems.Text = "Semester 2";

            string strgetSubDet = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@StuID", ID));
            Pr.Add(new SqlParameter("@ExamType", "Theory"));
            Pr.Add(new SqlParameter("@Semester", "Semester2"));
            DataSet dsSub = DBT.P_returnDataSet(strgetSubDet, Pr);

            rptMarks.DataSource = dsSub;
            rptMarks.DataBind();




            string strgetSubDet1 = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@StuID", ID));
            Pr1.Add(new SqlParameter("@ExamType", "Practical"));
            Pr1.Add(new SqlParameter("@Semester", "Semester2"));
            DataSet dsSub1 = DBT.P_returnDataSet(strgetSubDet1, Pr1);

            rptPrac.DataSource = dsSub1;
            rptPrac.DataBind();

            string GetSemID = dsSub.Tables[0].Rows[0]["SemID"].ToString();
            string GettotalResult = "select * from SemesterResult where StuID=@StuID and SemID=@SemID";
            List<SqlParameter> prn = new List<SqlParameter>();
            prn.Add(new SqlParameter("@StuID", ID));
            prn.Add(new SqlParameter("@SemID", GetSemID));
            DataSet DSN = DBT.P_returnDataSet(GettotalResult, prn);
            lblMarks.Text = DSN.Tables[0].Rows[0]["TotalMarks"].ToString();
            string mark = lblMarks.Text;
            int temp = Convert.ToInt32(mark);
            lblMarksWords.Text = ConvertNumbertoWords(temp);
            DateTime dd = Convert.ToDateTime(DSN.Tables[0].Rows[0]["PrintDate"].ToString());
            lblDate.Text = dd.ToString("dd-MM-yyyy");
            int cc = dsSub.Tables[0].Rows.Count;
            int cc1 = dsSub1.Tables[0].Rows.Count;
            int totCount = cc + cc1;
            int totalmarks = cc * 100;
            double avg = (temp) / totCount;
            if (avg > 40)
            {
                lblRes.Text = "Pass";
                im.Visible = true;
                imf.Visible = false;
            }
            else
            {
                lblRes.Text = "Fail";
                im.Visible = false;
                imf.Visible = true;
            }

        }
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }
    }

    protected void btnSem3_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string strGetData = "select * from AddStudent ast join CenterRegistration cr on ast.Cid=cr.id join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        string ID = ds.Tables[0].Rows[0]["ID"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            div1.Visible = true;
            imgStudentImg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            lblSems.Text = "Semester 3";

            string strgetSubDet = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@StuID", ID));
            Pr.Add(new SqlParameter("@ExamType", "Theory"));
            Pr.Add(new SqlParameter("@Semester", "Semester3"));
            DataSet dsSub = DBT.P_returnDataSet(strgetSubDet, Pr);

            rptMarks.DataSource = dsSub;
            rptMarks.DataBind();




            string strgetSubDet1 = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@StuID", ID));
            Pr1.Add(new SqlParameter("@ExamType", "Practical"));
            Pr1.Add(new SqlParameter("@Semester", "Semester3"));
            DataSet dsSub1 = DBT.P_returnDataSet(strgetSubDet1, Pr1);

            rptPrac.DataSource = dsSub1;
            rptPrac.DataBind();

            string GetSemID = dsSub.Tables[0].Rows[0]["SemID"].ToString();
            string GettotalResult = "select * from SemesterResult where StuID=@StuID and SemID=@SemID";
            List<SqlParameter> prn = new List<SqlParameter>();
            prn.Add(new SqlParameter("@StuID", ID));
            prn.Add(new SqlParameter("@SemID", GetSemID));
            DataSet DSN = DBT.P_returnDataSet(GettotalResult, prn);
            lblMarks.Text = DSN.Tables[0].Rows[0]["TotalMarks"].ToString();
            string mark = lblMarks.Text;
            int temp = Convert.ToInt32(mark);
            lblMarksWords.Text = ConvertNumbertoWords(temp);
            DateTime dd = Convert.ToDateTime(DSN.Tables[0].Rows[0]["PrintDate"].ToString());
            lblDate.Text = dd.ToString("dd-MM-yyyy");
            int cc = dsSub.Tables[0].Rows.Count;
            int cc1 = dsSub1.Tables[0].Rows.Count;
            int totCount = cc + cc1;
            int totalmarks = cc * 100;
            double avg = (temp) / totCount;
            if (avg > 40)
            {
                lblRes.Text = "Pass";
                im.Visible = true;
                imf.Visible = false;
            }
            else
            {
                lblRes.Text = "Fail";
                im.Visible = false;
                imf.Visible = true;
            }
        }
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }
    }

    protected void btnSem4_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string strGetData = "select * from AddStudent ast join CenterRegistration cr on ast.Cid=cr.id join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        string ID = ds.Tables[0].Rows[0]["ID"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            div1.Visible = true;
            imgStudentImg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            lblSems.Text = "Semester 4";

            string strgetSubDet = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@StuID", ID));
            Pr.Add(new SqlParameter("@ExamType", "Theory"));
            Pr.Add(new SqlParameter("@Semester", "Semester4"));
            DataSet dsSub = DBT.P_returnDataSet(strgetSubDet, Pr);

            rptMarks.DataSource = dsSub;
            rptMarks.DataBind();




            string strgetSubDet1 = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@StuID", ID));
            Pr1.Add(new SqlParameter("@ExamType", "Practical"));
            Pr1.Add(new SqlParameter("@Semester", "Semester4"));
            DataSet dsSub1 = DBT.P_returnDataSet(strgetSubDet1, Pr1);

            rptPrac.DataSource = dsSub1;
            rptPrac.DataBind();

            string GetSemID = dsSub.Tables[0].Rows[0]["SemID"].ToString();
            string GettotalResult = "select * from SemesterResult where StuID=@StuID and SemID=@SemID";
            List<SqlParameter> prn = new List<SqlParameter>();
            prn.Add(new SqlParameter("@StuID", ID));
            prn.Add(new SqlParameter("@SemID", GetSemID));
            DataSet DSN = DBT.P_returnDataSet(GettotalResult, prn);
            lblMarks.Text = DSN.Tables[0].Rows[0]["TotalMarks"].ToString();
            string mark = lblMarks.Text;
            int temp = Convert.ToInt32(mark);
            lblMarksWords.Text = ConvertNumbertoWords(temp);
            DateTime dd = Convert.ToDateTime(DSN.Tables[0].Rows[0]["PrintDate"].ToString());
            lblDate.Text = dd.ToString("dd-MM-yyyy");
            int cc = dsSub.Tables[0].Rows.Count;
            int cc1 = dsSub1.Tables[0].Rows.Count;
            int totCount = cc + cc1;
            int totalmarks = cc * 100;
            double avg = (temp) / totCount;
            if (avg > 40)
            {
                lblRes.Text = "Pass";
                im.Visible = true;
                imf.Visible = false;
            }
            else
            {
                lblRes.Text = "Fail";
                im.Visible = false;
                imf.Visible = true;
            }

        }
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }
    }

    protected void btnSem5_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string strGetData = "select * from AddStudent ast join CenterRegistration cr on ast.Cid=cr.id join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        string ID = ds.Tables[0].Rows[0]["ID"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            div1.Visible = true;
            imgStudentImg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            lblSems.Text = "Semester 5";

            string strgetSubDet = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@StuID", ID));
            Pr.Add(new SqlParameter("@ExamType", "Theory"));
            Pr.Add(new SqlParameter("@Semester", "Semester5"));
            DataSet dsSub = DBT.P_returnDataSet(strgetSubDet, Pr);

            rptMarks.DataSource = dsSub;
            rptMarks.DataBind();




            string strgetSubDet1 = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@StuID", ID));
            Pr1.Add(new SqlParameter("@ExamType", "Practical"));
            Pr1.Add(new SqlParameter("@Semester", "Semester5"));
            DataSet dsSub1 = DBT.P_returnDataSet(strgetSubDet1, Pr1);

            rptPrac.DataSource = dsSub1;
            rptPrac.DataBind();

            string GetSemID = dsSub.Tables[0].Rows[0]["SemID"].ToString();
            string GettotalResult = "select * from SemesterResult where StuID=@StuID and SemID=@SemID";
            List<SqlParameter> prn = new List<SqlParameter>();
            prn.Add(new SqlParameter("@StuID", ID));
            prn.Add(new SqlParameter("@SemID", GetSemID));
            DataSet DSN = DBT.P_returnDataSet(GettotalResult, prn);
            lblMarks.Text = DSN.Tables[0].Rows[0]["TotalMarks"].ToString();
            string mark = lblMarks.Text;
            int temp = Convert.ToInt32(mark);
            lblMarksWords.Text = ConvertNumbertoWords(temp);
            DateTime dd = Convert.ToDateTime(DSN.Tables[0].Rows[0]["PrintDate"].ToString());
            lblDate.Text = dd.ToString("dd-MM-yyyy");
            int cc = dsSub.Tables[0].Rows.Count;
            int cc1 = dsSub1.Tables[0].Rows.Count;
            int totCount = cc + cc1;
            int totalmarks = cc * 100;
            double avg = (temp) / totCount;
            if (avg > 40)
            {
                lblRes.Text = "Pass";
                im.Visible = true;
                imf.Visible = false;
            }
            else
            {
                lblRes.Text = "Fail";
                im.Visible = false;
                imf.Visible = true;
            }

        }
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }
    }

    protected void btnSem6_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string strGetData = "select * from AddStudent ast join CenterRegistration cr on ast.Cid=cr.id join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        string ID = ds.Tables[0].Rows[0]["ID"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            div1.Visible = true;
            imgStudentImg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            lblSems.Text = "Semester 6";

            string strgetSubDet = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@StuID", ID));
            Pr.Add(new SqlParameter("@ExamType", "Theory"));
            Pr.Add(new SqlParameter("@Semester", "Semester6"));
            DataSet dsSub = DBT.P_returnDataSet(strgetSubDet, Pr);

            rptMarks.DataSource = dsSub;
            rptMarks.DataBind();




            string strgetSubDet1 = "select * from Result r join MainExam me on r.ExamID=me.ID join Semesters s on r.SemID=s.ID where r.StuID=@StuID and ExamType=@ExamType and s.Semester=@Semester";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@StuID", ID));
            Pr1.Add(new SqlParameter("@ExamType", "Practical"));
            Pr1.Add(new SqlParameter("@Semester", "Semester6"));
            DataSet dsSub1 = DBT.P_returnDataSet(strgetSubDet1, Pr1);

            rptPrac.DataSource = dsSub1;
            rptPrac.DataBind();

            string GetSemID = dsSub.Tables[0].Rows[0]["SemID"].ToString();
            string GettotalResult = "select * from SemesterResult where StuID=@StuID and SemID=@SemID";
            List<SqlParameter> prn = new List<SqlParameter>();
            prn.Add(new SqlParameter("@StuID", ID));
            prn.Add(new SqlParameter("@SemID", GetSemID));
            DataSet DSN = DBT.P_returnDataSet(GettotalResult, prn);
            lblMarks.Text = DSN.Tables[0].Rows[0]["TotalMarks"].ToString();
            string mark = lblMarks.Text;
            int temp = Convert.ToInt32(mark);
            lblMarksWords.Text = ConvertNumbertoWords(temp);
            DateTime dd = Convert.ToDateTime(DSN.Tables[0].Rows[0]["PrintDate"].ToString());
            lblDate.Text = dd.ToString("dd-MM-yyyy");
            int cc = dsSub.Tables[0].Rows.Count;
            int cc1 = dsSub1.Tables[0].Rows.Count;
            int totCount = cc + cc1;
            int totalmarks = cc * 100;
            double avg = (temp) / totCount;
            if (avg > 40)
            {
                lblRes.Text = "Pass";
                im.Visible = true;
                imf.Visible = false;
            }
            else
            {
                lblRes.Text = "Fail";
                im.Visible = false;
                imf.Visible = true;
            }
        }
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }
    }
}