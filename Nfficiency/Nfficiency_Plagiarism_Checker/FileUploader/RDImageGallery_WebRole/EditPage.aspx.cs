using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EditPage : System.Web.UI.Page
{
    private List<SqlParameter> insertParameters = new List<SqlParameter>();
    public string txtDueDate;

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





    protected void ibtnCalendar_Click(object sender, ImageClickEventArgs e)
    {
        ibtnCalendar.Visible = false;
        Calendar4.Visible = true;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlDataSource sql1 = new SqlDataSource();
        sql1 = SqlDataSource1;
        SqlDataSource1.InsertParameters["Course_id"].DefaultValue = TextBox3.Text;
        SqlDataSource1.InsertParameters["Assignment"].DefaultValue = TextBox8.Text;
        SqlDataSource1.InsertParameters["Subject_id"].DefaultValue = TextBox4.Text;
        SqlDataSource1.InsertParameters["Instructor"].DefaultValue = TextBox5.Text;
        SqlDataSource1.InsertParameters["Instructor_rank"].DefaultValue = Convert.ToString(TextBox6.Text);
        SqlDataSource1.InsertParameters["Due_Date"].DefaultValue = TextBox9.Text;
        try
        {
            SqlDataSource1.Insert();
            TextBox3.Text = "";
            TextBox8.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox9.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = "A DB error has occurred. " + "Message: " + ex.Message;
        
        }
    }
    protected void ibtnCalendar_Click1(object sender, EventArgs e)
    {
        ibtnCalendar.Visible = false;
        Calendar4.Visible = true;
    }
    protected void Calendar4_SelectionChanged(object sender, EventArgs e)
    {
        TextBox9.Text = Calendar4.SelectedDate.Month.ToString() + "/" +
                             Calendar4.SelectedDate.Day.ToString() + "/" +
                             Calendar4.SelectedDate.Year.ToString();

        Calendar4.Visible = false;
        ibtnCalendar.Visible = true;
    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Session["theme"] = ddlTheme.SelectedItem.Value;
        Server.Transfer(Request.FilePath);
    }
}