using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TurnupNunitMay20
{
    internal class TimeMaterial
    {
        private IWebDriver driver;

        public TimeMaterial(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void clickCreateNew()
        {
            try
            {
                //CreateNew button and then click//
                IWebElement createNew = driver.FindElement(By.XPath("//a[@href='/TimeMaterial/Create']"));
                createNew.Click();
            }
            catch (Exception message)
            {
                Console.WriteLine(message.ToString());
                Assert.Fail();
            }
            
        }

        internal void CreateNewRecord(string code, string description)
        {
            NewRecord(code);

        }

        internal void EditNewRecord()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[5]/a[1]")).Click();
            NewRecord("1234");
        }

        internal void DeleteNewRecord()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[2]/td[5]/a[2]")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

        }

        private void NewRecord(string code)
        {
            //Find Code button
            IWebElement Code = driver.FindElement(By.Id("Code"));
            Code.SendKeys(code);
            //Find description button and entering value//
            IWebElement description = driver.FindElement(By.XPath("//input[contains(@id,'Description')]"));
            description.SendKeys("Purple");
            //Finding pricePerUnit and entering value//
            //Thread.Sleep(500);
            //IWebElement pricePerUnit = driver.FindElement(By.XPath("//input[contains(@class,'k-formatted-value k-input')]"));
            //Thread.Sleep(500);

            //for (var i = 0; i < 10; i++)
            //{
            //    Thread.Sleep(500);
            //    pricePerUnit.SendKeys(Keys.Backspace);
            //}
            //pricePerUnit.SendKeys("3000");
            //finding  save button and then click
            IWebElement saveButton = driver.FindElement(By.XPath("//input[contains(@id,'SaveButton')]"));
            saveButton.Click();
        }

        internal void ValidateRecord(string expectedCode)
        {
            // Wait for 1 second
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();
            try
            {
                while (true)
                {
                    // what;t the count
                    for (var i = 1; i <= 10; i++)
                    {
                        var code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        Console.WriteLine(code.Text);

                        var testDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[3]")).Text;

                        Assert.That(code.Text, Is.EqualTo(expectedCode));
                        Assert.That(testDescription, Is.EqualTo("Purple"));
                        //// logic to compare the one we wanted
                        //if (code.Text == expectedCode && testDescription == "Purple")
                        //{
                        //    Console.WriteLine("Test Passed");
                        //    return;
                        //}
                    }
                    //click next page
                    driver.FindElement(By.XPath("//span[contains(.,'Go to the next page')]")).Click();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");
            }


        }
    }
}