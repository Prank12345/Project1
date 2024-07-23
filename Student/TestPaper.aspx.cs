using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Student_TestPaper : System.Web.UI.Page
{
    DBTrac DBt = new DBTrac();
    Wizard wizard1 = new Wizard();
    Label lblQues = new Label();
    
    protected void Page_Init(object sender, EventArgs e)
    {
        wizard1.Style.Add("width", "100%");
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@ExamID", Request.QueryString["TID"].ToString()));
        DataSet ds = DBt.P_returnDataSet("select * from Questions where ExamID=@ExamID",prm);

        //wizard1.DisplaySideBar = false;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            int x = i + 1;
            WizardStep step1 = new WizardStep();            
            //step1.ID = "Question" + x.ToString();            
            //step1.Title = "Question" + x.ToString();
            PlaceHolder ph = new PlaceHolder();
            ph.ID = "ph" + x.ToString();
            lblQues.ID = "lblQues" + x.ToString();
            ph.Controls.Add(new LiteralControl("<h2>"+ "Question " + x.ToString()+": " + ds.Tables[0].Rows[i]["Question"].ToString() + "</h1>"));
            ph.Controls.Add(lblQues);
            ph.Controls.Add(new LiteralControl("<br/>"));
            RadioButtonList rblist = new RadioButtonList();
            rblist.ID = "rblist" + i.ToString();
            rblist.RepeatDirection = RepeatDirection.Horizontal;
            //rblist.Items[0].Attributes.CssStyle.Add("padding:5px;");
            

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
        wizard1.StartNextButtonStyle.CssClass = "btn-success";
        wizard1.StepNextButtonStyle.CssClass = "btn-success";
        wizard1.FinishPreviousButtonStyle.CssClass = "btn-warning";
        wizard1.StepPreviousButtonStyle.CssClass = "btn-warning";
        wizard1.StepPreviousButtonStyle.CssClass = "btn-warning";
        wizard1.FinishCompleteButtonStyle.CssClass = "btn-success";

        wizard1.FinishButtonClick += Wizard1_FinishButtonClickQues;
    }
    private void Wizard1_FinishButtonClickQues(object sender, WizardNavigationEventArgs e)
    {
        //WizardStepType t = wizard1.WizardSteps[e.NextStepIndex].StepType;
        string strGetData = Request.QueryString["TID"].ToString();
        string id = "select * from Questions where ExamID=@ExamID";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@ExamID", strGetData));
        DataSet ds = DBt.P_returnDataSet(id,pr);
        int ch = ds.Tables[0].Rows.Count;
        string vMark = "";
        int j = 0;
        string option = "";
        foreach (WizardStep step in wizard1.WizardSteps)
        {
           
            RadioButtonList rbl = (RadioButtonList)step.FindControl("rblist" + j.ToString());
            option = rbl.SelectedValue.ToString();
            
            
            if(j < ch)
            {
                if(ds.Tables[0].Rows[0]["CorrectAnswer"].ToString()==option)
                {
                    vMark = ds.Tables[0].Rows[0]["Marks"].ToString();
                }
                else
                {
                    vMark = "0";
                }
                string InsertData = "insert into StudentAnwers(QuesID,StuID,Answer,isDisplay,MarksObtained) values(@QuesID,@StuID,@Answer,@isDisplay,@MarksObtained)";
                List<SqlParameter> Pram = new List<SqlParameter>();
                Pram.Add(new SqlParameter("@QuesID", ds.Tables[0].Rows[j]["ID"].ToString()));
                Pram.Add(new SqlParameter("@StuID", Session["SID"].ToString()));
                Pram.Add(new SqlParameter("@Answer", option));
                Pram.Add(new SqlParameter("@isDisplay", "1"));
                Pram.Add(new SqlParameter("@MarksObtained", ""));
                DBt.P_ExecuteNonQuery(InsertData, Pram);
                j++;
            }
        }
        
        
        Response.Redirect("TakeTests.aspx");
        // throw new NotImplementedException();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
        }
    }
}