using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewPage : System.Web.UI.Page
{
     private SurvayClass survay;
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
        survay = (SurvayClass)Session["Survay"];
        this.Displaysurvay();
    }

    //
// public DateTime DueDate { get; set; }
 //   public string Professor { get; set; }
 //   public string Assignment { get; set; }
 //   public string Subject { get; set; }
 //   public string Difficulty { get; set; }
 //   public bool retake { get; set; }
 //   public string Grade { get; set; }
 //   public string Learning { get; set; }
//

    private void Displaysurvay()
    {
        lblDueDate.Text = survay.DueDate.ToShortDateString();
       
       
        lblAssignment.Text = survay.Professor.ToString();
        lblDifficulty.Text = survay.Difficulty;
        

        if (survay.retake)
            lblRetake.Text = "Yes";
        else
            lblRetake.Text = "No";

        if (survay.Learning == "")
            lblNotes.Text = "None";
        else
            lblNotes.Text = survay.Learning;
         lblGrade.Text = survay.Grade;
        lblCourselName.Text = survay.Assignment;
        lblProf.Text = survay.Subject;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Thank you for your request.<br />" +
                          "We will get back to you within 24 hours.";

        HttpCookie nameCookie = new HttpCookie("UserName", lblCourselName.Text);
        nameCookie.Expires = DateTime.Now.AddMonths(6);
        Response.Cookies.Add(nameCookie);

        HttpCookie emailCookie = new HttpCookie("Email", lblProf.Text);
        emailCookie.Expires = DateTime.Now.AddMonths(6);
        Response.Cookies.Add(emailCookie);
    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Session["theme"] = ddlTheme.SelectedItem.Value;
        Server.Transfer(Request.FilePath);
    }
}
