//*************************************************
//   Called using the following instance....... 
//
//   protected void btnProcess_Click(object sender, EventArgs e)
//    {
//        assignmentReturn ar = new assignmentReturn();
//        LinkedList<Paper> pa = new LinkedList<Paper>();
//        pa = ar.getAssignmentList();
//
//        for (int i = 0; i < pa.Count; i++)
//            txtOut.Text = pa.First.Value.Data.First.Value.ToString();
//    }
//



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

namespace RDImageGallery_WebRole.Old_App_Code
{
    public class assignmentReturn
    {

//Default getAssignmentList
//Takes no paramiters, uses default container "gallery"
        public LinkedList<Paper> getAssignmentList()
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
                //txtTest.Text = srcBlob.DownloadText();
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
            //lblInfo.Text = (AssignmentsList.Count().ToString());
            //RefreshGallery();

            return AssignmentsList;
        }


        //Default getAssignmentList
        //Takes container as paramiter, container in aGUID, connection string = "DataConnectionString 
        public LinkedList<Paper> getAssignmentList(string container)
        {

            LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();

            CloudBlobContainer blobContainer = null;
            CloudStorageAccount storageAccount = null;
            CloudBlobClient blobClient = null;

            storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            blobClient = storageAccount.CreateCloudBlobClient();

            blobContainer = blobClient.GetContainerReference(container.ToString()); //Gets the blobe storage
            var blobs = blobContainer.ListBlobs(); //Gets the entire list of Blob items
            var blobList = new List<string>();
            foreach (var blob in blobs)
            {
                Paper newPaper = new Paper();
                var srcBlob = blobContainer.GetBlobReference(blob.Uri.ToString()); //Gets each blobs Uri
                srcBlob.FetchAttributes();
                //txtTest.Text = srcBlob.DownloadText();
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
            return AssignmentsList;
        }


    }

    }
