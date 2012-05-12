// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

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
    
        public partial class _Default : System.Web.UI.Page
        {
            /// <summary>
            /// 
            /// </summarry
            /// <param name="sender"></param>
            /// <param name="e"></param>
            
            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        this.EnsureContainerExists();
                    }
                    this.RefreshGallery();
                }
                catch (System.Net.WebException we)
                {
                    status.Text = "Network error: " + we.Message;
                    if (we.Status == System.Net.WebExceptionStatus.ConnectFailure)
                    {
                        status.Text += "<br />Please check if the blob service is running at " +
                        ConfigurationManager.AppSettings["storageEndpoint"];
                    }
                }
                catch (StorageException se)
                {
                    Console.WriteLine("Storage service error: " + se.Message);
                }
            }

            protected void upload_Click(object sender, EventArgs e)
            {
                if (txtFileName.HasFile)
                {
                    status.Text = "Inserted [" + txtFileName.FileName + "] - Content Type [" + txtFileName.PostedFile.ContentType + "] - Length [" + txtFileName.PostedFile.ContentLength + "]";

                    this.SaveImage(
                      Guid.NewGuid().ToString(),
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

            /// <summary>
            /// Cast out blob instance and bind it's metadata to metadata repeater
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
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
                    var srcBlob = this.GetContainer().GetBlobReference(blobUri);

                    // Create new blob
                    var newBlob = this.GetContainer().GetBlobReference(newId.ToString());

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
                      // lblInfo.Text = ("Metadata key: " + key);
                      // lblInfo1.Text = ("Metadata value: " + srcBlob.Metadata.Get(key));
                   }

                    RefreshGallery();
                }
            }



            private void EnsureContainerExists()
            {
                var container = GetContainer();
                container.CreateIfNotExist();

                var permissions = container.GetPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(permissions);
            }

            private CloudBlobContainer GetContainer()
            {
                // Get a handle on account, create a blob service client and get container proxy
                var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                var client = account.CreateCloudBlobClient();

                return client.GetContainerReference(RoleEnvironment.GetConfigurationSettingValue("ContainerName"));
            }

            private void RefreshGallery()
            {
                images.DataSource =
                  this.GetContainer().ListBlobs(new BlobRequestOptions()
                  {
                      UseFlatBlobListing = true,
                      BlobListingDetails = BlobListingDetails.All
                  });
                images.DataBind();
            }

            private void SaveImage(string id, string name, string description, string tags, string fileName, string contentType, byte[] data)
            {
                // Create a blob in container and upload image bytes to it
                var blob = this.GetContainer().GetBlobReference(name);

                blob.Properties.ContentType = contentType;

                // Create some metadata for this image
                var metadata = new NameValueCollection();
                metadata["LinkId"] = id;
                metadata["Filename"] = fileName;
                metadata["AssignID"] = String.IsNullOrEmpty(name) ? "unknown" : name;
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
                
                blobContainer = blobClient.GetContainerReference("gallery"); //Gets the blobe storage
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
            
    
            public  LinkedList<Paper> getAssignmentList()
            {

                LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();

                CloudBlobContainer blobContainer = null;
                CloudStorageAccount storageAccount = null;
                CloudBlobClient blobClient = null;
                
                storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                blobClient = storageAccount.CreateCloudBlobClient();
                
                blobContainer = blobClient.GetContainerReference("gallery"); //Gets the blobe storage
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
            }

        }
    
