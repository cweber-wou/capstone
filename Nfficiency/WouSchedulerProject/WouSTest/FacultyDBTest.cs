using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace WouSTest
{
    
    
    /// <summary>
    ///This is a test class for FacultyDBTest and is intended
    ///to contain all FacultyDBTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FacultyDBTest
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
        ///A test for GetAllFauclty
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobsLaptop\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51941/")]
        public void GetAllFaucltyTest()
        {
            //List<Faculty> expected = null; // TODO: Initialize to an appropriate value
            List<Faculty> actual;
            actual = FacultyDB.GetAllFauclty();
            Assert.IsTrue(actual != null);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetConnectionString
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobsLaptop\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51941/")]
        [DeploymentItem("WouSchedulerProject.dll")]
        public void GetConnectionStringTest()
        {
            string expected = "Data Source=140.211.126.155;Initial Catalog=Nifficiency_Scheduler;Persist Security Info=True;User ID=Nifficiency_Scheduler;Password=password1234";
            string actual;
            actual = FacultyDB_Accessor.GetConnectionString();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteFaculty
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobsLaptop\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51941/")]
        public void DeleteFacultyTest()
        {
            Faculty f = new Faculty();
            f.first = "TestPerson";
            f.last = "TestPersonsLastname";

            FacultyDB.InsertFaculty(f);
           
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = FacultyDB.DeleteFaculty(f);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateFaculty
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobsLaptop\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51941/")]
        public void UpdateFacultyTest()
        {
            Faculty f = new Faculty(); // TODO: Initialize to an appropriate value
            f.first = "TestPerson";
            f.last = "TestPersonsLastname";

            FacultyDB.InsertFaculty(f);
            f.first = "IloveLamp";
            f.last = "thisSHouldWOrkkk";

            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = FacultyDB.UpdateFaculty(f);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
            FacultyDB.DeleteFaculty(f);
        }

        /// <summary>
        ///A test for InsertFaculty
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobsLaptop\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51941/")]
        public void InsertFacultyTest()
        {
            Faculty f = new Faculty();
            f.first = "TestPerson";
            f.last = "TestPersonsLastname";

            FacultyDB.InsertFaculty(f);

            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = FacultyDB.DeleteFaculty(f);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
