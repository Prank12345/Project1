using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class SuperAdminBackend_ExamList : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {        
        if(!IsPostBack)
        {
            LoadGvCenter();
        }
    }
    protected void LoadGvCenter()
    {
        string strGetData = "select * from ExamList order by ID";
        gvCenter.DataSource = DBT.returnDataSet(strGetData);
        gvCenter.DataBind();
    }
    protected void loadrptr()
    {

    }

    protected void lbques_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        string ds = "select * from Questions where ExamID=@ExamID" + ID;
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ExamID", ID));

        rptQues.DataSource = DBT.P_returnDataSet(ds,Pram);
        rptQues.DataBind();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openQues();", true);


    }

    protected void lbCenDetail_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", id));
        string ID = DBT.P_returnOneValue("select CenterID from ExamList where id = @ID",Pram);
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ID", ID));
        DataSet ds = DBT.P_returnDataSet("select * from CenterRegistration where Id=@ID",Pram);
        lblCenterName.Text = ds.Tables[0].Rows[0]["InstituteName"].ToString();
        lblCenterID.Text = ds.Tables[0].Rows[0]["CenterID"].ToString();
        lblPersonName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
        lblCAddr.Text = ds.Tables[0].Rows[0]["Address"].ToString();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "openCer();", true);
    }
}