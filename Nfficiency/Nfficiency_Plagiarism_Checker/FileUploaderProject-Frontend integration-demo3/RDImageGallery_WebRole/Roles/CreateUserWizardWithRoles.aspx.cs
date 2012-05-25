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

public partial class Roles_CreateUserWizardWithRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Reference the SpecifyRolesStep WizardStep
            WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep;

            // Reference the RoleList CheckBoxList
            CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

            // Bind the set of roles to RoleList
            RoleList.DataSource = Roles.GetAllRoles();
            RoleList.DataBind();
        }
    }

    protected void RegisterUserWithRoles_ActiveStepChanged(object sender, EventArgs e)
    {
        // Have we JUST reached the Complete step?
        if (RegisterUserWithRoles.ActiveStep.Title == "Complete")
        {
            // Reference the SpecifyRolesStep WizardStep
            WizardStep SpecifyRolesStep = RegisterUserWithRoles.FindControl("SpecifyRolesStep") as WizardStep;

            // Reference the RoleList CheckBoxList
            CheckBoxList RoleList = SpecifyRolesStep.FindControl("RoleList") as CheckBoxList;

            // Add the checked roles to the just-added user
            foreach (ListItem li in RoleList.Items)
            {
                if (li.Selected)
                    Roles.AddUserToRole(RegisterUserWithRoles.UserName, li.Text);
            }
        }
    }
}
