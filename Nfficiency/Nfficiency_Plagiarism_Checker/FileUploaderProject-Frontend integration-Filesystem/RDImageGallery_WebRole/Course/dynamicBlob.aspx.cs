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
//  File System Repository
//  Need to save a file to proper directory, with proper file name
//  Need to retrieve file from directory and store in linked list
//  Need to parse file for linked list
//  
//
//////////////////////////////////////////////////////////////////////////


using System;
using System.Data;
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
    using RDImageGallery_WebRole.Old_App_Code1;

    public partial class dynamicBlob : System.Web.UI.Page
    {
        string Course_ID;
        string User_ID;
        string aGUID;
        bool b = true;
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
      PageArrayList = (ArrayList)ViewState["arrayListInViewState"]; //Passed paramiter for page reload
      Course_ID = PageArrayList[0].ToString(); //retrieved from state
      User_ID = PageArrayList[1].ToString(); //retrieved from state
      aGUID = PageArrayList[2].ToString(); //retrieved from state
      this.GetContainer(aGUID.ToString()); //retrieved from state
    }
    else
    {
      // ArrayList isn't in view state, so we need to load it from scratch, we don't have the aGUID yet.
      PageArrayList = CreateArray();
      PageArrayList.Insert(0, Course_ID.ToString());
      PageArrayList.Insert(1, User_ID.ToString());
      PageArrayList.Insert(2, "Dummy");
    }
            if (IsPostBack) { b = true; } // we really don't care if this is a postback, we catch the viewstate on page load.
            }
         void Page_PreRender(object sender, EventArgs e)
         {
             // Save PageArrayList before the page is rendered, make sure it's the freshest version.
             ViewState.Add("arrayListInViewState", PageArrayList);
         }
                       
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
                    status.Text = "No file";
            }


            public DataSet ToDataSet(LinkedList<Paper> list)
            {
                Type elementType = typeof(Paper);
                DataSet ds = new DataSet();
                DataTable t = new DataTable();
                ds.Tables.Add(t);
                var g = typeof(Paper).GetProperties(); 
                t.Columns.Add("AID");
                t.Columns.Add("UserID");
                t.Columns.Add("txtFileName");
                t.Columns.Add("Link");           

                //go through each property on T and add each value to the table
                foreach (Paper item in list)
                {
                    DataRow row = t.NewRow();
                    
                        row[0] = item.AID.ToString();
                        row[1] = item.UserID.ToString();
                        row[2] = item.FileName.ToString();
                        row[3] = item.Link.ToString();
                    

                    //This line was missing:
                    t.Rows.Add(row);
                }
               return ds;
            }

            public DataSet ToDataSetImage(LinkedList<Paper> list)
            {
                Type elementType = typeof(Paper);
                DataSet ds = new DataSet();
                DataTable t = new DataTable();
                ds.Tables.Add(t);
                var g = typeof(Paper).GetProperties();
                t.Columns.Add("txtFileName");
                //add a column to table for each public property on T
                //go through each property on T and add each value to the table
                foreach (Paper item in list)
                {
                    DataRow row = t.NewRow();
                    row[0] = item.FileName.ToString();
                    t.Rows.Add(row);
                }
                return ds;
            }

            private void RefreshGallery()
            {
                images.DataSource = ToDataSetImage(pathToPapers(GetContainer(aGUID.ToString())));
                images.DataBind();
            }
           
          // Cast out blob instance and bind it's metadata to metadata repeater
          // the "this" needs to be set using GetContainer(aGUID)  
            protected void OnBlobDataBound(object sender, ListViewItemEventArgs e)
            {
                if (b==true) {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    var metadataRepeater = e.Item.FindControl("blobMetadata") as Repeater;
                    var blob = ((ListViewDataItem)(e.Item)).DataItem;
                    if (blob != null)
                    {
                    var delBtn = e.Item.FindControl("deleteBlob") as LinkButton;

                            if (delBtn != null)
                            {
                                delBtn.Text = "Delete Snapshot";
                            }

                            var snapshotBtn = e.Item.FindControl("SnapshotBlob") as LinkButton;
                            if (snapshotBtn != null) snapshotBtn.Visible = false;
                            if (metadataRepeater != null)
                            {
                                //bind to metadata
                                metadataRepeater.DataSource = ToDataSet(pathToPapers(GetContainer(aGUID.ToString())));
                                metadataRepeater.DataBind();
                            }
                                b = false;
                        }
                    }
                }
            }

            
            protected void OnDeleteImage(object sender, CommandEventArgs e)
            {
                try
                {
                    if (e.CommandName == "Delete")
                    {
                        var blobUri = (string)e.CommandArgument;
                        //var blob = this.GetContainer().GetBlobReference(blobUri);
                        status.Text = "File Removed";
                       // blob.DeleteIfExists();
                    }
                }
                catch (StorageClientException se)
                {
                    status.Text = "Storage client error: " + se.Message;
                }
                catch (Exception) { }

                RefreshGallery();
            }

            
            protected void OnCopyImage(object sender, CommandEventArgs e)
            {
                if (e.CommandName == "Copy")
                {
                    // Prepare an Id for the copied blob
                    var newId = Guid.NewGuid();

                    // Get source blob
                    var blobUri = (string)e.CommandArgument;
                   // var srcBlob = this.GetContainer(aGUID.ToString()).GetBlobReference(blobUri);

                    // Create new blob
                   // var newBlob = this.GetContainer(aGUID.ToString()).GetBlobReference(newId.ToString());

                    // Copy content from source blob
                   // newBlob.CopyFromBlob(srcBlob);

                    // Explicitly get metadata for new blob
                   // newBlob.FetchAttributes(new BlobRequestOptions { BlobListingDetails = BlobListingDetails.Metadata });

                    // Change metadata on the new blob to reflect this is a copy via UI
                   // newBlob.Metadata["txtAssignID"] = "Copy of \"" + newBlob.Metadata["txtAssignID"] + "\"";
                   // newBlob.Metadata["Id"] = newId.ToString();
                  //  newBlob.SetMetadata();

                    // Render all blobs
                    RefreshGallery();
                }
            }

           
            protected void OnSnapshotImage(object sender, CommandEventArgs e)
            {
                if (e.CommandName == "Snapshot")
                {
                    // Get source blob
                    var blobUri = (string)e.CommandArgument;
                  //  var srcBlob = this.GetContainer().GetBlobReference(blobUri);

                    // Create a snapshot
                 //   var snapshot = srcBlob.CreateSnapshot();

                 //   status.Text = "A snapshot has been taken for image blob:" + srcBlob.Uri + " at " + snapshot.SnapshotTime;

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
               //     var srcBlob = this.GetContainer().GetBlobReference(blobUri);
               //     srcBlob.DownloadToFile(fileToDownload);
               //     String fileDL = srcBlob.DownloadText();
              //     Byte [] A = srcBlob.DownloadByteArray();
              //     String B = srcBlob.DownloadText();
                                      
             //      status.Text = fileDL.ToString();
             //      txtTest.Text = fileDL.ToString();  //Multiline textbox
             //       lblInfo.Text = srcBlob.Metadata.Get("id");
                    
                    // status.Text = "The file: " + srcBlob.Uri + " has been downloaded to: " + fileToDownload;
           //         string[] lines = fileDL.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
           //        lblInfo.Text = lines[0].ToString();
                    //Loops through all Blobs
            //       foreach (string key in srcBlob.Metadata.Keys)
                   {
                      
                   }

                   RefreshGallery();
                }
            }
        
            private void EnsureContainerExists()
            {
                var container = GetContainer();
                System.IO.FileInfo file = new System.IO.FileInfo(container);
                file.Directory.Create(); // If the directory already exists, this method does nothing.
            }
         

            private string GetContainer()
            {
                {
                    if (aGUID == null)
                    {
                        string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
                        return activeDir;
                    }
                    else
                    {
                        string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
                        activeDir = Path.Combine(activeDir, "FileRepository");
                        activeDir = Path.Combine(activeDir, Course_ID);
                        return activeDir;
                    }
                }
            }

        //Returns the directory of the assignment
            private string GetContainer(String aGUID)
            {
                string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
                activeDir = Path.Combine(activeDir, "FileRepository");
                activeDir = Path.Combine(activeDir, Course_ID);
                activeDir = Path.Combine(activeDir, aGUID);
                return activeDir;
                
            }
        
       

            protected void SaveImage(string id, string container_AID, string userID_blob, string description, string tags, string fileName, string contentType, byte[] data)
            {
                String newPath =  this.GetContainer(aGUID);
                string newFileName = User.Identity.Name.ToString() + ".txt"; 
                newPath = System.IO.Path.Combine(newPath, newFileName);
                //Overwrites existing
                System.IO.File.WriteAllBytes(newPath, data); // Write byte[] to file
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
                //Iterates through blobs
                foreach (var blob in blobs)
                {
                    Paper newPaper = new Paper();
                    var srcBlob = blobContainer.GetBlobReference(blob.Uri.ToString()); //Gets each blobs Uri
                    srcBlob.FetchAttributes();
                    txtTest.Text = srcBlob.DownloadText();
                    blobList.Add(blob.Uri.ToString());
                    
                    String fileDL = srcBlob.DownloadText();
                    LinkedList<String> dataList = new LinkedList<string>();
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
                   //Sets this container = aGUID
                 RefreshGallery();
            }

        //Checks if the FileRepository exists, if not creates it
            protected void btnCreateDir_Click(object sender, EventArgs e)
            {
                string c;
                c="c";
               createFile(c);  
                         
            }

            public void createRepoDir()
            {
                
                string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
                //Create a new subfolder under the current active folder
                string newPath = System.IO.Path.Combine(activeDir, "FileRepository");
                //Checks if the directory exists, if it dosn't then it makes it
                DirectoryInfo dir = new DirectoryInfo(activeDir);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                else
                    // Create the subfolder under activeDir
                    System.IO.Directory.CreateDirectory(newPath);
            }//End createRepoDir

            public void createFile(string inDir)
            {
               String newPath =  this.GetContainer(aGUID);
                string newFileName = User.Identity.Name.ToString() + ".txt"; 
                newPath = System.IO.Path.Combine(newPath, newFileName);

               //Overwrites existing
                if (!System.IO.File.Exists(newPath))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(newPath))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);
                        }
                    }
                }}
//Gets all the file names in the path
public LinkedList<string> getAllFiles(string path)
{
    LinkedList<string> allFiles = new LinkedList<string>();
     System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
                foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
                {
                allFiles.AddFirst(f.Name);
                }
                return allFiles;
}//End getAllFiles


//Takes the path of the directory, converts to LL<str> of files
//Converts to LL of papers
//Returns LL<papers>
//Don't want to pull in data here due to overhead
public LinkedList<Paper> pathToPapers(string path)
{
    LinkedList<string> allFiles = new LinkedList<string>();
    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
    foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
    {
        allFiles.AddFirst(f.Name);
    }
    LinkedList<Paper> allPapers = new LinkedList<Paper>();
    foreach (string p in allFiles)
    {
        Paper paper = new Paper();
        paper.AID = aGUID.ToString();
        string fullPath = Path.Combine(path, p);
        paper.Link = fullPath.ToString();
        string truUserID = Path.GetFileNameWithoutExtension(p);
        paper.UserID = truUserID.ToString();//need to parse file name to get user name.

        paper.FileName = p.ToString();
        allPapers.AddFirst(paper);
    }
    return allPapers;


}

    }// End Class



        }// End NameSpace
    

