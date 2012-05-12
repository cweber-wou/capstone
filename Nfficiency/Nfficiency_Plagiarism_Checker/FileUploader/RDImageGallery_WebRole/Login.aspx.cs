using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{

    protected string inUser_Name;


    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SmokeAndGlass";

    }

    public string User_Name
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
    
    private string retPass;

    protected void Page_Load(object sender, EventArgs e)
    {

        inUser_Name = Request.QueryString["id"];
        if(inUser_Name != null)
        txtUser.Text = inUser_Name.ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        userEncrypt userEnc = new userEncrypt();
        userEnc.User_id = txtUser.Text;
        userEnc.Password_id = txtPassword.Text;
       retPass = LoginClass.returnPassword(userEnc);

       if (retPass != userEnc.Password_id)
           lblError.Text = "USERNAME or PASSWORD does not match";
       else{  Response.Redirect("App.aspx"); }
      
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx"); //String is redirected here
    }

    //***************************************************
    //
    // DB Error checking
    //
    //**************************************************
    protected void ObjectDataSource1_Updated1(
       object sender, ObjectDataSourceStatusEventArgs e)
    {
        e.AffectedRows = Convert.ToInt32(e.ReturnValue);
    }

    protected void GridView1_RowUpdated1(
        Object sender, GridViewUpdatedEventArgs e)
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

    protected void GridView1_RowDeleted(
        object sender, GridViewDeletedEventArgs e)
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

    protected void DetailsView1_ItemInserted1(
        object sender, DetailsViewInsertedEventArgs e)
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
    }


  
}