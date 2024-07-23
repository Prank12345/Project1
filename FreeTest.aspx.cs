using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FreeTest : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadRepeater();
        }
    }

    private void LoadRepeater()
    {
        string GetData = "select * from ExamList where ExamType=@ExamType";
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@ExamType", "Free Test"));
        rptTest.DataSource = DBT.P_returnDataSet(GetData, prm);
        rptTest.DataBind();

    }

    protected void rptTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            Label lbl = (Label)item.FindControl("lblqueistion");
            HiddenField hf = (HiddenField)item.FindControl("hf");
            string getdata = "select * from FreeTestQuestion where ExamID=@ExamID";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@ExamID", hf.Value));
            DataSet ds = DBT.P_returnDataSet(getdata,Pram);
            int test = ds.Tables[0].Rows.Count;
            lbl.Text = Convert.ToString(test);
        }
    }
}