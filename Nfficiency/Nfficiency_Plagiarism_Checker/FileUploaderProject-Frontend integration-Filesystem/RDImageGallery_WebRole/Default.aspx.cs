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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            WelcomeBackMessage.Text = "Welcome back, " + User.Identity.Name + "!\n You are enrolled in:\n" ;
            lblUserName.Text = User.Identity.Name; // used for grid view load.
        

            // Reference the CustomPrincipal / CustomIdentity
            CustomIdentity ident = User.Identity as CustomIdentity;
            if (ident != null)
                WelcomeBackMessage.Text += string.Format(" You are the {0} of {1}.", ident.Title, ident.CompanyName);

            AuthenticatedMessagePanel.Visible = true;
            AnonymousMessagePanel.Visible = false;
        }
        else
        {
            AuthenticatedMessagePanel.Visible = false;
            AnonymousMessagePanel.Visible = true;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string course_id = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
        Response.Redirect("~/Instructor/instCourseHome.aspx?id=" + course_id); //String is redirected here passed to dynamicStudentBlob
    }
}
