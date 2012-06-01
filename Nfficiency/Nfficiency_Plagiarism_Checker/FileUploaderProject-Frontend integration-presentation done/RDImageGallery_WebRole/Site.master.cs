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
using System.Configuration.Provider;

public partial class Site : System.Web.UI.MasterPage
{

    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Dynamic site map selection
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
                SiteMapPath1.SiteMapProvider = "SiteMapInstructor";
                SiteMapDataSource1.SiteMapProvider = "SiteMapInstructor";
                SiteMapPath1.DataBind();
                menu.DataBind();
                break;

            case "Student":
                SiteMapPath1.SiteMapProvider = "SiteMapStudent";
                SiteMapDataSource1.SiteMapProvider = "SiteMapStudent";
                SiteMapPath1.DataBind();
                menu.DataBind();
                break;

            case "Default":
                SiteMapPath1.SiteMapProvider = "SiteMapDefault";
                SiteMapDataSource1.SiteMapProvider = "SiteMapDefault";
                SiteMapPath1.DataBind();
                menu.DataBind();
                break;

            //If logged out, role will = ""
            case "":
                SiteMapPath1.SiteMapProvider = "SiteMapDefault";
                SiteMapDataSource1.SiteMapProvider = "SiteMapDefault";
                SiteMapPath1.DataBind();
                menu.DataBind();
                break;
        }
        lblInfo.Text = SiteMapPath1.SiteMapProvider.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {


    }
}//End Class