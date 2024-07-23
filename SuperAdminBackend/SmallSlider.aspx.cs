using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdminBackend_SmallSlider : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadSlider();
        }
        
    }

    private void LoadSlider()
    {
        string strGetData = "select * from SliderStatement where ID=@ID order by ID desc";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@ID", "1"));
        DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
        txtStatement.Text = ds.Tables[0].Rows[0]["SliderStatement"].ToString();
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string statement = txtStatement.Text;
        string strUpdateData = "update SliderStatement set SliderStatement=@SliderStatement where ID=@ID";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@SliderStatement", statement));
        Pram.Add(new SqlParameter("@ID", "1"));
        DBT.P_ExecuteNonQuery(strUpdateData, Pram);
        Response.Redirect("SmallSlider.aspx");
    }
}