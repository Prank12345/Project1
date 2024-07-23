using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class SuperAdminBackend_ViewDistCenter : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData();
        }
    }
    protected void LoadData()
    {
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", Request.QueryString["DID"].ToString()));
        string strGetName = DBT.P_returnOneValue("select FullName from Distributors where ID=@ID",Pram);
        lblName.Text = strGetName;

        string strGetData = "select * from CenterRegistration where DistID=@ID order by ID desc";
        gvCenter.DataSource = DBT.P_returnDataSet(strGetData,Pram);
        gvCenter.DataBind();
       
    }

    protected void hlView_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
       
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        string getstudent = "select* from AddStudent where Cid=@Cid order by ID desc";
        gvstudent.DataSource = DBT.P_returnDataSet(getstudent,Pram);
        gvstudent.DataBind(); 
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openMod();", true);
    }
}