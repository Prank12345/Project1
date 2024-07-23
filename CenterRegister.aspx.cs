using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CenterRegister : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    
    protected void btnregister_Click(object sender, EventArgs e)
    {
        
        string PersonName = txtname.Text;
        string Email = txtemail.Text;
        string InstituteName = txtinstit.Text;
        string Address = txtaddress.Text;
        string State = ddlState.SelectedItem.Text;
       
        string PinCode = txtpin.Text;
        string TotalPC = txtpcs.Text;
        string Staffs = txtstaff.Text;
        string PhoneNumber = txtphone.Text;
        string Varify = "";
        string VtotLab = txtTotalPracticalLab.Text;
        string vTotRoom = txtTotalTheoryRoom.Text;
        string vOffice = rblOffice.SelectedValue;
        string vToilet = rblToilet.Text;
        string vQual = txtQualification.Text;
        string vWorkExp = txtWorkExp.Text;

        string vRegistrationDate = DateTime.Now.ToShortDateString();
        string vIsDistributor = rblDistributor.SelectedValue;
        string vDistID = "";
       
        Random ren = new Random();
        string centerID = "";
        centerID = "NPCVB" + ren.Next(999999);
        string vLab = "";
        if (fuLab.HasFile)
        {
            vLab = centerID + fuLab.FileName;
            fuLab.SaveAs(Server.MapPath("~/Center-Document/" + vLab));
            //vLab = fuLab.FileName;
        }
        string vOfficePic = "";
        if (fuOffice.HasFile)
        {
            vOfficePic= centerID + fuOffice.FileName;
            fuOffice.SaveAs(Server.MapPath("~/Center-Document/" + vOfficePic));
            //vOfficePic = fuOffice.FileName;
        }
        string vRoom = "";
        if (fuRoom.HasFile)
        {
            vRoom = centerID + fuRoom.FileName;
            fuRoom.SaveAs(Server.MapPath("~/Center-Document/" + vRoom));
            //vRoom = fuRoom.FileName;

        }

       
        string passportpic = "";
        if (fuPhoto.HasFile)
        {
            passportpic = centerID + fuPhoto.FileName;
            fuPhoto.SaveAs(Server.MapPath("~/Center-Document/" + passportpic));
            //passportpic = fuPhoto.FileName;

            System.Drawing.Image img = System.Drawing.Image.FromStream(fuPhoto.PostedFile.InputStream);
            int height = img.Height;
            int width = img.Width;
            int size = fuPhoto.PostedFile.ContentLength;
            string dimension = width.ToString() + "*" + height.ToString();
            if (500 < size && dimension == "400*400")
            {
                string Signature = "";
                if (fuSign.HasFile)
                {
                    Signature = centerID + fuSign.FileName;
                    fuSign.SaveAs(Server.MapPath("~/Center-Document/" + Signature));
                   

                    System.Drawing.Image img1 = System.Drawing.Image.FromStream(fuSign.PostedFile.InputStream);
                    int width1 = img1.Width;
                    int height1 = img1.Height;
                    string dimension1 = width1.ToString() + "*" + height1.ToString();
                    int size1 = fuSign.PostedFile.ContentLength;
                    if (500 < size1  && dimension1 == "200*100")
                    {
                        string AadharCard = "";
                        if (fuAdhaar.HasFile)
                        {
                            AadharCard = centerID + fuAdhaar.FileName;
                            fuAdhaar.SaveAs(Server.MapPath("~/Center-Document/" + AadharCard));
                           

                        }

                        string Marksheet = "";
                        if (fuMarsht.HasFile)
                        {
                            Marksheet = centerID + fuMarsht.FileName;
                            fuMarsht.SaveAs(Server.MapPath("~/Center-Document/" + Marksheet));
                            
                        }

                        string ChkData = "select * from CenterRegistration where Email=@Email or PhoneNumber=@PhoneNumber or InstituteName=@InstituteName";
                        List<SqlParameter> pr = new List<SqlParameter>();
                        pr.Add(new SqlParameter("@Email", txtemail.Text));
                        pr.Add(new SqlParameter("@PhoneNumber", txtphone.Text));
                        pr.Add(new SqlParameter("@InstituteName", txtinstit.Text));
                        DataSet ds = DBT.P_returnDataSet(ChkData,pr);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("<script>alert('Center Has Been Already Registered....');</script>");
                        }
                        else
                        {
                            if (rblDistributor.SelectedValue == "0")
                            {
                                vDistID = "0";
                                string strInsertQry = "insert into CenterRegistration (PersonName,Email,InstituteName,Address,State,PinCode,TotalPC,Staffs,PhoneNumber,Varify,isrequest,AadharCard,Marksheet,passportpic,Signature,CenterID,RegisDate,TotNumPracticalLab,TotNumTheoryRoom,LabPicture,TheoryRoomPic,IsOffice,OfficePic,Toilet,Qualification,WorkExp,IsLogin,IsDistributor,DistID,IsActiveBackDate,IsShowPerformer) values(@PersonName,@Email,@InstituteName,@Address,@State,@PinCode,@TotalPC,@Staffs,@PhoneNumber,@Varify,@isrequest,@AadharCard,@Marksheet,@passportpic,@Signature,@CenterID,@RegisDate,@TotNumPracticalLab,@TotNumTheoryRoom,@LabPicture,@TheoryRoomPic,@IsOffice,@OfficePic,@Toilet,@Qualification,@WorkExp,@IsLogin,@IsDistributor,@DistID,@IsActiveBackDate,@IsShowPerformer)";

                                List<SqlParameter> Pram = new List<SqlParameter>();
                                Pram.Add(new SqlParameter("@PersonName", PersonName));
                                Pram.Add(new SqlParameter("@Email", Email));
                                Pram.Add(new SqlParameter("@InstituteName", InstituteName));
                                Pram.Add(new SqlParameter("@Address", Address));
                                Pram.Add(new SqlParameter("@State", State));
                                //Pram.Add(new SqlParameter("@District", District));
                                //Pram.Add(new SqlParameter("@City", City));
                                Pram.Add(new SqlParameter("@Pincode", PinCode));
                                Pram.Add(new SqlParameter("@TotalPC", TotalPC));
                                Pram.Add(new SqlParameter("@Staffs", Staffs));
                                Pram.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                                Pram.Add(new SqlParameter("@Varify", Varify));
                                Pram.Add(new SqlParameter("@isrequest", "0"));
                                Pram.Add(new SqlParameter("@AadharCard", AadharCard));
                                Pram.Add(new SqlParameter("@Marksheet", Marksheet));
                                Pram.Add(new SqlParameter("@passportpic", passportpic));
                                Pram.Add(new SqlParameter("@Signature", Signature));
                                Pram.Add(new SqlParameter("@CenterID", centerID));
                                Pram.Add(new SqlParameter("@RegisDate", vRegistrationDate));
                                Pram.Add(new SqlParameter("@TotNumPracticalLab", VtotLab));
                                Pram.Add(new SqlParameter("@TotNumTheoryRoom", vTotRoom));
                                Pram.Add(new SqlParameter("@LabPicture", vLab));
                                Pram.Add(new SqlParameter("@TheoryRoomPic", vRoom));
                                Pram.Add(new SqlParameter("@IsOffice", vOffice));
                                Pram.Add(new SqlParameter("@OfficePic", vOfficePic));
                                Pram.Add(new SqlParameter("@Toilet", vToilet));
                                Pram.Add(new SqlParameter("@Qualification", vQual));
                                Pram.Add(new SqlParameter("@WorkExp", vWorkExp));
                                Pram.Add(new SqlParameter("@IsLogin", "1"));
                                Pram.Add(new SqlParameter("@IsDistributor", vIsDistributor));
                                Pram.Add(new SqlParameter("@DistID", vDistID));
                                Pram.Add(new SqlParameter("@IsActiveBackDate", "0"));
                                Pram.Add(new SqlParameter("@IsShowPerformer", "0"));

                                DBT.P_ExecuteNonQuery(strInsertQry, Pram);

                                string strInsert = "insert into LatestAmtAdmCen (CenterID,Amount) values(@CenterID,@Amount)";
                                List<SqlParameter> Param = new List<SqlParameter>();
                                Param.Add(new SqlParameter("@CenterID", centerID));
                                Param.Add(new SqlParameter("@Amount", "0.00"));
                                DBT.P_ExecuteNonQuery(strInsert, Param);

                                Response.Write("<script>alert('You are succesfully Registered');</script>");
                            }
                            else
                            {
                                List<SqlParameter> sqp = new List<SqlParameter>();
                                sqp.Add(new SqlParameter("@DistributorID", txtDistNumber.Text));
                                DataSet distNumber = DBT.P_returnDataSet("select * from Distributors where DistributorID=@DistributorID",sqp);
                                if (distNumber.Tables[0].Rows.Count > 0)
                                {
                                    vDistID = distNumber.Tables[0].Rows[0]["ID"].ToString();
                                    string strInsertQry = "insert into CenterRegistration (PersonName,Email,InstituteName,Address,State,PinCode,TotalPC,Staffs,PhoneNumber,Varify,isrequest,AadharCard,Marksheet,passportpic,Signature,CenterID,RegisDate,TotNumPracticalLab,TotNumTheoryRoom,LabPicture,TheoryRoomPic,IsOffice,OfficePic,Toilet,Qualification,WorkExp,IsLogin,IsDistributor,DistID) values(@PersonName,@Email,@InstituteName,@Address,@State,@PinCode,@TotalPC,@Staffs,@PhoneNumber,@Varify,@isrequest,@AadharCard,@Marksheet,@passportpic,@Signature,@CenterID,@RegisDate,@TotNumPracticalLab,@TotNumTheoryRoom,@LabPicture,@TheoryRoomPic,@IsOffice,@OfficePic,@Toilet,@Qualification,@WorkExp,@IsLogin,@IsDistributor,@DistID)";

                                    List<SqlParameter> Pram = new List<SqlParameter>();
                                    Pram.Add(new SqlParameter("@PersonName", PersonName));
                                    Pram.Add(new SqlParameter("@Email", Email));
                                    Pram.Add(new SqlParameter("@InstituteName", InstituteName));
                                    Pram.Add(new SqlParameter("@Address", Address));
                                    Pram.Add(new SqlParameter("@State", State));
                                    //Pram.Add(new SqlParameter("@District", District));
                                    //Pram.Add(new SqlParameter("@City", City));
                                    Pram.Add(new SqlParameter("@Pincode", PinCode));
                                    Pram.Add(new SqlParameter("@TotalPC", TotalPC));
                                    Pram.Add(new SqlParameter("@Staffs", Staffs));
                                    Pram.Add(new SqlParameter("@PhoneNumber", PhoneNumber));
                                    Pram.Add(new SqlParameter("@Varify", Varify));
                                    Pram.Add(new SqlParameter("@isrequest", "0"));
                                    Pram.Add(new SqlParameter("@AadharCard", AadharCard));
                                    Pram.Add(new SqlParameter("@Marksheet", Marksheet));
                                    Pram.Add(new SqlParameter("@passportpic", passportpic));
                                    Pram.Add(new SqlParameter("@Signature", Signature));
                                    Pram.Add(new SqlParameter("@CenterID", centerID));
                                    Pram.Add(new SqlParameter("@RegisDate", vRegistrationDate));
                                    Pram.Add(new SqlParameter("@TotNumPracticalLab", VtotLab));
                                    Pram.Add(new SqlParameter("@TotNumTheoryRoom", vTotRoom));
                                    Pram.Add(new SqlParameter("@LabPicture", vLab));
                                    Pram.Add(new SqlParameter("@TheoryRoomPic", vRoom));
                                    Pram.Add(new SqlParameter("@IsOffice", vOffice));
                                    Pram.Add(new SqlParameter("@OfficePic", vOfficePic));
                                    Pram.Add(new SqlParameter("@Toilet", vToilet));
                                    Pram.Add(new SqlParameter("@Qualification", vQual));
                                    Pram.Add(new SqlParameter("@WorkExp", vWorkExp));
                                    Pram.Add(new SqlParameter("@IsLogin", "1"));
                                    Pram.Add(new SqlParameter("@IsDistributor", vIsDistributor));
                                    Pram.Add(new SqlParameter("@DistID", vDistID));

                                    DBT.P_ExecuteNonQuery(strInsertQry, Pram);

                                    string strInsert = "insert into LatestAmtAdmCen (CenterID,Amount) values(@CenterID,@Amount)";
                                    List<SqlParameter> Param = new List<SqlParameter>();
                                    Param.Add(new SqlParameter("@CenterID", centerID));
                                    Param.Add(new SqlParameter("@Amount", "0.00"));
                                    DBT.P_ExecuteNonQuery(strInsert, Param);

                                    Response.Write("<script>alert('You are succesfully Registered');</script>");
                                }
                                else
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No Distributor Found!');", true);
                                }
                            }
                            //Loadfu()
                            
                        }
                        
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Insert Signature with dimension 200*100 and size less than 500KB.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Select Center Image!');", true);
                }

               
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Insert Passport size image with dimension 400*400 and size less than 500KB.');", true);

            }
                
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Select Center Image!');", true);
        }
       
       
    }

    protected void rblDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rblDistributor.SelectedValue=="0")
        {
            lbldistNum.Visible = false;
            txtDistNumber.Visible = false;
        }
        else
        {
            lbldistNum.Visible = true;
            txtDistNumber.Visible = true;
        }
    }
}