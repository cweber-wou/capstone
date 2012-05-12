using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SmokeAndGlass";
       
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx"); //String is redirected here
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("Login.aspx"); //String is redirected here
    }
}