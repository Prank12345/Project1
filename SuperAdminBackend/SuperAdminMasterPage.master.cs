using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_SuperAdminMasterPage : System.Web.UI.MasterPage
{
    string id = "";
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        //id = Session["centerid"].ToString();
        if (!IsPostBack)
        {
            loadname();
        }

    }
    protected void loadname()
    {
        if (Session["Admin"] != null)
        {
            hlStaff.Visible = true;
            hlmsi.Visible = true;
            hlss.Visible = true;
            hlmpb.Visible = true;
            hld.Visible = true;
            hlgi.Visible = true;
            hlaft.Visible = true;
            hlmc.Visible = true;
            hldv.Visible = true;
            hlms.Visible = true;
            hlps.Visible = true;
            hlct.Visible = true;
            hlnc.Visible = true;
            hlew.Visible = true;
            hlsc.Visible = true;
            hlcl.Visible = true;
            hldl.Visible = true;
            hlsl.Visible = true;
            hlE.Visible = true;
            hlcr.Visible = true;
            hlvcq.Visible = true;
            hlnc.Visible = true;
            hlcp.Visible = true;
            hlwc.Visible = true;
            hlsv.Visible = true;
            hlcm.Visible = true;
          
        }
        else if (Session["StaffID"] != null)
        {
            string str = "select * from AdminStaff where id=@id";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@id", Session["StaffID"].ToString()));
            DataSet dsst = DBT.P_returnDataSet(str, Pram);
            if (dsst.Tables[0].Rows[0]["ManagePopupBanner"].ToString() != "0")
            {
                hlmpb.Visible = true;
            }
            else
            {
                hlmpb.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["StaffManagement"].ToString() != "0")
            {
                hlStaff.Visible = true;
            }
            else
            {
                hlStaff.Visible = false;
            }
            if(dsst.Tables[0].Rows[0]["MainSliderImage"].ToString() != "0" || dsst.Tables[0].Rows[0]["SlidingStatement"].ToString() != "0" || dsst.Tables[0].Rows[0]["Download"].ToString() != "0" || dsst.Tables[0].Rows[0]["Gallery"].ToString() != "0" || dsst.Tables[0].Rows[0]["AddFreeTest"].ToString() != "0")
            {
                hlwc.Visible = true;
            }
            else
            {
                hlwc.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["MainSliderImage"].ToString() != "0")
            {
                hlmsi.Visible = true;
            }
            else
            {
                hlmsi.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["SlidingStatement"].ToString() != "0")
            {
                hlss.Visible = true;
            }
            else
            {
                hlss.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["Download"].ToString() != "0")
            {
                hld.Visible = true;
            }
            else
            {
                hld.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["Gallery"].ToString() != "0")
            {
                hlgi.Visible = true;
            }
            else
            {
                hlgi.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["AddFreeTest"].ToString() != "0")
            {
                hlaft.Visible = true;
            }
            else
            {
                hlaft.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["CenterVerification"].ToString() != "0")
            {
                hlmc.Visible = true;
            }
            else
            {
                hlmc.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["DistributorVerification"].ToString() != "0")
            {
                hldv.Visible = true;
            }
            else
            {
                hldv.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["VerifyStudent"].ToString() != "0" || dsst.Tables[0].Rows[0]["PendingStudent"].ToString() != "0")
            {
                hlsv.Visible = true;
            }
            else
            {
                hlsv.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["VerifyStudent"].ToString() != "0")
            {
                hlms.Visible = true;
            }
            else
            {
                hlms.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["PendingStudent"].ToString() != "0")
            {
                hlps.Visible = true;
            }            
            else
            {
                hlps.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["CourseType"].ToString() != "0" || dsst.Tables[0].Rows[0]["NewCourse"].ToString() != "0")
            {
                hlcm.Visible = true;
            }
            else
            {
                hlcm.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["CourseType"].ToString() != "0")
            {
                hlct.Visible = true;
            }
            else
            {
                hlct.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["NewCourse"].ToString() != "0")
            {
                hlnc.Visible = true;
            }
            else
            {
                hlnc.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["eWallet"].ToString() != "0")
            {
                hlew.Visible = true;
            }
            else
            {
                hlew.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["StudentCertification"].ToString() != "0")
            {
                hlsc.Visible = true;
            }
            else
            {
                hlsc.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["CenterList"].ToString() != "0")
            {
                hlcl.Visible = true;
            }
            else
            {
                hlcl.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["DistributorList"].ToString() != "0")
            {
                hldl.Visible = true;
            }
            else
            {
                hldl.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["StudentList"].ToString() != "0")
            {
                hlsl.Visible = true;
            }
            else
            {
                hlsl.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["Exams"].ToString() != "0")
            {
                hlE.Visible = true;
            }
            else
            {
                hlE.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["CenterRenewal"].ToString() != "0")
            {
                hlcr.Visible = true;
            }
            else
            {
                hlcr.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["ViewCenterQuerries"].ToString() != "0")
            {
                hlvcq.Visible = true;
            }
            else
            {
                hlvcq.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["SendNotification"].ToString() != "0")
            {
                hlnc.Visible = true;
            }
            else
            {
                hlnc.Visible = false;
            }
            if (dsst.Tables[0].Rows[0]["ChangePassword"].ToString() != "0")
            {
                hlcp.Visible = true;
            }
            else
            {
                hlcp.Visible = false;
            }
        }
        else
        {
            Session["StaffID"] = null;
            Session["Admin"] = null;
            Response.Redirect("~/AdminLogin.aspx");

        }
    }
    protected void logout_click(object sender, EventArgs e)
    {
        Session["StaffID"] = null;
        Session["Admin"] = null;       
        Response.Redirect("~/AdminLogin.aspx");
    }

    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session["StaffID"] = null;
        Session["Admin"] = null;
        Response.Redirect("~/AdminLogin.aspx");
    }
}
