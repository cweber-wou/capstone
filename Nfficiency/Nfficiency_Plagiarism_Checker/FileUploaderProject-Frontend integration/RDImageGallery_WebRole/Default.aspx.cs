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
            WelcomeBackMessage.Text = "Welcome back, " + User.Identity.Name + "!\n You are enrolled in:\n";
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
        
    
        //Dynamic path selection
        string[] rolesUserBelongsTo = Roles.GetRolesForUser();
        string locRole = "";

        for (int i = 0; i < rolesUserBelongsTo.Length; i++)
        {
            if (rolesUserBelongsTo[i].Equals("Instructors") || rolesUserBelongsTo[i].Equals("Administrators"))
                locRole = "Instructors";
            if (locRole != "Instructors" && rolesUserBelongsTo[i].Equals("Student") || locRole != "Instructors" && rolesUserBelongsTo[i].Equals("Users"))
                locRole = "Student";
        }

        switch (locRole)
        {
            case "Instructors":
               string course_id = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
        Response.Redirect("~/Course/dynamicBlob.aspx?id=" + course_id); //String is redirected here passed to dynamicStudentBlob
                break;

            case "Student":
                string course_id1 = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
        Response.Redirect("~/Student/stuAssignUpload.aspx?id=" + course_id1); //String is redirected here passed to dynamicStudentBlob
                break;

            case "Default":
                string course_id2 = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
        Response.Redirect("~/Student/stuAssignUpload.aspx?id=" + course_id2); //String is redirected here passed to dynamicStudentBlob
                break;

            //If logged out, role will = ""
            case "":
                string course_id3 = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
        Response.Redirect("~/Student/stuAssignUpload.aspx?id=" + course_id3); //String is redirected here passed to dynamicStudentBlob
                break;
        }
        
    }




       
    
}
