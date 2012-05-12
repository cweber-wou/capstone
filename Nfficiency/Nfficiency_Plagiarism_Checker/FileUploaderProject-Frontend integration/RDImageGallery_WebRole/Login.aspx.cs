using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                // This is an unauthorized, authenticated request...
                Response.Redirect("~/UnauthorizedAccess.aspx");
        }
    }

    //protected void LoginButton_Click(object sender, EventArgs e)
    //{
    //    // Validate the user against the Membership framework user store
    //    if (Membership.ValidateUser(UserName.Text, Password.Text))
    //    {
    //        // Log the user into the site
    //        FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked);
    //    }

    //    // If we reach here, the user's credentials were invalid
    //    InvalidCredentialsMessage.Visible = true;
    //}


    protected void myLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        // Get the email address entered
        TextBox EmailTextBox = myLogin.FindControl("Email") as TextBox;
        string email = EmailTextBox.Text.Trim();

        // Verify that the username/password pair is valid
        if (Membership.ValidateUser(myLogin.UserName, myLogin.Password))
        {
            // Username/password are valid, check email
            MembershipUser usrInfo = Membership.GetUser(myLogin.UserName);
            if (usrInfo != null && string.Compare(usrInfo.Email, email, true) == 0)
            {
                // Email matches, the credentials are valid
                e.Authenticated = true;
            }
            else
            {
                // Email address is invalid...
                e.Authenticated = false;
            }
        }
        else
        {
            // Username/password are not valid...
            e.Authenticated = false;
        }
    }

    protected void myLogin_LoginError(object sender, EventArgs e)
    {
        // Determine why the user could not login...        
        myLogin.FailureText = "Your login attempt was not successful. Please try again.";

        // Does there exist a User account for this user?
        MembershipUser usrInfo = Membership.GetUser(myLogin.UserName);
        if (usrInfo != null)
        {
            // Is this user locked out?
            if (usrInfo.IsLockedOut)
            {
                myLogin.FailureText = "Your account has been locked out because of too many invalid login attempts. Please contact the administrator to have your account unlocked.";
            }
            else if (!usrInfo.IsApproved)
            {
                myLogin.FailureText = "Your account has not yet been approved. You cannot login until an administrator has approved your account.";
            }
        }        
    }
}
