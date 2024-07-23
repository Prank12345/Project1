using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_MainExamPaper : System.Web.UI.Page
{
    DBTrac DBt = new DBTrac();
    Wizard wizard1 = new Wizard();
   
    Label lblQues = new Label();

    protected void Page_Init(object sender, EventArgs e)
    {
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ExamID", Session["EID"].ToString()));
        DataSet ds = DBt.P_returnDataSet("select * from MainExQuestions where ExamID=@ExamID",Pr);
       
            wizard1.Style.Add("width", "100%");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int x = i + 1;
            WizardStep step1 = new WizardStep();
           
            PlaceHolder ph = new PlaceHolder();
            ph.ID = "ph" + x.ToString();
            lblQues.ID = "lblQues" + x.ToString();
            ph.Controls.Add(new LiteralControl("<h2 style='background-color:midnightblue; padding:10px; color:white;' class='polaroid'>" + "Question " + x.ToString() + ": " + ds.Tables[0].Rows[i]["Question"].ToString() + "</h1>"));
            ph.Controls.Add(lblQues);
            ph.Controls.Add(new LiteralControl("<br/>"));
           
            
                RadioButtonList rblist = new RadioButtonList();
                rblist.ID = "rblist" + i.ToString();
                rblist.RepeatDirection = RepeatDirection.Vertical;                
                rblist.Items.Add(new ListItem(ds.Tables[0].Rows[i]["Option1"].ToString(), "A"));
                rblist.Items.Add(new ListItem(ds.Tables[0].Rows[i]["Option2"].ToString(), "B"));
                rblist.Items.Add(new ListItem(ds.Tables[0].Rows[i]["Option3"].ToString(), "C"));
                rblist.Items.Add(new ListItem(ds.Tables[0].Rows[i]["Option4"].ToString(), "D"));
            rblist.Attributes.Add("margin", "50px;");
            rblist.CssClass = "rbl";
            ph.Controls.Add(rblist);
            
            ph.Controls.Add(new LiteralControl("<br/>"));
            step1.Controls.Add(ph);
            wizard1.WizardSteps.Add(step1);
        }
            wizard_container.Controls.Add(wizard1);
            wizard_container.Controls.Add(wizard1);
            wizard1.StartNextButtonStyle.CssClass = "btn-success btn button";
            wizard1.StepNextButtonStyle.CssClass = "btn-success btn button";
            wizard1.FinishPreviousButtonStyle.CssClass = "btn btn-warning button";
            wizard1.StepPreviousButtonStyle.CssClass = "btn btn-warning button";
            wizard1.StepPreviousButtonStyle.CssClass = "btn btn-warning button";
            wizard1.FinishCompleteButtonStyle.CssClass = "btn btn-success button";

            wizard1.FinishButtonClick += Wizard1_FinishButtonClickQues;
        
    }
    private void Wizard1_FinishButtonClickQues(object sender, WizardNavigationEventArgs e)
    {
       
        string strGetData = Session["SID"].ToString();
        string GetSemID = "select * from MainExam where ID=@ID" ;
        List<SqlParameter> PRm = new List<SqlParameter>();
        PRm.Add(new SqlParameter("@ID", Session["EID"].ToString()));
        DataSet dsSemID = DBt.P_returnDataSet(GetSemID,PRm);
        string SemID = dsSemID.Tables[0].Rows[0]["SemesterName"].ToString();

        string id = "select * from MainExQuestions where ExamID=@ID";

        DataSet ds = DBt.P_returnDataSet(id,PRm);
        int ch = ds.Tables[0].Rows.Count;
        string vMark = "";
        int j = 0;
        string Answer = "";
        string option = "";
        double marksobt = 0.00;
        foreach (WizardStep step in wizard1.WizardSteps)
        {
            RadioButtonList rbl = (RadioButtonList)step.FindControl("rblist" + j.ToString());
            option = rbl.SelectedValue.ToString();
            if (j < ch)
            {
                Answer = ds.Tables[0].Rows[j]["CorrectAnswer"].ToString();
                if (Answer == option)
                {
                    vMark = ds.Tables[0].Rows[j]["Marks"].ToString();
                }
                else
                {
                    vMark = "0";
                }
                string InsertData = "insert into StudentAnwers(QuesID,StuID,Answer,isDisplay,MarksObtained,ExamID) values(@QuesID,@StuID,@Answer,@isDisplay,@MarksObtained,@ExamID)";
                List<SqlParameter> Pram = new List<SqlParameter>();
                Pram.Add(new SqlParameter("@QuesID", ds.Tables[0].Rows[j]["ID"].ToString()));
                Pram.Add(new SqlParameter("@StuID", Session["SID"].ToString()));
                Pram.Add(new SqlParameter("@Answer", option));
                Pram.Add(new SqlParameter("@isDisplay", "1"));
                Pram.Add(new SqlParameter("@MarksObtained", vMark));
                Pram.Add(new SqlParameter("@ExamID", Session["EID"].ToString()));
                DBt.P_ExecuteNonQuery(InsertData, Pram);
                j++;
                marksobt = marksobt + Convert.ToDouble(vMark);

            }
        }
        string fvn = Session["fn"].ToString();
        string InsertRes = "insert into Result (MaxMarks,ObtainedMarks,StuID,ExamID,IsDisplay,IsMarksheet,SemID,studentImg,ExamDate,ExamTime) values(@MaxMarks,@ObtainedMarks,@StuID,@ExamID,@IsDisplay,@IsMarksheet,@SemID,@studentImg,@ExamDate,@ExamTime)";
        List<SqlParameter> Param = new List<SqlParameter>();
        Param.Add(new SqlParameter("@MaxMarks", "70"));
        Param.Add(new SqlParameter("@ObtainedMarks", marksobt));
        Param.Add(new SqlParameter("@StuID", Session["SID"].ToString()));
        Param.Add(new SqlParameter("@ExamID",Session["EID"].ToString()));
        Param.Add(new SqlParameter("@IsDisplay", "1"));
        Param.Add(new SqlParameter("@IsMarksheet", "1"));
        Param.Add(new SqlParameter("@SemID", SemID));
        Param.Add(new SqlParameter("@studentImg", Session["fn"].ToString()));
        Param.Add(new SqlParameter("@ExamDate", DateTime.Now.ToString("dd/MM/yyyy")));
        Param.Add(new SqlParameter("@ExamTime", DateTime.Now.ToString("hh:mm:ss")));

        DBt.P_returnDataSet(InsertRes, Param);

        string updateqry = "update SetMainExam set IsExamGiven=@IsExamGiven where Sid=@Sid";
        List<SqlParameter> sqp = new List<SqlParameter>();
        sqp.Add(new SqlParameter("@IsExamGiven", "1"));
        sqp.Add(new SqlParameter("@Sid", Session["SID"].ToString()));
        DBt.P_ExecuteNonQuery(updateqry,sqp);

        string updateStuqry = "update AddStudent set IsCertificateRequest=@IsCertificateRequest where id=@Sid";
        List<SqlParameter> sq = new List<SqlParameter>();
        sq.Add(new SqlParameter("@IsCertificateRequest", "1"));
        sq.Add(new SqlParameter("@Sid", Session["SID"].ToString()));
        DBt.P_ExecuteNonQuery(updateStuqry,sq);

        Response.Redirect("Dashboard.aspx");        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
}