using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distributor_EWallet : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadBalance();
        }
    }

    protected void LoadBalance()
    {
        string Did = "";
        if (Session["DID"] != null)
        {
            Did = Session["DID"].ToString();
            List<SqlParameter> pr1 = new List<SqlParameter>();
            pr1.Add(new SqlParameter("@DID", Did));
            string strGetMoney = DBT.P_returnOneValue("select Amount from DistributorWallet where DID=@DID", pr1);
            lblBalance.Text = strGetMoney;

            string strGetData = "select * from TransactionDist where DistributorID=@DistributorID order by ID desc";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@DistributorID", Did));
            DataSet ds = DBT.P_returnDataSet(strGetData, Pram);
            gvTransact.DataSource = ds;
            gvTransact.DataBind();
        }
       else
        {
            Response.Redirect("~/DistributorLogin.aspx");
        }
        
    }
    protected void gvTransact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Credit = e.Row.Cells[3].Text.ToString();
            string Debit = e.Row.Cells[4].Text.ToString();
            if (Credit.CompareTo("0") == 0 && Debit.CompareTo("0") == 0)
            {
                e.Row.Cells[3].Text = "Credit Request Pending";
                e.Row.Cells[4].Text = "Amount Not Debited";
            }
            else if (Debit.CompareTo("0") == 0)
            {
                e.Row.Cells[3].Text = "Credited Amount";
                e.Row.Cells[4].Text = "Amount Not Debited";
            }
            else
            {
                e.Row.Cells[3].Text = "Amount Not Credited";
                e.Row.Cells[4].Text = "Debited Amount";
            }

        }
    }
}