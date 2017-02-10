using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleSearch
{
    public class ElementFind
    {
        public object JavaScriptExecutor { get; private set; }

        public static bool IsElementDisplayed(IWebDriver driver, By element)
        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
            if (elements.Count > 0)
            {
               
                return elements.ElementAt(0).Displayed;
               
            }
            return false;
        }

        public static bool IsElementDisplayedL(IWebDriver driver, By element)
        {
            List<IWebElement> elements = driver.FindElements(element).ToList();
            if (elements.Count > 0)
            {

                return elements.ElementAt(0).Displayed;
               // elements.Click();
            }
            return false;
        }

        //public static void pageScroll()
        //{
        //    if (IsElementPresent(By.XPath(".//*[@id='page-footer']/continue-arrow-indicator/div")))
        //    {
        //        IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyCollection.driver;
        //        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        //    }
        //}

        //public void ScrollTo(int xPosition = 0, int yPosition = 0)
        //{
        //    var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
        //    JavaScriptExecutor.ExecuteScript(js);
        //}

        public static void WaitForElementLoad(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }
    }
}
