using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticeTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTestFramework.PageElements
{
    public class TextBox : BaseElement
    {

        public TextBox(TestFramework TFrame, By Selector, int WaitTimeSeconds)
        {
            this.TFrame = TFrame;
            this.Selector = Selector;
            this.WaitTimeSeconds = WaitTimeSeconds;

            Element = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver,Selector, WaitTimeSeconds);
        }

        /// <summary>
        /// Print text in text field
        /// </summary>
        /// <param name="text">Text to print</param>
        public void SendKeys(string text)
        {
            Element.SendKeys(text);
        }
    }
}
