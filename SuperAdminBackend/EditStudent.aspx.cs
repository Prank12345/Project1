using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_EditStudent : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loadDropdown();
            loadData();
        }
    }
    protected void loadDropdown()
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
   
    protected void loadData()
    {
        string strGetdata = "select * from AddStudent where id=@id" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", Request.QueryString["SID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(strGetdata,Pram);
        hfID.Value = ds.Tables[0].Rows[0]["StudentID"].ToString();
        ddlcourse.Items.FindByValue(ds.Tables[0].Rows[0]["Course"].ToString()).Selected = true;
        txtfee.Text = ds.Tables[0].Rows[0]["CourseFee"].ToString();
        txtsname.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        txtfhname.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
        txtdob.Text = ds.Tables[0].Rows[0]["DateOfbirth"].ToString();
        txtFOccupation.Text = ds.Tables[0].Rows[0]["FatherOccupation"].ToString();
        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        ddid.Items.FindByValue(ds.Tables[0].Rows[0]["IDType"].ToString()).Selected = true;
        txtidnum.Text = ds.Tables[0].Rows[0]["IDNumber"].ToString();
        txtphone.Text = ds.Tables[0].Rows[0]["StudentPhone"].ToString();
        txtemail.Text = ds.Tables[0].Rows[0]["StudentEmail"].ToString();
        txtsessionfrom.Text = ds.Tables[0].Rows[0]["SessionFrom"].ToString();
        txtsessionto.Text = ds.Tables[0].Rows[0]["SessionTo"].ToString();
        txtExamFees.Text = ds.Tables[0].Rows[0]["ExamFees"].ToString();
        txtRegisFees.Text = ds.Tables[0].Rows[0]["RegFees"].ToString(); 
        ddlInsMode.SelectedItem.Text=ds.Tables[0].Rows[0]["Instruction"].ToString();
        ddlMedium.SelectedItem.Text = ds.Tables[0].Rows[0]["LangMed"].ToString();
        ddlCasteCat.SelectedItem.Text = ds.Tables[0].Rows[0]["CasteCategory"].ToString();
        ddlCate.SelectedItem.Text = ds.Tables[0].Rows[0]["Category"].ToString();
        txtSOccupation.Text = ds.Tables[0].Rows[0]["StudentOccupation"].ToString();
        txtEmergency.Text = ds.Tables[0].Rows[0]["EmergencyNumber"].ToString();
        txtMName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
        ddlInitial.SelectedItem.Text = ds.Tables[0].Rows[0]["Initials"].ToString();
        txtBoardU10.Text = ds.Tables[0].Rows[0]["Boardu10"].ToString();
        txtPassU10.Text = ds.Tables[0].Rows[0]["PassU10"].ToString();
        txtMarksU10.Text = ds.Tables[0].Rows[0]["MarksU10"].ToString();
        txtPercentageU10.Text = ds.Tables[0].Rows[0]["PercentU10"].ToString();

        txtBoard10.Text = ds.Tables[0].Rows[0]["Board10"].ToString();
        txtPass10.Text = ds.Tables[0].Rows[0]["Pass10"].ToString();
        txtMarks10.Text = ds.Tables[0].Rows[0]["Marks10"].ToString();
        txtPer10.Text = ds.Tables[0].Rows[0]["Percent10"].ToString();

        txtBoard12.Text = ds.Tables[0].Rows[0]["Board12"].ToString();
        txtPass12.Text = ds.Tables[0].Rows[0]["Pass12"].ToString();
        txtMarks12.Text = ds.Tables[0].Rows[0]["Marks12"].ToString();
        txtPer12.Text = ds.Tables[0].Rows[0]["Percent12"].ToString();

        txtBoardGrad.Text = ds.Tables[0].Rows[0]["BoardGrad"].ToString();
        txtPassGrad.Text = ds.Tables[0].Rows[0]["PassGrad"].ToString();
        txtMarksGrad.Text = ds.Tables[0].Rows[0]["MarksGrad"].ToString();
        txtPerGrad.Text = ds.Tables[0].Rows[0]["PercentGrad"].ToString();

        txtBoardPG.Text = ds.Tables[0].Rows[0]["BoardPG"].ToString();
        txtPassPG.Text = ds.Tables[0].Rows[0]["PassPG"].ToString();
        txtMarksPG.Text = ds.Tables[0].Rows[0]["MarksPG"].ToString();
        txtPerPG.Text = ds.Tables[0].Rows[0]["PercentPG"].ToString();

        lblStuImg.Text = ds.Tables[0].Rows[0]["StudentImage"].ToString();
        lblMarks.Text = ds.Tables[0].Rows[0]["Marksheet"].ToString();
        lblidImg.Text = ds.Tables[0].Rows[0]["IDImage"].ToString();
        lblPayScreen.Text = ds.Tables[0].Rows[0]["PaymentScreenshot"].ToString();

        imgStuimg.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
        imgMarksheet.ImageUrl = "~/Marksheet/" + ds.Tables[0].Rows[0]["Marksheet"].ToString();
        imgID.ImageUrl = "~/ID-Image/" + ds.Tables[0].Rows[0]["IDImage"].ToString();
        imgPay.ImageUrl = "~/Payment-Screenshot/" + ds.Tables[0].Rows[0]["PaymentScreenshot"].ToString();
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
        
        string StudentImage = "";
        if (fustdimg.HasFile)
        {
            StudentImage =hfID.Value+ fustdimg.FileName;
            fustdimg.SaveAs(Server.MapPath("~/Student-Image/" + StudentImage));
           
        }
        else
        {
            StudentImage = lblStuImg.Text;
        }
        string Marksheet = "";
        if (fumarkst.HasFile)
        {
            Marksheet =hfID.Value+ fumarkst.FileName;
            fumarkst.SaveAs(Server.MapPath("~/Marksheet/" + Marksheet));
            
        }
        else
        {
            Marksheet = lblMarks.Text;
        }
        string IDImage = "";
        if (fuidimage.HasFile)
        {
            IDImage =hfID.Value+ fuidimage.FileName;
            fuidimage.SaveAs(Server.MapPath("~/ID-Image/" + IDImage));
            
        }
        else
        {
            IDImage = lblidImg.Text;
        }
        string PaymentScreenshot = "";
        if (fupscreen.HasFile)
        {
            PaymentScreenshot = hfID.Value + fupscreen.FileName;
            fupscreen.SaveAs(Server.MapPath("~/Payment-Screenshot/" + PaymentScreenshot));
            
        }
        else
        {
            PaymentScreenshot = lblPayScreen.Text;
        }
        string strUpdateQry = "Update AddStudent Set Course=@Course,CourseFee=@CourseFee,StudentName=@StudentName,FatherHusbandName=@FatherHusbandName,Gender=@Gender,DateOfbirth=@DateOfBirth,FatherOccupation=@FatherOccupation,Address=@Address,IDType=@IDType,IDNumber=@IDNumber,StudentPhone=@StudentPhone,StudentEmail=@StudentEmail,SessionFrom=@SessionFrom,SessionTo=@SessionTo,StudentImage=@StudentImage,IDImage=@IDImage,Marksheet=@Marksheet,PaymentScreenshot=@PaymentScreenshot,ExamFees=@ExamFees,RegFees=@RegFees,Instruction=@Instruction,LangMed=@LangMed,CasteCategory=@CasteCategory,Category=@Category,StudentOccupation=@StudentOccupation,EmergencyNumber=@EmergencyNumber,MotherName=@MotherName,Initials=@Initials,Boardu10=@Boardu10,PassU10=@PassU10,MarksU10=@MarksU10,PercentU10=@PercentU10,Board10=@Board10,Board12=@Board12,BoardGrad=@BoardGrad,BoardPG=@BoardPG,Pass10=@Pass10,Pass12=@Pass12,PassGrad=@PassGrad,PassPG=@PassPG,Marks10=@Marks10,Marks12=@Marks12,MarksGrad=@MarksGrad,MarksPG=@MarksPG,Percent10=@Percent10,Percent12=@Percent12,PercentGrad=@PercentGrad,PercentPG=@PercentPG where id=@id";

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
        Pram.Add(new SqlParameter("@id", Request.QueryString["SID"]));
        DBT.P_ExecuteNonQuery(strUpdateQry, Pram);
       
        Response.Redirect("StudentList.aspx");
    }

    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "select * from Courses where id=@id";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", ddlcourse.SelectedValue));
        DataSet Fees = DBT.P_returnDataSet(str,Pram);
        txtfee.Text = Fees.Tables[0].Rows[0]["ProgFeesUniv"].ToString();
        txtRegisFees.Text = Fees.Tables[0].Rows[0]["RegFeesUniv"].ToString();
        txtShortName.Text = Fees.Tables[0].Rows[0]["ShortName"].ToString();
        txtDuration.Text = Fees.Tables[0].Rows[0]["Duration"].ToString();
        string strGet = "select * from Semesters where CourseID=@ID";
        DataSet dsFees = DBT.P_returnDataSet(strGet,Pram);
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