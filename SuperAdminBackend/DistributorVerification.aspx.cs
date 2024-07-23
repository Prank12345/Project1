using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_DistributorVerification : System.Web.UI.Page
{
    string Password = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGvCenter();

        }
    }
    DBTrac DBT = new DBTrac();
    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void LoadGvCenter()
    {
        string strGetData = "select * from Distributors where IsRequest=@IsRequest order by id desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@IsRequest", "0"));

        gvCenter.DataSource = DBT.P_returnDataSet(strGetData,Pram);
        gvCenter.DataBind();
    }

    protected void gvCenter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlVerification");
            DataRowView dr = (DataRowView)e.Row.DataItem;

            string vOld = dr["IsRequest"].ToString();


            if (vOld == "0")
            {

                ddl.Items.FindByValue("0").Selected = true;

            }
            else if (vOld == "1")
            {
                ddl.Items.FindByValue("1").Selected = true;
            }
            else if (vOld == "2")
            {
                ddl.Items.FindByValue("2").Selected = true;
            }

        }
    }

    protected void ddlVerification_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.NamingContainer;

        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();

        if (ddl.SelectedValue == "0")
        {
            string updateDisplay = "Update Distributors Set IsRequest = @IsRequest Where ID = @ID" + id;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@IsRequest", "0"));
            Pram.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay,Pram);

            LoadGvCenter();

        }

        if (ddl.SelectedValue == "1")
        {
            DBTrac DBT = new DBTrac();
            Random ren = new Random();

            Password = "NPCVB" + ren.Next(999999);
            string vVerifyDate = DateTime.Now.ToShortDateString();
            string vRenwalDate = DateTime.Now.AddYears(5).ToShortDateString();
            string updateDisplay = "Update Distributors Set IsRequest = @IsRequest,Password=@Password Where ID = @ID" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@Password", Password));
            Pram.Add(new SqlParameter("@IsRequest", "1"));
            Pram.Add(new SqlParameter("@ID", id));

            DBT.P_ExecuteNonQuery(updateDisplay, Pram);

            string Get = "select * from Distributors where id=@id" ;
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@id", id));
            DataSet ds = DBT.P_returnDataSet(Get,Pr);
            SendMail(ds.Tables[0].Rows[0]["EmailID"].ToString(), "NPCVBSkillDevelopment", id);


            ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openModal();", true);
            LoadGvCenter();
        }
        if (ddl.SelectedValue == "2")
        {
            string updateDisplay = "Update Distributors Set IsRequest = @IsRequest Where ID = @ID" + id;
            List<SqlParameter> Pr = new List<SqlParameter>();
            Pr.Add(new SqlParameter("@IsRequest", "2"));
            Pr.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();
            DBT.P_ExecuteNonQuery(updateDisplay,Pr);

            hf.Value = id;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openRejectMessage();", true);
            LoadGvCenter();
        }
    }
    protected void SendMailR(string to, string site, string id)
    {
        string from = "noreply@npcvb.com"; //Replace this with your own correct Gmail Address

        MailMessage mail = new MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "Message From Website", System.Text.Encoding.UTF8);
        mail.Subject = "Center Registration Rejected" + site;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = contactR(id);
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
    protected void SendMail(string to, string site, string id)
    {
        string from = "noreply@npcvb.com"; //Replace this with your own correct Gmail Address

        MailMessage mail = new MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "Message From Website", System.Text.Encoding.UTF8);
        mail.Subject = "Your Center ID and password" + site;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = contact(id);
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


    public string contact(string id)
    {
        string Get = "select * from Distributors where id=@id";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet(Get,pram);
        string returnString = "<table style='width:100%; border:1px solid black; '>";
        returnString = returnString + "<tr style='background-color:#003a6a;'>";
        returnString = returnString + "<td style='width:40%; padding-right:5px; padding-left:5px; text-align:center;'><h3 style='color:white;'>NATIONAL PARAMEDICAL COUNCILAND VOCATIONAL BOARD SKILL DEVELOPMENT</ h3 ></td>";
        returnString = returnString + "<td style='width:20%; text-align:center; padding-top:5px; background-color:#c7d0fe;'><img src='http://www.npcvb.com/Image/nlogo.png' style='width:100px'/></td>";
        returnString = returnString + "<td style='width:40%; padding-left:5px; text-align:center'><h2 style='color:white;'> राष्ट्रीय पैरामेडिकल काउंसिल एंड वोकेशनल बोर्ड कौशल विकास </h2></td> ";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table align='center'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/NationalHumanRightsCommission.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/ISO9001-2015.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/NationalComissionForWomen.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/QRO.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/wcd.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/nspfb.png' style='width:80px;'/></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + " <hr />";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table style='width:100%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='text-align:center; padding-left:40px;'><h2>Welcome To NPCVB skill Development</h2></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding-left:200px;'>";
        returnString = returnString + "<p style='color:red;padding-left:200px; font-family:Arial;'>Hi, <b>" + ds.Tables[0].Rows[0]["FullName"].ToString() + "(" + ds.Tables[0].Rows[0]["DistributorID"].ToString() + ")" + "</b></p>";
        returnString = returnString + "<p style='color:black; font-family:Arial;'>You Are All Set Now You Can Intrtoduce New Centers With Us And We Can Grow Together</p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='text-align:center;'> <p style='color:white; font-family:Arial; border:solid 1px black; padding:10px; margin-left:300px; margin-right:300px; background-color:#690319;color:yellow;'>Your Login Details To Use your Dashboard</p></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style=''>";
        returnString = returnString + "<table align='center' style='border:solid 1px lightgray; width:32%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'> <span style='padding:5px; padding-right:50px;'> center-ID </span></td>";
        returnString = returnString + "<td style='padding:5px;border-bottom:1px solid lightgray;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["DistributorID"].ToString() + "</span></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Login ID</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["EmailID"].ToString() + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Password</span></td>";
        returnString = returnString + "<td style='padding:5px;border-top:1px solid lightgray;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["Password"].ToString() + "</span><br/></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr><td colspan='3' style='margin-top:20px;'><a href='http://www.npcvb.com/DistributorLogin.aspx' style='color:white; font-family:Arial; border:solid 1px #3bcefe; padding:10px; margin-left:400px;margin-right:400px; background-color:#0ac3c8;text-decoration:none;'>Click Here To Login </a></td></tr>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='padding-left:10px;'>";
        returnString = returnString + "<p style='color:lightgray;'> Warm Rewards </p>";
        returnString = returnString + "<p style='color:gray;'> Verification Team </p>";
        returnString = returnString + "<p style='color:gray;'> NPCVB SKILL DEVELOPMENT Pvt Ltd</p>";
        returnString = returnString + "<p style='color:gray'> P - 7017830092 | E - Info@npcvb.com </p>";
        returnString = returnString + "<hr/>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='text-align:center;'>";

        returnString = returnString + "<table align='center'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td>";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/ministryofCorporateAffairs.png' style='width:100px;'/>";
        returnString = returnString + "</td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/ministryofLabourEmployment.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MinistryOfSkillDevelopment.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MinistryOfYouthAffairsAndSports.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MHA.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/msme.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MEIT.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/DigitalIndia.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/Ayush.png' style='width:100px;'/></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + " </td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr style='color:white; background-color:#003a6a; '>";
        returnString = returnString + "<td colspan='3' style='text-align:center; padding:20px; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:12px;'>";
        returnString = returnString + "<p style='text-align:justify;'> Save Paper !Save Trees!Before printing, think about the environment.</p> ";
        returnString = returnString + "<p style='text-align:justify;'> The information in this e - mail and any attachments is confidential and may be legally privileged.It is intended solely for the addressee or addressees.If you are not an intended recipient, please delete the message and any attachments and notify the sender of misdelivery.Any use or disclosure of the contents of either is unauthorized and may be unlawful.All liability for viruses is excluded to the fullest extent permitted by law.Any views expressed in this message are those of the individual sender, except where the sender states them, with requisite authority, to be those of the specific NPCVB SKILL DEVELOPMENT Pvt Ltd. </p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='text-align:center; padding:10px; color:white; background-color:#003a6a;'>";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/facebooklogo.png' width='40px' height='40px' />";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/insta.png' width='40px' height='40px' />";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/twitter.png' width='40px' height='40px' />";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        return returnString;
    }
    public string contactR(string id)
    {
        string Get = "select * from Distributors where id=@id" ;
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet(Get,pram);
        string returnString = "<table style='width:100%; border:1px solid black; '>";
        returnString = returnString + "<tr style='background-color:#003a6a;'>";
        returnString = returnString + "<td style='width:40%; padding-right:5px; padding-left:5px; text-align:center;'><h3 style='color:white;'>NATIONAL PARAMEDICAL COUNCILAND VOCATIONAL BOARD SKILL DEVELOPMENT</ h3 ></td>";
        returnString = returnString + "<td style='width:20%; text-align:center; padding-top:5px; background-color:#c7d0fe;'><img src='http://www.npcvb.com/Image/nlogo.png' style='width:100px'/></td>";
        returnString = returnString + "<td style='width:40%; padding-left:5px; text-align:center'><h2 style='color:white;'> राष्ट्रीय पैरामेडिकल काउंसिल एंड वोकेशनल बोर्ड कौशल विकास </h2></td> ";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table align='center'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/NationalHumanRightsCommission.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/ISO9001-2015.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/NationalComissionForWomen.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/QRO.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/wcd.png' style='width:80px;'/></td>";
        returnString = returnString + "<td style='width:100px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/nspfb.png' style='width:80px;'/></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + " <hr />";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3'>";
        returnString = returnString + "<table style='width:100%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='text-align:center; padding-left:40px;'><h2>Welcome To NPCVB skill Development</h2></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding-left:180px;'>";
        returnString = returnString + "<p style='color:red;padding-left:200px; font-family:Arial;'>Hello, <b>" + ds.Tables[0].Rows[0]["FullName"].ToString() + "</b></p>";
        returnString = returnString + "<p style='color:black; font-family:Arial;'>Sorry Your Request For Center Has been Rejected For the Following Reason</p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='text-align:center;'> <p style='color:white; font-family:Arial; border:solid 1px black; padding:10px; margin-left:300px; margin-right:300px; background-color:#690319;color:yellow;'>" + txtReason.Text + "</p></td>";
        returnString = returnString + "</tr>";

        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr><td colspan='3' style='margin-top:20px;'><a href='http://www.npcvb.com/CenterRegister.aspx' style='color:white; font-family:Arial; border:solid 1px #3bcefe; padding:10px; margin-left:400px;margin-right:400px; background-color:#0ac3c8;text-decoration:none;'>Click Here To Re-Register with different Email and Mobile Number </a></td></tr>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='padding-left:10px;'>";
        returnString = returnString + "<p style='color:lightgray;'> Warm Rewards </p>";
        returnString = returnString + "<p style='color:gray;'> Verification Team </p>";
        returnString = returnString + "<p style='color:gray;'> NPCVB SKILL DEVELOPMENT Pvt Ltd</p>";
        returnString = returnString + "<p style='color:gray'> P - 7017830092 | E - Info@npcvb.com </p>";
        returnString = returnString + "<hr/>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='text-align:center;'>";

        returnString = returnString + "<table align='center'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td>";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/ministryofCorporateAffairs.png' style='width:100px;'/>";
        returnString = returnString + "</td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/ministryofLabourEmployment.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MinistryOfSkillDevelopment.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MinistryOfYouthAffairsAndSports.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MHA.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/msme.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/MEIT.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/DigitalIndia.png' style='width:100px;'/></td>";
        returnString = returnString + "<td style='width:20px;'></td>";
        returnString = returnString + "<td><img src='http://www.npcvb.com/Image/Ayush.png' style='width:100px;'/></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + " </td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr style='color:white; background-color:#003a6a; '>";
        returnString = returnString + "<td colspan='3' style='text-align:center; padding:20px; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-size:12px;'>";
        returnString = returnString + "<p style='text-align:justify;'> Save Paper !Save Trees!Before printing, think about the environment.</p> ";
        returnString = returnString + "<p style='text-align:justify;'> The information in this e - mail and any attachments is confidential and may be legally privileged.It is intended solely for the addressee or addressees.If you are not an intended recipient, please delete the message and any attachments and notify the sender of misdelivery.Any use or disclosure of the contents of either is unauthorized and may be unlawful.All liability for viruses is excluded to the fullest extent permitted by law.Any views expressed in this message are those of the individual sender, except where the sender states them, with requisite authority, to be those of the specific NPCVB SKILL DEVELOPMENT Pvt Ltd. </p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td colspan='3' style='text-align:center; padding:10px; color:white; background-color:#003a6a;'>";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/facebooklogo.png' width='40px' height='40px' />";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/insta.png' width='40px' height='40px' />";
        returnString = returnString + "<img src='http://www.npcvb.com/Image/twitter.png' width='40px' height='40px' />";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        return returnString;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string Get = "select * from Distributors where id=@id" ;
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@id", hf.Value));
        DataSet ds = DBT.P_returnDataSet(Get,pram);
        SendMailR(ds.Tables[0].Rows[0]["EmailID"].ToString(), "NPCVBSkillDevelopment", hf.Value);
        Response.Redirect("DistributorVerification.aspx");
    }
}