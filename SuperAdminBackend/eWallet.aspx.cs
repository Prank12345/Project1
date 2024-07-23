using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class SuperAdminBackend_eWallet : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //LoadBalance();
            loadTransaction();
        }
    }
    protected void LoadBalance()
    {
        string strGetMoney = "";
        strGetMoney= "select * from LatestAmtAdmCen where CenterID=@CenterID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@CenterID", "admin0000"));
        DataSet ds = DBT.P_returnDataSet(strGetMoney,Pram);

       // lblBalance.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
    }
    protected void loadTransaction()
    {
        string strGetData = "select * from TransactionAdmCen tac join CenterRegistration cr on tac.CenterID=cr.ID order by tac.ID desc";
        DataSet ds = DBT.returnDataSet(strGetData);
        gvTransact.DataSource = ds;
        gvTransact.DataBind();
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvTransact.DataKeys[row.RowIndex].Value.ToString();

        List<SqlParameter> PP = new List<SqlParameter>();
        PP.Add(new SqlParameter("@Id", id));
        DataSet ds = DBT.P_returnDataSet("select * from TransactionAdmCen where Id=@Id", PP);
      
        if (ds.Tables[0].Rows.Count > 0)
        {
            string vCredit = "1";
            string Cid = ds.Tables[0].Rows[0]["CenterID"].ToString();
            string Vamt= ds.Tables[0].Rows[0]["Amount"].ToString();
            double VaddAmt = Convert.ToDouble(Vamt);
            string update = "update TransactionAdmCen set Credit=@Credit where id=@id";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@Credit", vCredit));
            Pram.Add(new SqlParameter("@id", id));
            DBT.P_ExecuteNonQuery(update, Pram);

            List<SqlParameter> pr1 = new List<SqlParameter>();
            pr1.Add(new SqlParameter("@ID", Cid));
            string vCenID = DBT.P_returnOneValue("select CenterID from CenterRegistration where ID=@ID", pr1);

            List<SqlParameter> pr = new List<SqlParameter>();
            pr.Add(new SqlParameter("@CenID", vCenID));
            string WalletAmt = DBT.P_returnOneValue("select Amount from LatestAmtAdmCen where CenterID=@CenID", pr);
            double vWalletAmt = Convert.ToDouble(WalletAmt);
            double totAmt = VaddAmt + vWalletAmt;

            string UpdateWallet = "update LatestAmtAdmCen set Amount=@Amount where CenterID=@CenID";
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@Amount",totAmt.ToString()));
            Param.Add(new SqlParameter("@CenID", vCenID));
            DBT.P_ExecuteNonQuery(UpdateWallet, Param);

            loadTransaction();
        }
    }

    protected void gvTransact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField field = e.Row.FindControl("HFISActive") as HiddenField;
            HiddenField hfDebit = e.Row.FindControl("hfDebit") as HiddenField;
            Button btn = e.Row.FindControl("btnVerify") as Button;
           
            Label lbl = e.Row.FindControl("lblText") as Label;
            
            if (field.Value == "1"&&hfDebit.Value=="0")
            {
                btn.Visible = false;
                lbl.Text = "Verified";


            }
            else if(hfDebit.Value == "0")
            {

                btn.Visible = true;
                lbl.Visible = false;
                

            }
            else if (hfDebit.Value == "1")
            {

                btn.Visible = false;
                lbl.Text="Amount Debited";
                lbl.ForeColor = System.Drawing.Color.BlueViolet;


            }

        }
    }

    protected void gvTransact_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gvTransact.DataKeys[e.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        string DeleteCategory = "Delete From TransactionAdmCen Where ID = @id";

        DBTrac DBT = new DBTrac();

        DBT.P_ExecuteNonQuery(DeleteCategory, pram);
        loadTransaction();
    }

    protected void lnkbtnCenterDetail_Click(object sender, EventArgs e)
    {
        LinkButton btnSender = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvTransact.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        string vID = DBT.P_returnOneValue("select CenterID from TransactionAdmCen where id = @id", pram);
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@id", vID));
        DataSet ds = DBT.P_returnDataSet("select * from CenterRegistration where Id=@id", param);
        lblCenterName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCAddr.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        lblCenID.Text = ds.Tables[0].Rows[0]["CenterID"].ToString();
        lblMN.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
        

        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openCenter();", true);
    }
}