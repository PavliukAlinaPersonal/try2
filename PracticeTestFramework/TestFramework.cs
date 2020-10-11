using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using PracticeTestFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTestFramework
{//first
    public class TestFramework
    {
        public IWebDriver Driver { get; set; }
        public IJavaScriptExecutor JSExecutor
        {
            get
            {
                return (IJavaScriptExecutor)Driver;
            }
            set { }
        }
        public FunctionsTests FuncTests { get; set; }

        public TestFramework()
        {
            Driver = CreateDriver();
            FuncTests = new FunctionsTests(this);
        }

        public TestFramework(IWebDriver driver)
        {
            Driver = driver;
            FuncTests = new FunctionsTests(this);
        }

        /// <summary>
        /// Create full window chrome driver
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--autoplay-policy=no-user-gesture-required");
            return new ChromeDriver(options);
        }


    }
}
