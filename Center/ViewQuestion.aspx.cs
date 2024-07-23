using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_ViewQuestion : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static string strID;
    protected void Page_Load(object sender, EventArgs e)
    {
        strID = Request.QueryString["ID"].ToString();
        if(!IsPostBack)
        {
            LoadData();
        }
    }
    protected void LoadData()
    {
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> pr = new List<SqlParameter>();
            pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData, pr);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string strGetData = "select * from MainExQuestions meq, MainExam em, SetMainExam sme, AddStudent ast where meq.ExamID=em.id and sme.EListid=em.id and sme.[sid]=ast.id and sme.cid=@cid and ExamID=@ExamID";
        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@cid", Cid));
        pr1.Add(new SqlParameter("@ExamID", Request.QueryString["QID"].ToString()));
        //string strGetData = "select * from Questions where ExamID=" + Request.QueryString["ID"].ToString();
        rptQuestion.DataSource = DBT.returnDataSet(strGetData);
        rptQuestion.DataBind();
        DataSet dsstu = DBT.P_returnDataSet(strGetData, pr1);

    }
}