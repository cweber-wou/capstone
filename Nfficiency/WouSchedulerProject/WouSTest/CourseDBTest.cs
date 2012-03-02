using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace WouSTest
{
    
    
    /// <summary>
    ///This is a test class for CourseDBTest and is intended
    ///to contain all CourseDBTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CourseDBTest
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
        ///A test for DeleteCourse
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobs\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51491/")]
        public void DeleteCourseTest()
        {
            Course course = new Course(); // TODO: Initialize to an appropriate value
            course.CID = 0;
            course.DID = 0;
            course.Description = "this is a test";
            course.Hours = 0;

            CourseDB.InsertCourse(course);

            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            actual = CourseDB.DeleteCourse(course);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAllCourses
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobs\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51491/")]
        public void GetAllCoursesTest()
        {
            List<Course> expected = null; // TODO: Initialize to an appropriate value
            List<Course> actual;
            actual = CourseDB.GetAllCourses();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetConnectionString
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobs\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51491/")]
        [DeploymentItem("WouSchedulerProject.dll")]
        public void GetConnectionStringTest()
        {
            string expected = "Data Source=140.211.126.155;Initial Catalog=Nifficiency_Scheduler;Persist Security Info=True;User ID=Nifficiency_Scheduler;Password=password1234"; // TODO: Initialize to an appropriate value
            string actual;
            actual = CourseDB_Accessor.GetConnectionString();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InsertCourse
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobs\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51491/")]
        public void InsertCourseTest()
        {
            Course course = new Course(); // TODO: Initialize to an appropriate value
            course.CID = 0;
            course.DID = 0;
            course.Description = "this is a test";
            course.Hours = 0;

            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            actual = CourseDB.InsertCourse(course);
            Assert.AreEqual(expected, actual);
            CourseDB.DeleteCourse(course);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateCourse
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("c:\\users\\jobs\\documents\\visual studio 2010\\Projects\\WouSchedulerProject\\WouSchedulerProject", "/")]
        [UrlToTest("http://localhost:51491/")]
        public void UpdateCourseTest()
        {
            Course original_Course = null; // TODO: Initialize to an appropriate value
            Course course = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = CourseDB.UpdateCourse(course);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
