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
using System.Security.Permissions;

public partial class Roles_RoleBasedAuthorization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindUserGrid();
    }

    private void BindUserGrid()
    {
        MembershipUserCollection allUsers = Membership.GetAllUsers();
        UserGrid.DataSource = allUsers;
        UserGrid.DataBind();
    }

    #region RowCreated Event Handler
    protected void UserGrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != UserGrid.EditIndex)
        {
            // Programmatically reference the Edit and Delete LinkButtons
            LinkButton EditButton = e.Row.FindControl("EditButton") as LinkButton;
            LinkButton DeleteButton = e.Row.FindControl("DeleteButton") as LinkButton;

            EditButton.Visible = (User.IsInRole("Administrators") || User.IsInRole("Instructors"));
            DeleteButton.Visible = User.IsInRole("Administrators");
        }
    }
    #endregion

    #region Editing-related Event Handlers
    protected void UserGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the grid's EditIndex and rebind the data
        UserGrid.EditIndex = e.NewEditIndex;
        BindUserGrid();
    }

    protected void UserGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        // Revert the grid's EditIndex to -1 and rebind the data
        UserGrid.EditIndex = -1;
        BindUserGrid();
    }

    [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
    [PrincipalPermission(SecurityAction.Demand, Role = "Instructors")]
    protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Exit if the page is not valid
        if (!Page.IsValid)
            return;

        // Determine the username of the user we are editing
        string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

        // Read in the entered information and update the user
        TextBox EmailTextBox = UserGrid.Rows[e.RowIndex].FindControl("Email") as TextBox;
        TextBox CommentTextBox = UserGrid.Rows[e.RowIndex].FindControl("Comment") as TextBox;

        // Return information about the user
        MembershipUser UserInfo = Membership.GetUser(UserName);

        // Update the User account information
        UserInfo.Email = EmailTextBox.Text.Trim();
        UserInfo.Comment = CommentTextBox.Text.Trim();

        Membership.UpdateUser(UserInfo);

        // Revert the grid's EditIndex to -1 and rebind the data
        UserGrid.EditIndex = -1;
        BindUserGrid();
    }
    #endregion

    #region RowDeleting Event Handler
    [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
    protected void UserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Determine the username of the user we are editing
        string UserName = UserGrid.DataKeys[e.RowIndex].Value.ToString();

        // Delete the user
        Membership.DeleteUser(UserName);

        // Revert the grid's EditIndex to -1 and rebind the data
        UserGrid.EditIndex = -1;
        BindUserGrid();
    }
    #endregion
}
