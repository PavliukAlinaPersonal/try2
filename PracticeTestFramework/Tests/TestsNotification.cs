using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PracticeTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTestFramework.Tests
{
    [TestFixture]
    class TestsNotification
    {
        TestFramework TFrame;

        public void Setup(string browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    IWebDriver DriverChrome = new ChromeDriver();
                    TFrame = new TestFramework(DriverChrome);
                    break;
                case "firefox":
                    IWebDriver DriverFirefox = new FirefoxDriver();
                    TFrame = new TestFramework(DriverFirefox);
                    break;
                default:
                    TFrame = new TestFramework();
                    break;
            }

        }

        [TearDown]
        public void AfterMethod()
        {
            TFrame.Driver.Close();
            TFrame.Driver.Quit();
        }

        [Test]
        [TestCaseSource(typeof(FunctionsTests), "BrowserToRunWith")]
        public void Test_alert(string browserName)
        {
            Setup(browserName);

            TFrame.Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");

            var expectedAlertText = "I am a JS Alert";

            By selectorAlertButton = By.XPath("//button[.='Click for JS Alert']");
            IWebElement elementAlertButton = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorAlertButton, 30);
            elementAlertButton.Click();

            var elementAlertWindow = TFrame.Driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertText, elementAlertWindow.Text);

            elementAlertWindow.Accept();
        }
    }


}
