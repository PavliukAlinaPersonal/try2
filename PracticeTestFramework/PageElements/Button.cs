using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticeTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTestFramework.PageElements
{
    public class Button : BaseElement
    {
        public Button(TestFramework TFrame, By Selector, int WaitTimeSeconds)
        {
            this.TFrame = TFrame;
            this.Selector = Selector;
            this.WaitTimeSeconds = WaitTimeSeconds;

            Element = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver,Selector, WaitTimeSeconds);

        }

        /// <summary>
        /// Click on button
        /// </summary>
        public void Click()
        {
            Element.Click();
        }

    }

}
