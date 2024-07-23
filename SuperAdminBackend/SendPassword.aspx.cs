using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_SendPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loadDropdownlist();
        }
    }
    protected void loadDropdownlist()
    {
        DBTrac DBT = new DBTrac();
        string strGetData = "Select * from CenterRegistration";
        DataSet dsCt = DBT.returnDataSet(strGetData);
        ddlCenter.DataSource = dsCt;
        ddlCenter.DataMember = dsCt.Tables[0].TableName;
        ddlCenter.DataTextField = "InstituteName";
        ddlCenter.DataValueField = "id";
        ddlCenter.DataBind();
        ddlCenter.Items.Insert(0, new ListItem("--Select Category--", "0"));
    }
    protected void lnkbtnSend_Click(object sender, EventArgs e)
    {
        try
        {
            DBTrac DBT = new DBTrac();
            string VcenterID = txtCenterIDGen.Text;
            string vPassword = txtPassGen.Text;

            SendMail(txtEmail.Text, ddlCenter.SelectedItem.Text);

            string strUpdate = "update CenterRegistration set Password=@Password,CenterID=@CenterID where Email=@Email";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@CenterID", VcenterID));
            Pram.Add(new SqlParameter("@Password", vPassword));
            Pram.Add(new SqlParameter("@Email", txtEmail.Text));
            DBT.P_ExecuteNonQuery(strUpdate,Pram);
            txtPassGen.Text = txtCenterIDGen.Text = txtEmail.Text = "";
            ddlCenter.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Something Wrong..Please try after sometime.');</script>");
        }
    }

    protected void ddlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBTrac DBT = new DBTrac();
        string strGetData = "Select id,Email from CenterRegistration where id=@id";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", ddlCenter.SelectedValue));
        DataSet dsCt = DBT.P_returnDataSet(strGetData,pram);
        txtEmail.Text = dsCt.Tables[0].Rows[0]["Email"].ToString();
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
        returnString = returnString + "<td style='background-color:#EFF7FA;'>Password</td><td style='background-color:#D3FFD5;'>" + txtPassGen.Text + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='background-color:#EFF7FA;'>Center ID</td><td style='background-color:#D3FFD5;'>" + txtCenterIDGen.Text+ "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='2' style='background-color:#3AB7FF; text-align:center; color:white; font-variant:small-caps;'> Note: Don't reply for this mail. Please Change your Password Before Use</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        return returnString;
    }
    protected void btnClickMe_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openModal();", true);
    }
}