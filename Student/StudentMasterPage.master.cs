using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_StudentMasterPage : System.Web.UI.MasterPage
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
        }
    }
    protected void LoadData()
    {
        string strGetData = "select * from AddStudent where Id=" + Session["SID"].ToString();
        DataSet ds = DBT.returnDataSet(strGetData);
        lblshowName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
        imgShowPic.ImageUrl = "~/Student-Image/" + ds.Tables[0].Rows[0]["StudentImage"].ToString();
        if(ds.Tables[0].Rows[0]["CertificateD"].ToString()==""&& ds.Tables[0].Rows[0]["CertificateD"]==null)
        {
            hlCertificate.NavigateUrl = "#";
        }
        else
        {
            hlCertificate.NavigateUrl = "~/SuperAdminBackend/pdfs/" + ds.Tables[0].Rows[0]["CertificateD"].ToString();
        }
        if(ds.Tables[0].Rows[0]["ICard"].ToString()==""&& ds.Tables[0].Rows[0]["ICard"]==null)
        {
            hlICard.NavigateUrl = "#";
        }
        else
        {
            hlICard.NavigateUrl = "~/SuperAdminBackend/pdfs/" + ds.Tables[0].Rows[0]["ICard"].ToString();
        }        
        string strGetMaksheet = "select top 1 * from SemesterResult where StuID='" + Session["SID"].ToString()+"' order by ID Desc";
        DataSet dsMark = DBT.returnDataSet(strGetMaksheet);
        if(dsMark.Tables[0].Rows.Count>0)
        {
            hlMarksheet.NavigateUrl = "~/SuperAdminBackend/pdfs/" + dsMark.Tables[0].Rows[0]["MarksheetD"].ToString(); 
        }
        else
        {
            hlMarksheet.NavigateUrl = "#";
        }        
    }

    protected void lbexam_Click(object sender, EventArgs e)
    {
        string strGetData = "select * from SetMainExam where IsExamGiven=0 and DateOfExam='"+DateTime.Now.ToShortDateString()+"' and Sid=" + Session["SID"].ToString();
        DataSet ds = DBT.returnDataSet(strGetData);
        if(ds.Tables[0].Rows.Count>0)
        {
            Response.Redirect("~/Student/MainExam.aspx");
        }
       else
        {
            Response.Write("<script>alert('No Exam Is Set. Kindly Contact Your Center Head For Further Details')</script>");
        }
    }
    protected void logout_click(object sender, EventArgs e)
    {       
        Session["SID"] = null;       
        Response.Redirect("~/StudentLogin.aspx");
    }
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session["SID"] = null;
        Response.Redirect("~/StudentLogin.aspx");
    }
}
