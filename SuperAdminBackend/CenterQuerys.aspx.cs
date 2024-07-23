using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdminBackend_CenterQuerys : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            manage();
        }
       
    }
    protected void manage()
    {
        DBTrac DBT = new DBTrac();
        string str = "select * from CenterQuary order by ID desc";
        gvquery.DataSource = DBT.returnDataSet(str);
        gvquery.DataBind();
    }

    protected void btnCenter_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvquery.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@ID",id));
        string ID = DBT.P_returnOneValue("select Cid from CenterQuary where id = @ID",pram);
        List<SqlParameter> Param = new List<SqlParameter>();
        Param.Add(new SqlParameter("@ID", ID));
        DataSet ds = DBT.P_returnDataSet("select * from CenterRegistration where Id=@ID",Param);
        lblCenterName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCenterID.Text = ds.Tables[0].Rows[0]["CenterID"].ToString();
        lblPersonName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
        lblCAddr.Text = ds.Tables[0].Rows[0]["Address"].ToString();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openCer();", true);
    }


    protected void gvquery_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField field = e.Row.FindControl("HFISActive") as HiddenField;
            Button btn = e.Row.FindControl("btnSend") as Button;
            Button btnV = e.Row.FindControl("btnViewAns") as Button;
            Label lbl = e.Row.FindControl("lblText") as Label;
            Label lblv = e.Row.FindControl("lblTextView") as Label;
           
            if (field.Value == "1")
            {
                btn.Visible = false;
                btnV.Visible = true;
               
                lbl.Text = "Replied";
              
            }
            else
            {
             
                btn.Visible = true;
                lbl.Visible = false;

                btnV.Visible = false;
                lblv.Visible = true;

                lblv.Text = "Not Replied";
              

            }
        }
    }

    protected void lbsend_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvquery.DataKeys[row.RowIndex].Value.ToString();
     
        List<SqlParameter> PP = new List<SqlParameter>();
        PP.Add(new SqlParameter("@Id",id));
        DataSet ds = DBT.P_returnDataSet("select * from CenterQuary where Id=@Id",PP);
        string Answer = ""; 
        if (ds.Tables[0].Rows.Count>0)
        {
            string visReply = "1";
            string update = "update CenterQuary set isReply=@isReply,Answers=@Answers where id=@id" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@isReply", visReply));
            Pram.Add(new SqlParameter("@Answers", Answer));
            Pram.Add(new SqlParameter("@id", id));
            DBT.P_ExecuteNonQuery(update, Pram);
            manage();
        }
        
    }

    protected void btnViewAns_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvquery.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        string strGetData = "select * from CenterQuary where id = @ID" ;
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        lblViewques.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
        lblViewProb.Text = ds.Tables[0].Rows[0]["Problemdetails"].ToString();
        lblViewAns.Text = ds.Tables[0].Rows[0]["Answers"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "OpenViewAnswer();", true);
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvquery.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID",id));
        string strGetData = "select * from CenterQuary where id = @ID" ;
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        lblQuestion.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
        lblqryAns.Text = ds.Tables[0].Rows[0]["Problemdetails"].ToString();
        HFISActive.Value = ds.Tables[0].Rows[0]["id"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openAnswerSend();", true);
    }
   
    protected void btnSendAns_Click(object sender, EventArgs e)
    {
        string visReply = "1";
        string visView = "1";
        string id = HFISActive.Value;
        string Answer = txtAnswer.Text;
       
        string update = "update CenterQuary set isReply=@isReply,isAdmView=@isAdmView,Answers=@Answers where id=@ID" ;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@isReply", visReply));
        Pram.Add(new SqlParameter("@isAdmView", visView));
        Pram.Add(new SqlParameter("@Answers", Answer));
        Pram.Add(new SqlParameter("@ID", id));
        DBT.P_ExecuteNonQuery(update, Pram);
        Response.Redirect("CenterQuerys.aspx");
    }
}