using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Student_Image_TakeTests : System.Web.UI.Page
{
    DBTrac DBt = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadRepeater();
        }
    }
    protected void LoadRepeater()
    {
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@id", Session["SID"].ToString()));
        string GetCourseID = DBt.P_returnOneValue("select Course from AddStudent where id=@id",prm) ;

        List<SqlParameter> parm = new List<SqlParameter>();
        parm.Add(new SqlParameter("@CourseID", GetCourseID));
        parm.Add(new SqlParameter("@ExamType", "Test"));
        string strGetData = "select * from ExamList where ExamType=@ExamType and CourseID=@CourseID";
        
        rptTestList.DataSource = DBt.P_returnDataSet(strGetData,parm);
        rptTestList.DataBind();       
    }
}