///////////////////////////////////////////////////////////////////////////
//
//	File: CartItem.cs
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
using RDImageGallery_WebRole.Old_App_Code1;

public class CartItem
{
    public CartItem() { }

    public CartItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
        
    }

    public Product Product { get; set; }
    public int Quantity { get; set; }
   

    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    //**********************************************
    //Displays the string from Cart
    //Values are stored in Product or passed locally
    //
    //Returns string displaystring
    // Product Class = string inCourse_id, string inaGUID, string inAssignmentNumber, int inNum_Assignments
    //**********************************************
    public string Display()
    {
        string spaces = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"; // without spaces after &
        spaces = HttpUtility.HtmlDecode(spaces);

        string displayString = "COURSE ID : " + Product.Course_id +spaces+ "ASSIGNMENT NUMBER: " + Product.assignmentNumber + spaces + "DESCRIPTION: " + Product.descripton;
        return displayString;
    }

    //string inCourse_id, string inaGUID, string inAssignmentNumber, int inNum_Assignments

}