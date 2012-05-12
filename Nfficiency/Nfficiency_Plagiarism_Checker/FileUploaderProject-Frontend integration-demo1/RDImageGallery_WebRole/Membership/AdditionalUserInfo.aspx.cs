using System;
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

public partial class Membership_AdditionalUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UserProfileDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        // Get a reference to the currently logged on user
        MembershipUser currentUser = Membership.GetUser();
        
        // Determine the currently logged on user's UserId value
        Guid currentUserId = (Guid)currentUser.ProviderUserKey;

        // Assign the currently logged on user's UserId to the @UserId parameter
        e.Command.Parameters["@UserId"].Value = currentUserId;
    }

    protected void UserProfile_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        SettingsUpdatedMessage.Visible = true;
    }
}
