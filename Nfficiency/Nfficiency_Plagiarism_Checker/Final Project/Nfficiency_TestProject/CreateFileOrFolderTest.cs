using RDImageGallery_WebRole.Old_App_Code1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.IO;

namespace Nfficiency_TestProject
{
    
    
    /// <summary>
    ///This is a test class for CreateFileOrFolderTest and is intended
    ///to contain all CreateFileOrFolderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CreateFileOrFolderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CreateFileOrFolder Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
  //      [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]
      
        [UrlToTest("http://localhost:8080/")]
        public void CreateFileOrFolderConstructorTest()
        {
            CreateFileOrFolder target = new CreateFileOrFolder();
            
        }

        /// <summary>
        ///A test for createDir1
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
    //    [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]

        [UrlToTest("http://localhost:8080/")]
        public void createDir1Test()
        {
            string inActiveDir = Path.GetPathRoot(Directory.GetCurrentDirectory()); 
            string inDir = "FileRepository";

            try
            {
                CreateFileOrFolder.createDir1(inActiveDir, inDir);
            }
            catch (IOException)
            {
                Assert.Fail("Unable to create Repository Directory.");
               
            }
            
          }

        /// <summary>
        ///A test for createRepoDir
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
     //   [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]

        [UrlToTest("http://localhost:8080/")]
        public void createRepoDirTest()
        {
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string newPath = System.IO.Path.Combine(activeDir, "FileRepository");
            DirectoryInfo dir = new DirectoryInfo(activeDir);
            if (!dir.Exists)
            {
            dir.Create();
            }
            else
            // Create the subfolder under activeDir
            
            try
            {
                System.IO.Directory.CreateDirectory(newPath);
                CreateFileOrFolder.createRepoDir();
            }
            catch (IOException)
            {

                Assert.Fail("Unable to create Repository Directory.");
            }
            
        }

        /// <summary>
        ///A test for getActiveDir
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
    //    [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]

        [UrlToTest("http://localhost:8080/")]
        public void getActiveDirTest()
        {
            string aGUID = "341bc9cc-3c9e-485f-ab4f-9a278caf041c"; // TODO: Initialize to an appropriate value
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            activeDir = Path.Combine(activeDir, "FileRepository");
            activeDir = Path.Combine(activeDir, aGUID);
            string expected = activeDir;
            string actual;
            actual = CreateFileOrFolder.getActiveDir(aGUID);
            if (StringAssert.Equals(expected, actual) == true) { }
            else { Assert.Inconclusive("Verify the correctness of this test method."); }
        }

        /// <summary>
        ///A test for getActiveDir
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
   //     [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]
        [UrlToTest("http://localhost:8080/")]
        public void getActiveDirTest1()
        {
            string aGUID = "341bc9cc-3c9e-485f-ab4f-9a278caf041c"; // TODO: Initialize to an appropriate value
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            activeDir = Path.Combine(activeDir, "FileRepository");
            activeDir = Path.Combine(activeDir, aGUID);
            string expected = activeDir;
            string actual;
            actual = CreateFileOrFolder.getActiveDir(aGUID);
            if (StringAssert.Equals(expected, actual) == true) { }
            else { Assert.Inconclusive("Verify the correctness of this test method."); }
        }
    }
}
