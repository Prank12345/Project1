using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class Center_SendPassword : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if(!IsPostBack)
        {
            studentid();
        }
    }

    protected void lnkbtnSend_Click(object sender, EventArgs e)
    {
        try
        {
            DBTrac DBT = new DBTrac();
           

            SendMail(txtemail.Text, "-NPCVBSkillsDevelopment-");

           
            txtpass.Text = txtname.Text = txtemail.Text = "";
            ddlstudentid.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Wrong..Please try after sometime.');</script>");
        }

    }
    protected void SendMail(string to, string site)
    {
        string from = "noreply@jaynatechnologies.com"; //Replace this with your own correct Gmail Address

        MailMessage mail = new MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "Message From Website", System.Text.Encoding.UTF8);
        mail.Subject = "Your Center ID and password" + site;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = contact();
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "Noreply$2017");

        client.Port = 25; // Gmail works on this port
        client.Host = "mail.jaynatechnologies.com";
        client.EnableSsl = false; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);

            // Response.Write("<script>alert('Thanks for your message. We will revert back to you soon.');</script>");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try 
    }


    public string contact()
    {
        string returnString = "<table cellpadding='10'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='2' style='background-color:#3AB7FF; text-align:center; color:white; font-variant:small-caps;'>Your Password and Center ID:   " + DateTime.Now.ToString("dd MMM yyyy") + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='background-color:#EFF7FA;'>Password</td><td style='background-color:#D3FFD5;'>" + txtpass.Text + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='background-color:#EFF7FA;'>Center ID</td><td style='background-color:#D3FFD5;'>" + ddlstudentid.SelectedItem.Text + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='2' style='background-color:#3AB7FF; text-align:center; color:white; font-variant:small-caps;'> Note: Don't reply for this mail. Please Change your Password Before Use</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        return returnString;
    }
    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        string getData = "select * from AddStudent where id =@id";
        List<SqlParameter> PR = new List<SqlParameter>();
        PR.Add(new SqlParameter("@id", ddlstudentid.SelectedValue));
        DataSet dsCt = DBT.P_returnDataSet(getData,PR);
        txtname.Text = dsCt.Tables[0].Rows[0]["StudentName"].ToString();
        txtemail.Text = dsCt.Tables[0].Rows[0]["StudentEmail"].ToString();
        txtpass.Text = dsCt.Tables[0].Rows[0]["Password"].ToString();
    }
    protected void studentid()
    {
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where ID = @ID";
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pr);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string getdata = "select id,StudentID from AddStudent where IsRequest=@IsRequest and Cid=@Cid";
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@IsRequest", "1"));
        Pr1.Add(new SqlParameter("@Cid", Cid));
        DataSet ds = DBT.P_returnDataSet(getdata,Pr1);
        ddlstudentid.DataSource = ds;
        ddlstudentid.DataMember = ds.Tables[0].TableName;
        ddlstudentid.DataTextField = "StudentID";
        ddlstudentid.DataValueField = "id";
        ddlstudentid.DataBind();
        ddlstudentid.Items.Insert(0, new ListItem("--select Student ID--", "0"));


    }

}