using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Center_Dashboard : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        chkUsr();     
    }

    protected void chkUsr()
    {
        if(Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID ";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pram);
            dd.Visible = false;


        }
        else if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            dd.Visible = true;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", Session["centerid"].ToString()));
            string strGetCenter = DBT.P_returnOneValue("select CenterID from CenterRegistration where ID=@ID",Pram);

            string str = "select count(ID) from AddStudent where isRequest=@isRequest and Cid=@Cid";
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@Cid", Session["centerid"].ToString()));
            Param.Add(new SqlParameter("@isRequest", "1"));
            string countstudent = DBT.P_returnOneValue(str,Param);
            lblstudent.Text = countstudent;

            string course = "select count(ID) from Courses";
            string countcourse = DBT.returnOneValue(course);
            lblcourse.Text = countcourse;

            string test = "select count(ID) from ExamList where ExamType=@ExamType and CenterID=@CenterID";
            List<SqlParameter> Param2 = new List<SqlParameter>();
            Param2.Add(new SqlParameter("@CenterID", Session["centerid"].ToString()));
            Param2.Add(new SqlParameter("@ExamType", "Test"));
            string counttest = DBT.P_returnOneValue(test,Param2);
            lbltest.Text = counttest;

            string Query = "select count(ID) from CenterQuary where isReply=@isReply and isCentView=@isCentView and Cid=@Cid";
            List<SqlParameter> Param1 = new List<SqlParameter>();
            Param1.Add(new SqlParameter("@Cid", Session["centerid"].ToString()));
            Param1.Add(new SqlParameter("@isReply", "1"));
            Param1.Add(new SqlParameter("@isCentView", "0"));
            string countqry = DBT.P_returnOneValue(Query,Param1);
            lblQryreq.Text = countqry;

            string Notification = "select count(ID) from NotificationLog where isRead=@isRead and CenterID=@CenterID";
            List<SqlParameter> Param3 = new List<SqlParameter>();
            Param3.Add(new SqlParameter("@CenterID", strGetCenter));
            Param3.Add(new SqlParameter("@isRead", "0"));
            string countNotif = DBT.P_returnOneValue(Notification,Param3);
            lblNotif.Text = countNotif;

            string WalletAmount = "select Amount from LatestAmtAdmCen where CenterID=@CenterID";
            List<SqlParameter> Param4 = new List<SqlParameter>();
            Param4.Add(new SqlParameter("@CenterID", strGetCenter));          
            string WalletAmt = DBT.P_returnOneValue(WalletAmount, Param4);
            lblmoney.Text = WalletAmt;

        }
    }
}