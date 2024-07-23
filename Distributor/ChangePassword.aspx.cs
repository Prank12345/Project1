using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distributor_ChangePassword : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void lnkbtnSubmit_Click(object sender, EventArgs e)
    {
        string login = "select Password from Distributors where ID=@ID";
        List<SqlParameter> Pr = new List<SqlParameter>();
        Pr.Add(new SqlParameter("@ID", Session["DID"].ToString()));
        DataSet ds = DBT.P_returnDataSet(login,Pr);
        if (txtOld.Text != ds.Tables[0].Rows[0]["Password"].ToString())
        {
            Label1.Text = "Password is incorrect";
        }
        else
        {
            string password = txtNew.Text;
            if (txtNew.Text != txtConfirm.Text)
            {
                Label1.Text = "Mismatch Password";
            }
            else
            {
                string insertqry = "update Distributors set Password=@Password where ID=@ID";
                List<SqlParameter> Pmeter = new List<SqlParameter>();
                Pmeter.Add(new SqlParameter("@Password", password));
                Pmeter.Add(new SqlParameter("@ID", Session["DID"].ToString()));
                DBT.P_ExecuteNonQuery(insertqry, Pmeter);
                Response.Redirect("~/Distributor/Dashboard.aspx");
            }

        }
    }
}