using System;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Membership_EnhancedCreateUserWizard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void NewUserWizard_CreatedUser(object sender, EventArgs e)
    {
        // Get the UserId of the just-added user
        MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);
        Guid newUserId = (Guid)newUser.ProviderUserKey;

        // Insert a new record into UserProfiles
        string connectionString = ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
        string insertSql = "INSERT INTO UserProfiles(UserId, HomeTown, HomepageUrl, Signature) VALUES(@UserId, @HomeTown, @HomepageUrl, @Signature)";

        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
            myCommand.Parameters.AddWithValue("@UserId", newUserId);
            myCommand.Parameters.AddWithValue("@HomeTown", DBNull.Value);
            myCommand.Parameters.AddWithValue("@HomepageUrl", DBNull.Value);
            myCommand.Parameters.AddWithValue("@Signature", DBNull.Value);

            myCommand.ExecuteNonQuery();

            myConnection.Close();
            // If we reach here, we need to add the user to the role
            Roles.AddUserToRole(newUser.ToString(), "Student");
        }
    }

    protected void NewUserWizard_ActiveStepChanged(object sender, EventArgs e)
    {
        // Have we JUST reached the Complete step?
        if (NewUserWizard.ActiveStep.Title == "Complete")
        {
            WizardStep UserSettings = NewUserWizard.FindControl("UserSettings") as WizardStep;

            // Programmatically reference the TextBox controls
            TextBox HomeTown = UserSettings.FindControl("HomeTown") as TextBox;
            TextBox HomepageUrl = UserSettings.FindControl("HomepageUrl") as TextBox;
            TextBox Signature = UserSettings.FindControl("Signature") as TextBox;

            // Update the UserProfiles record for this user
            // Get the UserId of the just-added user
            MembershipUser newUser = Membership.GetUser(NewUserWizard.UserName);
            Guid newUserId = (Guid)newUser.ProviderUserKey;

            // Insert a new record into UserProfiles
            string connectionString = ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
            string updateSql = "UPDATE UserProfiles SET HomeTown = @HomeTown, HomepageUrl = @HomepageUrl, Signature = @Signature WHERE UserId = @UserId";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(updateSql, myConnection);
                myCommand.Parameters.AddWithValue("@HomeTown", HomeTown.Text.Trim());
                myCommand.Parameters.AddWithValue("@HomepageUrl", HomepageUrl.Text.Trim());
                myCommand.Parameters.AddWithValue("@Signature", Signature.Text.Trim());
                myCommand.Parameters.AddWithValue("@UserId", newUserId);

                myCommand.ExecuteNonQuery();

                myConnection.Close();
            }
        }
    }
}
