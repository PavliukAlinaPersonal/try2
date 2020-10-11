using OpenQA.Selenium;
using PracticeTestFramework.PageElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTestFramework.Pages
{
    class PageEnter
    {
        private TestFramework TFrame;

        public Button Enter;
        private readonly By EnterSelector = By.XPath("//header//div[contains(@class,'head')]//div[contains(@class,'head-autorize')]//a[contains(text(),'Войти')]");

        public PageEnter(TestFramework TFrame)
        {
            this.TFrame = TFrame;
            Enter = new Button(TFrame, EnterSelector, 30);
        }
    }
}
