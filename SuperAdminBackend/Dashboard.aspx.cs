using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class SuperAdminBackend_Dashboard : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        counting();
    }
    protected void counting()
    {
        string str = "select count (ID) from CenterRegistration";
        string count = DBT.returnOneValue(str);
        lblAllCenter.Text = count;

        string student = "select count(ID) from AddStudent";
        string countstu = DBT.returnOneValue(student);
        lblTotStudent.Text = countstu;

        string varifycenter = "select count(ID) from CenterRegistration where isrequest=@isRequest";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@isRequest", "0"));
        string countcenter = DBT.P_returnOneValue(varifycenter,Pram);
        lblCenterVerification.Text = countcenter;

        string varifystudent = "select count(ID) from AddStudent where isrequest=@isRequest";
        List<SqlParameter> PramS = new List<SqlParameter>();
        PramS.Add(new SqlParameter("@isRequest", "0"));
        string countstudent = DBT.P_returnOneValue(varifystudent, PramS);
        lblStudentVerification.Text = countstudent;

        string query = "select count(ID) from CenterQuary where isReply=@isReply";
        List<SqlParameter> PramQ = new List<SqlParameter>();
        PramQ.Add(new SqlParameter("@isReply", "0"));
        string countQry = DBT.P_returnOneValue(query, PramQ);
        lblQry.Text = countQry;

        string DistributorList = "select count(ID) from Distributors where IsRequest=@IsRequest";
        List<SqlParameter> PramD = new List<SqlParameter>();
        PramD.Add(new SqlParameter("@IsRequest", "1"));
        string countDistribut = DBT.P_returnOneValue(DistributorList, PramD);
        lbldistList.Text = countDistribut;

        string updateCenter = "update CenterRegistration set IsLogin=0 where RenewalDate<getdate()";    
        DBT.executeNonQuery(updateCenter);

    }
}