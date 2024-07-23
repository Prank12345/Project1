using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Student_studentnotification : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        notify();
    }
    protected void notify()
    {
        string str = "select * from NotificationsDet where SubmittedTo=@SubmittedTo";
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@SubmittedTo", "Student"));
        gvnotification.DataSource = DBT.P_returnDataSet(str,prm);
        gvnotification.DataBind();
        string update = "update NotificationLog set isRead=@isRead";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@isRead", "1"));
        DBT.P_ExecuteNonQuery(update,pram);
    }
}