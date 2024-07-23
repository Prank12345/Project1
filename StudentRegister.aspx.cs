using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentRegister : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load();
        }
    }
    protected void load()
    {
        string str = "select id,FullCourseName from Courses";
        DataSet ds = DBT.returnDataSet(str);
        ddlcourse.DataSource = ds;
        ddlcourse.DataMember = ds.Tables[0].TableName;
        ddlcourse.DataTextField = "FullCourseName";
        ddlcourse.DataValueField = "id";
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("--Select Course--", "0"));

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        string Course = ddlcourse.SelectedValue;
        string CourseFee = txtfee.Text;
        string StudentName = txtsname.Text;
        string FatherHusbandName = txtfhname.Text;
        string Gender = rbgender.SelectedValue;
        string DateOfBirth = txtdob.Text;
        string vFatherOccupation = txtFOccupation.Text;
        string Address = txtaddress.Text;
        string IDType = ddid.SelectedValue;
        string IDNumber = txtidnum.Text;
        string StudentPhone = txtphone.Text;
        string StudentEmail = txtemail.Text;
        string SessionFrom = txtsessionfrom.Text;
        string SessionTo = txtsessionto.Text;

        string ExamFees = txtExamFees.Text;
        string regFees = txtRegisFees.Text;
        string InsMode = ddlInsMode.SelectedItem.Text;
        string Medium = ddlMedium.SelectedItem.Text;
        string vCaste = ddlCasteCat.SelectedItem.Text;
        string vCategory = ddlCate.SelectedItem.Text;
        string vStudentOccupation = txtSOccupation.Text;
        string vEmergencyNumber = txtEmergency.Text;
        string vMotherName = txtMName.Text;
        string vInitials = ddlInitial.SelectedItem.Text;
        string vBoardu10 = txtBoardU10.Text;
        string vPassU10 = txtPassU10.Text;
        string vMarksU10 = txtMarksU10.Text;
        string vPercentU10 = txtPercentageU10.Text;

        string vBoard10 = txtBoard10.Text;
        string vPass10 = txtPass10.Text;
        string vMarks10 = txtMarks10.Text;
        string vPercent10 = txtPer10.Text;

        string vBoard12 = txtBoard12.Text;
        string vPass12 = txtPass12.Text;
        string vMarks12 = txtMarks12.Text;
        string vPercent12 = txtPer12.Text;

        string vBoardGrad = txtBoardGrad.Text;
        string vPassGrad = txtPassGrad.Text;
        string vMarksGrad = txtMarksGrad.Text;
        string vPercentgrad = txtPerGrad.Text;

        string vBoardPG = txtBoardPG.Text;
        string vPassPG = txtPassPG.Text;
        string vMarksPG = txtMarksPG.Text;
        string vPercentPG = txtPerPG.Text;

        string StudentID = "";
        string GetID = "select * from AddStudent";
        DataSet ds = DBT.returnDataSet(GetID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Get = DBT.returnOneValue("select Max(ID) from AddStudent");
            int x = 2001;
            int newid = x + Convert.ToInt32(Get);
            StudentID = "NPCVB" + DateTime.Now.Year + Convert.ToString(newid);
        }
        else
        {
            StudentID = "NBCVB" + DateTime.Now.Year + "2001";
        }
        string Marksheet = "";
        if (fumarkst.HasFile)
        {
            Marksheet = StudentID + fumarkst.FileName;
            fumarkst.SaveAs(Server.MapPath("~/Marksheet/" + Marksheet));

        }
        string IDImage = "";
        if (fuidimage.HasFile)
        {
            IDImage = StudentID + fuidimage.FileName;
            fuidimage.SaveAs(Server.MapPath("~/ID-Image/" + IDImage));
        }
        string PaymentScreenshot = "";        
        string Cid = "0";
         
            string StudentImage = "";

        if (fustdimg.HasFile)
        {
            StudentImage = StudentID + fustdimg.FileName;
            fustdimg.SaveAs(Server.MapPath("~/Student-Image/" + StudentImage));
            System.Drawing.Image img = System.Drawing.Image.FromStream(fustdimg.PostedFile.InputStream);
            int height = img.Height;
            int width = img.Width;
            int size = fustdimg.PostedFile.ContentLength;
            string dimension = width.ToString() + "*" + height.ToString();
            if (dimension == "200*200")
            {
                string strInsertQry = "insert into AddStudent(Course,CourseFee,StudentName,FatherHusbandName,Gender,DateOfbirth,FatherOccupation,Address,IDType,IDNumber,StudentPhone,StudentEmail,SessionFrom,SessionTo,StudentImage,Marksheet,IDImage,PaymentScreenshot,Cid,isrequest,isdisplay,StudentID,IsCertificateRequest,IsMarksheetRequest,ExamFees,RegFees,Instruction,LangMed,CasteCategory,Category,StudentOccupation,EmergencyNumber,MotherName,Initials,Boardu10,PassU10,MarksU10,PercentU10,Board10,Board12,BoardGrad,BoardPG,Pass10,Pass12,PassGrad,PassPG,Marks10,Marks12,MarksGrad,MarksPG,Percent10,Percent12,PercentGrad,PercentPG,isDirect) Values(@Course,@CourseFee,@StudentName,@FatherHusbandName,@Gender,@DateOfBirth,@FatherOccupation,@Address,@IDType,@IDNumber,@StudentPhone,@StudentEmail,@SessionFrom,@SessionTo,@StudentImage,@Marksheet,@IDImage,@PaymentScreenshot,@Cid,@isrequest,@isdisplay,@StudentID,@IsCertificateRequest,@IsMarksheetRequest,@ExamFees,@RegFees,@Instruction,@LangMed,@CasteCategory,@Category,@StudentOccupation,@EmergencyNumber,@MotherName,@Initials,@Boardu10,@PassU10,@MarksU10,@PercentU10,@Board10,@Board12,@BoardGrad,@BoardPG,@Pass10,@Pass12,@PassGrad,@PassPG,@Marks10,@Marks12,@MarksGrad,@MarksPG,@Percent10,@Percent12,@PercentGrad,@PercentPG,@isDirect)";

                List<SqlParameter> Pram = new List<SqlParameter>();
                Pram.Add(new SqlParameter("@Course", Course));
                Pram.Add(new SqlParameter("@CourseFee", CourseFee));
                Pram.Add(new SqlParameter("@StudentName", StudentName));
                Pram.Add(new SqlParameter("@FatherHusbandName", FatherHusbandName));
                Pram.Add(new SqlParameter("@Gender", Gender));
                Pram.Add(new SqlParameter("@DateOfBirth", DateOfBirth));
                Pram.Add(new SqlParameter("@FatherOccupation", vFatherOccupation));
                Pram.Add(new SqlParameter("@Address", Address));
                Pram.Add(new SqlParameter("@IDType", IDType));
                Pram.Add(new SqlParameter("@IDNumber", IDNumber));
                Pram.Add(new SqlParameter("@StudentPhone", StudentPhone));
                Pram.Add(new SqlParameter("@StudentEmail", StudentEmail));
                Pram.Add(new SqlParameter("@SessionFrom", SessionFrom));
                Pram.Add(new SqlParameter("@SessionTo", SessionTo));
                Pram.Add(new SqlParameter("@StudentImage", StudentImage));
                Pram.Add(new SqlParameter("@Marksheet", Marksheet));
                Pram.Add(new SqlParameter("@IDImage", IDImage));
                Pram.Add(new SqlParameter("@PaymentScreenshot", PaymentScreenshot));
                Pram.Add(new SqlParameter("@Cid", Cid));
                Pram.Add(new SqlParameter("@isrequest", "0"));
                Pram.Add(new SqlParameter("@isdisplay", "1"));
                Pram.Add(new SqlParameter("@StudentID", StudentID));
                Pram.Add(new SqlParameter("@IsCertificateRequest", "0"));
                Pram.Add(new SqlParameter("@IsMarksheetRequest", "0"));
                Pram.Add(new SqlParameter("@ExamFees", ExamFees));
                Pram.Add(new SqlParameter("@RegFees", regFees));
                Pram.Add(new SqlParameter("@Instruction", InsMode));
                Pram.Add(new SqlParameter("@LangMed", Medium));
                Pram.Add(new SqlParameter("@CasteCategory", vCaste));
                Pram.Add(new SqlParameter("@Category", vCategory));
                Pram.Add(new SqlParameter("@StudentOccupation", vStudentOccupation));
                Pram.Add(new SqlParameter("@EmergencyNumber", vEmergencyNumber));
                Pram.Add(new SqlParameter("@MotherName", vMotherName));
                Pram.Add(new SqlParameter("@Initials", vInitials));
                Pram.Add(new SqlParameter("@Boardu10", vBoardu10));
                Pram.Add(new SqlParameter("@PassU10", vPassU10));
                Pram.Add(new SqlParameter("@MarksU10", vMarksU10));
                Pram.Add(new SqlParameter("@PercentU10", vPercentU10));
                Pram.Add(new SqlParameter("@Board10", vBoard10));
                Pram.Add(new SqlParameter("@Board12", vBoard12));
                Pram.Add(new SqlParameter("@BoardGrad", vBoardGrad));
                Pram.Add(new SqlParameter("@BoardPG", vBoardPG));
                Pram.Add(new SqlParameter("@Pass10", vPass10));
                Pram.Add(new SqlParameter("@Pass12", vPass12));
                Pram.Add(new SqlParameter("@PassGrad", vPassGrad));
                Pram.Add(new SqlParameter("@PassPG", vPassPG));
                Pram.Add(new SqlParameter("@Marks10", vMarks10));
                Pram.Add(new SqlParameter("@Marks12", vMarks12));
                Pram.Add(new SqlParameter("@MarksGrad", vMarksGrad));
                Pram.Add(new SqlParameter("@MarksPG", vMarksPG));
                Pram.Add(new SqlParameter("@Percent10", vPercent10));
                Pram.Add(new SqlParameter("@Percent12", vPercent12));
                Pram.Add(new SqlParameter("@PercentGrad", vPercentgrad));
                Pram.Add(new SqlParameter("@PercentPG", vPercentPG));
                Pram.Add(new SqlParameter("@isDirect", "1"));
                DBT.P_ExecuteNonQuery(strInsertQry, Pram);

                Response.Write("<script language='javascript'>window.alert('Student added Successfully. Verification is Pending.');window.location='Default.aspx';</script>");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Insert Passport size image with dimension 200*200 ');", true);

            }

        }          

    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "select * from Courses where id=@id";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@id", ddlcourse.SelectedValue));
        DataSet Fees = DBT.P_returnDataSet(str, Pr);
        txtfee.Text = Fees.Tables[0].Rows[0]["ProgFeesUniv"].ToString();
        txtRegisFees.Text = Fees.Tables[0].Rows[0]["RegFeesUniv"].ToString();
        txtShortName.Text = Fees.Tables[0].Rows[0]["ShortName"].ToString();
        txtDuration.Text = Fees.Tables[0].Rows[0]["Duration"].ToString();
        string strGet = "select * from Semesters where CourseID=@id";
        DataSet dsFees = DBT.P_returnDataSet(strGet, Pr);
        double fees = 0;
        for (int i = 0; i < dsFees.Tables[0].Rows.Count; i++)
        {
            fees = fees + Convert.ToDouble(dsFees.Tables[0].Rows[i]["ExamFees"].ToString());
        }
        txtExamFees.Text = fees.ToString();
        string sems = Convert.ToString(dsFees.Tables[0].Rows.Count);
        txtTotSem.Text = sems;
    }
}