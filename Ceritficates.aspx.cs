using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Ceritficates : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string vCID = "";
        string strGetData = "select * from AddStudent ast join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID and IsRequest=1";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
        if (ds.Tables[0].Rows.Count > 0)
        {            
            divShow.Visible = true;
            vCID = ds.Tables[0].Rows[0]["Cid"].ToString();
            string vCTID = ds.Tables[0].Rows[0]["CTID"].ToString();
            List<SqlParameter> pr1 = new List<SqlParameter>();
            pr1.Add(new SqlParameter("@ID", vCTID));
            string vCourseType = DBT.P_returnOneValue("select CourseType from CourseType where ID=@ID", pr1);
            dv.Style["background-image"] = "Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
            dv.Style["background-repeat"] = "no-repeat";
            //dv.Style["background-size"] = "cover";
            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblMName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
            //lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            lblDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            lblIdProof.Text = ds.Tables[0].Rows[0]["IDType"].ToString();
            lblIDNum.Text = ds.Tables[0].Rows[0]["IDNumber"].ToString();
            lblEnNum.Text = txtStudentID.Text;
            lblEnDate.Text = ds.Tables[0].Rows[0]["SessionFrom"].ToString();
            lblStatus.Text = "Verified";
            string strGetCenter = "select * from CenterRegistration where ID=@ID";
            List<SqlParameter> prn = new List<SqlParameter>();
            prn.Add(new SqlParameter("@ID", vCID));
            DataSet dscen = DBT.P_returnDataSet(strGetCenter, prn);
            lblAcDev.Text = vCourseType;
           // imgStudent.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();

            lblCName.Text = dscen.Tables[0].Rows[0]["InstituteName"].ToString() + dscen.Tables[0].Rows[0]["Address"].ToString();

            lblCourse.Text = ds.Tables[0].Rows[0]["FullCourseName"].ToString();

            lblCTime.Text = ds.Tables[0].Rows[0]["Duration"].ToString();
            string psy = ds.Tables[0].Rows[0]["SessionTo"].ToString();
            string[] splitpsy = psy.Split('-');

            //lblPassYear.Text = splitpsy[0].ToString();


            //if (countnum== ts)
            //{
            //    lblShow.Text = "Certificate Generated";
            //    lblShow.ForeColor = Color.Green;

            //}   
            //else
            //{
            //    lblShow.Text = "Course Is Not Completed Yet";
            //    lblShow.ForeColor = Color.Orange;
            //}         

            string vID = ds.Tables[0].Rows[0]["ID"].ToString();
            string vCoID= ds.Tables[0].Rows[0]["Course"].ToString();
            string subList = "select * from Semesters where CourseID=@CourseID";
            List<SqlParameter> sqp = new List<SqlParameter>();
            sqp.Add(new SqlParameter("@CourseID", vCoID));
            DataSet DSSem = DBT.P_returnDataSet(subList,sqp);
            string subject = "";
            //string[] splitsub = {""};
            int length = 0;
            for(int i=0;i<DSSem.Tables[0].Rows.Count;i++)
            {
                subject = DSSem.Tables[0].Rows[i]["Subjects"].ToString();
                string[] splitsub = subject.Split(',');
                int len = splitsub.Length;
                length = length + len;
            }
            string GettotalResult = "select * from SemesterResult where StuID=@StuID";
            List<SqlParameter> prn1 = new List<SqlParameter>();
            prn1.Add(new SqlParameter("@StuID", vID));
           
            DataSet DSN = DBT.P_returnDataSet(GettotalResult, prn1);
            double marks = 0.00;
            int totalmarks = length*100;

            for (int i=0;i<DSN.Tables[0].Rows.Count;i++)
            {
                marks = marks + Convert.ToDouble(DSN.Tables[0].Rows[0]["TotalMarks"].ToString());
            }
            lblMarks.Text =marks.ToString()+"/"+totalmarks.ToString();

            double avg = marks / length;
            if(avg>40)
            {
                lblPass.Text = "Pass";
            }

        }            
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }

    }
    
}