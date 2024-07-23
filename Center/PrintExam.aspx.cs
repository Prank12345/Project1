using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Center_PrintExam : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            loadquestion();
        }
    }
    protected void loadquestion()
    {
        string todatdate = DateTime.Now.ToShortDateString();
        string stID = Session["stID"].ToString();
        string[] splitID = stID.Split(',');
        string nid = "";
        int vLen = splitID.Length;
        DataTable dt = new DataTable();
        for(int i=0;i<vLen;i++)
        {
            nid = splitID[i];
            string getdata = "select * from AddStudent astd , CenterRegistration creg, SetMainExam me where astd.Cid=creg.id and me.Sid=astd.id and astd.ID='" + nid+"' and me.ElistID="+Session["id"].ToString();
            DataSet ds = DBT.returnDataSet(getdata);
            if(dt.Rows.Count > 0)
            {
                dt.ImportRow(ds.Tables[0].Rows[0]);
            }
            else
            {
                dt = ds.Tables[0].Copy();
            }

        }

        rptShowData.DataSource = dt;
        rptShowData.DataBind();

    }

    
    protected void rptShowData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string strGetData = "select * from MainExam where ID=" + Session["id"].ToString();

            DataSet ds = DBT.returnDataSet(strGetData);
            Label lblSubName = (Label)e.Item.FindControl("lblSubName");
            lblSubName.Text = ds.Tables[0].Rows[0]["SubjectName"].ToString();
            Repeater rpt = (Repeater)e.Item.FindControl("rpt");
            string getdata = "select * from MainExQuestions where ExamID='" + Session["id"].ToString()+ "'";
            rpt.DataSource = DBT.returnDataSet(getdata);
            rpt.DataBind();
        }
    }
}