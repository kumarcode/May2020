using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TurnupNunitMay20.HookUp
{
    [Binding]
    public class TimeAndMaterialSteps
    {
        IWebDriver driver;

        [Given(@"I have logged in to the Turnup portal successfully")]
        public void GivenIHaveLoggedInToTheTurnupPortalSuccessfully()
        {
            // open a browser
            driver = new ChromeDriver();

            //Creating instance of Login Page
            var loginPage = new Login(driver);
            loginPage.LoginSuccess();
        }
        
        [Given(@"I create a time and material")]
        public void GivenICreateATimeAndMaterial()
        {
            // Creating an instance of home page
            var homePage = new Home(driver);
            homePage.clickAdminstration();
            homePage.clickTimenMaterials();


            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.clickCreateNew();
            timeMaterial.CreateNewRecord("test", "testDescription");
            //timeMaterial.EditNewRecord();
            //timeMaterial.DeleteNewRecord();
            timeMaterial.ValidateRecord("test");
        }
        
        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            driver.Quit();
        }

        [Given(@"I edit an existing time and material record")]
        public void GivenIEditAnExistingTimeAndMaterialRecord()
        {
            // Creating an instance of home page
            var homePage = new Home(driver);
            homePage.clickAdminstration();
            homePage.clickTimenMaterials();

            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.EditNewRecord();
        }

        [Then(@"the record should be edited successfully")]
        public void ThenTheRecordShouldBeEditedSuccessfully()
        {
            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.ValidateRecord("edit");
            driver.Quit();
        }

        [Given(@"I create a time and material with below (.*)")]
        public void GivenICreateATimeAndMaterialWithBelow(string p0, string p1)
        {
            // Creating an instance of home page
            var homePage = new Home(driver);
            homePage.clickAdminstration();
            homePage.clickTimenMaterials();


            TimeMaterial timeMaterial = new TimeMaterial(driver);
            timeMaterial.clickCreateNew();
            timeMaterial.CreateNewRecord(p0, p1);
            //timeMaterial.EditNewRecord();
            //timeMaterial.DeleteNewRecord();
            timeMaterial.ValidateRecord(p0);
        }



    }
}
