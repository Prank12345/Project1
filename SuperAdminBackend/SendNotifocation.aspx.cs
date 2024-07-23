using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_SendNotifocation : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
            LoadData();
            loadDropDown();
        }
    }

    protected void gvNotification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DBTrac DBT = new DBTrac();
        string id = gvNotification.DataKeys[e.RowIndex].Value.ToString();
        List<SqlParameter> PRam = new List<SqlParameter>();
        PRam.Add(new SqlParameter("@ID", id));
        string DeleteCategory = "Delete From NotificationsDet Where ID = @ID" ;
        string DeleteCategory1 = "Delete From NotificationLog Where NDID = @ID";

        DBT.P_ExecuteNonQuery(DeleteCategory,PRam);
        DBT.P_ExecuteNonQuery(DeleteCategory1,PRam);
        LoadData();
    }
    protected void LoadData()
    {
        string strGetData = "select * from NotificationsDet order by ID desc";
        gvNotification.DataSource = DBT.returnDataSet(strGetData);
        gvNotification.DataBind();
    }
    protected void lnkbtnSend_Click(object sender, EventArgs e)
    {
        string vMessage = txtMessage.Text;
        string vSubmittedTo = ddlNotificationTo.SelectedItem.Text;
        string vSubmittedBy = "Admin";
        string SendDate = DateTime.Now.ToShortDateString();
        
        string IsDisplay = "1";
        string MsgId = "";
        Random ren = new Random();

        MsgId = "Msg" + ren.Next(999999);
       
        string strinsert = "insert into NotificationsDet(NotifMessage,SubmittedBy,SubmittedTo,SendOnDate,IsDisplay,MsgID) values(@NotifMessage,@SubmittedBy,@SubmittedTo,@SendOnDate,@IsDisplay,@MsgID)";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@NotifMessage", vMessage));
        Pram.Add(new SqlParameter("@SubmittedBy", vSubmittedBy));
        Pram.Add(new SqlParameter("@SubmittedTo", vSubmittedTo));
        Pram.Add(new SqlParameter("@SendOnDate", SendDate));
        Pram.Add(new SqlParameter("@IsDisplay", IsDisplay));
        
        Pram.Add(new SqlParameter("@MsgID", MsgId));

        DBT.P_ExecuteNonQuery(strinsert, Pram);
        string strGetID = DBT.returnOneValue("select MAX(ID) from NotificationsDet");
        if (ddlNotificationTo.SelectedValue=="1")
        {
            string str ="select * from CenterRegistration";
            DataSet ds = DBT.returnDataSet(str);
            int count = ds.Tables[0].Rows.Count;
            string CenterID = "";
            
            for (int i=0;i<count;i++)
            {
                CenterID = ds.Tables[0].Rows[i]["CenterID"].ToString();
                string strinsertLog = "insert into NotificationLog(CenterID,MsgID,isDisplay,isRead,NDID) values(@CenterID,@MsgID,@isDisplay,@isRead,@NDID)";
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@CenterID", CenterID));
                Param.Add(new SqlParameter("@MsgID", MsgId));
                Param.Add(new SqlParameter("@isDisplay", "1"));
                Param.Add(new SqlParameter("@isRead", "0"));
                Param.Add(new SqlParameter("@NDID", strGetID));

                DBT.P_ExecuteNonQuery(strinsertLog, Param);
            }
        }
        else if(ddlNotificationTo.SelectedValue == "2")
        {
            string str ="select * from AddStudent";
            DataSet ds = DBT.returnDataSet(str);
            int count = ds.Tables[0].Rows.Count;
            string StudentID = "";
            for (int i = 0; i < count; i++)
            {
                StudentID = ds.Tables[0].Rows[i]["StudentID"].ToString();
                string strinsertLog = "insert into NotificationLog(CenterID,MsgID,isDisplay,isRead,NDID) values(@CenterID,@MsgID,@isDisplay,@isRead,@NDID)";
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@CenterID", StudentID));
                Param.Add(new SqlParameter("@MsgID", MsgId));
                Param.Add(new SqlParameter("@isDisplay", "1"));
                Param.Add(new SqlParameter("@isRead", "0"));
                Param.Add(new SqlParameter("@NDID", strGetID));
                DBT.P_ExecuteNonQuery(strinsertLog, Param);
            }
            
        }
        else if (ddlNotificationTo.SelectedValue == "3")
        {
           
            string WebID = "Website";
            
               
                string strinsertLog = "insert into NotificationLog(CenterID,MsgID,isDisplay,isRead,NDID) values(@CenterID,@MsgID,@isDisplay,@isRead,@NDID)";
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@CenterID", WebID));
                Param.Add(new SqlParameter("@MsgID", MsgId));
                Param.Add(new SqlParameter("@isDisplay", "1"));
            Param.Add(new SqlParameter("@isRead", "0"));
            Param.Add(new SqlParameter("@NDID", strGetID));
            DBT.P_ExecuteNonQuery(strinsertLog, Param);
            

        }
        ddlNotificationTo.SelectedValue = "0";
        txtMessage.Text = "";
        LoadData();

    }
    protected void loadDropDown()
    {
        string strGetData = "select * from CenterRegistration where isrequest=@isrequest order by ID desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@isrequest", "1"));
        gvCenterNotif.DataSource = DBT.P_returnDataSet(strGetData,Pram);
        gvCenterNotif.DataBind();

    }
    protected void gvNotification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            
            //Label lblName = e.Row.FindControl("lblShowName") as Label;
            //string ID = e.Row.Cells[2].Text.ToString();
            //GridViewRow row = (GridViewRow)lblName.NamingContainer;
            //string strCenterName = DBT.returnOneValue("select InstituteName from CenterRegistration where CenterID ="+ID);
        }
    }

    protected void lnkbtnSendCenter_Click(object sender, EventArgs e)
    {
        string vMessage = txtMsg.Text;
        string vSubmittedTo = "";
        string vSubmittedBy = "Admin";
        string SendDate = DateTime.Now.ToShortDateString();
        
        string IsDisplay = "1";

        //string str = "";// "select * from CenterRegistration where id=" + ddlCenter.SelectedValue;
        //DataSet ds = DBT.returnDataSet(str);

        //int count = ds.Tables[0].Rows.Count;


       // vSubmittedTo = ds.Tables[0].Rows[0]["CenterID"].ToString();
       
        string Attachment = "";
        if (fup.HasFile)
        {
            fup.SaveAs(Server.MapPath("~/Notification_Attachment/" + fup.FileName));
            Attachment = fup.FileName;
        }

        string MsgId = "";
        Random ren = new Random();
        MsgId = "Msg" + ren.Next(999999);
        foreach (GridViewRow row in gvCenterNotif.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

            if (chkSelect.Checked == true)
            {
                string selectid= gvCenterNotif.DataKeys[row.RowIndex].Value.ToString();
                List<SqlParameter> sqp = new List<SqlParameter>();
                sqp.Add(new SqlParameter("@id", selectid));
                vSubmittedTo = DBT.P_returnOneValue("select CenterID from CenterRegistration where id=@id",sqp);
               

                string strinsert = "insert into NotificationsDet(NotifMessage,SubmittedBy,SubmittedTo,SendOnDate,IsDisplay,Attachment,MsgID) values(@NotifMessage,@SubmittedBy,@SubmittedTo,@SendOnDate,@IsDisplay,@Attachment,@MsgID)";
                List<SqlParameter> Pram = new List<SqlParameter>();
                Pram.Add(new SqlParameter("@NotifMessage", vMessage));
                Pram.Add(new SqlParameter("@SubmittedBy", vSubmittedBy));
                Pram.Add(new SqlParameter("@SubmittedTo", vSubmittedTo));
                Pram.Add(new SqlParameter("@SendOnDate", SendDate));
                Pram.Add(new SqlParameter("@IsDisplay", IsDisplay));
                Pram.Add(new SqlParameter("@Attachment", Attachment));
                Pram.Add(new SqlParameter("@MsgID", MsgId));
                DBT.P_ExecuteNonQuery(strinsert, Pram);
                string strGetID = DBT.returnOneValue("select MAX(ID) from NotificationsDet");
                string strinsertLog = "insert into NotificationLog(CenterID,MsgID,isDisplay,isRead,NDID) values(@CenterID,@MsgID,@isDisplay,@isRead,@NDID)";
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@CenterID", vSubmittedTo));
                Param.Add(new SqlParameter("@MsgID", MsgId));
                Param.Add(new SqlParameter("@isDisplay", "1"));
                Param.Add(new SqlParameter("@isRead", "0"));
                Param.Add(new SqlParameter("@NDID", strGetID));
                DBT.P_ExecuteNonQuery(strinsertLog, Param);
            }
        }

       // ddlCenter.SelectedValue = "0";
        txtMessage.Text = "";
        LoadData();
    }
    
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvNotification.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet("select * from NotificationsDet where Id=@id",prm);

        txtUpdateMessage.Text = ds.Tables[0].Rows[0]["NotifMessage"].ToString();
        lblShowSendTo.Text = ds.Tables[0].Rows[0]["SubmittedTo"].ToString();
        lblMsgID.Text = ds.Tables[0].Rows[0]["MsgID"].ToString();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openEditModal();", true);        
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvNotification.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet("select * from NotificationsDet where Id=@id",prm);
        if(ds.Tables[0].Rows[0]["Attachment"].ToString()!="")
        {
            imgPreview.ImageUrl = "~/Notification_Attachment/" + ds.Tables[0].Rows[0]["Attachment"].ToString();
            lblShowAttachName.Text = ds.Tables[0].Rows[0]["Attachment"].ToString();
           // btnDownload.Visible = true;
        }
        else
        {
            lblShowAttachName.Text = "No Attachment Found";
            //btnDownload.Visible = false;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "ViewAttach();", true);
    }
   
    protected void btnUdate_Click(object sender, EventArgs e)
    {
        string vMessage = txtUpdateMessage.Text;
        string strupdate = "update NotificationsDet set NotifMessage=@NotifMessage where MsgID=@MsgID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@NotifMessage", vMessage));
        Pram.Add(new SqlParameter("@MsgID", lblMsgID.Text));
        DBT.P_ExecuteNonQuery(strupdate, Pram);
        Response.Redirect("~/SuperAdminBackend/SendNotifocation.aspx");
    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelect = (CheckBox)sender;  // get the link button which trigger the event
        GridViewRow row = (GridViewRow)chkSelect.NamingContainer; // get the GridViewRow that contains the linkbutton         
        int idChk = row.RowIndex;
    }
}