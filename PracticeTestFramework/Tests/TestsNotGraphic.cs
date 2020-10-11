using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PracticeTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace PracticeTestFramework.Tests
{

    [TestFixture]
    class TestsNotGraphic
    {
        TestFramework TFrame;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--headless");

            var service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); 
            service.LogPath = @"chromedriver.log";
            service.EnableVerboseLogging = true;

            IWebDriver driver = new ChromeDriver(service, options);

            TFrame = new TestFramework(driver);
        }

        [TearDown]
        public void AfterMethod()
        {
            TFrame.Driver.Close();
            TFrame.Driver.Quit();
        }

        [Test]
        public void TestOpenGid()
        {
            TFrame.Driver.Navigate().GoToUrl("https://kreisfahrer.gitbooks.io/selenium-webdriver/content/");
            Assert.AreEqual("Introduction | Selenium Webdriver", TFrame.Driver.Title);
        }
    }

}

