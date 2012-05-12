///////////////////////////////////////////////////////////////////////////
//
//	File: OrderPage.cs
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

public partial class OrderPage : System.Web.UI.Page
{
    private CartItemList cart; // class CartItemList type
    private Product selectedProduct; //class Product type 
    
    private string course_id;
    private int count;

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
        lblDate.Text = "Order Submitted at" + Convert.ToString(DateTime.Now);
    }

    //**************************************************************************
    // DEFAULT PAGE LOAD
    //
    // Takes: object
    // Takes: EventArgs
    // Returns: NONE
    //
    // -Handles preconditions if page has allready submitted 
    //  a cart item. 
    //**************************************************************************
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        course_id = Request.QueryString["id"];

        
        cart = CartItemList.GetCart();
            
       
       
        if (!IsPostBack)
            this.DisplayCart(); // Make this load the course assignments
             
    }

    //**************************************************************************
    // PAGE LOAD: Handles preconditions if page has allready submitted 
    //  a cart item.
    //
    // Takes: object
    // Takes: EventArgs
    // Takes: int for customer id on postback
    // Returns: NONE
    //
    // -Retains customer information
    // -Handles PostBack conditions
    // -If postback displays Cart items.
    //**************************************************************************

    protected void Page_Load(object sender, EventArgs e, int cus_id)
    {
       course_id = Request.QueryString["id"];           //row["Customer_id"].ToString();
       
        if (!IsPostBack)        
       
        if (!IsPostBack)
            this.DisplayCart();
            }


  





   
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        
        selectedProduct = new Product();
        this.selectedProduct.Course_id = course_id.ToString();
       
        if (Page.IsValid)
        {
            CartItemList cart = CartItemList.GetCart();
            int locCount = cart.Count;
            locCount = locCount + 1;
            this.selectedProduct.assignmentNumber = locCount.ToString();
            this.selectedProduct.aGUID = Guid.NewGuid().ToString();
            this.selectedProduct.Num_Assignment = locCount;
            CartItem cartItem = new CartItem();
            
            int Num_Assignments=0;
            int assignment;
            assignment = 1; //will be produced from loop according to Num_Assignments
            cart = CartItemList.GetCart();
            cartItem = cart[selectedProduct.Course_id];
           
            if (cartItem == null)
            {
                cart.AddItem(selectedProduct, Num_Assignments,assignment);
            }
            else
            {
                cart.AddItem(selectedProduct, Num_Assignments, assignment);
                cartItem.AddQuantity(1);
            }
            this.DisplayCart();
            
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    //***********************************
    //
    // Test for Radio group button
    //
    //***********************************
   

    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

   
   
    //*********************************************
    //
    // Displays local cart
    //
    //********************************************
    private void DisplayCart()
    {
        
        lstCart.Items.Clear();
        CartItem item;
        for (int i = 0; i < cart.Count; i++)
        {
            item = cart[i];
            lstCart.Items.Add(item.Display());
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (cart.Count > 0)
        {
            if (lstCart.SelectedIndex > -1)
            {
                cart.RemoveAt(lstCart.SelectedIndex);
                this.DisplayCart();
            }
        }
    }

    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        if (cart.Count > 0)
        {
            cart.Clear();
            lstCart.Items.Clear();
        }
    }

    //****************************************************************
    //
    // Adds items to pizzaProduct
    // pizzaSelectedProduct is the local instance of pizza order cart
    //****************************************************************
    private void compileCart()
    {

        lstCart.Items.Clear();
        CartItem item;
        for (int i = 0; i < cart.Count; i++)
        {
            item = cart[i];
            lstCart.Items.Add(item.Display());
            ProductDB.InsertOrder(item.Product);
        }

      
        Response.Redirect("~/Course/Cart.aspx?id" +course_id); //String is redirected here 
    }

   
}