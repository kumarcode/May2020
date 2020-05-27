using System;
using OpenQA.Selenium;
using TurnupNunitMay20.Helpers;

namespace TurnupNunitMay20
{
    internal class Login
    {
        private IWebDriver driver;

        IWebElement UserName => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Name("Password"));
        IWebElement LoginBtn => driver.FindElement(By.XPath("//input[@type='submit']"));

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void LoginSuccess()
        {
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            WaitHelper.ForElement(By.Id("UserName"),driver,TimeSpan.FromSeconds(10));

            // enter hari as username
            UserName.SendKeys("hari");
            //identfying password & sending password
            Password.SendKeys("123123");
            //clicked login btn
            LoginBtn.Click();
        }

        public void LoginFailure()
        {
            //Identify username
            // enter hari as username
            UserName.SendKeys("hari");

            //identfying password & sending password
            Password.SendKeys("123123");
        }
    }
}
