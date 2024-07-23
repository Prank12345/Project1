using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_Notifications : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            {
            LoadData();
        }
    }
    protected void LoadData()
    {
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
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@Id",Cid));
        string centerId = DBT.P_returnOneValue("select CenterID from CenterRegistration where id=@Id" ,Pr1);
        List<SqlParameter> Pr2 = new List<SqlParameter>();
        Pr2.Add(new SqlParameter("@SubmittedTo", centerId));
        Pr2.Add(new SqlParameter("@Sub", "Center"));
        string MsgID = "select * from NotificationsDet where SubmittedTo=@SubmittedTo or SubmittedTo =@Sub order by ID ";
      
        gvNotification.DataSource = DBT.P_returnDataSet(MsgID,Pr2);
        gvNotification.DataBind();
        string update = "update NotificationLog set isRead=@isRead ";
        List<SqlParameter> Pr3 = new List<SqlParameter>();
        Pr3.Add(new SqlParameter("@isRead", "1"));
        DBT.P_ExecuteNonQuery(update,Pr3);
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvNotification.DataKeys[row.RowIndex].Value.ToString();
        // string MsgID = DBT.returnOneValue("select NDID from NotificationLog where id="+id);
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@Id",id));
        DataSet ds = DBT.P_returnDataSet("select * from NotificationsDet where Id=@Id",pram);
        if (ds.Tables[0].Rows[0]["Attachment"].ToString() != "")
        {
            imgPreview.Visible = true;
            imgPreview.ImageUrl = "~/Notification_Attachment/" + ds.Tables[0].Rows[0]["Attachment"].ToString();
            lblShowAttachName.Text = ds.Tables[0].Rows[0]["Attachment"].ToString();
        }
        else
        {
            imgPreview.Visible = false;
            lblShowAttachName.Text = "No Attachment Found";
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "ViewAttach();", true);
    }
}