using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminForgotPassword : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string vEmail = txtEmail.Text;
        
        string strGetData = "select * from AdminLogin where EmailID=@EmailID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@EmailID", vEmail));

        DataSet ds = DBT.P_returnDataSet(strGetData,pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            SendMail(vEmail, "-NPCVBSkillsDevelopment");
        }
        else
        {
            Response.Write("<script>alert('Something went Wrong');</script>");
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
        string vEmail = txtEmail.Text;
        string qry = "select * from AdminLogin where EmailID= @EmailID";
       
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@EmailID", vEmail));
        string strGetPassword = DBT.P_returnOneValue(qry,pram);

        string returnString = "<table cellpadding='10'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='2' style='background-color:#3AB7FF; text-align:center; color:white; font-variant:small-caps;'>Your Password:   " + DateTime.Now.ToString("dd MMM yyyy") + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='background-color:#EFF7FA;'>Password</td><td style='background-color:#D3FFD5;'>" + strGetPassword + "</td>";
        returnString = returnString + "</tr>";        
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='2' style='background-color:#3AB7FF; text-align:center; color:white; font-variant:small-caps;'> Note:Please Change your Password Before Use</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        return returnString;
    }
}