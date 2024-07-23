using System;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;
using System.Data;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;

public partial class SuperAdminBackend_StudentCertificate : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
            //saveBarCode("test.png", "chk");
        }
    }
    protected void LoadData()
    {
        //lblSpace.Text = "&nbsp;";
        string stGetData = "select * from AddStudent where ID=@ID";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ID", Session["ID"].ToString()));
           
        //string id = Session["ID"].ToString();
        DataSet ds = DBT.P_returnDataSet(stGetData,pr);

        lblStudentName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        lblFathersName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
        lblMothersName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
        lblEnrollmentNumber.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
        lblRollNumber.Text = ds.Tables[0].Rows[0]["RollNumber"].ToString();
        lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
        lblDate1.Text = ds.Tables[0].Rows[0]["SessionFrom"].ToString();
        lblDate2.Text = ds.Tables[0].Rows[0]["SessionTo"].ToString();
      

        string vCourseID = ds.Tables[0].Rows[0]["Course"].ToString();
        string strGetDataCourse = "select * from Courses where Id=@Id" ;
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@Id", vCourseID));
        DataSet dsCourse = DBT.P_returnDataSet(strGetDataCourse,Pr1);
        lblCourseName.Text = dsCourse.Tables[0].Rows[0]["FullCourseName"].ToString();
        string CourseTypeID = dsCourse.Tables[0].Rows[0]["CTID"].ToString();
        List<SqlParameter> Pr2 = new List<SqlParameter>();
        Pr2.Add(new SqlParameter("@ID", CourseTypeID));
        string CourseType =DBT.P_returnOneValue("select CourseType from CourseType where ID=@ID",Pr2);
        lblCourseType.Text = CourseType;
        lblDuration.Text = dsCourse.Tables[0].Rows[0]["Duration"].ToString();
       
       
        imgStudentImg.Text= ds.Tables[0].Rows[0]["StudentImage"].ToString();
        string vCID = ds.Tables[0].Rows[0]["CID"].ToString();
        string strGetDataCenter = "select * from CenterRegistration where Id=@Id";
        List<SqlParameter> Pr3 = new List<SqlParameter>();
        Pr3.Add(new SqlParameter("@Id", vCID));
        DataSet dscenter = DBT.P_returnDataSet(strGetDataCenter,Pr3);
        string Vcenter = dscenter.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCenterAddress.Text= dscenter.Tables[0].Rows[0]["Address"].ToString();
        imgCenterSign.Text = dscenter.Tables[0].Rows[0]["Signature"].ToString();
        lblCenterName.Text = Vcenter;

        string strResult = "select * from SemesterResult where ID=@ID" ;
        List<SqlParameter> Pr4 = new List<SqlParameter>();
        Pr4.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
        DataSet dsres = DBT.P_returnDataSet(strResult,Pr4);
        string GetSemID = dsres.Tables[0].Rows[0]["SemID"].ToString();
        string dtd=dsres.Tables[0].Rows[0]["PrintDate"].ToString();
        if(dtd==DateTime.Now.AddDays(2).ToShortDateString())
        {
            lblDate.Text = dtd;
        }
        else
        {
            lblDate.Text = "Still Days left to print date"; 
        }
        lblDate.Text = dsres.Tables[0].Rows[0]["PrintDate"].ToString();
        string strGetSem = "select * from Semesters where ID=@ID" ;
        List<SqlParameter> Pr5 = new List<SqlParameter>();
        Pr5.Add(new SqlParameter("@ID", GetSemID));
        DataSet dsSem = DBT.P_returnDataSet(strGetSem,Pr5);
        string sem = "";
        string TotGmarks = "";
        double marks = 0;
        string TotGObtmarks = "";
        double obtmarks = 0;
        string[] vyearsplit = lblDate.Text.Split('/');
        string vMonth = vyearsplit[1];
        int vm = Convert.ToInt32(vMonth);
        int vd =Convert.ToInt32(vyearsplit[2]);

        string vyear = vyearsplit[0];
        DateTime dd = Convert.ToDateTime(dtd);
        string fullMonthName = dd.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
        lblSpace.Text = fullMonthName +"-"+ vyearsplit[0];
        string[] splitdur = lblDuration.Text.Split('-');
        string num = splitdur[0];
        string str = splitdur[1];
        int temn = 0;
        string resn = "";
        double nn = Convert.ToDouble(num);
        if (str== "Months")
        {
            if(nn<12)
            {
                temn = 1;
            }
            else if(nn>12)
            {
                
                    temn = 3;
               
            }
        }
       else if(str== "Year")
        {
            double temp = nn * 2;
            temn = Convert.ToInt32(temp);
        }
        
         resn = "Semester" + Convert.ToString(temn);
        if (resn == dsSem.Tables[0].Rows[0]["Semester"].ToString())
        {
            BtnNoc.Visible = true;
            btnSave.Visible = true;

        }
        else
        {
            BtnNoc.Visible = false;
            btnSave.Visible = false;
        }
        
        if (dsSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester1")
        {
            //if(vd>=1&&vd<=10)
            //{
            //    int vyy = Convert.ToInt32(vyear);

            //    if(vm==1)
            //    {
            //        vyy = vyy - 1;
            //        lblSpace.Text = "December-" + Convert.ToString(vyy);
            //    }
            //    else if(vm==7)
            //    {
            //        lblSpace.Text = "June-" + Convert.ToString(vyy);
            //    }
            //}
            //else
            //{
            //    if (vm >= 1 && vm < 7)
            //    {
            //        lblSpace.Text = "June-" + vyear;
            //    }
            //    else
            //    {
            //        lblSpace.Text = "December-" + vyear;
            //    }
            //}           
            sem = "1st";
            //string strAllSemResult = "select * from SemesterResult where ID=@ID";
            List<SqlParameter> Pr6 = new List<SqlParameter>();
            Pr6.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
            DataSet dsAllSemRes = DBT.P_returnDataSet(strResult,Pr6);
            string GetAllStuID = dsAllSemRes.Tables[0].Rows[0]["StuID"].ToString();

            string strAllSemsR = "select * from SemesterResult where StuID=@StuID";
            List<SqlParameter> pra1 = new List<SqlParameter>();
            pra1.Add(new SqlParameter("@StuID", GetAllStuID));
            DataSet dsAllSems = DBT.P_returnDataSet(strAllSemsR,pra1);
            for (int i = 0; i < dsAllSems.Tables[0].Rows.Count; i++)
            {
                string GetAllSems = dsAllSems.Tables[0].Rows[i]["SemID"].ToString();
                string strGetNameSem = "select * from Semesters where ID=@ID" ;
                List<SqlParameter> pra2 = new List<SqlParameter>();
                pra2.Add(new SqlParameter("@ID", GetAllSems));
                DataSet dsNameSem = DBT.P_returnDataSet(strGetNameSem,pra2);
                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester1")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID=@SemID and res.StuID=@StuID";
                    List<SqlParameter> pra3 = new List<SqlParameter>();
                    pra3.Add(new SqlParameter("@SemID", GetAllSems));
                    pra3.Add(new SqlParameter("@StuID", GetAllStuID));
                    DataSet dsResult = DBT.P_returnDataSet(strRes,pra3);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem1MArks.Text = Convert.ToString(tm);
                    lblSemesterName1.Text = "1st";
                    lblOBMArks1.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();

                    lblSemesterName6.Text = " ";
                    lblTotSem6MArks.Text = " ";
                    lblSemesterName5.Text = " ";
                    lblTotSem5MArks.Text = " ";
                    lblSemesterName4.Text = " ";
                    lblTotSem4MArks.Text = " ";
                    lblSemesterName3.Text = " ";
                    lblTotSem3MArks.Text = " ";
                    lblSemesterName2.Text = " ";
                    lblTotSem2MArks.Text = " ";
                   
                    lblOBMArks2.Text = " ";
                    lblOBMArks3.Text = " ";
                    lblOBMArks4.Text = " ";
                    lblOBMArks5.Text = " ";
                    lblOBMArks6.Text = " ";

                }
            }
            TotGmarks = lblTotSem1MArks.Text;
            TotGObtmarks = lblOBMArks1.Text;

        }
        else if (dsSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester2")
        {
            
            sem = "2nd";
            //string strAllSemResult = "select * from SemesterResult where ID=" + Session["SemRes"].ToString();
            List<SqlParameter> Pr7 = new List<SqlParameter>();
            Pr7.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
            DataSet dsAllSemRes = DBT.P_returnDataSet(strResult,Pr7);
            string GetAllStuID = dsAllSemRes.Tables[0].Rows[0]["StuID"].ToString();

            string strAllSemsR = "select * from SemesterResult where StuID=" + GetAllStuID;
            DataSet dsAllSems = DBT.returnDataSet(strAllSemsR);
            for (int i = 0; i < dsAllSems.Tables[0].Rows.Count; i++)
            {
                string GetAllSems = dsAllSems.Tables[0].Rows[i]["SemID"].ToString();
              
                string strGetNameSem = "select * from Semesters where ID=" + GetAllSems;
                DataSet dsNameSem = DBT.returnDataSet(strGetNameSem);
                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester1")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem1MArks.Text = Convert.ToString(tm);
                    lblSemesterName1.Text = "1st";
                    lblOBMArks1.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester2")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem2MArks.Text = Convert.ToString(tm);
                    lblSemesterName2.Text = "2nd";
                    lblOBMArks2.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                    lblSemesterName6.Text = " ";
                    lblTotSem6MArks.Text = " ";
                    lblSemesterName5.Text = " ";
                    lblTotSem5MArks.Text = " ";
                    lblSemesterName4.Text = " ";
                    lblTotSem4MArks.Text = " ";
                    lblSemesterName3.Text = " ";
                    lblTotSem3MArks.Text = " ";
                    lblOBMArks3.Text = " ";
                    lblOBMArks4.Text = " ";
                    lblOBMArks5.Text = " ";
                    lblOBMArks6.Text = " ";
                }
            }
            int m1, m2;
            m1 = m2 = 0;
            m1 = Convert.ToInt32(lblTotSem1MArks.Text);
            m2 = Convert.ToInt32(lblTotSem2MArks.Text);
            marks = m1 + m2;
           
            m1 = Convert.ToInt32(lblOBMArks1.Text);
            m2 = Convert.ToInt32(lblOBMArks2.Text);
            obtmarks = m1 + m2;
            TotGmarks = Convert.ToString(marks);
            TotGObtmarks = Convert.ToString(obtmarks);
        }
        else if (dsSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester3")
        {
            
            sem = "3rd";
            //string strAllSemResult = "select * from SemesterResult where ID=" + Session["SemRes"].ToString();
            List<SqlParameter> Pr8 = new List<SqlParameter>();
            Pr8.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
            DataSet dsAllSemRes = DBT.P_returnDataSet(strResult,Pr8);
            string GetAllStuID = dsAllSemRes.Tables[0].Rows[0]["StuID"].ToString();

            string strAllSemsR = "select * from SemesterResult where StuID=" + GetAllStuID;
            DataSet dsAllSems = DBT.returnDataSet(strAllSemsR);
            for (int i = 0; i < dsAllSems.Tables[0].Rows.Count; i++)
            {
                string GetAllSems = dsAllSems.Tables[0].Rows[i]["SemID"].ToString();
                string strGetNameSem = "select * from Semesters where ID=" + GetAllSems;
                DataSet dsNameSem = DBT.returnDataSet(strGetNameSem);
                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester1")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem1MArks.Text = Convert.ToString(tm);
                    lblSemesterName1.Text = "1st";
                    lblOBMArks1.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();

                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester2")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem2MArks.Text = Convert.ToString(tm);
                    lblSemesterName2.Text = "2nd";
                    lblOBMArks2.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();

                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester3")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName3.Text = "3rd";
                    lblTotSem3MArks.Text = Convert.ToString(tm);
                    lblOBMArks3.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                    lblSemesterName6.Text = " ";
                    lblTotSem6MArks.Text = " ";
                    lblSemesterName5.Text = " ";
                    lblTotSem5MArks.Text = " ";
                    lblSemesterName4.Text = " ";
                    lblTotSem4MArks.Text = " ";
                    lblOBMArks4.Text = " ";
                    lblOBMArks5.Text = " ";
                    lblOBMArks6.Text = " ";
                }
            }
            int m1, m2,m3;
            m1 = m2 =m3= 0;
            m1 = Convert.ToInt32(lblTotSem1MArks.Text);
            m2 = Convert.ToInt32(lblTotSem2MArks.Text);
            m3 = Convert.ToInt32(lblTotSem3MArks.Text);
            marks = m1 + m2+m3;
            
            m1 = Convert.ToInt32(lblOBMArks1.Text);
            m2 = Convert.ToInt32(lblOBMArks2.Text);
            m3 = Convert.ToInt32(lblOBMArks3.Text);
            obtmarks = m1 + m2+m3;
            TotGmarks = Convert.ToString(marks);
            TotGObtmarks = Convert.ToString(obtmarks);
        }
        else if (dsSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester4")
        {
            
            sem = "4th";
            //string strAllSemResult = "select * from SemesterResult where ID=" + Session["SemRes"].ToString();
            List<SqlParameter> Pr9 = new List<SqlParameter>();
            Pr9.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
            DataSet dsAllSemRes = DBT.P_returnDataSet(strResult,Pr9);
            string GetAllStuID = dsAllSemRes.Tables[0].Rows[0]["StuID"].ToString();

            string strAllSemsR = "select * from SemesterResult where StuID=" + GetAllStuID;
            DataSet dsAllSems = DBT.returnDataSet(strAllSemsR);
            for (int i = 0; i < dsAllSems.Tables[0].Rows.Count; i++)
            {
                string GetAllSems = dsAllSems.Tables[0].Rows[i]["SemID"].ToString();
                string strGetNameSem = "select * from Semesters where ID=" + GetAllSems;
                DataSet dsNameSem = DBT.returnDataSet(strGetNameSem);
                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester1")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem1MArks.Text = Convert.ToString(tm);
                    lblSemesterName1.Text = "1st";
                    lblOBMArks1.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();

                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester2")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem2MArks.Text = Convert.ToString(tm);
                    lblSemesterName2.Text = "2nd";
                    lblOBMArks2.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester3")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName3.Text = "3rd";
                    lblTotSem3MArks.Text = Convert.ToString(tm);
                    lblOBMArks3.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester4")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName4.Text = "4th";
                    lblTotSem4MArks.Text = Convert.ToString(tm);
                    lblOBMArks4.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();

                    lblSemesterName6.Text = " ";
                    lblTotSem6MArks.Text = " ";
                    lblSemesterName5.Text = " ";
                    lblTotSem5MArks.Text = " ";
                    lblOBMArks5.Text = " ";
                    lblOBMArks6.Text = " ";
                }
            }
            int m1, m2, m3,m4;
            m1 = m2 = m3 = m4 = 0;
            m1 = Convert.ToInt32(lblTotSem1MArks.Text);
            m2 = Convert.ToInt32(lblTotSem2MArks.Text);
            m3 = Convert.ToInt32(lblTotSem3MArks.Text);
            m4 = Convert.ToInt32(lblTotSem4MArks.Text);
            marks = m1 + m2 + m3 + m4;
           
            m1 = Convert.ToInt32(lblOBMArks1.Text);
            m2 = Convert.ToInt32(lblOBMArks2.Text);
            m3 = Convert.ToInt32(lblOBMArks3.Text);
            m4 = Convert.ToInt32(lblOBMArks4.Text);
            obtmarks = m1 + m2 + m3 + m4;
            TotGmarks = Convert.ToString(marks);
            TotGObtmarks = Convert.ToString(obtmarks);
        }
        else if (dsSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester5")
        {
            
            sem = "5th";
            //string strAllSemResult = "select * from SemesterResult where ID=" + Session["SemRes"].ToString();
            List<SqlParameter> Pr10 = new List<SqlParameter>();
            Pr10.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
            DataSet dsAllSemRes = DBT.P_returnDataSet(strResult,Pr10);
            string GetAllStuID = dsAllSemRes.Tables[0].Rows[0]["StuID"].ToString();

            string strAllSemsR = "select * from SemesterResult where StuID=" + GetAllStuID;
            DataSet dsAllSems = DBT.returnDataSet(strAllSemsR);
            for (int i = 0; i < dsAllSems.Tables[0].Rows.Count; i++)
            {
                string GetAllSems = dsAllSems.Tables[0].Rows[i]["SemID"].ToString();
                string strGetNameSem = "select * from Semesters where ID=" + GetAllSems;
                DataSet dsNameSem = DBT.returnDataSet(strGetNameSem);
                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester1")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem1MArks.Text = Convert.ToString(tm);
                    lblSemesterName1.Text = "1st";
                    lblOBMArks1.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester2")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem2MArks.Text = Convert.ToString(tm);
                    lblSemesterName2.Text = "2nd";
                    
                    lblOBMArks2.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester3")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName3.Text = "3rd";
                    lblTotSem3MArks.Text = Convert.ToString(tm);
                    lblOBMArks3.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester4")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName4.Text = "4th";
                    lblTotSem4MArks.Text = Convert.ToString(tm);
                    lblOBMArks4.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester5")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName5.Text = "5th";
                    lblTotSem5MArks.Text = Convert.ToString(tm);


                    lblOBMArks5.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                    lblSemesterName6.Text = " ";
                    lblTotSem6MArks.Text = " ";
                    lblOBMArks6.Text = " ";
                }
            }
            int m1, m2, m3, m4,m5;
            m1 = m2 = m3 = m4=m5 = 0;
            m1 = Convert.ToInt32(lblTotSem1MArks.Text);
            m2 = Convert.ToInt32(lblTotSem2MArks.Text);
            m3 = Convert.ToInt32(lblTotSem3MArks.Text);
            m4 = Convert.ToInt32(lblTotSem4MArks.Text);
            m5 = Convert.ToInt32(lblTotSem5MArks.Text);
            marks = m1 + m2 + m3 + m4+m5;
           
            m1 = Convert.ToInt32(lblOBMArks1.Text);
            m2 = Convert.ToInt32(lblOBMArks2.Text);
            m3 = Convert.ToInt32(lblOBMArks3.Text);
            m4 = Convert.ToInt32(lblOBMArks4.Text);
            m5 = Convert.ToInt32(lblOBMArks5.Text);
            obtmarks = m1 + m2 + m3 + m4 + m5;
            TotGmarks = Convert.ToString(marks);
            TotGObtmarks = Convert.ToString(obtmarks);
        }
        else if (dsSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester6")
        {
            
            sem = "6th";
           // string strAllSemResult = "select * from SemesterResult where ID=" + Session["SemRes"].ToString();
            List<SqlParameter> Pr11 = new List<SqlParameter>();
            Pr11.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
            DataSet dsAllSemRes = DBT.P_returnDataSet(strResult,Pr11);
            string GetAllStuID = dsAllSemRes.Tables[0].Rows[0]["StuID"].ToString();

            string strAllSemsR = "select * from SemesterResult where StuID=" + GetAllStuID;
            DataSet dsAllSems = DBT.returnDataSet(strAllSemsR);
            for (int i = 0; i < dsAllSems.Tables[0].Rows.Count; i++)
            {
                string GetAllSems = dsAllSems.Tables[0].Rows[i]["SemID"].ToString();
                string strGetNameSem = "select * from Semesters where ID=" + GetAllSems;
                DataSet dsNameSem = DBT.returnDataSet(strGetNameSem);
                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester1")
                {
                   
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem1MArks.Text = Convert.ToString(tm);
                    lblSemesterName1.Text = "1st";
                    lblOBMArks1.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();

                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester2")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;
                    lblTotSem2MArks.Text = Convert.ToString(tm);
                    lblSemesterName2.Text = "2nd";
                   
                    lblOBMArks2.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester3")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName3.Text = "3rd";
                    lblTotSem3MArks.Text = Convert.ToString(tm);
                    lblOBMArks3.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester4")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName4.Text = "4th";
                    lblTotSem4MArks.Text = Convert.ToString(tm);
                    lblOBMArks4.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester5")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName5.Text = "5th";
                    lblTotSem5MArks.Text = Convert.ToString(tm);
                    lblOBMArks5.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }

                if (dsNameSem.Tables[0].Rows[0]["Semester"].ToString() == "Semester6")
                {
                    string strRes = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetAllSems + "' and res.StuID='" + GetAllStuID + "'";
                    DataSet dsResult = DBT.returnDataSet(strRes);
                    int count = dsResult.Tables[0].Rows.Count;
                    int m = 100;
                    int tm = m * count;

                    lblSemesterName6.Text = "6th";
                    lblTotSem6MArks.Text = Convert.ToString(tm);
                    lblOBMArks6.Text = dsAllSems.Tables[0].Rows[i]["TotalMarks"].ToString();
                }
            }
            int m1, m2, m3, m4, m5,m6;
            m1 = m2 = m3 = m4 = m5=m6 = 0;
            m1 = Convert.ToInt32(lblTotSem1MArks.Text);
            m2 = Convert.ToInt32(lblTotSem2MArks.Text);
            m3 = Convert.ToInt32(lblTotSem3MArks.Text);
            m4 = Convert.ToInt32(lblTotSem4MArks.Text);
            m5 = Convert.ToInt32(lblTotSem5MArks.Text);
            m6 = Convert.ToInt32(lblTotSem6MArks.Text);
            marks = m1 + m2 + m3 + m4 + m5 + m6;
          
            m1 = Convert.ToInt32(lblOBMArks1.Text);
            m2 = Convert.ToInt32(lblOBMArks2.Text);
            m3 = Convert.ToInt32(lblOBMArks3.Text);
            m4 = Convert.ToInt32(lblOBMArks4.Text);
            m5 = Convert.ToInt32(lblOBMArks5.Text);
            m6 = Convert.ToInt32(lblOBMArks6.Text);
            obtmarks = m1 + m2 + m3 + m4 + m5 + m6;
            TotGmarks = Convert.ToString(marks);
            TotGObtmarks = Convert.ToString(obtmarks);
        }
        lblGObtTot.Text = TotGObtmarks;
        lblGTot.Text = TotGmarks;
        lblSemester.Text = sem;
        if (lblFathersName.Text=="")
        {
            lblFathersName.Text = "&nbsp;";
        }
        if(lblMothersName.Text=="")
        {
            lblMothersName.Text = "&nbsp;";
        }
               
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
           // Response.ContentType = "application/pdf";

           // FileStream fs = new FileStream(Server.MapPath("~//"+"Certificate-" + lblStudentName.Text + DateTime.Now.ToShortDateString())+".pdf", FileMode.CreateNew);
            // System.IO.FileStream fs = new FileStream(Server.MapPath(".") + "\\" + "Certificate"+lblStudentName.Text + DateTime.Now.ToShortDateString() + ".pdf", FileMode.CreateNew);

            Response.AddHeader("content-disposition", "attachment;filename=Certificate" + lblEnrollmentNumber.Text + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

           

            string imageFilePath = Server.MapPath(".") + "/templateImage/3.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);           
            Document pdfDoc = new Document();          
            jpg.ScaleAbsolute(595, 842);           
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;            
            jpg.SetAbsolutePosition(0, 0);

            PdfWriter PdfWrtr = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //string path = Server.MapPath("/Marksheet");
            PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("pdfs/Certificate"+lblEnrollmentNumber.Text+".pdf"), FileMode.Create));
            // PdfWriter.GetInstance(pdfDoc,new FileStream(path, "/Certificate.pdf",FileMode.Create ));
            pdfDoc.Open();
            pdfDoc.NewPage();

            string vCertificatename = "Certificate" + lblEnrollmentNumber.Text + ".pdf";

            string updatestudent = "update AddStudent set CertificateD=@CertificateD where ID=@ID";
            List<SqlParameter> sqp = new List<SqlParameter>();
            sqp.Add(new SqlParameter("@CertificateD", vCertificatename));
            sqp.Add(new SqlParameter("@ID", Session["ID"].ToString()));
            DBT.P_ExecuteNonQuery(updatestudent, sqp);

            Paragraph vStudentName = new Paragraph(lblStudentName.Text.ToUpper());
            vStudentName.Alignment = Element.ALIGN_LEFT;
            vStudentName.Font = FontFactory.GetFont("Arial", 16);
            vStudentName.IndentationLeft = 145;
            vStudentName.SpacingBefore = 225;
            
            Paragraph vFatherName = new Paragraph(lblFathersName.Text.ToUpper());
            vFatherName.Alignment = Element.ALIGN_LEFT;

            vFatherName.IndentationLeft = 145;
            vFatherName.SpacingBefore = 3;

            Paragraph vMotherName = new Paragraph(lblMothersName.Text);
            vMotherName.Alignment = Element.ALIGN_LEFT;
            vMotherName.IndentationLeft =145;
            vMotherName.SpacingBefore = 6;

            Paragraph VEnrolmentNumber = new Paragraph(lblEnrollmentNumber.Text);
            VEnrolmentNumber.Font = FontFactory.GetFont("Arial", 16);
            VEnrolmentNumber.IndentationLeft = 145;
            VEnrolmentNumber.SpacingBefore = 4;

            Paragraph vDOB = new Paragraph(lblDOB.Text);
            vDOB.Font = FontFactory.GetFont("Arial", 16);
            vDOB.IndentationLeft = 145;
            vDOB.SpacingBefore = 3;

            Paragraph vCourseName = new Paragraph(lblCourseName.Text);
            vCourseName.Font.Size = 14;
            vCourseName.IndentationLeft = 5;
            vCourseName.IndentationRight = 5;
            vCourseName.SpacingBefore = 12;
            vCourseName.Alignment = Element.ALIGN_CENTER;

            Paragraph vSession = new Paragraph(lblDuration.Text);
            vSession.Font = FontFactory.GetFont("Arial", 16);
            vSession.IndentationLeft = 288;
            vSession.SpacingBefore = 22;

            PdfContentByte cbVVenture = PdfWrtr.DirectContent;
            ColumnText ctVVenture = new ColumnText(cbVVenture);
            
            Phrase myTextVVenture = new Phrase(lblCourseType.Text);
            if(lblCourseType.Text.Length<=60)
            {
                myTextVVenture.Font.Size = 10;
            }
            else
            {
                myTextVVenture.Font.Size = 7;
            }
            ctVVenture.SetSimpleColumn(myTextVVenture, 305, 155, 580, 323, 20, Element.ALIGN_LEFT);
            
            ctVVenture.Go();

            double percentage = 0.00;
            double gt = Convert.ToDouble(lblGTot.Text);
            double gto = Convert.ToDouble(lblGObtTot.Text);
            double temp1 = gto * 100;
            int per =Convert.ToInt32(temp1 / gt);
            percentage = temp1 / gt;
            string res = "";
            if (per >= 85) 
            {
                res = "A+";
            }
            else if (per >= 75 && per<= 84)
            {
                res = "A";
            }
            else if (per >= 65 && per <= 74)
            {
                res = "B+";
            }
            else if(per >= 50 && per <= 64)
            {
                res = "B";
            }                        
            else if (per >= 40 && per <= 49)
            {
                res = "C";
            }
            else
            {
                res = "Fail";
            }
           
            Paragraph vAvgMarks = new Paragraph(percentage.ToString("0.00")+"%");
            vAvgMarks.Font.Size = 10;
            vAvgMarks.IndentationLeft = 203;
            vAvgMarks.SpacingBefore = 95;

            Paragraph vGrade = new Paragraph(res);
            vGrade.Font.Size = 10;
            vGrade.IndentationLeft = 312;
            vGrade.SpacingBefore = 1;

            iTextSharp.text.Font arial1 = FontFactory.GetFont("Arial", 10, iTextSharp.text.BaseColor.BLACK);
            Paragraph vDuration = new Paragraph(lblDate1.Text + "                 " + lblDate2.Text,arial1);            
            vDuration.IndentationLeft = 298;
            vDuration.SpacingBefore = 1;

            Paragraph vCenter = new Paragraph(lblCenterName.Text);
            vCenter.Font.Size = 8;          
            vCenter.Alignment = Element.ALIGN_CENTER;
            vCenter.SpacingBefore = 16;

            Paragraph vCenterAddr = new Paragraph("ADDRESS:-" + lblCenterAddress.Text.ToUpper());
            vCenterAddr.Font.Size = 8;         
            vCenterAddr.SpacingBefore = -1;
            vCenterAddr.Alignment = Element.ALIGN_CENTER;

            string imgVerifiedPath = Server.MapPath(ResolveUrl("~/images/NCVB-removebg-preview.png"));
            iTextSharp.text.Image imgVer = iTextSharp.text.Image.GetInstance(imgVerifiedPath);
            imgVer.ScaleToFit(90, 60);
            imgVer.SetAbsolutePosition(425, 465);

            string imageSignPathMan = Server.MapPath(ResolveUrl("~/images/MANDASHIYA PNG FILE SINGH.png"));
            iTextSharp.text.Image signImageMan = iTextSharp.text.Image.GetInstance(imageSignPathMan);

            signImageMan.ScaleToFit(80, 60);
            signImageMan.SetAbsolutePosition(350, 100);

            string imageStuPath = Server.MapPath(ResolveUrl("~/Student-Image/" + imgStudentImg.Text));
            string imageSignPath = Server.MapPath(ResolveUrl("~/Image/SignatureCertificate.png"));
            iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);
            iTextSharp.text.Image signImage = iTextSharp.text.Image.GetInstance(imageSignPath);
            stuImage.ScaleToFit(130, 110);

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

            stuImage.SetAbsolutePosition(460, 465);
            signImage.ScaleToFit(80, 60);
            signImage.SetAbsolutePosition(480, 95);

            PdfContentByte cbVDate = PdfWrtr.DirectContent;
            ColumnText ctVDate = new ColumnText(cbVDate);
            string[] splitDate = lblDate.Text.Split('/');
            string dd = splitDate[0];
            string mm = splitDate[1];
            string yy = splitDate[2];
            int vd = Convert.ToInt32(dd);
            int vm = Convert.ToInt32(mm);
            int vy = Convert.ToInt32(yy);
            string vDatest = "";
            if (vm==1||vm==7)
            {
                DateTime oDate = Convert.ToDateTime(lblDate.Text);
                 vDatest = oDate.AddDays(3).ToString("dd/MM/yyyy");
            }
            else 
            {
                if (vd >= 28)
                {
                    DateTime oDate = Convert.ToDateTime(lblDate.Text);
                     vDatest = oDate.AddDays(3).ToString("dd/MM/yyyy");

                }
                else
                {
                    DateTime oDate = Convert.ToDateTime(lblDate.Text);
                    vDatest = oDate.AddDays(3).ToString("dd/MM/yyyy");
                }
            }
            string newdate = vDatest;
            Phrase myTextVDate = new Phrase(newdate);
            ctVDate.SetSimpleColumn(myTextVDate, 45, 95, 355, 159, 44, Element.ALIGN_LEFT);
            ctVDate.Go();

            string name = lblStudentName.Text;
            string code = Session["ID"].ToString();

            saveBarCode(name + "-" + code + ".png", "https://www.npcvb.com/ViewStudentDetails.aspx?SID=" + lblEnrollmentNumber.Text);
            string imageBarPath = Server.MapPath(ResolveUrl("~/StudentBarcode/" + lblStudentName.Text + "-" + code + ".png"));
            iTextSharp.text.Image barImage = iTextSharp.text.Image.GetInstance(imageBarPath);
            barImage.ScaleToFit(70, 50);
            barImage.SetAbsolutePosition(135, 90);

            string imageSignCenterPath = Server.MapPath(ResolveUrl("~/Center-Document/" + imgCenterSign.Text));
            iTextSharp.text.Image CenterSign = iTextSharp.text.Image.GetInstance(imageSignCenterPath);
            CenterSign.ScaleToFit(80, 100);
            CenterSign.SetAbsolutePosition(220, 125);

            pdfDoc.Add(jpg);
            pdfDoc.Add(stuImage);
            pdfDoc.Add(imgVer);
            pdfDoc.Add(vStudentName);
            pdfDoc.Add(vFatherName);
            pdfDoc.Add(vMotherName);
            pdfDoc.Add(VEnrolmentNumber);
            pdfDoc.Add(vDOB);
            pdfDoc.Add(vCourseName);
            pdfDoc.Add(vSession);
            pdfDoc.Add(vAvgMarks);
            pdfDoc.Add(vGrade);
            pdfDoc.Add(vDuration);
            pdfDoc.Add(vCenter);
            pdfDoc.Add(vCenterAddr);
            pdfDoc.Add(signImage);
            pdfDoc.Add(signImageMan);
            pdfDoc.Add(CenterSign);
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

    protected void btnMark_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=Marksheet" + lblEnrollmentNumber.Text + ".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string imageFilePath = Server.MapPath(".") + "/templateImage/2.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
        
            Document pdfDoc = new Document();
          
            jpg.ScaleAbsolute(595, 842);
           
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
        
            jpg.SetAbsolutePosition(0, 0);

            PdfWriter PdfWrtr = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath("pdfs/Marksheet" + lblEnrollmentNumber.Text + ".pdf"), FileMode.Create));

            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.NewPage();

            string vCertificatename = "Marksheet" + lblEnrollmentNumber.Text + ".pdf";

            string updatestudent = "update SemesterResult set MarksheetD=@MarksheetD where ID=@ID";
            List<SqlParameter> sqpl = new List<SqlParameter>();
            sqpl.Add(new SqlParameter("@MarksheetD", vCertificatename));
            sqpl.Add(new SqlParameter("@ID", Session["SemRes"]));
            DBT.P_ExecuteNonQuery(updatestudent, sqpl);

            Paragraph vExamination = new Paragraph(lblSpace.Text);
            vExamination.Font.Size = 8;
            vExamination.IndentationLeft = 65;
            vExamination.SpacingBefore = 1;

            Paragraph vRollNumber = new Paragraph(lblRollNumber.Text);
            vRollNumber.Font.Size = 8;
            vRollNumber.IndentationLeft = 65;
            vRollNumber.SpacingBefore = 2;

            Paragraph VEnrolmentNumber = new Paragraph(lblEnrollmentNumber.Text);
            VEnrolmentNumber.Font.Size = 8;
            VEnrolmentNumber.IndentationLeft = 65;
            VEnrolmentNumber.SpacingBefore = 1;

            

            Paragraph vStudentName = new Paragraph(lblStudentName.Text);
            vStudentName.Alignment = Element.ALIGN_LEFT;
            vStudentName.Font.Size = 8;
            vStudentName.IndentationLeft = 65;
            vStudentName.SpacingBefore = 2;

            //iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 12, iTextSharp.text.BaseColor.BLACK);
           

            Paragraph vFatherName = new Paragraph(lblFathersName.Text);
            vFatherName.Alignment = Element.ALIGN_LEFT;
            vFatherName.Font.Size = 8;
            vFatherName.IndentationLeft = 65;
            vFatherName.SpacingBefore = 1;

            Paragraph vMotherName = new Paragraph(lblMothersName.Text);
            vMotherName.Alignment = Element.ALIGN_LEFT;
            vMotherName.Font.Size = 8;
            vMotherName.IndentationLeft = 65;
            vMotherName.SpacingBefore = 0;
            
            Paragraph vCourse = new Paragraph(lblCourseName.Text);
            vCourse.Font.Size = 8;
            vCourse.IndentationLeft = 65;
            vCourse.SpacingBefore = 1;

            Paragraph vCenter = new Paragraph(lblCenterName.Text);
            vCenter.Font.Size = 8;
            vCenter.IndentationLeft = 65;
            vCenter.SpacingBefore = 2;
           

            string strResult = "select * from SemesterResult where ID=@ID" ;
            List<SqlParameter> sqp = new List<SqlParameter>();
            sqp.Add(new SqlParameter("@ID", Session["SemRes"].ToString()));
            DataSet ds = DBT.P_returnDataSet(strResult,sqp);
            string GetSemID = ds.Tables[0].Rows[0]["SemID"].ToString();
            string GetStuID = ds.Tables[0].Rows[0]["StuID"].ToString();

            PdfContentByte cb = PdfWrtr.DirectContent;
            //BaseFont title = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.WINANSI, BaseFont.EMBEDDED);
            //Font titleFont = new Font(title, 10, Font.BOLD, Color.Black);



            // cb.SetFontAndSize(title, 22);
            //ColumnText ct = new ColumnText(cb);
            //Phrase myText = new Phrase("Verified");
            //ct.SetSimpleColumn(myText, 450, 550, 500, 341, 15, Element.ALIGN_LEFT);
            //ct.Go();
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);

            Paragraph VVerified = new Paragraph("Verified", font);
            //VVerified.Font.Size = 15;
            VVerified.IndentationLeft = 390;
            VVerified.SpacingBefore = -280;
            //VVerified.Font.SetFamily("Helvetica");
            VVerified.Font.SetColor(1,152,117);
            

            string strResTheory = "select * from Result res,MainExam me where res.ExamID=me.id and res.SemID='" + GetSemID + "' and res.StuID='" + GetStuID + "'";
            DataSet dsResultTh = DBT.returnDataSet(strResTheory);
          
            PdfPTable tbl = new PdfPTable(9);

            tbl.SpacingBefore = 65;
            
            tbl.TotalWidth = 517f;
            tbl.LockedWidth = true;
            float[] widths = new float[] { 215f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 20f };
            tbl.SetWidths(widths);
            tbl.DefaultCell.BorderWidth = 0;
            BaseFont bftbl = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fonttbl = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);

            PdfPTable tblp = new PdfPTable(9);

            tblp.TotalWidth = 517f;
            tblp.LockedWidth = true;
            float[] widthsp = new float[] { 215f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 20f };
            tblp.SetWidths(widthsp);
            tblp.DefaultCell.BorderWidth = 0;
             tblp.SpacingBefore = 10;
            // int count = dsResultTh.Tables[0].Rows.Count + dsResultPr.Tables[0].Rows.Count;
            Random ren = new Random();

            int temp = ren.Next(999999);
            for (int i = 0; i < 10; i++)
            {
                if (dsResultTh.Tables[0].Rows.Count>i  && dsResultTh.Tables[0].Rows[i]["ExamType"].ToString() == "Theory")
                {
                    temp = temp + i;
                    
                    PdfPCell cell1 = new PdfPCell(new Phrase("Sub" + temp +"   "+ dsResultTh.Tables[0].Rows[i]["SubjectName"].ToString().ToUpper(), fonttbl));
                    cell1.BorderWidth = 0;
                    tbl.AddCell(cell1);
                    PdfPCell cell2 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["MaxMarks"].ToString(), fonttbl));
                    cell2.BorderWidth = 0;
                    tbl.AddCell(cell2);
                    PdfPCell cell3 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["ObtainedMarks"].ToString(), fonttbl));
                    cell3.BorderWidth = 0;
                    tbl.AddCell(cell3);
                    PdfPCell cell4 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["InternalMaxMarks"].ToString(), fonttbl));
                    cell4.BorderWidth = 0;
                    tbl.AddCell(cell4);
                    PdfPCell cell5 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["InternalObtainedMarks"].ToString(), fonttbl));
                    cell5.BorderWidth = 0;
                    tbl.AddCell(cell5);
                    PdfPCell cell6 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["TotMaxMarks"].ToString(), fonttbl));
                    cell6.BorderWidth = 0;
                    tbl.AddCell(cell6);
                    PdfPCell cell7 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["MinMarks"].ToString(), fonttbl));
                    cell7.BorderWidth = 0;
                    tbl.AddCell(cell7);
                    PdfPCell cell8 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["TotMarksObtained"].ToString(), fonttbl));
                    cell8.BorderWidth = 0;
                    tbl.AddCell(cell8);
                    PdfPCell cell9 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["Grade"].ToString().ToUpper(), fonttbl));
                    cell9.BorderWidth = 0;
                    tbl.AddCell(cell9);
                    
                   
                }
               else if(dsResultTh.Tables[0].Rows.Count >i && dsResultTh.Tables[0].Rows[i]["ExamType"].ToString()== "Practical")
                {
                    temp = temp + i;
                    
                    PdfPCell cell1 = new PdfPCell(new Phrase("Sub" + temp + "   " + dsResultTh.Tables[0].Rows[i]["SubjectName"].ToString().ToUpper(), fonttbl));
                    cell1.BorderWidth = 0;
                    tblp.AddCell(cell1);
                    PdfPCell cell2 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["MaxMarks"].ToString(), fonttbl));
                    cell2.BorderWidth = 0;
                    tblp.AddCell(cell2);
                    PdfPCell cell3 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["ObtainedMarks"].ToString(), fonttbl));
                    cell3.BorderWidth = 0;
                    tblp.AddCell(cell3);
                    PdfPCell cell4 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["InternalMaxMarks"].ToString(), fonttbl));
                    cell4.BorderWidth = 0;
                    tblp.AddCell(cell4);
                    PdfPCell cell5 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["InternalObtainedMarks"].ToString(), fonttbl));
                    cell5.BorderWidth = 0;
                    tblp.AddCell(cell5);
                    PdfPCell cell6 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["TotMaxMarks"].ToString(), fonttbl));
                    cell6.BorderWidth = 0;
                    tblp.AddCell(cell6);
                    PdfPCell cell7 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["MinMarks"].ToString(), fonttbl));
                    cell7.BorderWidth = 0;
                    tblp.AddCell(cell7);
                    PdfPCell cell8 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["TotMarksObtained"].ToString(), fonttbl));
                    cell8.BorderWidth = 0;
                    tblp.AddCell(cell8);
                    PdfPCell cell9 = new PdfPCell(new Phrase(dsResultTh.Tables[0].Rows[i]["Grade"].ToString().ToUpper(), fonttbl));
                    cell9.BorderWidth = 0;
                    tblp.AddCell(cell9);
                }
                else
                {
                    tblp.AddCell(" ");
                    
                    tblp.AddCell(" ");
                    tblp.AddCell(" ");
                    tblp.AddCell(" ");
                    tblp.AddCell(" ");
                    tblp.AddCell(" ");
                    tblp.AddCell(" ");
                    tblp.AddCell(" ");
                    tblp.AddCell(" ");
                   
                }

            }
            
            Paragraph Vsem = new Paragraph(lblSemester.Text);
            Vsem.Font.Size = 11;
            Vsem.IndentationLeft = -8;
            Vsem.SpacingBefore = 176;



            PdfContentByte cbVsemName1st = PdfWrtr.DirectContent;
            ColumnText ctVsemName1st = new ColumnText(cbVsemName1st);
            Phrase myTextVsemName1st = new Phrase(lblSemesterName1.Text);
            ctVsemName1st.SetSimpleColumn(myTextVsemName1st, 120, 100, 480, 242, 30, Element.ALIGN_LEFT);
            ctVsemName1st.Go();

            PdfContentByte cbTotSem1MArks = PdfWrtr.DirectContent;
            ColumnText ctTotSem1MArks = new ColumnText(cbTotSem1MArks);
            Phrase myTextTotSem1MArks = new Phrase(lblTotSem1MArks.Text);
            ctTotSem1MArks.SetSimpleColumn(myTextTotSem1MArks, 115, 100, 450, 230, 32, Element.ALIGN_LEFT);
            ctTotSem1MArks.Go();

            PdfContentByte cbsemTotObtMarks1st = PdfWrtr.DirectContent;
            ColumnText ctsemTotObtMarks1st = new ColumnText(cbsemTotObtMarks1st);
            Phrase myTextsemTotObtMarks1st = new Phrase(lblOBMArks1.Text);
            ctsemTotObtMarks1st.SetSimpleColumn(myTextsemTotObtMarks1st, 115, 100, 450, 220, 34, Element.ALIGN_LEFT);
            ctsemTotObtMarks1st.Go();

            PdfContentByte cbVsemName2nd = PdfWrtr.DirectContent;
            ColumnText ctVsemName2nd = new ColumnText(cbVsemName2nd);
            Phrase myTextVsemName2nd = new Phrase(lblSemesterName2.Text);
            ctVsemName2nd.SetSimpleColumn(myTextVsemName2nd, 150, 100, 480, 242, 30, Element.ALIGN_LEFT);
            ctVsemName2nd.Go();

            PdfContentByte cbVsemTotMarks2nd = PdfWrtr.DirectContent;
            ColumnText ctVsemTotMarks2nd = new ColumnText(cbVsemTotMarks2nd);
            Phrase myTextVsemTotMarks2nd = new Phrase(lblTotSem2MArks.Text);
            ctVsemTotMarks2nd.SetSimpleColumn(myTextVsemTotMarks2nd, 150, 100, 450, 230, 32, Element.ALIGN_LEFT);
            ctVsemTotMarks2nd.Go();

            PdfContentByte cbVsemTotObtMarks2nd = PdfWrtr.DirectContent;
            ColumnText ctVsemTotObtMarks2nd = new ColumnText(cbVsemTotObtMarks2nd);
            Phrase myTextVsemTotObtMarks2nd = new Phrase(lblOBMArks2.Text);
            ctVsemTotObtMarks2nd.SetSimpleColumn(myTextVsemTotObtMarks2nd, 150, 100, 450, 220, 34, Element.ALIGN_LEFT);
            ctVsemTotObtMarks2nd.Go();

            PdfContentByte cbVsemName3rd = PdfWrtr.DirectContent;
            ColumnText ctVsemName3rd = new ColumnText(cbVsemName3rd);
            Phrase myTextVsemName3rd = new Phrase(lblSemesterName3.Text);
            ctVsemName3rd.SetSimpleColumn(myTextVsemName3rd, 190, 100, 480, 242, 30, Element.ALIGN_LEFT);
            ctVsemName3rd.Go();

            PdfContentByte cbVsemTotMarks3rd = PdfWrtr.DirectContent;
            ColumnText ctVsemTotMarks3rd = new ColumnText(cbVsemTotMarks3rd);
            Phrase myTextVsemTotMarks3rd = new Phrase(lblTotSem3MArks.Text);
            ctVsemTotMarks3rd.SetSimpleColumn(myTextVsemTotMarks3rd, 190, 100, 450, 230, 32, Element.ALIGN_LEFT);
            ctVsemTotMarks3rd.Go();

            PdfContentByte cbVsemTotObtMarks3rd = PdfWrtr.DirectContent;
            ColumnText ctVsemTotObtMarks3rd = new ColumnText(cbVsemTotObtMarks3rd);
            Phrase myTextVsemTotObtMarks3rd = new Phrase(lblOBMArks3.Text);
            ctVsemTotObtMarks3rd.SetSimpleColumn(myTextVsemTotObtMarks3rd, 190, 100, 450, 220, 34, Element.ALIGN_LEFT);
            ctVsemTotObtMarks3rd.Go();

            PdfContentByte cbVsemName4th = PdfWrtr.DirectContent;
            ColumnText ctVsemName4th = new ColumnText(cbVsemName4th);
            Phrase myTextVsemName4th = new Phrase(lblSemesterName4.Text);
            ctVsemName4th.SetSimpleColumn(myTextVsemName4th, 225, 100, 480, 242, 30, Element.ALIGN_LEFT);
            ctVsemName4th.Go();

            PdfContentByte cbVsemTotMarks4th = PdfWrtr.DirectContent;
            ColumnText ctVsemTotMarks4th = new ColumnText(cbVsemTotMarks4th);
            Phrase myTextVsemTotMarks4th = new Phrase(lblTotSem4MArks.Text);
            ctVsemTotMarks4th.SetSimpleColumn(myTextVsemTotMarks4th, 225, 100, 450, 230, 32, Element.ALIGN_LEFT);
            ctVsemTotMarks4th.Go();

            PdfContentByte cbVsemTotObtMarks4th = PdfWrtr.DirectContent;
            ColumnText ctVsemTotObtMarks4th = new ColumnText(cbVsemTotObtMarks4th);
            Phrase myTextVsemTotObtMarks4th = new Phrase(lblOBMArks4.Text);
            ctVsemTotObtMarks4th.SetSimpleColumn(myTextVsemTotObtMarks4th, 225, 100, 450, 220, 34, Element.ALIGN_LEFT);
            ctVsemTotObtMarks4th.Go();

            PdfContentByte cbVsemName5th = PdfWrtr.DirectContent;
            ColumnText ctVsemName5th = new ColumnText(cbVsemName5th);
            Phrase myTextVsemName5th = new Phrase(lblSemesterName5.Text);
            ctVsemName5th.SetSimpleColumn(myTextVsemName5th, 260, 100, 480, 242, 30, Element.ALIGN_LEFT);
            ctVsemName5th.Go();

            PdfContentByte cbVsemTotMarks5th = PdfWrtr.DirectContent;
            ColumnText ctVsemTotMarks5th = new ColumnText(cbVsemTotMarks5th);
            Phrase myTextVsemTotMarks5th = new Phrase(lblTotSem5MArks.Text);
            ctVsemTotMarks5th.SetSimpleColumn(myTextVsemTotMarks5th, 260, 100, 450, 230, 32, Element.ALIGN_LEFT);
            ctVsemTotMarks5th.Go();

            PdfContentByte cbVsemTotObtMarks5th = PdfWrtr.DirectContent;
            ColumnText ctVsemTotObtMarks5th = new ColumnText(cbVsemTotObtMarks5th);
            Phrase myTextVsemTotObtMarks5th = new Phrase(lblOBMArks5.Text);
            ctVsemTotObtMarks5th.SetSimpleColumn(myTextVsemTotObtMarks5th, 260, 100, 450, 220, 34, Element.ALIGN_LEFT);
            ctVsemTotObtMarks5th.Go();

            PdfContentByte cbVsemName6th = PdfWrtr.DirectContent;
            ColumnText ctVsemName6th = new ColumnText(cbVsemName6th);
            Phrase myTextVsemName6th = new Phrase(lblSemesterName6.Text);
            ctVsemName6th.SetSimpleColumn(myTextVsemName6th, 298, 100, 480, 242, 30, Element.ALIGN_LEFT);
            ctVsemName6th.Go();

            PdfContentByte cbVsemTotMarks6th = PdfWrtr.DirectContent;
            ColumnText ctVsemTotMarks6th = new ColumnText(cbVsemTotMarks6th);
            Phrase myTextVsemTotMarks6th = new Phrase(lblTotSem6MArks.Text);
            ctVsemTotMarks6th.SetSimpleColumn(myTextVsemTotMarks6th, 298, 100, 450, 230, 32, Element.ALIGN_LEFT);
            ctVsemTotMarks6th.Go();

            PdfContentByte cbVsemTotObtMarks6th = PdfWrtr.DirectContent;
            ColumnText ctVsemTotObtMarks6th = new ColumnText(cbVsemTotObtMarks6th);
            Phrase myTextVsemTotObtMarks6th = new Phrase(lblOBMArks6.Text);
            ctVsemTotObtMarks6th.SetSimpleColumn(myTextVsemTotObtMarks6th, 298, 100, 450, 220, 34, Element.ALIGN_LEFT);
            ctVsemTotObtMarks6th.Go();


            PdfContentByte cbVGrandTot = PdfWrtr.DirectContent;
            ColumnText ctVGrandTot = new ColumnText(cbVGrandTot);
            Phrase myTextVGrandTot = new Phrase(lblGTot.Text);
            ctVGrandTot.SetSimpleColumn(myTextVGrandTot, 340, 100, 450, 230, 32, Element.ALIGN_LEFT);
            ctVGrandTot.Go();

            PdfContentByte cbVGrandObt = PdfWrtr.DirectContent;
            ColumnText ctVGrandObt = new ColumnText(cbVGrandObt);
            Phrase myTextVGrandObt = new Phrase(lblGObtTot.Text);
            ctVGrandObt.SetSimpleColumn(myTextVGrandObt, 340, 100, 450, 220, 34, Element.ALIGN_LEFT);
            ctVGrandObt.Go();
            double percentage = 0.00;
            double gt = Convert.ToDouble(lblGTot.Text);
            double gto = Convert.ToDouble(lblGObtTot.Text);
            double temp1 = gto * 100;
            percentage = temp1 / gt;
            string res = "";
            if(percentage>=40)
            {
                res = "Passed";
            }
            else
            {
                res = "Fail";
            }
            PdfContentByte cbResult = PdfWrtr.DirectContent;
            ColumnText ctResult = new ColumnText(cbResult);
            Phrase myTextResult = new Phrase(res);
            ctResult.SetSimpleColumn(myTextResult, 410, 100, 470, 230, 33, Element.ALIGN_LEFT);
            ctResult.Go();

            

            PdfContentByte cbPercentage = PdfWrtr.DirectContent;
            ColumnText ctPercentage = new ColumnText(cbPercentage);
            Phrase myTextPercentage = new Phrase(Convert.ToString(percentage.ToString("0.00"))+"%");
            ctPercentage.SetSimpleColumn(myTextPercentage, 490, 100, 540, 230, 33, Element.ALIGN_LEFT);
            ctPercentage.Go();

            DateTime vdtd = Convert.ToDateTime(lblDate.Text);
            string vdate = vdtd.ToString("dd/MM/yyyy");

            PdfContentByte cbVDate = PdfWrtr.DirectContent;
            ColumnText ctVDate = new ColumnText(cbVDate);
            Phrase myTextVDate = new Phrase(vdate);
            ctVDate.SetSimpleColumn(myTextVDate, 51, 153, 340, 50, 42, Element.ALIGN_LEFT);
            ctVDate.Go();

            
            string name = lblStudentName.Text;
            string code = Session["ID"].ToString();

            saveBarCode(name +"-"+ code + ".png", "https://www.npcvb.com/ViewStudentDetails.aspx?SID=" + lblEnrollmentNumber.Text);
            string imageBarPath = Server.MapPath(ResolveUrl("~/StudentBarcode/" + lblStudentName.Text + "-" + code + ".png"));
            iTextSharp.text.Image barImage = iTextSharp.text.Image.GetInstance(imageBarPath);
            barImage.ScaleToFit(70, 50);
            barImage.SetAbsolutePosition(120, 90);

            string imgVerifiedPath = Server.MapPath(ResolveUrl("~/images/NCVB-removebg-preview.png"));
            iTextSharp.text.Image imgVer = iTextSharp.text.Image.GetInstance(imgVerifiedPath);
            imgVer.ScaleToFit(90, 60);
            imgVer.SetAbsolutePosition(430, 515);

            string imageStuPath = Server.MapPath(ResolveUrl("~/Student-Image/" + imgStudentImg.Text));
            string imageSignPath = Server.MapPath(ResolveUrl("~/Image/SignatureCertificate.png"));
            iTextSharp.text.Image stuImage = iTextSharp.text.Image.GetInstance(imageStuPath);
            iTextSharp.text.Image signImage = iTextSharp.text.Image.GetInstance(imageSignPath);
            stuImage.ScaleToFit(108, 130);
            stuImage.SetAbsolutePosition(465, 515);
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

            signImage.ScaleToFit(60, 80);
            signImage.SetAbsolutePosition(480, 97);
            string imageSignCenterPath = Server.MapPath(ResolveUrl("~/Center-Document/" + imgCenterSign.Text));
            iTextSharp.text.Image CenterSign = iTextSharp.text.Image.GetInstance(imageSignCenterPath);
            CenterSign.ScaleToFit(80, 100);
            CenterSign.SetAbsolutePosition(220, 125);

            string imageSignPathMan = Server.MapPath(ResolveUrl("~/images/MANDASHIYA PNG FILE SINGH.png"));
            iTextSharp.text.Image signImageMan = iTextSharp.text.Image.GetInstance(imageSignPathMan);

            signImageMan.ScaleToFit(80, 60);
            signImageMan.SetAbsolutePosition(350, 97);
            pdfDoc.Add(jpg);
          
            pdfDoc.Add(stuImage);
            pdfDoc.Add(imgVer);
            pdfDoc.Add(Vsem);
            pdfDoc.Add(vExamination);
            pdfDoc.Add(vRollNumber);
            pdfDoc.Add(VEnrolmentNumber);
            pdfDoc.Add(vStudentName);
            pdfDoc.Add(vFatherName);
            pdfDoc.Add(vMotherName);
            
            pdfDoc.Add(vCourse);
            pdfDoc.Add(vCenter);

            pdfDoc.Add(tbl);
            pdfDoc.Add(tblp);
            
            pdfDoc.Add(barImage);
            pdfDoc.Add(signImage);
            pdfDoc.Add(signImageMan);
            pdfDoc.Add(CenterSign);

            pdfDoc.Close();

            Response.Write(pdfDoc);

            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void BtnNoc_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=CertificateNOC"+lblStudentName.Text+DateTime.Now.ToShortDateString()+".pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string imageFilePath = Server.MapPath(".") + "/templateImage/1.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
           
            Document pdfDoc = new Document();
           
            jpg.ScaleAbsolute(595, 842);
          
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
       
            jpg.SetAbsolutePosition(0, 0);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.NewPage();

            string[] split = lblSpace.Text.Split('-');
            string mm =split[0];
            string yy = split[1];
            Paragraph vRefnumber = new Paragraph("2001/NPCVB/NOC/"+ yy);
            vRefnumber.Alignment = Element.ALIGN_LEFT;
            vRefnumber.Font = FontFactory.GetFont("Arial", 16);
            vRefnumber.IndentationLeft = 75;
            vRefnumber.SpacingBefore = 186;

            string iDate = lblDate.Text;
            DateTime oDate = Convert.ToDateTime(iDate);
            string fdate = oDate.AddDays(8).ToString("dd/MM/yyyy");

            Paragraph vdate = new Paragraph(fdate);
            vdate.Alignment = Element.ALIGN_LEFT;
            vdate.Font.Size = 8;
            vdate.IndentationLeft = 480;
            vdate.SpacingBefore = -13;

            Paragraph vStudentName = new Paragraph(lblStudentName.Text.ToUpper());
            vStudentName.Alignment = Element.ALIGN_LEFT;
            vStudentName.Font = FontFactory.GetFont("Arial", 16);
            vStudentName.IndentationLeft = 170;
            vStudentName.SpacingBefore = 205;

            //iTextSharp.text.Font arial = FontFactory.GetFont("Arial", 12, iTextSharp.text.BaseColor.BLACK);


            Paragraph vFatherName = new Paragraph(lblFathersName.Text.ToUpper());
            vFatherName.Alignment = Element.ALIGN_LEFT;

            vFatherName.IndentationLeft = 170;
            vFatherName.SpacingBefore = 13;

            Paragraph vMotherName = new Paragraph(lblMothersName.Text);
            vMotherName.Alignment = Element.ALIGN_LEFT;
            vMotherName.IndentationLeft = 170;
            vMotherName.SpacingBefore = 10;

            Paragraph vDOB = new Paragraph(lblDOB.Text);
            vDOB.Font = FontFactory.GetFont("Arial", 16);
            vDOB.IndentationLeft = 170;
            vDOB.SpacingBefore = 10;

            Paragraph VEnrolmentNumber = new Paragraph(lblEnrollmentNumber.Text);
            VEnrolmentNumber.Font = FontFactory.GetFont("Arial", 16);
            VEnrolmentNumber.IndentationLeft = 170;
            VEnrolmentNumber.SpacingBefore = 8;
            
            Paragraph vSession = new Paragraph(lblCourseName.Text);
            vSession.Font = FontFactory.GetFont("Arial", 16);
            vSession.IndentationLeft = 170;
            vSession.SpacingBefore = 6;

            Paragraph vCourse = new Paragraph(lblDuration.Text);
            vCourse.Font = FontFactory.GetFont("Arial", 14);
            vCourse.IndentationLeft = 170;
            vCourse.SpacingBefore = 22;

            Paragraph vCenter = new Paragraph(lblCenterName.Text);
            vCenter.Font = FontFactory.GetFont("Arial", 14);
            vCenter.IndentationLeft = 170;
            vCenter.SpacingBefore = 25;



          
            string imageSignPath = Server.MapPath(ResolveUrl("~/Image/SignatureCertificate.png"));
          
            iTextSharp.text.Image signImage = iTextSharp.text.Image.GetInstance(imageSignPath);
           
            signImage.ScaleToFit(80, 60);
            signImage.SetAbsolutePosition(440, 40);

            pdfDoc.Add(jpg);
            pdfDoc.Add(vRefnumber);
            pdfDoc.Add(vdate);
            pdfDoc.Add(vStudentName);
            pdfDoc.Add(vFatherName);
            pdfDoc.Add(vMotherName);
            pdfDoc.Add(vDOB);
            pdfDoc.Add(VEnrolmentNumber);
           
            pdfDoc.Add(vSession);
            pdfDoc.Add(vCourse);
            pdfDoc.Add(vCenter);
            pdfDoc.Add(signImage);
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