using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_PopupBanner : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadBanner();
        }
    }
    protected void LoadBanner()
    {
        string strGetData = "select * from PopupBanner where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", "1"));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);

       
        txtH2.Text = ds.Tables[0].Rows[0]["HBottom"].ToString();
        lblImg.Text = ds.Tables[0].Rows[0]["BnrImg"].ToString();
        imgImage.ImageUrl= "~/images/"+ ds.Tables[0].Rows[0]["BnrImg"].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
        string vH2 = txtH2.Text;
        string vImage = "";
        if(fup.HasFile)
        {
            fup.SaveAs(Server.MapPath("~/images/" + fup.FileName));
            vImage = fup.FileName;
        }
        else
        {
            vImage = lblImg.Text;
        }
        string strUpdate = "update PopupBanner set HBottom=@HBottom,BnrImg=@BnrImg where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
      
        Pram.Add(new SqlParameter("@HBottom", vH2));
        Pram.Add(new SqlParameter("@BnrImg", vImage));
        Pram.Add(new SqlParameter("@ID", "1"));
        DBT.P_ExecuteNonQuery(strUpdate, Pram);
        Response.Redirect("PopupBanner.aspx");
    }
}