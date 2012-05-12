///////////////////////////////////////////////////////////////////////////
//
//	File: CartItem.cs
//	Author: Chris Kessel
//	e-mail: chriskessel@comcast.net
//	CS420 WOU Fall term 2011
//	Group #5 Application 
//
//////////////////////////////////////////////////////////////////////////


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
           
        
    string displayString = "Course_ID  " + Product.Course_id + "  aGUID " + Product.aGUID + " AssignmentNumber" + Product.assignmentNumber + " Number of Assignment" + Product.Num_Assignment;
        return displayString;
    }

    //string inCourse_id, string inaGUID, string inAssignmentNumber, int inNum_Assignments

}