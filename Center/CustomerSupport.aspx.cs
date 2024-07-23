using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Center_CustomerSupport : System.Web.UI.Page
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
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pram);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string str = "select * from CenterQuary where Cid=@Cid order by ID desc";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@Cid", Cid));
        gvquery.DataSource = DBT.P_returnDataSet(str,Pr);
        gvquery.DataBind();
    }
    protected void gvquery_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField field = e.Row.FindControl("HFISActive") as HiddenField;
          
            Button btnV = e.Row.FindControl("btnViewAns") as Button;
           
            Label lblv = e.Row.FindControl("lblTextView") as Label;
            
            if (field.Value == "1")
            {
                
                btnV.Visible = true;
                lblv.Visible = false;

            }
            else
            {
              
               
                btnV.Visible = false;
                lblv.Visible = true;
                lblv.Text = "Wating For reply";
              

            }
        }
    }
    protected void lbSubmit_Click(object sender, EventArgs e)
    {
        string subject = txtSubject.Text;
        string subproblem = txtDesc.Text;
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pr);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string problem = "Insert into CenterQuary (Subject,Problemdetails,Cid,isdisplay,isReply,isAdmView,isCentView) values(@Subject,@Problemdetails,@Cid,@isdisplay,@isReply,@isAdmView,@isCentView)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@Subject", subject));
        Pram.Add(new SqlParameter("@Problemdetails", subproblem));
        Pram.Add(new SqlParameter("@Cid", Cid));
        Pram.Add(new SqlParameter("@isdisplay", "1"));
        Pram.Add(new SqlParameter("@isReply", "0"));
        Pram.Add(new SqlParameter("@isAdmView", "0"));
        Pram.Add(new SqlParameter("@isCentView", "0"));

        DBT.P_ExecuteNonQuery(problem, Pram);
        Response.Redirect("~/Center/Dashboard.aspx");
        
    }
    protected void btnViewAns_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvquery.DataKeys[row.RowIndex].Value.ToString();
        string strGetData = "select * from CenterQuary where id = @id";
        List<SqlParameter> pr = new List<SqlParameter>();
        pr.Add(new SqlParameter("@id", id));

        DataSet ds = DBT.P_returnDataSet(strGetData,pr);

        lblViewques.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
       
        lblViewAns.Text = ds.Tables[0].Rows[0]["Answers"].ToString();
        string updateqry = "update CenterQuary set isCentView=@isCentView where id=@id" ;
        List<SqlParameter> PRam = new List<SqlParameter>();
        PRam.Add(new SqlParameter("@isCentView", "1"));
        PRam.Add(new SqlParameter("@id", id));

        DBT.P_ExecuteNonQuery(updateqry,PRam);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "OpenViewAnswer();", true);
    }

}