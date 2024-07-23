using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class StudentVerification : System.Web.UI.Page
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
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        if(ds.Tables[0].Rows.Count>0)
        {
            
            divResShow.Visible = false;
            divShow.Visible = true;
            vCID = ds.Tables[0].Rows[0]["Cid"].ToString();
            string vCTID= ds.Tables[0].Rows[0]["CTID"].ToString();
            List<SqlParameter> pr1 = new List<SqlParameter>();
            pr1.Add(new SqlParameter("@ID", vCTID));
            string vCourseType = DBT.P_returnOneValue("select CourseType from CourseType where ID=@ID", pr1);

            lblName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblMName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
            lblGen.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
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
            imgStudent.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
           
            lblCName.Text = dscen.Tables[0].Rows[0]["InstituteName"].ToString()+ dscen.Tables[0].Rows[0]["Address"].ToString();
          
            lblCourse.Text = ds.Tables[0].Rows[0]["FullCourseName"].ToString();
          
            lblCTime.Text= ds.Tables[0].Rows[0]["Duration"].ToString();
            string psy = ds.Tables[0].Rows[0]["SessionTo"].ToString();
            string[] splitpsy = psy.Split('-');
            
            //lblPassYear.Text = splitpsy[0].ToString();

        }
        else
        {
            Response.Write("<script>alert('No data Found');</script>");
        }
       
    }

    protected void btnResult_Click(object sender, EventArgs e)
    {
        string vSearchID = txtStudentID.Text;
        string strGetData = "select * from AddStudent ast join CenterRegistration cr on ast.Cid=cr.id join Courses ac on ast.Course=ac.id where ast.StudentID =@StudentID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentID", vSearchID));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        string vid = ds.Tables[0].Rows[0]["ID"].ToString();
        string vCourseid = ds.Tables[0].Rows[0]["Course"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            divResShow.Visible = true;
            divShow.Visible = false;
            lblCeNm.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
            lblCoNm.Text = ds.Tables[0].Rows[0]["FullCourseName"].ToString();
            string GetResult = "select top 1 * from SemesterResult where StuID=@StuID order by id desc";
            List<SqlParameter> prnew = new List<SqlParameter>();
            prnew.Add(new SqlParameter("@StuID", vid));
            
            DataSet dsnew = DBT.P_returnDataSet(GetResult, prnew);
            if(dsnew.Tables[0].Rows.Count>0)
            {
                sem.Visible = true;
                string semID = dsnew.Tables[0].Rows[0]["SemID"].ToString();

                List<SqlParameter> prsem = new List<SqlParameter>();
                prsem.Add(new SqlParameter("@SemID", semID));
                prsem.Add(new SqlParameter("@StuID", vid));
                string SubCount = DBT.P_returnOneValue("select count(ID) from Result where SemID=@SemID and StuID=@StuID", prsem);
                int count = Convert.ToInt32(SubCount);
                double totMarks = count * 100;

                lblTotalMarks.Text = Convert.ToString(totMarks);
                lblMarks.Text = dsnew.Tables[0].Rows[0]["TotalMarks"].ToString();

                double marksobt = Convert.ToDouble(lblMarks.Text);
                double avg = (marksobt * 100 / totMarks);
                if (avg > 40)
                {
                    lblResult.Text = "Pass";
                    lblResult.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblResult.Text = "Fail";
                    lblResult.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                sem.Visible = false;
                lblResult.Text = "Please Give Exams";
            }
           
        }
    }
}