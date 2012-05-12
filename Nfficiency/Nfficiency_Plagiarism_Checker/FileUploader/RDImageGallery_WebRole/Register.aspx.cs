///////////////////////////////////////////////////////////////////////////
//
//	File: Register.cs
//	Author: Chris Kessel
//	e-mail: chriskessel@comcast.net
//	CS470 WOU Fall term 2011
//	
//
//////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected string inUser_Name;

    protected void Page_Load(object sender, EventArgs e)
    {
        inUser_Name = Request.QueryString["id"];
        
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SmokeAndGlass";

    }

    public string user_name
    {
        get
        {
            return inUser_Name;
        }
        set
        {
            inUser_Name = value;
        }
    }
      protected void ObjectDataSource1_Updated(
        object sender, ObjectDataSourceStatusEventArgs e)
    {
        e.AffectedRows = Convert.ToInt32(e.ReturnValue);
    }

    protected void DetailsView2_RowUpdated(
        Object sender, DetailsViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred.<br /><br />" +
                e.Exception.Message;
            if (e.Exception.InnerException != null)
                lblError.Text += "<br />Message: "
                    + e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
        }
        else if (e.AffectedRows == 0)
            lblError.Text = "Another user may have updated that category."
                + "<br />Please try again.";
    }

    protected void ObjectDataSource1_Deleted(
        object sender, ObjectDataSourceStatusEventArgs e)
    {
        e.AffectedRows = Convert.ToInt32(e.ReturnValue);
    }

    protected void DetailsView2_RowDeleted(
        object sender, DetailsViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred.<br /><br />" +
                e.Exception.Message;
            if (e.Exception.InnerException != null)
                lblError.Text += "<br />Message: "
                    + e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else if (e.AffectedRows == 0)
            lblError.Text = "Another user may have updated that category. "
                + "<br />Please try again.";
    }

    protected void DetailsView2_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred.<br /><br />" +
                e.Exception.Message;
            if (e.Exception.InnerException != null)
                lblError.Text += "<br />Message: "
                    + e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else {
            //inUser_Name = category.User_ID.ToString();
           inUser_Name = CategoryDB.returnUser_ID();
                      Response.Redirect(("Login.aspx?id=" + inUser_Name));  }
    }

    
 

  



    protected void DetailsView2_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        Response.Redirect("Login.aspx"); //String is redirected here
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

    }
}
