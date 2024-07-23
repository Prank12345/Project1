using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBTrac
/// </summary>
public class DBTrac
{
    string ConStr;

    public DBTrac()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    protected SqlConnection getConn()
    {
        ConStr = ConfigurationManager.AppSettings["ConStr"].ToString();
        SqlConnection Conn = new SqlConnection(ConStr);
        return Conn;
    }

    public void executeNonQuery(string QryStr)
    {
        SqlConnection Conn = getConn();

        Conn.Open();

        SqlCommand cmdQryStr = new SqlCommand(QryStr, Conn);

        cmdQryStr.ExecuteNonQuery();

        Conn.Close();
    }

    public string returnOneValue(string QryStr)
    {
        SqlConnection Conn = getConn();

        Conn.Open();

        SqlCommand cmdQryStr = new SqlCommand(QryStr, Conn);

        string value = cmdQryStr.ExecuteScalar().ToString();

        Conn.Close();

        return value;
    }

    public string P_returnOneValue(string QryStr, List<SqlParameter> Parm)
    {
        SqlConnection Conn = getConn();

        Conn.Open();

        SqlCommand cmdQryStr = new SqlCommand(QryStr, Conn);

        foreach (SqlParameter p in Parm)
        {
            cmdQryStr.Parameters.AddWithValue(p.ParameterName, p.Value);
        }

        string value = cmdQryStr.ExecuteScalar().ToString();

        Conn.Close();

        return value;
    }

    public DataSet returnDataSet(string QryStr)
    {
        SqlConnection Conn = getConn();

        SqlDataAdapter daQryStr = new SqlDataAdapter(QryStr, Conn);


        DataSet dsQryStr = new DataSet();

        daQryStr.Fill(dsQryStr);

        return dsQryStr;
    }

    public DataSet P_returnDataSet(string str, List<SqlParameter> Parm)
    {

        SqlConnection Conn = getConn();

        SqlDataAdapter daQryStr = new SqlDataAdapter(str, Conn);
        foreach (SqlParameter p in Parm)
        {
            daQryStr.SelectCommand.Parameters.AddWithValue(p.ParameterName, p.Value);
        }

        DataSet dsQryStr = new DataSet();

        daQryStr.Fill(dsQryStr);

        return dsQryStr;
    }

    public int P_ExecuteNonQuery(string str, List<SqlParameter> Parm)
    {

        SqlConnection Conn = getConn();
        Conn.Open();
        SqlCommand cmd = new SqlCommand(str, Conn);
        foreach (SqlParameter p in Parm)
        {

            cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
        }

        return cmd.ExecuteNonQuery();
    }

    

   
}