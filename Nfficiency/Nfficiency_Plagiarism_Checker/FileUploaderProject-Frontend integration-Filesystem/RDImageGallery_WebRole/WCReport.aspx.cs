using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using RDImageGallery_WebRole.Old_App_Code;

public partial class Main : System.Web.UI.Page
{
    private Tester test = new Tester();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "SmokeAndGlass";

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        String s = Request.QueryString["aGUID"];
        test.run(s);
        ListView1.DataSource = test.getReports();
        
        ListView1.Sort("TestID", SortDirection.Ascending);
        ListView1.DataBind();
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx"); //String is redirected here
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        Response.Redirect("Default.aspx"); //String is redirected here
    }

    //Handles link request from asp, opens file
    //NEED to open file using GUID
    protected void LinkLabel_Click(object sender, EventArgs e)
    {
        CloudBlobContainer blobContainer = null;
        CloudStorageAccount storageAccount = null;
        CloudBlobClient blobClient = null;

        LinkButton btn = (LinkButton)(sender);
        string yourValue = btn.CommandArgument;
        lblInfo.Text = yourValue.ToString();
        Guid guid = new Guid(yourValue);
        
    } 

    

    protected void ListView1_Sorting(object sender, ListViewSortEventArgs e)
    {

    }

    
    
}