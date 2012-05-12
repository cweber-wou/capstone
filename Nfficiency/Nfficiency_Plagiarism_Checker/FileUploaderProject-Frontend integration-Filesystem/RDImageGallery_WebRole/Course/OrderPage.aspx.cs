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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;
using RDImageGallery_WebRole.Old_App_Code1;


public partial class OrderPage : System.Web.UI.Page
{
    private CartItemList cart; // class CartItemList type
    private CartItemList newCart; // Holds only new items to be added 
    private Product selectedProduct; //class Product type 
    
    private string course_id;
    private int count;
     string User_ID;

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
    void Page_PreRender(object sender, EventArgs e)
    {
       // lstCart.Items.Clear();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        course_id = Request.QueryString["id"];
        User_ID = User.Identity.Name.ToString(); // Gets user that is logged in

     
        lstCart.Items.Clear();
        if (IsPostBack) // On Postback
        {
            cart = new CartItemList();
            newCart = new CartItemList();
            cart = CartItemList.GetCart();
            newCart = CartItemList.GetNewCart();
        }
        if (!IsPostBack) // Not postback, inital load
        {
            CartItemList.newCart();
            cart = new CartItemList();
            newCart = new CartItemList();
            cart = CartItemList.GetCart();
            List<Product> productList = new List<Product>();
            //productList = ProductDB.GetProduct();
            productList = ProductDB.GetProductCID(course_id);
            foreach (Product p in productList)
            {
                cart.AddItem(p, Convert.ToInt32(p.Course_id), Convert.ToInt32(p.assignmentNumber));
            }
            
            this.DisplayCart(); // Make this load the course assignments
           // this.DisplayNewCart();
        } 
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
          {
              this.DisplayCart();
          //    this.DisplayNewCart();
          }
            }

    /// <summary>
    /// //////////////////Create Folder Methods//////////////////////////////////////////////
    /// ///////////////// This could be done recursavely
    /// </summary>
    /// <param name="aGUID"></param>
    protected void createFolder(String locPath, String inCourse_ID, String aGUID)
    {
        string activeDir = locPath;
        string newPath = System.IO.Path.Combine(activeDir, inCourse_ID); // generates new path
        DirectoryInfo dir = new DirectoryInfo(activeDir); //Checks if the Parent directory exists
        if (!dir.Exists )
        {
            dir.Create();
        }
        else
            // Create the subfolder under activeDir
            System.IO.Directory.CreateDirectory(newPath);

        activeDir = newPath;
        newPath = System.IO.Path.Combine(activeDir, aGUID);
        dir = new DirectoryInfo(activeDir); //Checks if the Parent directory exists
        if (!dir.Exists )
        {
            dir.Create();
        }
        else
            // Create the subfolder under activeDir
            System.IO.Directory.CreateDirectory(newPath);
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
            CartItem newCartItem = new CartItem();
            int Num_Assignments=0;
            int assignment = 1; //will be produced from loop according to Num_Assignments
            cart = CartItemList.GetCart();
            cartItem = cart[selectedProduct.Course_id];
            newCartItem = cart[selectedProduct.Course_id];

            if (cartItem == null)
            {
                cart.AddItem(selectedProduct, Num_Assignments,assignment);
                newCart.AddItem(selectedProduct, Num_Assignments, assignment);
            }
            else
            {
                cart.AddItem(selectedProduct, Num_Assignments, assignment);
                newCart.AddItem(selectedProduct, Num_Assignments, assignment);
                cartItem.AddQuantity(1);
                newCartItem.AddQuantity(1);
            }
            this.DisplayCart();
      //      this.DisplayNewCart();
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

    //*********************************************
    //
    // Displays local newCart
    //
    //********************************************
    private void DisplayNewCart()
    { 
  //  lstNewCart.Items.Clear();
  //      CartItem item;
  //      for (int i = 0; i < cart.Count; i++)
  //      {
  //          item = newCart[i];
  //          lstNewCart.Items.Add(item.Display());
  //      }
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
        if (newCart.Count > 0)
        {
            newCart.Clear();
            lstNewCart.Items.Clear();
        }
    }

    //****************************************************************
    //
    // Adds items to Cart
    // Adds items to sql 
    // Creates folder for the course
    //
    //****************************************************************
    private void compileCart()
    {
        lstCart.Items.Clear();
        CartItem item;
        CartItem oldItem;

        //Checks that all folders associated with the list are present in the file structure
        //List is populated from Assignments DB
        for (int i = 0; i < cart.Count; i++)
        {
            oldItem = cart[i];
            string activeDir = CreateFileOrFolder.getActiveDir(); // should retun current path + FileRepository
            createFolder(activeDir, oldItem.Product.Course_id, oldItem.Product.aGUID); //Checks if the course folder exists, else it creates it
            course_id = oldItem.Product.Course_id.ToString();
        }


        for (int i = 0; i < newCart.Count; i++)
        {
           
            item = newCart[i];
            lstCart.Items.Add(item.Display());
            lstNewCart.Items.Add(item.Display());
            ProductDB.InsertOrder(item.Product); //I don't need to add all items, just the new ones
            string activeDir = CreateFileOrFolder.getActiveDir(); // should retun current path + FileRepository
            createFolder(activeDir, item.Product.Course_id, item.Product.aGUID); //Checks if the course folder exists, else it creates it
            course_id = item.Product.Course_id.ToString();
        }
        Response.Redirect("dynamicBlob.aspx?id=" + course_id); //String is redirected here 
    }

    protected void btn_AddAssignment_Click(object sender, EventArgs e)
    {
        compileCart(); //We know what this does now don't we.
    }

    protected void btnAssignmentBlob_Click(object sender, EventArgs e)
    {
        Response.Redirect("dynamicBlob.aspx?id=" + course_id); //Page is redirected here passing the course_id value 
    }

   
}