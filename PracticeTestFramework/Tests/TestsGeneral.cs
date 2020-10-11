using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PracticeTestFramework.Helpers;
using PracticeTestFramework.Pages;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace PracticeTestFramework.Tests
{
    class TestsGeneral
    {
        TestFramework TFrame;

        [SetUp]
        public void Setup()
        {
            TFrame = new TestFramework();
        }

        [TearDown]
        public void AfterMethod()
        {
            TFrame.Driver.Close();
            TFrame.Driver.Quit();
        }

        [Test]
        [Category("First")]//open cmd and type: dotnet test "C:\source\repos\PracticeTestFramework\PracticeTestFramework\bin\Debug\netcoreapp3.1\PracticeTestFramework.dll" --filter "Category = First"
        public void Test1()
        {
            TFrame.Driver.Navigate().GoToUrl("http://lurkmore.to/DotA");

            By selector = By.XPath("//body[contains(@class,'page-DotA')]//div[@id='mw-content-text']" +
                "//div[contains(@class,'thumbinner morphcontainer') and descendant::a[contains(text(),'Свободно поиграть')]]");
            IWebElement element = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selector, 30);

            string fileName = "screen8";

            TFrame.FuncTests.ScrollToElement(element);

            TFrame.FuncTests.MakeScreenshot(fileName);

        }

        [Test]
        [Category("First")]
        public void Test2()
        {
            TFrame.Driver.Navigate().GoToUrl("https://gotovim-doma.ru");

            PageEnter enterPage = new PageEnter(TFrame);
            enterPage.Enter.Click();

            PageLogin loginPage = new PageLogin(TFrame);
            loginPage.Username.SendKeys("alikaalinka");
            loginPage.Password.SendKeys("18931212");

            ((IWebElement)(loginPage.Password.Element)).Submit();

            By selectorUsername = By.XPath("//header//div[contains(@class,'head')]//div[contains(@class,'head-autorize')]//a[contains(text(),'alikaalinka')]");
            IWebElement elementUsername = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorUsername, 30);

            Assert.IsTrue(elementUsername.Displayed);
        }




        [Test, TestCaseSource(typeof(FunctionsTests), "GetIMTDataFromCSV")]
        public void TestDataFromCSV(double num1, double num2, double num3)
        {
            TFrame.Driver.Navigate().GoToUrl("https://calcus.ru/calculator-imt");

            By selectorInputHeight = By.XPath("//input[@name ='height']");
            IWebElement elementInputHeight = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorInputHeight, 30);

            By selectorInputWeight = By.XPath("//input[@name ='weight']");
            IWebElement elementInputWeight = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorInputWeight, 30);

            elementInputHeight.SendKeys(Convert.ToString(num1));
            elementInputWeight.SendKeys(Convert.ToString(num2));

            elementInputWeight.Submit();

            By selectorIMT = By.XPath("//div[contains(@class,'calc-result-value')]");
            IWebElement elementIMT = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorIMT, 30);

            WebDriverWait wait = new WebDriverWait(TFrame.Driver, TimeSpan.FromSeconds(10));

            double numberIMT = 0;
            wait.Until((x) =>
            {
                return double.TryParse(elementIMT.Text, out numberIMT);
            });

            Assert.AreEqual(num3, numberIMT);
        }


        [Test]
        public void Test6()
        {
            TFrame.Driver.Navigate().GoToUrl("https://www.ilovepdf.com/ru/word_to_pdf");

            By selectorInputFile = By.XPath("//input[@type='file']");
            IWebElement elementInputFile = FunctionsTests.WaitElementIsExist(TFrame.Driver, selectorInputFile, 30);

            elementInputFile.SendKeys(@"C:\source\repos\fdf.docx");

            By selectorOutputFileName = By.XPath("//span[@class='file__info__name']");
            IWebElement elementOutputFileName = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorOutputFileName, 30);

            Assert.AreEqual(elementOutputFileName.Text, "fdf.docx");

        }

        [Test]
        public void Test7()
        {
            TFrame.Driver.Navigate().GoToUrl("https://kleki.com");

            By selectorCanvas = By.XPath("//canvas[contains(@style,'user-select')]");
            IWebElement elementCanvas = FunctionsTests.WaitElementIsExistVisible(TFrame.Driver, selectorCanvas, 30);

            var sizeCanvas = elementCanvas.Size;

            new Actions(TFrame.Driver).MoveToElement(elementCanvas, 2, 2).ClickAndHold()
                .MoveByOffset(sizeCanvas.Width / 2, sizeCanvas.Height / 2).Release().Perform();

            Screenshot screenshot = ((ITakesScreenshot)TFrame.Driver).GetScreenshot();
            screenshot.SaveAsFile(@"sqreenshotCanvasNew.png", OpenQA.Selenium.ScreenshotImageFormat.Png);

            Assert.IsTrue(FunctionsTests.CompareFilesByHash(@"resources\sqreenshotCanvas.png","sqreenshotCanvasNew.png"));
        }

        [Test]
        public void Test8()
        {
            TFrame.Driver.Navigate().GoToUrl("https://www.smplayer.info");

            By selectorIFrameBox = By.XPath("/html/body/div[4]/div[5]/div[2]/p");
            IWebElement elementIFrameBox = FunctionsTests.WaitElementIsExist(TFrame.Driver, selectorIFrameBox, 60);

            string js = string.Format("window.scroll(0, {0});", elementIFrameBox.Location.Y);
            ((IJavaScriptExecutor)(TFrame.Driver)).ExecuteScript(js);

            By selectorIFrame = By.XPath("//iframe[@width='560']");
            IWebElement elementIFrame = FunctionsTests.WaitElementIsExist(TFrame.Driver, selectorIFrame, 60);
            TFrame.Driver.SwitchTo().Frame(elementIFrame);

            By selectorVideo = By.XPath("//video[@class='video-stream html5-main-video']");
            IWebElement elementVideo = FunctionsTests.WaitElementIsExist(TFrame.Driver, selectorVideo, 60);

            ((IJavaScriptExecutor)(TFrame.Driver)).ExecuteScript("arguments[0].click();", elementVideo);
            Thread.Sleep(10000);

        }

    }
}
