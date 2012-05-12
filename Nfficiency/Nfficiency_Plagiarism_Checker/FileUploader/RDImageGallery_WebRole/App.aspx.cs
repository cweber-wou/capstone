using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class App : System.Web.UI.Page
{
    private static string theme; //needed for dynamic theme

  
    protected void Page_PreInit(object sender, EventArgs e)
    {
        
        theme = (string)Session["theme"];
        if ((theme != null) && (theme.Length != 0))
        {
            Page.Theme = theme;
            if (ddlTheme != null)
            {
                this.ddlTheme.ClearSelection();
                this.ddlTheme.Items.FindByValue(theme).Selected = true;
            }
            //ddlTheme.SelectedValue = theme.ToString();
        }
        else
        {
            Page.Theme = "UglyRed";
        }
    }
//Dynamic theme
    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["theme"] = ddlTheme.SelectedItem.Value;
        Server.Transfer(Request.FilePath);
        if (ddlTheme != null)
        {
            this.ddlTheme.ClearSelection();
            this.ddlTheme.Items.FindByValue(theme).Selected = true;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        theme = (string)Session["theme"];
    }
protected void  DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
{
    Session["theme"] = ddlTheme.SelectedItem.Value;
    Server.Transfer(Request.FilePath);
}
}