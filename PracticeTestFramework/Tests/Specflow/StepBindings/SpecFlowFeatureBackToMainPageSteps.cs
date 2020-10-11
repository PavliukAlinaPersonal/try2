using NUnit.Framework;
using OpenQA.Selenium;
using PracticeTestFramework.Helpers;
using System;
using TechTalk.SpecFlow;

namespace PracticeTestFramework.Tests.Specflow.StepBindings
{
    [Binding]
    class SpecFlowFeatureBackToMainPageSteps
    {
        TestFramework TFrame;
        public SpecFlowFeatureBackToMainPageSteps()
        {
            TFrame = new TestFramework();
        }

        [Given(@"open Specflow page")]
        public void GivenOpenSpecflowPage()
        {
            TFrame.Driver.Navigate().GoToUrl("https://www.softwaretestinghelp.com/specflow-and-selenium/");
            Assert.AreEqual("Specflow and Selenium Webdriver End to End Example", TFrame.Driver.Title);
        }
        
        [When(@"press home button")]
        public void WhenPressHomeButton()
        {
            By selectorButtonHome = By.XPath("//a[@title='Software Testing Home']");
            IWebElement elementButtonHome = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorButtonHome, 30);
            elementButtonHome.Click();
        }

        [Then(@"open Main page")]
        public void ThenOpenMainPage()
        {
            Assert.AreEqual("Software Testing Help - Free Software Testing & Development Courses", TFrame.Driver.Title);
        }

    }
}
