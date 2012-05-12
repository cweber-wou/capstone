///////////////////////////////////////////////////////////////////////////
//
//	File: dynamicBlob.aspx.cs
//	Author: Nfficiency
//	e-mail: Nfficiency@gmail.com
//	CS430 WOU Sprint term 2012
//	Group Nfficiency Final Project
//  Team Members: Chris Kessel, Chris Weber
//
//  protected void GridView1_SelectedIndexChanged
//  Gets aGUID for assignment from gridview and assigns the local variable aGUID
// Adds aGUID to index 2 of the IndexPageArray
//  this.GetContainer(aGUID.ToString());  sets the current object "this" to the appropriate container
//      the call is needed so the refresh, insert, bind's work.
//
//////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDImageGallery_WebRole
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Web.UI.WebControls;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.WindowsAzure.StorageClient;
    using Microsoft.WindowsAzure.StorageClient.Protocol;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using System.Collections.Generic;
using System.Collections;

    public partial class dynamicBlob : System.Web.UI.Page
    {
        string Course_ID;
        string User_ID;
        string aGUID;
        ArrayList PageArrayList;
        ArrayList CreateArray()
  {
    
    ArrayList result = new ArrayList(4);
    return result;
  }

         protected void Page_Load(object sender, EventArgs e)
            {
                Course_ID = Request.QueryString["id"];
                lblCourse_ID.Text = Course_ID;
                User_ID = User.Identity.Name.ToString(); // Gets user that is logged in
               
              if (ViewState["arrayListInViewState"] != null)
    {
      PageArrayList = (ArrayList)ViewState["arrayListInViewState"];
      Course_ID = PageArrayList[0].ToString();
      User_ID = PageArrayList[1].ToString();
      aGUID = PageArrayList[2].ToString();
      this.GetContainer(aGUID.ToString()); 
    }
    else
    {
      // ArrayList isn't in view state, so we need to load it from scratch, we don't have the aGUID yet.
      PageArrayList = CreateArray();
      PageArrayList.Insert(0, Course_ID.ToString());
      PageArrayList.Insert(1, User_ID.ToString());
      PageArrayList.Insert(2, "Dummy");
    }
    
                           
                if (IsPostBack) {} // we really don't care if this is a postback, we catch the viewstate on page load.

            }
         void Page_PreRender(object sender, EventArgs e)
         {
             // Save PageArrayList before the page is rendered, make sure it's the freshest version.
             ViewState.Add("arrayListInViewState", PageArrayList);
         }

        //Uses the 'this' refference set using GetContainer(aGUID)
            protected void upload_Click(object sender, EventArgs e)
            {
            if (User_ID !=null)
                {
                    status.Text = "Inserted [" + txtFileName.FileName + "] - Content Type [" + txtFileName.PostedFile.ContentType + "] - Length [" + txtFileName.PostedFile.ContentLength + "]";
                      SaveImage(
                      Guid.NewGuid().ToString(),lblInfo1.Text,
                      txtAssignID.Text,
                      txtFileLink.Text,
                      txtUserID.Text,
                      txtFileName.FileName,
                      txtFileName.PostedFile.ContentType,
                      txtFileName.FileBytes
                    );
                      RefreshGallery();
                }
                else
                    status.Text = "No image file";
            }

            
          // Cast out blob instance and bind it's metadata to metadata repeater
          // the "this" needs to be set using GetContainer(aGUID)  
            protected void OnBlobDataBound(object sender, ListViewItemEventArgs e)
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    var metadataRepeater = e.Item.FindControl("blobMetadata") as Repeater;
                    var blob = ((ListViewDataItem)(e.Item)).DataItem as CloudBlob;

                    // If this blob is a snapshot, rename button to "Delete Snapshot"
                    if (blob != null)
                    {
                        if (blob.SnapshotTime.HasValue)
                        {
                            var delBtn = e.Item.FindControl("deleteBlob") as LinkButton;

                            if (delBtn != null)
                            {
                                delBtn.Text = "Delete Snapshot";
                                var snapshotRequest = BlobRequest.Get(new Uri(delBtn.CommandArgument), 0, blob.SnapshotTime.Value, null);
                                delBtn.CommandArgument = snapshotRequest.RequestUri.AbsoluteUri;
                            }

                            var snapshotBtn = e.Item.FindControl("SnapshotBlob") as LinkButton;
                            if (snapshotBtn != null) snapshotBtn.Visible = false;
                        }

                        if (metadataRepeater != null)
                        {
                            //bind to metadata
                            metadataRepeater.DataSource = from key in blob.Metadata.AllKeys
                                                          select new
                                                          {
                                                              Name = key,
                                                              Value = blob.Metadata[key]
                                                          };
                            metadataRepeater.DataBind();
                        }
                    }
                }
            }

            /// <summary>
            /// Delete an image blob by Uri
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void OnDeleteImage(object sender, CommandEventArgs e)
            {
                try
                {
                    if (e.CommandName == "Delete")
                    {
                        var blobUri = (string)e.CommandArgument;
                        var blob = this.GetContainer().GetBlobReference(blobUri);
                        status.Text = "File Removed";
                        blob.DeleteIfExists();
                    }
                }
                catch (StorageClientException se)
                {
                    status.Text = "Storage client error: " + se.Message;
                }
                catch (Exception) { }

                RefreshGallery();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void OnCopyImage(object sender, CommandEventArgs e)
            {
                if (e.CommandName == "Copy")
                {
                    // Prepare an Id for the copied blob
                    var newId = Guid.NewGuid();

                    // Get source blob
                    var blobUri = (string)e.CommandArgument;
                    var srcBlob = this.GetContainer(aGUID.ToString()).GetBlobReference(blobUri);

                    // Create new blob
                    var newBlob = this.GetContainer(aGUID.ToString()).GetBlobReference(newId.ToString());

                    // Copy content from source blob
                    newBlob.CopyFromBlob(srcBlob);

                    // Explicitly get metadata for new blob
                    newBlob.FetchAttributes(new BlobRequestOptions { BlobListingDetails = BlobListingDetails.Metadata });

                    // Change metadata on the new blob to reflect this is a copy via UI
                    newBlob.Metadata["txtAssignID"] = "Copy of \"" + newBlob.Metadata["txtAssignID"] + "\"";
                    newBlob.Metadata["Id"] = newId.ToString();
                    newBlob.SetMetadata();

                    // Render all blobs
                    RefreshGallery();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void OnSnapshotImage(object sender, CommandEventArgs e)
            {
                if (e.CommandName == "Snapshot")
                {
                    // Get source blob
                    var blobUri = (string)e.CommandArgument;
                    var srcBlob = this.GetContainer().GetBlobReference(blobUri);

                    // Create a snapshot
                    var snapshot = srcBlob.CreateSnapshot();

                    status.Text = "A snapshot has been taken for image blob:" + srcBlob.Uri + " at " + snapshot.SnapshotTime;

                    RefreshGallery();
                }
            }

            //Method for downloading a image to local
           // Public assignmentReturn is class version of this method
            protected void OnDownloadImage(object sender, CommandEventArgs e)
            {
                string fileToDownload;
                fileToDownload = "C:\\Users\\Public\\newFile.cpp";
                if (e.CommandName == "Download")
                {
                    // Get source blob
                    var blobUri = (string)e.CommandArgument;
                    var srcBlob = this.GetContainer().GetBlobReference(blobUri);
                    srcBlob.DownloadToFile(fileToDownload);
                    String fileDL = srcBlob.DownloadText();
                   Byte [] A = srcBlob.DownloadByteArray();
                   String B = srcBlob.DownloadText();
                                      
                   status.Text = fileDL.ToString();
                   txtTest.Text = fileDL.ToString();  //Multiline textbox
                    lblInfo.Text = srcBlob.Metadata.Get("id");
                    
                    // status.Text = "The file: " + srcBlob.Uri + " has been downloaded to: " + fileToDownload;
                    string[] lines = fileDL.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                   lblInfo.Text = lines[0].ToString();
                    //Loops through all Blobs
                   foreach (string key in srcBlob.Metadata.Keys)
                   {
                      
                   }

                   RefreshGallery();
                }
            }
        
            private void EnsureContainerExists()
            {
                var container = GetContainer();
                lblInfo.Text = container.Name;
                container.CreateIfNotExist();
                var permissions = container.GetPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(permissions);
            }
         

            private CloudBlobContainer GetContainer()
            {
                if (aGUID == null)
                {
                    // Get a handle on account, create a blob service client and get container proxy
                    var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                    var client = account.CreateCloudBlobClient();
                    return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName"));
                }
                else {

                    CloudBlobContainer blobContainer = null;
                    CloudStorageAccount storageAccount = null;
                    CloudBlobClient blobClient = null;
                    storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                    blobClient = storageAccount.CreateCloudBlobClient();
                    blobContainer = blobClient.GetContainerReference(aGUID.ToString()); //Gets the blobe storage
                    return blobContainer;
                    
                }
            }

            private CloudBlobContainer GetContainer(String aGUID)
            {
                // Get a handle on account, create a blob service client and get container proxy
                CloudBlobContainer blobContainer = null;
                CloudStorageAccount storageAccount = null;
                CloudBlobClient blobClient = null;
                storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                blobClient = storageAccount.CreateCloudBlobClient();

                blobContainer = blobClient.GetContainerReference(aGUID.ToString()); //Gets the blobe storage
                return blobContainer;
            }

            private void RefreshGallery()
            {
              
                images.DataSource =this.GetContainer().ListBlobs(new BlobRequestOptions()
                  {
                      UseFlatBlobListing = true,
                      BlobListingDetails = BlobListingDetails.All
                  });
                images.DataBind();
            }

            protected void SaveImage(string id, string container_AID, string userID_blob, string description, string tags, string fileName, string contentType, byte[] data)
            {
                userID_blob = User.Identity.Name;
                
                // Create a blob in container and upload image bytes to it
                var blob = this.GetContainer(container_AID).GetBlobReference(userID_blob);

                blob.Properties.ContentType = contentType;

                // Create some metadata for this image
                var metadata = new NameValueCollection();
                metadata["LinkId"] = id;
                metadata["Filename"] = fileName;
                metadata["AssignID"] = String.IsNullOrEmpty(userID_blob) ? "unknown" : userID_blob;
                metadata["Description"] = String.IsNullOrEmpty(description) ? "unknown" : description; //Extra Field
                metadata["UserID"] = String.IsNullOrEmpty(tags) ? "unknown" : tags;

                // Add and commit metadata to blob
                blob.Metadata.Add(metadata);
                blob.UploadByteArray(data);
               
            }

            protected void images_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            //On_Click test method
            protected void btnProcess_Click(object sender, EventArgs e)
            {
                LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();
                CloudBlobContainer blobContainer = null;
                CloudStorageAccount storageAccount = null;
                CloudBlobClient blobClient = null;
                
                storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                blobClient = storageAccount.CreateCloudBlobClient();
                
                blobContainer = blobClient.GetContainerReference(aGUID.ToString()); //Gets the blobe storage
                Response.Redirect("~/WCReport.aspx?aGUID="+aGUID.ToString());
                var blobs = blobContainer.ListBlobs(); //Gets the entire list of Blob items
                var blobList = new List<string>();
                foreach (var blob in blobs)
                {
                    Paper newPaper = new Paper();
                    var srcBlob = blobContainer.GetBlobReference(blob.Uri.ToString()); //Gets each blobs Uri
                    srcBlob.FetchAttributes();
                    txtTest.Text = srcBlob.DownloadText();
                    blobList.Add(blob.Uri.ToString());
                    
                    String fileDL = srcBlob.DownloadText();
                    LinkedList<String> dataList = new LinkedList<string>();
                    //string[] lines = fileDL.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); //Splits file up by '\n'
                    string[] lines = fileDL.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); //Splits file up by '\n'
                    for (int i = 0; i < lines.Length; i++)
                        dataList.AddLast(lines[i].ToString());
                    newPaper.Data = dataList;
                    newPaper.Link = srcBlob.Metadata.Get("LinkID");
                    newPaper.AID = srcBlob.Metadata.Get("AssignID");
                    newPaper.UserID = srcBlob.Metadata.Get("UserID");
                    newPaper.FileName = srcBlob.Metadata.Get("FileName");

                        AssignmentsList.AddFirst(newPaper);
                }
                   lblInfo.Text = (AssignmentsList.Count().ToString());
                   RefreshGallery();
           
                }
            
    
            public  LinkedList<Paper> getAssignmentList(string container)
            {
                LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();
                CloudBlobContainer blobContainer = null;
                CloudStorageAccount storageAccount = null;
                CloudBlobClient blobClient = null;
                
                storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                blobClient = storageAccount.CreateCloudBlobClient();
                
                blobContainer = blobClient.GetContainerReference(container); //Gets the blobe storage
                var blobs = blobContainer.ListBlobs(); //Gets the entire list of Blob items
                var blobList = new List<string>();
                foreach (var blob in blobs)
                {
                    Paper newPaper = new Paper();
                    var srcBlob = blobContainer.GetBlobReference(blob.Uri.ToString()); //Gets each blobs Uri
                    srcBlob.FetchAttributes();
                    txtTest.Text = srcBlob.DownloadText();
                    blobList.Add(blob.Uri.ToString());
                    
                    String fileDL = srcBlob.DownloadText();
                    LinkedList<String> dataList = new LinkedList<string>();
                    //string[] lines = fileDL.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); //Splits file up by '\n'
                    string[] lines = fileDL.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); //Splits file up by '\n'
                    for (int i = 0; i < lines.Length; i++)
                        dataList.AddLast(lines[i].ToString());
                    newPaper.Data = dataList;
                    newPaper.Link = srcBlob.Metadata.Get("LinkID");
                    newPaper.AID = srcBlob.Metadata.Get("AssignID");
                    newPaper.UserID = srcBlob.Metadata.Get("UserID");
                    newPaper.FileName = srcBlob.Metadata.Get("FileName");

                        AssignmentsList.AddFirst(newPaper);
                }
                   lblInfo.Text = (AssignmentsList.Count().ToString());
                    RefreshGallery();

                    return AssignmentsList;
                }

            protected void txtAssignID_TextChanged(object sender, EventArgs e)
            {

            }
            
            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            {
                 aGUID = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
                 lblInfo1.Text = aGUID.ToString();
                 PageArrayList.Insert(2, aGUID.ToString());
                 this.GetContainer(aGUID.ToString());  //Sets this container = aGUID
                 RefreshGallery();
            }

           
            }

        }
    

