using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_StudentRequestCertificate : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //loadStudent();
            // LoadExam();
           // LoadCourse();
            LoadGv();
            loadStudent();
        }
    }
   
    protected void loadStudent()
    {
        string CenterID = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            CenterID = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pram);
            CenterID = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string strGetData = "select * from AddStudent where Cid=@Cid";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@Cid", CenterID));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pr);
        ddlStudent.DataSource = ds;
        ddlStudent.DataMember = ds.Tables[0].TableName;
        ddlStudent.DataTextField = "StudentID";
        ddlStudent.DataValueField = "id";
        ddlStudent.DataBind();
        ddlStudent.Items.Insert(0, new ListItem("--Select Student--", "0"));
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", ddlSubject.SelectedValue));
        string selectCourse = DBT.P_returnOneValue("select CourseID from MainExam where ID=@ID",Pram);
    }
    
    
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadCourse();
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@id", ddlStudent.SelectedValue));
        string getCouseID = DBT.P_returnOneValue("select Course from AddStudent where id=@id",pr);
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@CourseID", getCouseID));
        string getdata = "select * from Semesters where CourseID=@CourseID";
        DataSet dsn = DBT.P_returnDataSet(getdata,pr1);
        ddlSemster.DataSource = dsn;
        ddlSemster.DataMember = dsn.Tables[0].TableName;
        ddlSemster.DataTextField = "Semester";
        ddlSemster.DataValueField = "ID";
        ddlSemster.DataBind();
        ddlSemster.Items.Insert(0, new ListItem("--Select Semester--", "0"));

        string GetData = "select * from AddStudent where Id=@Id";
        List<SqlParameter> pr2 = new List<SqlParameter>();
        pr2.Add(new SqlParameter("@Id", ddlStudent.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(GetData,pr2);
        txtstuname.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        string CourseID = "";
        CourseID = ds.Tables[0].Rows[0]["Course"].ToString();
        List<SqlParameter> pr3 = new List<SqlParameter>();
        pr3.Add(new SqlParameter("@id", CourseID));
        string GetCourseName = DBT.P_returnOneValue("select FullCourseName from Courses where id=@id",pr3);
        txtcourse.Text = GetCourseName;
        //string SemID = DBT.returnOneValue("select SemID from SetMainExam where EListid=" + ddlSubject.SelectedValue);
        //txtSem.Text = SemID;
    }
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ID", ddlSubject.SelectedValue));
        string strGetExamType =DBT.P_returnOneValue("select ExamType from MainExam where ID=@ID",pr);
        
        string vMArksObtained = txtmarks.Text;
        string vstudentID = ddlStudent.SelectedValue;
        string vSemID = ddlSemster.SelectedValue;
        string vExamID = ddlSubject.SelectedValue;
        string vMaxMarks = "";
        int vObtMrks = Convert.ToInt32(vMArksObtained);
        string vGr = "";
        if(strGetExamType== "Practical")
        {
            vMaxMarks = "100";
        }
        else if(strGetExamType== "Theory")
        {
            vMaxMarks = "70";
        }
        if(vObtMrks >= 40)
        {
            vGr = "P";
        }
        else
        {
            vGr = "F";
        }
        string InsertRes = "insert into Result (MaxMarks,ObtainedMarks,StuID,ExamID,IsDisplay,IsMarksheet,SemID,TotMaxMarks,TotMarksObtained,MinMarks,Grade) values(@MaxMarks,@ObtainedMarks,@StuID,@ExamID,@IsDisplay,@IsMarksheet,@SemID,@TotMaxMarks,@TotMarksObtained,@MinMarks,@Grade)";
        List<SqlParameter> Param = new List<SqlParameter>();
        Param.Add(new SqlParameter("@MaxMarks", vMaxMarks));
        Param.Add(new SqlParameter("@ObtainedMarks", vMArksObtained));
        Param.Add(new SqlParameter("@StuID", vstudentID));
        Param.Add(new SqlParameter("@ExamID", vExamID));
        Param.Add(new SqlParameter("@IsDisplay", "1"));
        Param.Add(new SqlParameter("@IsMarksheet", "1"));
        Param.Add(new SqlParameter("@SemID", vSemID));

        Param.Add(new SqlParameter("@TotMaxMarks", "100"));
        Param.Add(new SqlParameter("@TotMarksObtained", vMArksObtained));
        Param.Add(new SqlParameter("@MinMarks", "40"));
        Param.Add(new SqlParameter("@Grade", vGr));

        DBT.P_returnDataSet(InsertRes, Param);

        string updateqry = "update SetMainExam set IsExamGiven=@IsExamGiven where Sid=@Sid" ;
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@IsExamGiven", "1"));
        pr1.Add(new SqlParameter("@Sid", vstudentID));
        DBT.P_ExecuteNonQuery(updateqry,pr1);

        string updateStuqry = "update AddStudent set IsCertificateRequest=@IsCertificateRequest where id=@id";
        List<SqlParameter> pr2 = new List<SqlParameter>();
        pr2.Add(new SqlParameter("@IsCertificateRequest", "1"));
        pr2.Add(new SqlParameter("@id", vstudentID));
        DBT.P_ExecuteNonQuery(updateStuqry,pr2);

        LoadGv();
        txtmarks.Text = "";
        //ddlCourse.ClearSelection();
        //ddlSemster.ClearSelection();
        //ddlSubject.ClearSelection();
        //ddlStudent.ClearSelection();
        Response.Write("<script>alert('Your Student's External Marks Added');</script>");

    }
    protected void LoadGv()
    {
        string CenterID = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            CenterID = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> pr = new List<SqlParameter>();
            pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,pr);
            CenterID = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string strGetData = "select * from Result,AddStudent where AddStudent.id=result.stuID and Result.IsMarksheet=@IsMarksheet and AddStudent.Cid=@Cid order by Result.ID desc";
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@IsMarksheet", "1"));
        pr1.Add(new SqlParameter("@Cid", CenterID));
        gvCertificate.DataSource = DBT.P_returnDataSet(strGetData,pr1);
        gvCertificate.DataBind();
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {

        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCertificate.DataKeys[row.RowIndex].Value.ToString();
        
        string strUpd = "update Result set IsMarksheet=@IsMarksheet where ID=@ID";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@IsMarksheet", "0"));
        pr.Add(new SqlParameter("@ID", id));
        List<SqlParameter> pr1 = new List<SqlParameter>();        
        pr1.Add(new SqlParameter("@ID", id));
        string examID =DBT.P_returnOneValue("select ExamID from Result where ID= @ID",pr1);
        List<SqlParameter> pr2 = new List<SqlParameter>();
        pr2.Add(new SqlParameter("@ExamID", examID));
        string strDelete = "delete from StudentAnwers where ExamID =@ExamID" ;
        string strResDelete = "delete from Result where ID =@ID";

        List<SqlParameter> pr3 = new List<SqlParameter>();
        pr3.Add(new SqlParameter("@IsExamGiven", "0"));
        pr3.Add(new SqlParameter("@EListid", examID));

        string strUpdEx = "update SetMainExam set IsExamGiven=@IsExamGiven where EListid=@EListid" ;
        DBT.P_ExecuteNonQuery(strUpd,pr);

        DBT.P_ExecuteNonQuery(strDelete,pr2);
        DBT.P_ExecuteNonQuery(strUpdEx,pr3);
        DBT.P_ExecuteNonQuery(strResDelete,pr1);
        LoadGv();
    }

    protected void btnRequest_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCertificate.DataKeys[row.RowIndex].Value.ToString();
        string SemID = "select * from Result where ID= @ID";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ID", id));
        DataSet ds = DBT.P_returnDataSet(SemID,pr);
        string vSemID = ds.Tables[0].Rows[0]["SemID"].ToString();
        string vStuID = ds.Tables[0].Rows[0]["StuID"].ToString();
        string strUpd = "update Result set IsMarksheet=@IsMarksheet where SemID=@SemID and stuID=@stuID";
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@IsMarksheet","2"));
        pr1.Add(new SqlParameter("@SemID", vSemID));
        pr1.Add(new SqlParameter("@stuID", vStuID));
        DBT.P_ExecuteNonQuery(strUpd,pr1);

        List<SqlParameter> pr2 = new List<SqlParameter>();
       
        pr2.Add(new SqlParameter("@SemID", vSemID));
        pr2.Add(new SqlParameter("@Sid", vStuID));

        DataSet GetSemID = DBT.P_returnDataSet("select * from SetMainExam where SemID=@SemID and Sid=@Sid",pr2);
        string vCourseID = ""; 
        string vTotalMarks = "";
        string StuID = "";
        double totMarks = 0.00;
        string vFinalDate = "";
        DateTime vTemDate = DateTime.MinValue;
        for (int i=0;i<GetSemID.Tables[0].Rows.Count;i++)
        {
            vCourseID = GetSemID.Tables[0].Rows[i]["Cid"].ToString();
            string vID= GetSemID.Tables[0].Rows[i]["EListid"].ToString();
            StuID = GetSemID.Tables[0].Rows[i]["SID"].ToString();
            string vSubRes = "select * from Result where ExamID=@ExamID and stuID=@stuID" ;
            List<SqlParameter> pr3 = new List<SqlParameter>();
            pr3.Add(new SqlParameter("@ExamID", vID));
            pr3.Add(new SqlParameter("@stuID", StuID));
            DataSet SubjectRes = DBT.P_returnDataSet(vSubRes,pr3);
            string vOMarks = "";

            vOMarks = SubjectRes.Tables[0].Rows[0]["TotMarksObtained"].ToString();
            totMarks = totMarks + Convert.ToDouble(vOMarks);

            DateTime td=Convert.ToDateTime(GetSemID.Tables[0].Rows[i]["DateOfExam"].ToString());
            if(vTemDate<td)
            {
                vTemDate = td;
            }
            

                        
        }
        vFinalDate = vTemDate.AddDays(2).ToString("yyyy/MM/dd");
       // lblTest.Text = vFinalDate;

        string vDatest = vFinalDate;


        vTotalMarks = Convert.ToString(totMarks);
        string insertqry = "insert into SemesterResult(StuID,CoueseID,SemID,IsAllExamGiven,TotalMarks,IsMarksheet,PrintDate) values(@StuID,@CoueseID,@SemID,@IsAllExamGiven,@TotalMarks,@IsMarksheet,@PrintDate)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StuID", StuID));
        Pram.Add(new SqlParameter("@CoueseID", vCourseID));
        Pram.Add(new SqlParameter("@SemID", vSemID));
        Pram.Add(new SqlParameter("@IsAllExamGiven", "1"));
        Pram.Add(new SqlParameter("@TotalMarks", vTotalMarks));
        Pram.Add(new SqlParameter("@IsMarksheet", "2"));
        Pram.Add(new SqlParameter("@PrintDate", vDatest));
        DBT.P_ExecuteNonQuery(insertqry, Pram);

        string strUpdstu = "update AddStudent set IsCertificateRequest=@IsCertificateRequest where ID=@ID";
        List<SqlParameter> pr4 = new List<SqlParameter>();
        pr4.Add(new SqlParameter("@IsCertificateRequest", "0"));
        pr4.Add(new SqlParameter("@ID", vStuID));
        DBT.P_ExecuteNonQuery(strUpdstu,pr4);
        LoadGv();
    }
    

    protected void ddlSemster_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getdata = "select * from MainExam me join SetMainExam sme on me.ID=sme.EListid where semID=@semID and SID=@SID" ;
        List<SqlParameter> pr4 = new List<SqlParameter>();
        pr4.Add(new SqlParameter("@semID", ddlSemster.SelectedValue));
        pr4.Add(new SqlParameter("@SID", ddlStudent.SelectedValue));
        DataSet ds = DBT.P_returnDataSet(getdata,pr4);
        ddlSubject.DataSource = ds;
        ddlSubject.DataMember = ds.Tables[0].TableName;
        ddlSubject.DataTextField = "SubjectName";
        ddlSubject.DataValueField = "ID";
        ddlSubject.DataBind();
        ddlSubject.Items.Insert(0, new ListItem("--Select Exam--", "0"));
    }

}