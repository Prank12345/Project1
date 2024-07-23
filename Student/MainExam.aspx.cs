using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Student_MainExam : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static string fn;
    protected void Page_Load(object sender, EventArgs e)
    {
        //fn = "";
    }
    [WebMethod()]
    public static bool SaveCapturedImage(string data)
    {
        Random ren = new Random();
        string fileName = "NPCVB-OnlineExam" + ren.Next(999999);
        fn = fileName;
        //Convert Base64 Encoded string to Byte Array.
        byte[] imageBytes = Convert.FromBase64String(data.Split(',')[1]);

        //Save the Byte Array as Image File.
        string filePath = HttpContext.Current.Server.MapPath(string.Format("~/Student/Captures/{0}.jpg", fileName));
        File.WriteAllBytes(filePath, imageBytes);
        return true;
    }
    //protected void btnUpload_Click(object sender, EventArgs e)
    //{

    //    btnExm.Enabled = true;

    //}
    protected void btnExm_Click(object sender, EventArgs e)
    {
        if(Session["SID"]!=null)
        {
            string strGetData = "select * from SetMainExam where IsExamGiven=@IsExamGiven and SID=@SID";
            List<SqlParameter> Pram = new List<SqlParameter>();
            Pram.Add(new SqlParameter("@IsExamGiven","0"));
            Pram.Add(new SqlParameter("@SID", Session["SID"].ToString()));
            DataSet ds = DBT.P_returnDataSet(strGetData,Pram);
            string id = ds.Tables[0].Rows[0]["EListid"].ToString();
            string vFilename = fn;
            Session["EID"] = id;
            Session["fn"] = vFilename;
           
            Response.Redirect("MainExamPaper.aspx");
        }
       else
        {
            Response.Redirect("~/StudentLogin.aspx");
        }
    }
}