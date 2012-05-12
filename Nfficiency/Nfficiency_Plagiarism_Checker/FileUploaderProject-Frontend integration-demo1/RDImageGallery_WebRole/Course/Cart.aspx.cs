///////////////////////////////////////////////////////////////////////////
//
//	File: Cart.cs
//	Author: Chris Kessel
//	e-mail: chriskessel@comcast.net
//	CS420 WOU Fall term 2011
//	Group #5 Application 
//
//////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

public partial class Cart : System.Web.UI.Page
{
    protected string aguid;
    protected string User_ID;
    protected string course_id;

    public string aGUID
    {
        get
        {
            return aguid;
        }
        set
        {
            aguid = value;
        }
    }

    public string Course_ID
    {
        get
        {
            return course_id;
        }
        set
        {
            course_id = value;
        }
    }

    

    protected void Page_Load(object sender, EventArgs e, string course_id)
    {
        course_id = Request.QueryString["id"];
        User_ID = User.Identity.Name.ToString(); // Gets user that is logged in
        lblInfo.Text = User_ID.ToString();
    }

    private void DisplayCart()
    {
    
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
       
    }

    protected void btnEmpty_Click(object sender, EventArgs e)
    {
       
    }

    //**********************************************************
    //
    // Gets PizzaItem from list and sends to OrderDB to be 
    // inserted into Order Table
    // 
    //*********************************************************
   // [DataObjectMethod(DataObjectMethodType.Insert)]

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {

       
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["justin_dbConnectionString"].ConnectionString;
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        
    }
}
