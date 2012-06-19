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

public partial class Membership_Guestbook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PostCommentButton_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        // Determine the currently logged on user's UserId
        MembershipUser currentUser = Membership.GetUser();
        Guid currentUserId = (Guid)currentUser.ProviderUserKey;

        // Insert a new record into GuestbookComments
        string connectionString = ConfigurationManager.ConnectionStrings["SecurityTutorialsConnectionString"].ConnectionString;
        string insertSql = "INSERT INTO GuestbookComments(Subject, Body, UserId) VALUES(@Subject, @Body, @UserId)";

        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(insertSql, myConnection);
            myCommand.Parameters.AddWithValue("@Subject", Subject.Text.Trim());
            myCommand.Parameters.AddWithValue("@Body", Body.Text.Trim());
            myCommand.Parameters.AddWithValue("@UserId", currentUserId);

            myCommand.ExecuteNonQuery();

            myConnection.Close();
        }

        // "Reset" the Subject and Body TextBoxes
        Subject.Text = string.Empty;
        Body.Text = string.Empty;

        // If you do not disable the ListView's ViewState, you can rebind the data to the ListView by uncommenting the following line
        // CommentList.DataBind();
    }
}
