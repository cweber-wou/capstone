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

public partial class Roles_ManageRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            DisplayRolesInGrid();
    }

    private void DisplayRolesInGrid()
    {
        RoleList.DataSource = Roles.GetAllRoles();
        RoleList.DataBind();
    }

    protected void CreateRoleButton_Click(object sender, EventArgs e)
    {
        string newRoleName = RoleName.Text.Trim();

        if (!Roles.RoleExists(newRoleName))
        {
            // Create the role
            Roles.CreateRole(newRoleName);

            // Refresh the RoleList Grid
            DisplayRolesInGrid();
        }

        RoleName.Text = string.Empty;
    }

    protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the RoleNameLabel
        Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;

        //Check if the role is the Admins.
        if (RoleNameLabel.Text == "Administrators")
            return;

        // Delete the role if it is not "Administrators" role.
        if(RoleNameLabel.Text != "Administrators")
        {
        Roles.DeleteRole(RoleNameLabel.Text, false);
        }

        // Rebind the data to the RoleList grid
        DisplayRolesInGrid();
    }
}
