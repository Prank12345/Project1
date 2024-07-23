using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class SuperAdminBackend_StudentCertification : System.Web.UI.Page
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
        string strGetData = "select * from SemesterResult sr join AddStudent astud on sr.StuID=astud.id where sr.IsMarksheet=@mr order by sr.ID desc";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@mr", "2"));
        gvCenter.DataSource = DBT.P_returnDataSet(strGetData,pram);
        gvCenter.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string SearchKey = txtSearch.Text;
        // string GetData = "select * from SemesterResult sr join AddStudent astud on sr.StuID=astud.id where astud.StudentID LIKE '% @SearchKey %'";
        string GetData = "Select * from SemesterResult, AddStudent Where SemesterResult.StuID = AddStudent.id AND AddStudent.StudentID LIKE '%' + @asd + '%'";
        List<SqlParameter> pram = new List<SqlParameter>();
        pram.Add(new SqlParameter("@asd", SearchKey));
        DataSet ds = DBT.P_returnDataSet(GetData, pram);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvCenter.Visible = true;
            lblMsg.Visible = false;
            gvCenter.DataSource = DBT.P_returnDataSet(GetData, pram);
            gvCenter.DataBind();
        }
        else
        {
            gvCenter.Visible = false;
            lblMsg.Visible = true;
            lblMsg.Text = "No Record Found";
        }
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> Pra = new List<SqlParameter>();
        Pra.Add(new SqlParameter("@id", id));
        string getSemID =DBT.P_returnOneValue("select SemID from SemesterResult where ID=@id",Pra);
        string getStuID = DBT.P_returnOneValue("select StuID from SemesterResult where ID=@id",Pra);

        string strUpd = "update Result set IsMarksheet=@IsMarksheet where SemID=@SemID and StuID=@StuID";
        List<SqlParameter> Pram = new List<SqlParameter>();

        Pram.Add(new SqlParameter("@IsMarksheet", "1"));
        Pram.Add(new SqlParameter("@SemID", getSemID));       
        Pram.Add(new SqlParameter("@StuID", getStuID));
        string strUpdsem = "delete SemesterResult where id=@id";
        
        DBT.P_ExecuteNonQuery(strUpd,Pram);
        DBT.P_ExecuteNonQuery(strUpdsem,Pra);
        LoadData();
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Button btnSender = (Button)sender;
        GridViewRow row = (GridViewRow)btnSender.NamingContainer;
        string id = gvCenter.DataKeys[row.RowIndex].Value.ToString();
        List<SqlParameter> PRam = new List<SqlParameter>();
        PRam.Add(new SqlParameter("@id", id));
        string GetStuID = DBT.P_returnOneValue("select StuID from SemesterResult where ID=@ID",PRam);
        List<SqlParameter> prm = new List<SqlParameter>();
        prm.Add(new SqlParameter("@ID", GetStuID));
        string getID = DBT.P_returnOneValue("select * from AddStudent where ID=@ID",prm);
        Session["ID"] = getID;
        Session["SemRes"] = id;
        Response.Redirect("~/SuperAdminBackend/StudentCertificate.aspx");
    }
}