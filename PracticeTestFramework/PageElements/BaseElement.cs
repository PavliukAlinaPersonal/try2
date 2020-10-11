using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTestFramework.PageElements
{
    public class BaseElement
    {
        protected TestFramework TFrame;
        public IWebElement Element { get; set; }
        public By Selector { get; set; }
        protected int WaitTimeSeconds { get; set; }

        public BaseElement(TestFramework TFrame)
        {
            this.TFrame = TFrame;
        }

        public BaseElement() { }
    }
}
