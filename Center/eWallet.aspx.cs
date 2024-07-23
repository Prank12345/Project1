using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_eWallet : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadBalance();
            loadTransaction();
        }
    }
    protected void loadTransaction()
    {
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID =@ID ";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData, pram);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string strGetData = "select * from TransactionAdmCen where CenterID=@CenterID order by ID desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@CenterID",Cid));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        gvTransact.DataSource = ds;
        gvTransact.DataBind();
    }
    protected void LoadBalance()
    {
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID =@ID ";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,pram);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@id", Cid));
        string str = DBT.P_returnOneValue("select CenterID from CenterRegistration where id=@id",pr);

        List<SqlParameter> pr1 = new List<SqlParameter>();
        pr1.Add(new SqlParameter("@CenterID", str));
        string strGetMoney = DBT.P_returnOneValue("select Amount from LatestAmtAdmCen where CenterID=@CenterID",pr1);
        lblBalance.Text = strGetMoney;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vAmount = txtAmount.Text;       
        string vParticular = txtNarrate.Text;
        string vPayslip = "";
        string vDdate = txtDate.Text;
        if(fupPaySlip.HasFile)
        {
            fupPaySlip.SaveAs(Server.MapPath("~/CenterPayment/" + fupPaySlip.FileName));
            vPayslip = fupPaySlip.FileName;
        }
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> pr = new List<SqlParameter>();
            pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,pr);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
            string strInsert = "insert into TransactionAdmCen (CenterID,Particulars,Credit,Debit,Amount,PaySlip,PayDate) values(@CenterID,@Particulars,@Credit,@Debit,@Amount,@PaySlip,@PayDate)";
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@CenterID", Cid));
            Param.Add(new SqlParameter("@Particulars", vParticular));           
            Param.Add(new SqlParameter("@Credit", "0"));
            Param.Add(new SqlParameter("@Debit", "0"));
            Param.Add(new SqlParameter("@Amount", vAmount));
            Param.Add(new SqlParameter("@PaySlip", vPayslip));
            Param.Add(new SqlParameter("@PayDate", vDdate));
            DBT.P_ExecuteNonQuery(strInsert, Param);

        loadTransaction();
        txtAmount.Text = txtDate.Text = txtNarrate.Text = "";
    }

    protected void gvTransact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Credit = e.Row.Cells[3].Text.ToString();
            string Debit = e.Row.Cells[4].Text.ToString();
            if (Credit.CompareTo("0") == 0&& Debit.CompareTo("0") == 0)
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