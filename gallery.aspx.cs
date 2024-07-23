using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gallery : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            getimage();
        }
    }
    protected void getimage()
    {
        string getdata = "select * from GalleryImage";
        rprimages.DataSource = DBT.returnDataSet(getdata);
        rprimages.DataBind();
    }
}