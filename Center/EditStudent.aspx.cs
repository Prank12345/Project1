using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Center_EditStudent : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    static string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        str = Request.QueryString["id"].ToString();
        if(!IsPostBack)
        {
            edit();
        }

    }
    protected void edit()
    {
        string strr = "select * from AddStudent where id=@id";
        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@id", str));
        DataSet ds = DBT.P_returnDataSet(strr,Pram);
        
        txtsname.Text= ds.Tables[0].Rows[0]["StudentName"].ToString();
        txtfhname.Text= ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
        txtdob.Text= ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
        rbgender.SelectedValue= ds.Tables[0].Rows[0]["Gender"].ToString();
        txtMName.Text = ds.Tables[0].Rows[0]["MotherName"].ToString();
        txtPhone.Text = ds.Tables[0].Rows[0]["StudentPhone"].ToString();
        txtOccupation.Text = ds.Tables[0].Rows[0]["FatherOccupation"].ToString();
        txtSOccupation.Text = ds.Tables[0].Rows[0]["StudentOccupation"].ToString();

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string vMName = txtMName.Text;
        string VPhone = txtPhone.Text;
        string vOccupation = txtOccupation.Text;
        string vSOccupation = txtSOccupation.Text;
        
        string StudentName = txtsname.Text;
        string FatherHusbandName = txtfhname.Text;
        string DateOfBirth = txtdob.Text;
        string Gender = rbgender.SelectedValue;


        string upd = "update AddStudent set StudentName=@StudentName,FatherHusbandName=@FatherHusbandName,DateOfBirth=@DateOfBirth,Gender=@Gender,MotherName=@MotherName,StudentPhone=@StudentPhone,FatherOccupation=@FatherOccupation,StudentOccupation=@StudentOccupation where id=@id";

        List<SqlParameter> Pram = new List<SqlParameter>();
        Pram.Add(new SqlParameter("@StudentName", StudentName));
        Pram.Add(new SqlParameter("@FatherHusbandName", FatherHusbandName));
        Pram.Add(new SqlParameter("@DateOfBirth", DateOfBirth));
        Pram.Add(new SqlParameter("@Gender", Gender));
        Pram.Add(new SqlParameter("@MotherName", vMName));
        Pram.Add(new SqlParameter("@StudentPhone", VPhone));
        Pram.Add(new SqlParameter("@FatherOccupation", vOccupation));
        Pram.Add(new SqlParameter("@StudentOccupation", vSOccupation));
        Pram.Add(new SqlParameter("@id", str));
        
        DBT.P_ExecuteNonQuery(upd, Pram);

            Response.Redirect("ManageStudent.aspx");
        }
    }

