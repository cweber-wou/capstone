using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS430_ASPNET_Role_Records
{
    public partial class frmUsrMngr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            lblUser_ID.Text = User.Identity.Name.ToString();
        }
    
     protected int course_id;

    public int Course_ID
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

    protected void ObjectDataSource1_Updated(
        object sender, ObjectDataSourceStatusEventArgs e)
    {
        e.AffectedRows = Convert.ToInt32(e.ReturnValue);
    }

    protected void GridView1_RowUpdated(
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

    protected void DetailsView1_ItemInserted(
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
   // protected void Page_Load(object sender, EventArgs e)
   // {

//    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   // protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
   // {
   //     GridViewRow row = GridView2.SelectedRow;
   //     cus_order_id = Convert.ToInt16(row.Cells[2].Text); //Gets the Customer_id of the selected item and stores in variable
   //     Response.Redirect("OrderPage.aspx?id="+cus_order_id); 
   // }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView3.SelectedRow;
        Course_ID = Convert.ToInt16(row.Cells[1].Text); //Gets the Customer_id of the selected item and stores in variable
        Response.Redirect("OrderPage.aspx?id=" + Course_ID); 
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}

    }
