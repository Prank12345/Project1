using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_ChangePassword : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            logo();
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pram);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string login = "select Password from CenterRegistration where id=@id" ;
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@id", Cid));
        DataSet ds = DBT.P_returnDataSet(login,Pr);
        if (txtoldpass.Text != ds.Tables[0].Rows[0]["Password"].ToString())
        {
            Label1.Text = "Password is incorrect";
        }
        else
        {
            string password = txtnewpass.Text;
            if (txtnewpass.Text != txtpasscofrm.Text)
            {
                Label1.Text = "Mismatch Password";
            }
            else
            {
                string insertqry = "update CenterRegistration set Password=@Password where id=@id";
                List<SqlParameter> Pmeter = new List<SqlParameter>();
                Pmeter.Add(new SqlParameter("@Password", password));
                Pmeter.Add(new SqlParameter("@id", Cid));
                DBT.P_ExecuteNonQuery(insertqry, Pmeter);
                Response.Redirect("~/Center/Dashboard.aspx");
            }

        }
    }
   protected void logo()
    {
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID" ;
            List<SqlParameter> PR = new List<SqlParameter>();
            PR.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,PR);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        string imglogos = "select * from CenterRegistration where id=@id";
        List<SqlParameter> Pr1 = new List<SqlParameter>();
        Pr1.Add(new SqlParameter("@id", Cid));
        DataSet ds = DBT.P_returnDataSet(imglogos,Pr1);
        imglogo.ImageUrl = "~/Center-Document/"+ ds.Tables[0].Rows[0]["CenterLogo"].ToString();
    }
    protected void btnchnglogo_Click(object sender, EventArgs e)
    {
        string imagelogo = "";
        string Cid = "";
        if (Session["centerid"] != null && Session["StaffID"] == null)
        {
            Cid = Session["centerid"].ToString();
        }

        else if (Session["centerid"] == null && Session["StaffID"] != null)
        {
            string strGetStaffData = "select * From CenterStaff where  ID = @ID";
            List<SqlParameter> Pr1 = new List<SqlParameter>();
            Pr1.Add(new SqlParameter("@ID", Session["StaffID"].ToString()));
            DataSet dsStLogin = DBT.P_returnDataSet(strGetStaffData,Pr1);
            Cid = dsStLogin.Tables[0].Rows[0]["CID"].ToString();
        }
        if (fulogo.HasFile)
        {
            fulogo.SaveAs(Server.MapPath("~/Center-Document/" + fulogo.FileName));
            imagelogo = fulogo.FileName;
            
        }
        string logoupdate = "update CenterRegistration set CenterLogo=@CenterLogo where id=@id" ;

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@CenterLogo", imagelogo));
        Pram.Add(new SqlParameter("@id", Cid));
        DBT.P_ExecuteNonQuery(logoupdate, Pram);
        logo();
    }
}