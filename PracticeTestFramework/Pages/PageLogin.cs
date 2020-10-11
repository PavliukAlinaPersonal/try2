using OpenQA.Selenium;
using PracticeTestFramework.PageElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeTestFramework.Pages
{
    class PageLogin
    {
        private TestFramework TFrame;

        private readonly By UsernameSelector = By.XPath("//div[@id ='entrance-popup']//form[@id = 'popup-login-form']//input[@id = 'popup-loginform-username']");
        private readonly By PasswordSelector = By.XPath("//div[@id ='entrance-popup']//form[@id = 'popup-login-form']//input[@id = 'popup-loginform-password']");

        public TextBox Username;
        public TextBox Password;

        public PageLogin(TestFramework TFrame)
        {
            this.TFrame = TFrame;
            Username = new TextBox(TFrame, UsernameSelector, 30);
            Password = new TextBox(TFrame, PasswordSelector, 30);
        }

    }
}
