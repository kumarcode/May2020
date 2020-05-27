using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TurnupNunitMay20
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void BeforeEachTest()
        {
            // open a browser
            driver = new ChromeDriver();

            //Creating instance of Login Page
            var loginPage = new Login(driver);
            loginPage.LoginSuccess();
        }

        [TearDown]
        public void AfterEachTest()
        {
            driver.Quit();
        }

        [Test]
        [TestCaseSource(typeof(TestDataClass), "TestCases")]
        public void CreateAndValidate(string code, string testDesc)
        {
            // Creating an instance of home page
            var homePage = new Home(driver);
            homePage.clickAdminstration();
            homePage.clickTimenMaterials();


            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.clickCreateNew();
            timeMaterial.CreateNewRecord(code, "testDescription");
            //timeMaterial.EditNewRecord();
            //timeMaterial.DeleteNewRecord();
            timeMaterial.ValidateRecord(code);      

        }

        [Test]
        public void EditnValidate()
        {
            // Creating an instance of home page
            var homePage = new Home(driver);
            homePage.clickAdminstration();
            homePage.clickTimenMaterials();

            TimeMaterial timeMaterial = new TimeMaterial(driver);       
            timeMaterial.EditNewRecord();
            timeMaterial.ValidateRecord("edit");

        }
    }
}