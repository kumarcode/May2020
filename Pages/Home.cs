using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TurnupNunitMay20
{
    internal class Home
    {
        private IWebDriver driver;

        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }
        internal void clickAdminstration()
        {
            Assert.That(driver.FindElement(By.XPath("//a[@href='#'][contains(.,'Administration')]")).Text, Is.EqualTo("Administration"));
            // click admin & click time and material
            driver.FindElement(By.XPath("//a[@href='#'][contains(.,'Administration')]")).Click();
        }

        internal void clickTimenMaterials()
        {
            driver.FindElement(By.XPath("//a[@href='/TimeMaterial']")).Click();
        }
    }
}