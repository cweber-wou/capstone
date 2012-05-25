using System;
using System.Collections.Generic;
using System.Web;

public class CartItemList
{
    private List<CartItem> cartItems;

    public CartItemList()
    {
        cartItems = new List<CartItem>();
    }

    public int Count
    {
        get { return cartItems.Count; }
    }

    public CartItem this[int index]
    {
        get { return cartItems[index]; }
        set { cartItems[index] = value; }
    }

    public CartItem this[string id]
    {
        get
        {
            foreach (CartItem c in cartItems)
                if (c.Product.Course_id == id) return c;
            return null;
        }
    }

    public static CartItemList GetCart()
    {
        CartItemList cart = (CartItemList)HttpContext.Current.Session["Cart"];
        if (cart == null)
            HttpContext.Current.Session["Cart"] = new CartItemList();
        return (CartItemList)HttpContext.Current.Session["Cart"];
    }

    public static CartItemList GetNewCart()
    {
        CartItemList NewCart = (CartItemList)HttpContext.Current.Session["NewCart"];
        if (NewCart == null)
            HttpContext.Current.Session["NewCart"] = new CartItemList();
        return (CartItemList)HttpContext.Current.Session["NewCart"];
    }

    public void AddItem(Product product, int quantity,int tSide)
    {
        CartItem c = new CartItem(product, quantity);
        cartItems.Add(c);
    }
    public static CartItemList newCart()
    {
        HttpContext.Current.Session["Cart"] = new CartItemList();
        return (CartItemList)HttpContext.Current.Session["Cart"];
    }

    public void RemoveAt(int index)
    {
        cartItems.RemoveAt(index);
    }

    public void Clear()
    {
        cartItems.Clear();
    }
}