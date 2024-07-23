using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Default2 : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadReeater();
            LoadNewsElement();
            LoadSlider();
            LoadMarquee();
            LoadBanner();
        }
    }
    protected void LoadBanner()
    {
        string strGetData = "Select * from PopupBanner where ID=@ID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@ID", "1"));
       // DBT.P_returnDataSet(strGetData, pram);
        DataSet ds = DBT.P_returnDataSet(strGetData,pram);
      
        lblpopH2.Text = ds.Tables[0].Rows[0]["HBottom"].ToString();
        imgImage.ImageUrl = "~/images/" + ds.Tables[0].Rows[0]["BnrImg"].ToString();
        
    }
    protected void LoadReeater()
    {
        string strGetData = "select * from CenterRegistration where isrequest=@isrequest and IsLogin=@IsLogin order by id desc";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@isrequest", "1"));
        pram.Add(new SqlParameter("@IsLogin", "1"));
        rptCenter.DataSource = DBT.P_returnDataSet(strGetData,pram);
        rptCenter.DataBind();
    }
    protected void LoadMarquee()
    {
        string getData = "select * from SliderStatement where ID=@ID";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@ID", "1"));
        
        DataSet ds = DBT.P_returnDataSet(getData, pram);
        lblMsg.Text = ds.Tables[0].Rows[0]["SliderStatement"].ToString();
    }
    protected void LoadNewsElement()
    {
        string strGetData = "select top 10 * from NotificationsDet where SubmittedTo=@SubmittedTo order by id desc";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@SubmittedTo", "Website"));

        //DataSet ds = DBT.P_returnDataSet(strGetData, pram);
        rptLatestNew.DataSource = DBT.P_returnDataSet(strGetData, pram);
        rptLatestNew.DataBind();
    }
    protected void LoadSlider()
    {
        string GetData = "select top 1 * from MainSlider order by id desc";
        DataSet ds = DBT.returnDataSet(GetData);
        if (ds.Tables[0].Rows.Count > 0)
        {
            img1.ImageUrl = "~/MainSlider/" + ds.Tables[0].Rows[0]["Image1"].ToString();
            img2.ImageUrl = "~/MainSlider/" + ds.Tables[0].Rows[0]["Image2"].ToString();
            img3.ImageUrl = "~/MainSlider/" + ds.Tables[0].Rows[0]["Image3"].ToString();
            img4.ImageUrl = "~/MainSlider/" + ds.Tables[0].Rows[0]["Image4"].ToString();
            img5.ImageUrl = "~/MainSlider/" + ds.Tables[0].Rows[0]["Image5"].ToString();
        }
        else
        {
            img1.ImageUrl = "~/Image/nlogo.png";
            img2.ImageUrl = "~/Image/nlogo.png";
            img3.ImageUrl = "~/Image/nlogo.png";
            img4.ImageUrl = "~/Image/nlogo.png";
            img5.ImageUrl = "~/Image/nlogo.png";
        }

        
    }
}