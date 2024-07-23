using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class OurBestPerformer : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            centerdata();
        }
    }
    protected void centerdata()
    {
        string getdata = "select * from CenterRegistration where isrequest=@isrequest and IsLogin=@IsLogin and IsShowPerformer= @IsShowPerformer order by PlaceOrder asc";
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@isrequest", "1"));
        prm.Add(new SqlParameter("@IsLogin", "1"));
        prm.Add(new SqlParameter("@IsShowPerformer", "1"));
        rptCenterName.DataSource = DBT.P_returnDataSet(getdata,prm);
        rptCenterName.DataBind();
    }
}