using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_CenterRenewal : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGvCenter();
        }
    }
    protected void LoadGvCenter()
    {
        //string renewDate = DateTime.Now.AddDays(15).ToShortDateString();
        //string renewdate2= DateTime.Now.ToShortDateString();
        string strGetData = "select * from CenterRegistration where isrequest=1 and RenewalDate<CONVERT(date, DATEADD(DAY, 15, GETDATE()))";
        gvCenter.DataSource = DBT.returnDataSet(strGetData);
        gvCenter.DataBind();
    }

    protected void chkRenew_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow row = (GridViewRow)checkbox.NamingContainer;
        string vVerifyDate = DateTime.Now.ToShortDateString();
        string vRenwalDate = DateTime.Now.AddYears(5).ToShortDateString();
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();

        if (checkbox.Checked == true)
        {
            string updateDisplay = "Update CenterRegistration Set IsLogin = @IsLogin,RenewalDate=@RenewalDate,VerifyDate=@VerifyDate Where ID = @ID";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@ID", id));
            Pr.Add(new SqlParameter("@IsLogin", "1"));
            Pr.Add(new SqlParameter("@RenewalDate", vRenwalDate));
            Pr.Add(new SqlParameter("@VerifyDate", vVerifyDate));
            DBT.P_ExecuteNonQuery(updateDisplay,Pr);
        }

        if (checkbox.Checked == false)
        {
            string updateDisplay = "Update CenterRegistration Set IsLogin = @IsLogin Where ID = @ID";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@ID", id));
            Pr.Add(new SqlParameter("@IsLogin", "0"));
            DBT.P_ExecuteNonQuery(updateDisplay, Pr);
        }
        LoadGvCenter();
    }

    protected void gvCenter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Display = e.Row.Cells[8].Text.ToString();
            if (Display.CompareTo("0") == 0)
            {
                e.Row.Cells[8].Text = "Renewal Pending";
                CheckBox ch = (CheckBox)e.Row.FindControl("chkRenew");
                ch.Checked = false;
            }
            else
            {
                e.Row.Cells[8].Text = "Fews Days Left For Renewal";
                CheckBox ch = (CheckBox)e.Row.FindControl("chkRenew");
                ch.Checked = true;
            }
        }
    }
}