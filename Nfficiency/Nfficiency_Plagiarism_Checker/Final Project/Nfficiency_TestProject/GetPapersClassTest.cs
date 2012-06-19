using RDImageGallery_WebRole.Old_App_Code1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;
using System.Data;

using System.Collections.Specialized;
using System.Configuration;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace Nfficiency_TestProject
{
    /// <summary>
    ///This is a test class for GetPapersClassTest and is intended
    ///to contain all GetPapersClassTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GetPapersClassTest
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
        ///A test for GetPapersClass Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
   //     [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]
        [UrlToTest("http://localhost:8080/")]
        public void GetPapersClassConstructorTest()
        {
            GetPapersClass target = new GetPapersClass();
           
        }

        /// <summary>
        ///A test for GetContainer
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
   //     [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole","/")]
        [UrlToTest("http://localhost:8080/")]
        public void GetContainerTest()
        {
            GetPapersClass target = new GetPapersClass(); // TODO: Initialize to an appropriate value
            string activeDir = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string aGUID = "adeac8b2-89eb-40e4-b44a-85927a3a1f20"; // TODO: Initialize to an appropriate value
            string Course_ID = "3"; // TODO: Initialize to an appropriate value
            string expected = "C:\\FileRepository\\3\\adeac8b2-89eb-40e4-b44a-85927a3a1f20"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetContainer(aGUID, Course_ID);
            //Assert.AreEqual(expected, actual);
            if(StringAssert.Equals(expected, actual) == true){}

            if (StringAssert.Equals(expected, actual) == false) {
                Assert.Fail("Check GetContainerTest Code");
            }
        
        }

        /// <summary>
        ///A test for ToDataSet1
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
  //      [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]
        [UrlToTest("http://localhost:8080/")]
        public void ToDataSet1Test()
        {

            string aGUID = "adeac8b2-89eb-40e4-b44a-85927a3a1f20";
            string Course_ID = "3";
            GetPapersClass gpc = new GetPapersClass(); //Create new instance
           
            GetPapersClass target = new GetPapersClass(); // TODO: Initialize to an appropriate value
            LinkedList<Paper> list = (gpc.pathToPapers(gpc.GetContainer(aGUID, Course_ID), aGUID));// TODO: Initialize to an appropriate value
            DataSet expected = gpc.ToDataSet1(gpc.pathToPapers(gpc.GetContainer(aGUID, Course_ID), aGUID)); // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ToDataSet1(list);
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Tables.Count, actual.Tables.Count); // Checks if the #of tables are the same
            Assert.AreEqual(expected.Tables.Contains("aGUID"), actual.Tables.Contains("aGUID")); // Checks if aGUID is a table name
            Assert.AreEqual(expected.Tables.Contains("UserID"), actual.Tables.Contains("UserID")); // Checks if UserID is a table name
            Assert.AreEqual(expected.Tables.Contains("txtFileName"), actual.Tables.Contains("txtFileName")); // Checks if txtFileName is a table name
            Assert.AreEqual(expected.Tables.Contains("Link"), actual.Tables.Contains("Link")); // Checks if txtFileName is a table name

            for(int i =0; i<expected.Tables.Count; i++)
                for(int j = 0; j< expected.Tables[i].Rows.Count; j++)
            {Assert.AreEqual(expected.Tables[i].Rows[j].ToString(), actual.Tables[i].Rows[j].ToString());}
            
        }

        /// <summary>
        ///A test for ToDataSetImage1
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
   //     [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]
        [UrlToTest("http://localhost:8080/")]
        public void ToDataSetImage1Test()
        {

            string aGUID = "adeac8b2-89eb-40e4-b44a-85927a3a1f20";
            string Course_ID = "3";
            GetPapersClass gpc = new GetPapersClass(); //Create new instance

            GetPapersClass target = new GetPapersClass(); // TODO: Initialize to an appropriate value
            LinkedList<Paper> list = (gpc.pathToPapers(gpc.GetContainer(aGUID, Course_ID), aGUID));// TODO: Initialize to an appropriate value
            DataSet expected = gpc.ToDataSet1(gpc.pathToPapers(gpc.GetContainer(aGUID, Course_ID), aGUID)); // TODO: Initialize to an appropriate value
            DataSet actual;
            actual = target.ToDataSetImage1(list);
            //Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Tables.Contains("txtFileName"), actual.Tables.Contains("txtFileName")); // Checks if txtFileName is a table name
        //Loops through all Columns and values in Rows and compairs values
            for (int i = 0; i < expected.Tables.Count; i++)
                for (int j = 0; j < expected.Tables[i].Rows.Count; j++)
                { Assert.AreEqual(expected.Tables[i].Rows[j].ToString(), actual.Tables[i].Rows[j].ToString()); }

           
        }

        /// <summary>
        ///A test for pathToPapers
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
   //     [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("$(SolutionDir)\\$(SolutionFileName)\\RDImageGallery_WebRole", "/")]
        [UrlToTest("http://localhost:8080/")]
        public void pathToPapersTest()
        {
            string aGUID = "adeac8b2-89eb-40e4-b44a-85927a3a1f20";
            string Course_ID = "3";
            GetPapersClass gpc = new GetPapersClass(); //Create new instance

           
            GetPapersClass target = new GetPapersClass(); // TODO: Initialize to an appropriate value
            string path = gpc.GetContainer(aGUID, Course_ID); // TODO: Initialize to an appropriate value

            LinkedList<Paper> expected = (gpc.pathToPapers(gpc.GetContainer(aGUID, Course_ID), aGUID)); // TODO: Initialize to an appropriate value
            LinkedList<Paper> actual;
            actual = target.pathToPapers(path, aGUID);

            LinkedListNode<Paper> p = expected.First;
            LinkedListNode<Paper> r = actual.First;
               
            //Iterates through Papers and compairs values
            while(p.Next != null)
                {
                StringAssert.Equals(p.Value.AID.ToString(), r.Value.AID.ToString());
                StringAssert.Equals(p.Value.FileName.ToString(), r.Value.FileName.ToString());
                StringAssert.Equals(p.Value.Link.ToString(), r.Value.Link.ToString());
                StringAssert.Equals(p.Value.UserID.ToString(), r.Value.UserID.ToString());
                //***************************************************

            
                //*****************************************************
                p = p.Next;
                r = r.Next;
                }
          //  Assert.AreEqual(expected, actual);
            
        }
    }
}
