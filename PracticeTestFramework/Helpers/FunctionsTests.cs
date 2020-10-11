using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PracticeTestFramework.Helpers
{
    public class FunctionsTests
    {
        TestFramework TFrame;
        public FunctionsTests(TestFramework TFrame) 
        {
            this.TFrame = TFrame;
        }

        /// <summary>
        /// Scroll to element
        /// </summary>
        /// <param name="element"></param>
        public void ScrollToElement(IWebElement element)
        {
            string js = string.Format("window.scroll({0},{1})", element.Location.X, element.Location.Y);
            TFrame.JSExecutor.ExecuteScript(js);
        }


        /// <summary>
        /// Make screenshot and save by path
        /// </summary>
        /// <param name="fileName"></param>
        public void MakeScreenshot(string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)TFrame.Driver).GetScreenshot();
            //todo function should take format as parameter
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }


        /// <summary>
        /// Wait until a page is fully loaded
        /// </summary>
        /// <param name="time"></param>
        public void WaitPageFullLoaded(int time)
        {
            WebDriverWait wait = new WebDriverWait(TFrame.Driver, TimeSpan.FromSeconds(time));

            wait.Until((x) =>
            {
                return TFrame.JSExecutor.ExecuteScript("return document.readyState").Equals("complete");
            });
        }


        /// <summary>
        /// Find and check visability and existence of element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="timeSeconds"></param>
        /// <returns></returns>
        public static IWebElement WaitElementIsExistVisible(IWebDriver driver, By selector, int timeSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
            return wait.Until((x) =>
                {
                    IWebElement element = driver.FindElement(selector);
                    if (element.Displayed)
                    {
                        return element;
                    }
                    return null;
                });
            
        }

        public static IWebElement WaitElementIsExist(IWebDriver driver, By selector, int timeSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
            return wait.Until((x) =>
            {
                IWebElement element = driver.FindElement(selector);
                    return element;
            });

        }
        /// <summary>
        /// Read from C:\Users\Стас\source\repos\csv.txt
        /// </summary>
        /// <returns>List which node contains three double numbers</returns>
        public static IEnumerable<double[]> GetIMTDataFromCSV()
        {
            List<double[]> dataIMT = new List<double[]>();
            CsvReader reader = new CsvReader(@"resources\csv.txt");
            while (reader.Next())
            {
                double column1 = double.Parse(reader[0]);
                double column2 = double.Parse(reader[1]);
                double column3 = double.Parse(reader[2]);
                dataIMT.Add(new double[] { column1, column2, column3 });
            }
            return dataIMT;
        }

        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = { "chrome", "firefox" };

            foreach (string b in browsers)
            {
                yield return b;
            }
        }

        public static bool CompareFilesByHash(string firstFilePath, string secondFilePath) 
        {
            byte[] firstFileByteArray = ReadAllBytes(firstFilePath);
            byte[] secondFileByteArray = ReadAllBytes(secondFilePath);

            byte[] hashFirstFile = MD5.Create().ComputeHash(firstFileByteArray);
            byte[] hashSecondFile = MD5.Create().ComputeHash(secondFileByteArray);

            return IsEqualByteArrays(hashFirstFile, hashSecondFile);
        }

        public static byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }


        public static bool IsEqualByteArrays(byte[] hashFirstFile, byte[] hashSecondFile)
        {
            bool bEqual = false;
            if (hashFirstFile.Length == hashSecondFile.Length)
            {
                int i = 0;
                while ((i < hashFirstFile.Length) && (hashFirstFile[i] == hashSecondFile[i]))
                {
                    i += 1;
                }
                if (i == hashFirstFile.Length)
                {
                    bEqual = true;
                }
            }

            return bEqual;
        }


    }
}
