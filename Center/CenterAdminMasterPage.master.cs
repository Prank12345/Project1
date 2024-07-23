using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Center_CenterAdminMasterPage : System.Web.UI.MasterPage
{
    string id = "";
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        //id = Session["centerid"].ToString();
        if(!IsPostBack)
        {
            loadname();
        }

    }
    protected void loadname()
    {
        if (Session["centerid"] != null)
        {

            string str = "select * from CenterRegistration where id=@id" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@id", Session["centerid"].ToString()));
            DataSet ds = DBT.P_returnDataSet(str,Pram);
            lblname.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
            imgCenterHead.ImageUrl = "~/Center-Document/" + ds.Tables[0].Rows[0]["passportpic"].ToString();
        }
        else if (Session["StaffID"] != null)
        {
            string str = "select * from CenterStaff where id=@id" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@id", Session["StaffID"].ToString()));
            DataSet dsst = DBT.P_returnDataSet(str,Pram);
            lblname.Text = dsst.Tables[0].Rows[0]["FullName"].ToString();

            if (dsst.Tables[0].Rows[0]["MyProfile"].ToString()!="0")
            {
                hlProf.Visible = true;
            }
            else
            {
                hlProf.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["StaffManagement"].ToString() != "0")
            {
                hlStaff.Visible = true;
            }
            else
            {
                hlStaff.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["Student"].ToString() != "0")
            {
                hlStuMgmt.Visible = true;
            }
            else
            {
                hlStuMgmt.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["courses"].ToString() != "0")
            {
                hlCourse.Visible = true;
            }
            else
            {
                hlCourse.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["Test"].ToString() != "0")
            {
                hlTest.Visible = true;
            }
            else
            {
                hlTest.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["StudentCertificateReq"].ToString() != "0")
            {
                hlReqStuCerti.Visible = true;
            }
            else
            {
                hlReqStuCerti.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["SetMainExam"].ToString() != "0")
            {
                hlSetExam.Visible = true;
            }
            else
            {
                hlSetExam.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["eWallet"].ToString() != "0")
            {
                hlWallet.Visible = true;
            }
            else
            {
                hlWallet.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["SendStudPass"].ToString() != "0")
            {
                hlSendPass.Visible = true;
            }
            else
            {
                hlSendPass.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["MyQueries"].ToString() != "0")
            {
                hlQry.Visible = true;
            }
            else
            {
                hlQry.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["Notifications"].ToString() != "0")
            {
                hlNotif.Visible = true;
            }
            else
            {
                hlNotif.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["InternalMarks"].ToString() != "0")
            {
                hlNotif.Visible = true;
            }
            else
            {
                hlNotif.Visible = false;
            }
        }
        else
        {
            Session["StaffID"] = null;
            Session["centerid"] = null;
            Response.Redirect("~/CenterLogin.aspx");
            
        }
    }
    protected void logout_click(object sender, EventArgs e)
    {
        Session["StaffID"] = null;
        Session["centerid"] = null;
        //hlLogout.HRef = "~/CenterLogin.aspx";
        Response.Redirect("~/CenterLogin.aspx");
    }

    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session["StaffID"] = null;
        Session["centerid"] = null;       
        Response.Redirect("~/CenterLogin.aspx");
    }
}
