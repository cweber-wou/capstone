﻿using backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace backendTests
{
    
    
    /// <summary>
    ///This is a test class for wcTest and is intended
    ///to contain all wcTest Unit Tests
    ///</summary>
    [TestClass()]
    public class wcTest
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
        ///A test for wc Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Acidraven\\Desktop\\CS430\\Nfficiency_Plagiarism_Checker\\Junk\\backend\\backend", "/")]
        [UrlToTest("http://localhost:3088/blank.aspx")]
        public void wcConstructorTest()
        {
            wc target = new wc();
           // Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for count
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Acidraven\\Desktop\\CS430\\Nfficiency_Plagiarism_Checker\\Junk\\backend\\backend", "/")]
        [UrlToTest("http://localhost:3088/blank.aspx")]
        public void countTest()
        {
            int x = 0;
            string c;
            LinkedList<string> input = new LinkedList<string>();
            c = "this is a test";
            x = c.Split(' ').Length;
            input.AddFirst(c);
            c = "this is a test";
            x += c.Split(' ').Length;
            input.AddFirst(c);
            c = "this is a test";
            x += c.Split(' ').Length;
            input.AddFirst(c);
            int expected = 12; // TODO: Initialize to an appropriate value
            int actual;
            actual = wc.count(input);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
