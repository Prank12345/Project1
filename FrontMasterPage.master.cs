using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontMasterPage : System.Web.UI.MasterPage
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Loadchk();
            loaddata();
        }
    }

   protected void Loadchk()
    {
        
    }

    protected void chkCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCheck.Checked == true)
        {
            btnSubmit.Enabled = true;
        }
        else
        {
            btnSubmit.Enabled = false;
        }
    }
    protected void loaddata()
    {
        string getCategory = "Select top 10 * from DowloadFile order by id desc";
        DataSet dsCategory = DBT.returnDataSet(getCategory);

        for (int i = 0; i < dsCategory.Tables[0].Rows.Count; i++)
        {
            downloadmenu.Items[0].ChildItems.Add(new MenuItem(dsCategory.Tables[0].Rows[i]["FileName"].ToString(), dsCategory.Tables[0].Rows[i]["ID"].ToString(), null, "~/Downloads/" + dsCategory.Tables[0].Rows[i]["UploadFile"].ToString()));

        }
    }
   
    protected void SendMail(string to, string site)
    {
        string from = "noreply@npcvb.com"; //Replace this with your own correct Email Address
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
        client.Credentials = new System.Net.NetworkCredential(from, "9ly6kJ7?");
        client.Port = 25;
        client.Host = "mail.npcvb.com";
        client.EnableSsl = false;
        try
        {
            client.Send(mail);
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
        }
    }
    public string contact()
    {
        string returnString = "<table style='width:100%; border:1px solid black; '>";
        returnString = returnString + "<tr style='background-color:#003a6a;'>";
        returnString = returnString + "<td style='width:40%; padding-right:5px; padding-left:5px; text-align:center;'><h3 style='color:white;'>NATIONAL PARAMEDICAL COUNCIL AND VOCATIONAL BOARD SKILL DEVELOPMENT</ h3 ></td>";
        returnString = returnString + "<td style='width:20%; text-align:center; padding-top:5px; background-color:#c7d0fe;'><img src='http://www.npcvb.com/Image/nlogo.png' style='width:100px'/></td>";
        returnString = returnString + "<td style='width:40%; padding-left:5px; text-align:center'><h2 style='color:white;'> राष्ट्रीय पैरामेडिकल कॉउन्सिल एंड वोकेशनल बोर्ड कौशल विकास</h2></td> ";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table style='width:100%;'>";
        returnString = returnString + "<tr> <td style='text-align:center; padding-left:40px;'><h2>Enquiry For Admission</h2></td> </tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style=''>";
        returnString = returnString + "<table align='center' style='border:solid 1px lightgray; width:32%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'> <span style='padding:5px; padding-right:50px;'> Full Name </span></td>";
        returnString = returnString + "<td style='padding:5px;border-bottom:1px solid lightgray;'> <span style='padding:5px;'>" + txtfullName.Text + "</span></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Phone Number</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + txtPhone.Text + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>State</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + ddlState.SelectedItem.Text + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>City</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + txtCity.Text + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Pin Code</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + txtPinCode.Text + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Email</span></td>";
        returnString = returnString + "<td style='padding:5px;border-top:1px solid lightgray;'> <span style='padding:5px;'>" + txtEmail.Text + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Message</span></td>";
        returnString = returnString + "<td style='padding:5px;border-top:1px solid lightgray;'> <span style='padding:5px;'>" + txtMessage.Text + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr style='color:white; background-color:#003a6a; '>";
        returnString = returnString + "<td colspan='3' style='text-align:center; padding:20px; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:12px;'>";
        returnString = returnString + "<p style='text-align:justify;'> Save Paper !Save Trees!Before printing, think about the environment.</p> ";
        returnString = returnString + "<p style='text-align:justify;'> The information in this e - mail and any attachments is confidential and may be legally privileged.It is intended solely for the addressee or addressees.If you are not an intended recipient, please delete the message and any attachments and notify the sender of misdelivery.Any use or disclosure of the contents of either is unauthorized and may be unlawful.All liability for viruses is excluded to the fullest extent permitted by law.Any views expressed in this message are those of the individual sender, except where the sender states them, with requisite authority, to be those of the specific NPCVB SKILL DEVELOPMENT Pvt Ltd. </p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        return returnString;
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        SendMail("info@npcvb.com", "-NPCVB-");
    }
}
