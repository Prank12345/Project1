using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Courses : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();   
    static int index;
    static int indexct;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            courses();
            index = 1;
            indexct = 1;
        }
    }

    protected int getIndex()
    {
        return index;
    }
    protected void incrementIndex()
    {
        index++;
    }

    protected int getIndexct()
    {
        return indexct;
    }
    protected void incrementIndexct()
    {
        indexct++;
    }
    protected void courses()
    {
        string GetData = "select * from CourseType";
        rptCourseType.DataSource = DBT.returnDataSet(GetData);
        rptCourseType.DataBind();
    }

    protected void rprcourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfID");
            Label lbl = (Label)e.Item.FindControl("lblExm");
            
          
            GridView gv = (GridView)e.Item.FindControl("gvSemester");
            string GetData = "select * from Semesters where CourseID=@CourseID";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CourseID", hf.Value));
            DataSet ds = DBT.P_returnDataSet(GetData,pram);
            string ExamFees = "";
            double totExm = 0;
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                ExamFees = ds.Tables[0].Rows[i]["ExamFees"].ToString();
                totExm = totExm + Convert.ToDouble(ExamFees);
            }
            lbl.Text = Convert.ToString(totExm);
            gv.DataSource = DBT.P_returnDataSet(GetData,pram);
            gv.DataBind();
        }
    }

    protected void gvSemester_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            Label lbCode = e.Row.FindControl("lblCode") as Label;
            Label lbsub = e.Row.FindControl("lblSubject") as Label;
            HiddenField hfCode = e.Row.FindControl("hfCode") as HiddenField;
            HiddenField hfSubject = e.Row.FindControl("hfSubject") as HiddenField;
            string vcode = hfCode.Value;
            string vsub = hfSubject.Value;
            string[] codesplit = vcode.Split(',');
            
            foreach(string code in codesplit)
            {
                lbCode.Text =lbCode.Text+"<br/>"+ code;
                
            }
            lbCode.Text = lbCode.Text.Remove(0, 5).ToString();
            string[] Subject = vsub.Split(',');
            foreach (string sub in Subject)
            {
                lbsub.Text = lbsub.Text + "<br/>" + sub;
               
            }
            lbsub.Text = lbsub.Text.Remove(0, 5).ToString();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string SearchKey = txtSearch.Text;
        string GetData = "select * from CourseType where CourseType like @CourseType";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@CourseType", SearchKey));
        DataSet ds = DBT.P_returnDataSet(GetData,pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rptCourseType.Visible = true;
            lblMsg.Visible = false;
            rptCourseType.DataSource = DBT.returnDataSet(GetData);
            rptCourseType.DataBind();
        }
        else
        {
            rptCourseType.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No Record Found";
        }
    }

    protected void rptCourseType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("hfIDCT");
           
            Repeater rpt = (Repeater)e.Item.FindControl("rprcourse");

            string getdata = "select * from Courses where CTID=@CTID order by ShortName asc";
            List<SqlParameter> pram = new List<SqlParameter>();
            pram.Add(new SqlParameter("@CTID",hf.Value));
            rpt.DataSource = DBT.P_returnDataSet(getdata,pram);
            rpt.DataBind();
        }
    }
}