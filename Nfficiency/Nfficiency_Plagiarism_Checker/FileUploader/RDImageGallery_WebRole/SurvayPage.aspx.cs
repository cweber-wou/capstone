using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

public partial class SurvayPage : System.Web.UI.Page
{

    private SurvayClass survay = new SurvayClass();
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
        if (!IsPostBack)
        {
           if (Session["Survay"] != null)
            {
                survay = (SurvayClass)Session["Survay"];
                this.DisplaySurvay();
            }
            else if (Request.Cookies["UserName"] != null)
            {
                txtCourse.Text = Request.Cookies["UserName"].Value;
                txtProf.Text = Request.Cookies["Email"].Value;
               
            }
            else
            {
                
            }
        }
    }
         private void DisplaySurvay()
    {
        txtDueDate.Text = survay.DueDate.ToShortDateString();
         DropDownList1.SelectedValue = survay.Subject.ToString();
        DropDownList2.SelectedValue = survay.Assignment.ToString();
        DropDownList3.SelectedValue = survay.Professor.ToString();
        ddlGrade.SelectedValue = survay.Grade.ToString();

        if (survay.Difficulty == "1")
            rdoDiff1.Checked = true;
        else if (survay.Difficulty == "2")
            rdoDiff2.Checked = true;
        else
            rdoDiff3.Checked = true;
     
        chkRetake.Checked = survay.retake;
        txtNote.Text = survay.Learning;
      }
        
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        survay.DueDate = Convert.ToDateTime(txtDueDate.Text);
        survay.Assignment = DropDownList1.SelectedValue.ToString();
        survay.Professor = DropDownList2.SelectedValue.ToString();
        survay.Subject = DropDownList3.SelectedValue.ToString();
        
        if (rdoDiff1.Checked)
            survay.Difficulty = "1";
        else if (rdoDiff2.Checked)
            survay.Difficulty = "2";
        else
            survay.Difficulty = "3";
        
        survay.retake = chkRetake.Checked;
        survay.Grade = ddlGrade.SelectedValue;
        survay.Learning = txtNote.Text;

        Session["survay"] = survay;
        Response.Redirect("ViewPage.aspx");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtDueDate.Text = "mm/dd/yyyy";
        rdoDiff3.Checked = true;
        chkRetake.Checked = false;
        txtNote.Text = "";
    }

    protected void ibtnCalendar_Click(object sender, ImageClickEventArgs e)
    {
        ibtnCalendar.Visible = false;
        clnDueDate.Visible = true;
    }

    protected void clnArrival_SelectionChanged(object sender, EventArgs e)
    {
        txtDueDate.Text = clnDueDate.SelectedDate.Month.ToString() + "/" +
                              clnDueDate.SelectedDate.Day.ToString() + "/" +
                              clnDueDate.SelectedDate.Year.ToString();
        clnDueDate.Visible = false;
        ibtnCalendar.Visible = true;
    }


    protected void rdoSuite_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Session["theme"] = ddlTheme.SelectedItem.Value;
        Server.Transfer(Request.FilePath);
    }
}