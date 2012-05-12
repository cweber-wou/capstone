using backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace backendTests
{
    
    
    /// <summary>
    ///This is a test class for TesterTest and is intended
    ///to contain all TesterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TesterTest
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
        ///A test for Tester Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Acidraven\\Desktop\\CS430\\Nfficiency_Plagiarism_Checker\\Junk\\backend\\backend", "/")]
        [UrlToTest("http://localhost:3088/blank.aspx")]
        public void TesterConstructorTest()
        {
            Tester target = new Tester();
            
            Assert.AreEqual(target.Tested, 0);
            Assert.IsNotNull(target.Reports);

            //Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for run
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Acidraven\\Desktop\\CS430\\Nfficiency_Plagiarism_Checker\\Junk\\backend\\backend", "/")]
        [UrlToTest("http://localhost:3088/blank.aspx")]
        public void runTest()
        {
            Tester target = new Tester(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.run();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        // <summary>
        ///A test for Type
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Acidraven\\Desktop\\CS430\\Nfficiency_Plagiarism_Checker\\Junk\\backend\\backend", "/")]
        [UrlToTest("http://localhost:3088/blank.aspx")]
        public void TypeTest()
        {
            Tester target = new Tester(); // TODO: Initialize to an appropriate value
            int expected = 1; // TODO: Initialize to an appropriate value
            int actual;
            target.Type = expected;
            actual = target.Type;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for AID
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Acidraven\\Desktop\\CS430\\Nfficiency_Plagiarism_Checker\\Junk\\backend\\backend", "/")]
        [UrlToTest("http://localhost:3088/blank.aspx")]
        public void AIDTest()
        {
            Tester target = new Tester(); // TODO: Initialize to an appropriate value
            int expected = 326; // TODO: Initialize to an appropriate value
            int actual;
            target.AID = expected;
            actual = target.AID;
            Assert.AreEqual(expected, actual);
            
        }
    }
}
