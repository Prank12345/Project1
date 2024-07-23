using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newcenters : System.Web.UI.Page
{
    DBTrac DBT = new DBTrac();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
        //    Center();
        //}
    }
    protected string Center()
    {
        string Get = "select * from CenterRegistration";
        DataSet ds = DBT.returnDataSet(Get);
        string returnString = "";
        for (int i=0;i<=ds.Tables[0].Rows.Count;i++)
        {
            returnString = "<div id='accordion'>";
            returnString = returnString + "<div class='card mt-3'>";
            returnString = returnString + "<class='card-header' style='text-align:center; background-color:mediumaquamarine;'>";
            returnString = returnString + "<div class='card-header style=text-align: center; background-color:mediumaquamarine;'>";
            returnString = returnString + "<div class='row'>";
            returnString = returnString + "<div class='col-12' style='text-align:center;'>";
            returnString = returnString + "<a class='card-link' data-toggle='collapse' href='#collapseOne' style='color:black;'>" + ds.Tables[0].Rows[i]["InstituteName"].ToString() + "</a>";
            returnString = returnString + "</div>";
            returnString = returnString + "</div>";
            returnString = returnString + "</div>";
            returnString = returnString + "<div id='collapseOne' class='collapse' data-parent='#accordion'>";
            returnString = returnString + "<div class='card-body'>";
            returnString = returnString + "<div class='row'>";
            returnString = returnString + "<div class='col-2'>";
            returnString = returnString + "<img src='Image/AKSharma.jpg' height='200px' width='200px' />";
            returnString = returnString + "</div>";
            returnString = returnString + "<div class='col-10'>";
            returnString = returnString + "<div class='row'>";
            returnString = returnString + "<div class='col-6'>";
            returnString = returnString + "<p>Center ID: " + ds.Tables[0].Rows[i]["CenterID"].ToString() + "</p> <hr/> ";
            returnString = returnString + "<p>Center Director Name: " + ds.Tables[0].Rows[i]["PersonName"].ToString() + "</p> <hr/> ";
            returnString = returnString + "<p>Center Address: " + ds.Tables[0].Rows[0]["Address"].ToString() + "</p> <hr/> ";
            returnString = returnString + "</div>";
            returnString = returnString + "<div class='col-6'>";
            returnString = returnString + "<p>Center Category: " + ds.Tables[0].Rows[i]["CenterID"].ToString() + "</p> <hr/> ";
            returnString = returnString + "<p>Center Location: " + ds.Tables[0].Rows[i]["CenterID"].ToString() + "</p> <hr/> ";
            returnString = returnString + "<p>Facilities: " + ds.Tables[0].Rows[i]["CenterID"].ToString() + "</p> <hr/> ";
            returnString = returnString + "</div>";
            returnString = returnString + "</div>";            
            returnString = returnString + "</div>";
        }
        
        return returnString;
    }
}