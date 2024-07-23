using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_ManageStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGvCenter();
            //loadCount();
        }
    }
    DBTrac DBT = new DBTrac();
    protected void gvCenter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
   
    protected void LoadGvCenter()
    {
        string strGetData = "select * from AddStudent where IsRequest=@IsRequest and isDirect=@isDirect order by id desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@IsRequest", "0"));
        Pram.Add(new SqlParameter("@isDirect", "0"));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetData,Pram);
        gvCenter.DataBind();
    }

  

    protected void gvCenter_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string Display = e.Row.Cells[0].Text.ToString();
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



        if (ddl.SelectedValue == "1")
        {
            try
            {
                DBTrac DBT = new DBTrac();
                List<SqlParameter> splp = new List<SqlParameter>();
                splp.Add(new SqlParameter("@ID", id));
                DataSet dsstrgetID = DBT.P_returnDataSet("select * from AddStudent where ID=@ID", splp);

                double totalAmount = 0.00;
                string vID = dsstrgetID.Tables[0].Rows[0]["Course"].ToString();
                string vCid = dsstrgetID.Tables[0].Rows[0]["Cid"].ToString();
                string strGetFees = "select * from Courses where id=@id";
                List<SqlParameter> pr = new List<SqlParameter>();
                pr.Add(new SqlParameter("@id", vID));
                DataSet dsfees = DBT.P_returnDataSet(strGetFees, pr);
                double RegisterFees = Convert.ToDouble(dsfees.Tables[0].Rows[0]["RegFeesUniv"].ToString());
                string strGetExamFee = "select * from Semesters where CourseID=@id";
                List<SqlParameter> pr1 = new List<SqlParameter>();
                pr1.Add(new SqlParameter("@id", vID));
                DataSet dsexFees = DBT.P_returnDataSet(strGetExamFee, pr1);
                double ExFees = 0.00;
                for (int i = 0; i < dsexFees.Tables[0].Rows.Count; i++)
                {
                    double ff = Convert.ToDouble(dsexFees.Tables[0].Rows[0]["ExamFees"].ToString());
                    ExFees = ExFees + ff;
                }
                totalAmount = RegisterFees + ExFees;

                string WalletAmount = "";

                string strGetCom = "";
                string strDistID = "";
                List<SqlParameter> pr2 = new List<SqlParameter>();
                pr2.Add(new SqlParameter("@Cid", vCid));
                string CenterID = DBT.P_returnOneValue("select CenterID from CenterRegistration where ID=@Cid", pr2);
                string strGetDist = DBT.P_returnOneValue("select DistID from CenterRegistration where ID=@Cid", pr2);
                if (strGetDist != "0")
                {
                    List<SqlParameter> prn = new List<SqlParameter>();
                    prn.Add(new SqlParameter("@id", strGetDist));
                    strGetCom = DBT.P_returnOneValue("select Comission from Distributors where ID=@id", prn);
                    strDistID = DBT.P_returnOneValue("select DistributorID from Distributors where ID=@id", prn);

                }
                List<SqlParameter> pr3 = new List<SqlParameter>();
                pr3.Add(new SqlParameter("@Cid", CenterID));
                WalletAmount = DBT.P_returnOneValue("select Amount from LatestAmtAdmCen where CenterID=@Cid", pr3);
                double wallAmt = Convert.ToDouble(WalletAmount);
                double WA = 0.00;
                double DA = 0.00;
                double AAmt = 0.00;
                if (totalAmount <= wallAmt)
                {
                    WA = wallAmt - totalAmount;
                    if (strGetCom != "0"&& strGetCom!="")
                    {
                        string DistAmt = "";
                        List<SqlParameter> prn1 = new List<SqlParameter>();
                        prn1.Add(new SqlParameter("@id", strGetDist));
                        string Distwallet = DBT.P_returnOneValue("select Amount from DistributorWallet where DID=@id", prn1);
                        double distWa = Convert.ToDouble(Distwallet);
                        double dw = 0.00;

                        int com = Convert.ToInt32(strGetCom);
                        DA = (totalAmount * com) / 100;
                        dw = DA + distWa;
                        // WA = WA - DA;
                        AAmt = totalAmount - DA;
                        string updateAW = "update LatestAmtAdmCen set Amount=@Amount where CenterID=@Cid";
                        List<SqlParameter> SqlPraa = new List<SqlParameter>();
                        SqlPraa.Add(new SqlParameter("@Amount", AAmt));
                        SqlPraa.Add(new SqlParameter("@Cid", "admin0000"));
                        DBT.P_ExecuteNonQuery(updateAW, SqlPraa);

                        DistAmt = Convert.ToString(dw);
                        string updateDistW = "update DistributorWallet set Amount=@Amount where DID=@DID";
                        List<SqlParameter> SqlPr1 = new List<SqlParameter>();
                        SqlPr1.Add(new SqlParameter("@Amount", DistAmt));
                        SqlPr1.Add(new SqlParameter("@DID", strGetDist));
                        DBT.P_ExecuteNonQuery(updateDistW, SqlPr1);

                        string strDInsert = "insert into TransactionDist (DistributorID,Particulars,Credit,Debit,Amount,PaySlip,PayDate) values(@DistributorID,@Particulars,@Credit,@Debit,@Amount,@PaySlip,@PayDate)";
                        List<SqlParameter> ParamD = new List<SqlParameter>();
                        ParamD.Add(new SqlParameter("@DistributorID", strGetDist));
                        ParamD.Add(new SqlParameter("@Particulars", "Student ADD Comission"));
                        ParamD.Add(new SqlParameter("@Credit", "1"));
                        ParamD.Add(new SqlParameter("@Debit", "0"));
                        ParamD.Add(new SqlParameter("@Amount", DA));
                        ParamD.Add(new SqlParameter("@PaySlip", ""));
                        ParamD.Add(new SqlParameter("@PayDate", DateTime.Now.ToShortDateString()));
                        DBT.P_ExecuteNonQuery(strDInsert, ParamD);
                    }

                    string updWallet = "update LatestAmtAdmCen set Amount=@Amount where CenterID=@Cid";
                    List<SqlParameter> SqlPr = new List<SqlParameter>();
                    SqlPr.Add(new SqlParameter("@Amount", WA));
                    SqlPr.Add(new SqlParameter("@Cid", CenterID));
                    DBT.P_ExecuteNonQuery(updWallet, SqlPr);

                    string strInsert = "insert into TransactionAdmCen (CenterID,Particulars,Credit,Debit,Amount,PaySlip,PayDate) values(@CenterID,@Particulars,@Credit,@Debit,@Amount,@PaySlip,@PayDate)";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@CenterID", vCid));
                    Param.Add(new SqlParameter("@Particulars", "Student ADD"));
                    Param.Add(new SqlParameter("@Credit", "3"));
                    Param.Add(new SqlParameter("@Debit", "1"));
                    Param.Add(new SqlParameter("@Amount", totalAmount.ToString()));
                    Param.Add(new SqlParameter("@PaySlip", ""));
                    Param.Add(new SqlParameter("@PayDate", DateTime.Now.ToShortDateString()));
                    DBT.P_ExecuteNonQuery(strInsert, Param);



                    string updateDisplay = "Update AddStudent Set isRequest = @IsRequest,isDirect=@isDirect,Password=@Password,RollNumber=@RollNumber Where ID = @ID";
                    Random ren = new Random();
                    string Password = "NPCVB" + ren.Next(999999);
                    string vRollNumber = "";
                    int ss = 2100;

                    ss = ss + Convert.ToInt32(id);
                    vRollNumber = "NPCVB-U8090-" + ss;
                    List<SqlParameter> Pram = new List<SqlParameter>();
                    Pram.Add(new SqlParameter("@Password", Password));
                    Pram.Add(new SqlParameter("@RollNumber", vRollNumber));
                    Pram.Add(new SqlParameter("@IsRequest", "1"));
                    Pram.Add(new SqlParameter("@isDirect", "3"));
                    Pram.Add(new SqlParameter("@ID", id));
                    DBT.P_ExecuteNonQuery(updateDisplay, Pram);

                    List<SqlParameter> PR = new List<SqlParameter>();
                    PR.Add(new SqlParameter("ID", id));
                    string Cid = DBT.P_returnOneValue("select Cid from AddStudent where ID=@ID", PR);
                    string Get = "select * from CenterRegistration where id=@ID";
                    List<SqlParameter> spr = new List<SqlParameter>();
                    spr.Add(new SqlParameter("@ID", Cid));
                    DataSet ds = DBT.P_returnDataSet(Get, spr);

                    LoadGvCenter();
                    //loadCount();
                    SendMail(ds.Tables[0].Rows[0]["Email"].ToString(), "NPCVBSkillDevelopment", id);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openModal();", true);
                }
                else
                {
                    Response.Write("<Script>alert('Insufficent Balance');</script>");
                }
            }
            catch(Exception ex)
            {

            }
        }
        if (ddl.SelectedValue == "2")
        {
            string updateDisplay = "Update AddStudent Set isRequest = @IsRequest,isDirect=@isDirect Where ID = @ID";
            List<SqlParameter> ud = new List<SqlParameter>();
            ud.Add(new SqlParameter("@IsRequest", "2"));
            ud.Add(new SqlParameter("@isDirect", "3"));
            ud.Add(new SqlParameter("@ID", id));
            DBTrac DBT = new DBTrac();

            DBT.P_ExecuteNonQuery(updateDisplay,ud);

            LoadGvCenter();
           // loadCount();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openPop();", true);
        }
    }
    protected void SendMail(string to, string site, string id)
    {
        string from = "noreply@jaynatechnologies.com"; //Replace this with your own correct Gmail Address

        MailMessage mail = new MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from, "Message From Website", System.Text.Encoding.UTF8);
        mail.Subject = "Your student's Student ID and password" + site;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = contact(id);
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


    
    public string contact(string id)
    {
        string Get = "select * from AddStudent where id=@id";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", id));
        DataSet ds = DBT.P_returnDataSet(Get,Pram);
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
        returnString = returnString + "<td style='text-align:center; padding-left:40px;'><h2>We Welcome Your Student To NPCVB skill Development Team</h2></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding-left:200px;'>";
        returnString = returnString + "<p style='color:red;padding-left:170px; font-family:Arial;'>Hi, Your Student:  <b>" + ds.Tables[0].Rows[0]["StudentName"].ToString() + "with Enrollment Number:-(" + ds.Tables[0].Rows[0]["StudentID"].ToString() + ")" + "</b></p>";
        returnString = returnString + "<p style='color:black; font-family:Arial;'>You Are All Set To Provide Passwords To Your Students And Enlighten Them And Enforce Them To Study Hard</p>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='text-align:center;'> <p style='color:white; font-family:Arial; border:solid 1px black; padding:10px; margin-left:300px; margin-right:300px; background-color:#690319;color:yellow;'>Your Students's Login Details</p></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style=''>";
        returnString = returnString + "<table align='center' style='border:solid 1px lightgray; width:32%;'>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'> <span style='padding:5px; padding-right:50px;'> Student-RollNumber </span></td>";
        returnString = returnString + "<td style='padding:5px;border-bottom:1px solid lightgray;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["RollNumber"].ToString() + "</span></td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Login ID</span></td>";
        returnString = returnString + "<td style='padding:5px;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["StudentEmail"].ToString() + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr>";
        returnString = returnString + "<td style='padding:5px;background-color:#c7d0fe;'><span style='padding:5px;padding-right:52px;'>Password</span></td>";
        returnString = returnString + "<td style='padding:5px;border-top:1px solid lightgray;'> <span style='padding:5px;'>" + ds.Tables[0].Rows[0]["Password"].ToString() + "</span></td>"; ;
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "</table>";
        returnString = returnString + "</td>";
        returnString = returnString + "</tr>";
        returnString = returnString + "<tr><td colspan='3' style='margin-top:20px;'><a href='http://www.npcvb.com/StudentLogin.aspx' style='color:white; font-family:Arial; border:solid 1px #3bcefe; padding:10px; margin-left:400px;margin-right:400px; background-color:#0ac3c8;text-decoration:none;'>Click Here For Student Login </a></td></tr>";
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
}