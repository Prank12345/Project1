using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data.SqlClient;

public partial class Centers : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static int index;
    static string email = "";
    static string institute;
    protected void Page_Load(object sender, EventArgs e)
    {
        institute = "";
        if(!IsPostBack)
        {
            centerdata();
            index = 1;
        }
    }

    protected int getIndex()
    {
        return index;
    }
    protected void incrementIndex()
    {
        index++;
    }
    protected void centerdata()
    {
        string getdata = "select * from CenterRegistration where isrequest=@isrequest and IsLogin=@IsLogin order by InstituteName asc";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@isrequest", "1"));
        pram.Add(new SqlParameter("@IsLogin", "1"));
        //rptcenter.DataSource = DBT.returnDataSet(getdata);
        //rptcenter.DataBind();
        rptCenterName.DataSource = DBT.P_returnDataSet(getdata,pram);
        rptCenterName.DataBind();
    }

    protected void rptCenterName_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lbl = (Label)item.FindControl("lblc");
            HiddenField hf = (HiddenField)item.FindControl("hfEmail");
                if (dr["email"].ToString() != "")
                {
                    email = hf.Value;
                }
                else
                {
                    Response.Write("<script>alert('Message may not be send right now Please try again later..')</script>");
                }
            
        }
    }

    protected void btnmoveconfirm_Click(object sender, EventArgs e)
    {        
        SendMail(email, "NPCVBSkillDevelopment");
        Response.Redirect("Centers.aspx");
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
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "9ly6kJ7?");

        client.Port = 25; // Gmail works on this port
        client.Host = "mail.npcvb.com";
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
        
        string returnString = "<table style='width:100%; border:1px solid black; '>";
        returnString = returnString + "<tr style='background-color:#003a6a;'>";
        returnString = returnString + "<td style='width:40%; padding-right:5px; padding-left:5px; text-align:center;'><h3 style='color:white;'>NATIONAL PARAMEDICAL COUNCILAND VOCATIONAL BOARD SKILL DEVELOPMENT</ h3 ></td>";
        returnString = returnString + "<td style='width:20%; text-align:center; padding-top:5px; background-color:#c7d0fe;'><img src='http://www.npcvb.com/Image/nlogo.png' style='width:100px'/></td>";
        returnString = returnString + "<td style='width:40%; padding-left:5px; text-align:center'><h2 style='color:white;'> राष्ट्रीय पैरामेडिकल काउंसिल एंड वोकेशनल बोर्ड कौशल विकास </h2></td> ";
        returnString = returnString + "</tr>";
       
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table style='width:100%;'>";
        returnString = returnString + "<tr> <td style='text-align:center; padding-left:40px;'><h2>Enquiry For Admission</h2></td> </tr>";
        
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style=''>";
        returnString = returnString + "<table align='center' style='border:solid 1px lightgray; width:32%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'> <span style='padding:5px; padding-right:50px;'> Applicant Name </span></td>";
        returnString = returnString + "<td style='padding:5px;border-bottom:1px solid lightgray;'> <span style='padding:5px;'>" + txtName.Text + "</span></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>City</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + txtCity.Text + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Mail</span></td>";
        returnString = returnString + "<td style='padding:5px;border-top:1px solid lightgray;'> <span style='padding:5px;'>" + txtMail.Text + "</span></td>"; ;
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
   
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SearchKey = ddlState.SelectedItem.Text;
        string GetData = "select * from CenterRegistration where isrequest=@isrequest and IsLogin=@IsLogin and State like '%'+ @State +'%' ";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@isrequest", "1"));
        pram.Add(new SqlParameter("@IsLogin", "1"));
        pram.Add(new SqlParameter("@State", SearchKey));
        DataSet ds = DBT.P_returnDataSet(GetData,pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptCenterName.Visible = true;
            lblMsg.Visible = false;
            rptCenterName.DataSource = ds;
            rptCenterName.DataBind();
        }
        else
        {
            rptCenterName.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No Record Found";
        }
    }
}