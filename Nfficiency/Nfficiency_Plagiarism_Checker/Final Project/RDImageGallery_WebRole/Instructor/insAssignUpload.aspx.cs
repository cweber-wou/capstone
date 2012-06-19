///////////////////////////////////////////////////////////////////////////
//
//	File: inAssignUpload.aspx.cs
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
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;


namespace RDImageGallery_WebRole 
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Web.UI.WebControls;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Collections;
    using RDImageGallery_WebRole.Old_App_Code1;
    using System.Text;

    public partial class insAssignUpload : System.Web.UI.Page
    {
        string Course_ID;
        string User_ID;
        string aGUID;
        bool b = true;
        ArrayList PageArrayList;
        GetPapersClass gpc = new GetPapersClass(); // Instance of container, papers, etc helper class

        //Creates an arraylist to hold the ViewState data
        ArrayList CreateArray()
        {
            ArrayList result = new ArrayList(4);
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Course_ID = Request.QueryString["id"];
            lblCourse_ID.Text = Course_ID;
            lblCourse_Name.Text = CourseClassDB.getCourseName(Course_ID);
            User_ID = User.Identity.Name.ToString(); // Gets user that is logged in

            if (ViewState["arrayListInViewState"] != null)
            {
                PageArrayList = (ArrayList)ViewState["arrayListInViewState"]; //Passed paramiter for page reload
                Course_ID = PageArrayList[0].ToString(); //retrieved from state
                User_ID = PageArrayList[1].ToString(); //retrieved from state
                aGUID = PageArrayList[2].ToString(); //retrieved from state
                gpc.GetContainer(aGUID.ToString(), Course_ID.ToString());
            }
            else
            {
                // ArrayList isn't in view state, so we need to load it from scratch, we don't have the aGUID yet.
                PageArrayList = CreateArray();
                PageArrayList.Insert(0, Course_ID.ToString());
                PageArrayList.Insert(1, User_ID.ToString());
                PageArrayList.Insert(2, "aGUID NOT SET");
            }
            if (IsPostBack) { b = true; } // we really don't care if this is a postback, we catch the viewstate on page load.
        }
        void Page_PreRender(object sender, EventArgs e)
        {
            // Save PageArrayList before the page is rendered, make sure it's the freshest version.
            ViewState.Add("arrayListInViewState", PageArrayList);
        }
        
        private void RefreshGallery()
        {
            images.DataSource = gpc.ToDataSetImage1(gpc.pathToPapers(gpc.GetContainer(aGUID.ToString(), Course_ID.ToString() ),aGUID.ToString()));
            images.DataBind();
        }

        // the "this" needs to be set using GetContainer(aGUID)  
        protected void OnBlobDataBound(object sender, ListViewItemEventArgs e)
        {
            if (b == true)
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    var metadataRepeater = e.Item.FindControl("blobMetadata") as Repeater;
                    var blob = ((ListViewDataItem)(e.Item)).DataItem;
                    if (blob != null)
                    {
                        var delBtn = e.Item.FindControl("deleteFile") as LinkButton;

                        if (delBtn != null)
                        {
                            delBtn.Text = "Delete Snapshot";
                        }

                        var snapshotBtn = e.Item.FindControl("SnapshotFile") as LinkButton;
                        if (snapshotBtn != null) snapshotBtn.Visible = false;
                        if (metadataRepeater != null)
                        {
                           //bind to metadata
                          // metadataRepeater.DataSource = GetPapersClass.ToDataSet1(pathToPapers(GetPapersClass.GetContainer(aGUID.ToString(), Course_ID.ToString() )));
                           metadataRepeater.DataSource = gpc.ToDataSet1(gpc.pathToPapers(gpc.GetContainer(aGUID, Course_ID), aGUID));
                           metadataRepeater.DataBind();
                        }
                        b = false;
                    }
                }
            }
        }


        protected void OnDeleteFile(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    var blobUri = (string)e.CommandArgument;
                    status.Text = "File Removed";

                }
            }
            catch (FileNotFoundException se)
            {
                status.Text = "Storage client error: " + se.Message;
            }
            catch (Exception) { }

            RefreshGallery();
        }


        protected void OnCopyFile(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Copy")
            {
                              
                
                RefreshGallery();
            }
        }


        protected void OnSnapshotFile(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Snapshot")
            {
             RefreshGallery();
            }
        }

        //Method for downloading a image to local
        // Public assignmentReturn is class version of this method
        protected void OnDownloadFile(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "Download")
            {
                {

                }

                RefreshGallery();
            }
        }

        private void EnsureContainerExists()
        {
            var container = gpc.GetContainer(aGUID, Course_ID);
            System.IO.FileInfo file = new System.IO.FileInfo(container);
            file.Directory.Create(); // If the directory already exists, this method does nothing.
        }

        protected void SaveImage(string id, string container_AID, string userID_blob, string description, string tags, string fileName, string contentType, byte[] data)
        {
            String newPath = gpc.GetContainer(aGUID, Course_ID);
            string newFileName = User.Identity.Name.ToString() + ".txt";
            newPath = System.IO.Path.Combine(newPath, newFileName);
            //Overwrites existing
            System.IO.File.WriteAllBytes(newPath, data); // Write byte[] to file
        }

        protected void images_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int isAGuidSet()
        {
            if (aGUID.Equals("aGUID NOT SET"))
                return 0;

            if (aGUID != "aGUID NOT SET")
                return 1;

            else { return -1; }
        }

        //Process File buttons
        protected void btnKeyWC_Click(object sender, EventArgs e)
        {
            int is_aguid_set = isAGuidSet();
            if (is_aguid_set == 0)
            {
                status.Text = "Please Select Assignment";
                return;
            }
            else
            {
                LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();
                Response.Redirect("~/KeyWCtest.aspx?aGUID=" + aGUID.ToString());
                RefreshGallery();
            }
        }

        
        protected void btnProcess_Click(object sender, EventArgs e)
        {
             int is_aguid_set = isAGuidSet();
             if (is_aguid_set == 0)
             {
                 status.Text = "Please Select Assignment";
                 return;
             }
             else
             {
                 LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();
                 Response.Redirect("~/WCReport.aspx?aGUID=" + aGUID.ToString());
                 RefreshGallery();
             }
        }

        protected void btnWordList_Click(object sender, EventArgs e)
        {
             int is_aguid_set = isAGuidSet();
             if (is_aguid_set == 0)
             {
                 status.Text = "Please Select Assignment";
                 return;
             }
             else
             {
                 LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();
                 Response.Redirect("~/WordList.aspx?aGUID=" + aGUID.ToString());
                 RefreshGallery();
             }
        }

        public string returnAGuidPath(string inAGUID)
        {
            string pathOfAGUID = string.Empty;
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            activeDir = Path.Combine(activeDir, "FileRepository");
            string[] files = Directory.GetDirectories(activeDir, inAGUID, SearchOption.AllDirectories);

            try
            {
                pathOfAGUID = files[0].ToString();
            }
            catch (DirectoryNotFoundException)
            {
                pathOfAGUID = "File Not Found: getCourseID_AGUID(string inAGUID)";
            }
            return pathOfAGUID;
        }

        public LinkedList<Paper> getAssignmentReport(string inAGuid)
        {
            string path = string.Empty;
            LinkedList<Paper> files = new LinkedList<Paper>();
            path = returnAGuidPath(inAGuid); // Gets the path of the aGUID
            files = pathToPapers(path.ToString());
            foreach (Paper p in files)
            {
                p.Data = new LinkedList<string>();
                string fileString = File.ReadAllText(p.Link); //gets the file as a byte[]
                string[] lines = fileString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); //Splits file up by '\n'
                for (int i = 0; i < lines.Length; i++)
                    p.Data.AddLast(lines[i].ToString());
            }
            return files;
        }
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            aGUID = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
            lblInfo1.Text = aGUID.ToString();
            PageArrayList.Insert(2, aGUID.ToString());
            RefreshGallery();
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

        public void createFile(string catFile)
        {
            String newPath = gpc.GetContainer(aGUID, Course_ID);

            //This line was changed for Instructor
            //string newFileName = User.Identity.Name.ToString() + ".txt";
            string newFileName = "Dictonary.txt";
            newPath = System.IO.Path.Combine(newPath, newFileName);

            //Overwrites existing
            if (!System.IO.File.Exists(newPath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(newPath))
                {
                    byte[] b = StringToByteArray(catFile.ToString());
                    fs.Write(b, 0, b.Length);
                    
                }
            }
        }


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
                string truUserID = Path.GetFileNameWithoutExtension(p);//parsed filename without extension
                paper.UserID = truUserID.ToString();

                paper.FileName = p.ToString();
                allPapers.AddFirst(paper);
            }
            return allPapers;
        }

        public Byte[] GetFileContent(System.IO.Stream inputstm)
        {
            Stream fs = inputstm;
            BinaryReader br = new BinaryReader(fs);
            Int32 lnt = Convert.ToInt32(fs.Length);
            byte[] bytes = br.ReadBytes(lnt);
            return bytes;
        }

        private void SaveFileContent()
        {
            LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();
            HttpPostedFile postFile;
            string catFile = string.Empty;
            string ImageName = string.Empty;

            byte[] path;
            string[] keys;

            try
            {
                string contentType = string.Empty;
                // byte[] imgContent = null;
                string[] fileTitle;
                string fileTitleName;
                HttpFileCollection files = Request.Files;
                keys = files.AllKeys;

                for (int i = 0; i < files.Count; i++)
                {
                    postFile = files[i];
                    if (postFile.ContentLength > 0)
                    {

                        contentType = postFile.ContentType;

                        path = GetFileContent(postFile.InputStream);
                        catFile += ByteArrayToString(path);

                        ImageName = System.IO.Path.GetFileName(postFile.FileName);
                        fileTitle = ImageName.Split('.');
                        fileTitleName = fileTitle[0];
                    }
                }

                txtTest.Text = catFile.ToString();
                createFile(catFile); //Helper function to save file
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        protected void btnAddFile_Click1(object sender, EventArgs e)
        {
            try
            {
                SaveFileContent();
                RefreshGallery();
            }
            catch (DirectoryNotFoundException)
            {
                status.Text = "Please Select Assignment";
                
            }
            
        }

        //Helper function
        public static byte[] StringToByteArray(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }

        //Helper function
        public string ByteArrayToString(byte[] input)
        {
            UTF8Encoding enc = new UTF8Encoding();
            string str = enc.GetString(input);
            return str;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int is_aguid_set = isAGuidSet();
            if (is_aguid_set == 0)
            {
                status.Text = "Please Select Assignment";
                return;
            }
            else
            {
                LinkedList<Paper> AssignmentsList = new LinkedList<Paper>();
                Response.Redirect("~/KeyOrder.aspx?aGUID=" + aGUID.ToString());
                RefreshGallery();
            }
        }

    }// End Class

}// End NameSpace


