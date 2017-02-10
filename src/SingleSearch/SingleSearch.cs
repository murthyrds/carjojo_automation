using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace SingleSearch
{
    public class SingleSearch
    {
        
             public static void Main(string[] args)
        {
            PropertyCollection.driver = new ChromeDriver(@"C:\Users\murth\Documents\Visual Studio 2015\Projects\Carjojo\src\SingleSearch\Drivers");

            PropertyCollection.driver.Navigate().GoToUrl("https://devfe1.carjojo.com/carjojo");
            PropertyCollection.driver.Manage().Window.Maximize();
            PropertyCollection.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
                                    
            Thread.Sleep(5000);

            if (IsElementPresent(By.XPath(".//*[@id='page-footer']/continue-arrow-indicator/div")))
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyCollection.driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            }

           

            // can change brand as per the li's.
            PropertyCollection.driver.FindElement(By.XPath(".//*[@id='select-brand']/div[1]/div/ul/li[31]/label")).Click();


            //can change model as per the li's. 

            if (IsElementPresent(By.XPath(".//*[@id='page-footer']/continue-arrow-indicator/div")))
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyCollection.driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            }
            Thread.Sleep(5000);
            PropertyCollection.driver.FindElement(By.XPath(".//*[@id='select-model']/div[1]/div/ul/li[17]/label")).Click();

            // Just check comment.
            //Zip code pop up.
            Thread.Sleep(5000);
            //Can change miles drop down value based on 'option' index value.
            PropertyCollection.driver.FindElement(By.XPath(".//*[@id='location-check-wrapper']//select/option[3]")).Click();
            // can change zip code value
            PropertyCollection.driver.FindElement(By.XPath(".//*[@id='location-check-wrapper']//input[@type='text']")).SendKeys("95008");
            PropertyCollection.driver.FindElement(By.XPath(".//*[@id='location-check-wrapper']//button[@class='button carjojo-button continue']")).Click();

            //Can change body style options FWD & AWD based on div[1 & 2].

            if (IsElementPresent(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[1]/div[1]")))
            {

                PropertyCollection.driver.FindElement(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[1]/div[1]")).Click();
                Console.WriteLine("1st row");
                if (IsElementPresent(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[2]/div[2]")))
                {
                    //do if exists
                    PropertyCollection.driver.FindElement(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[2]/div[2]")).Click();
                    Console.WriteLine("2nd row");
                    if (IsElementPresent(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[3]/div[2]")))
                    {
                        //do if does not exists
                        PropertyCollection.driver.FindElement(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[3]/div[2]")).Click();
                        Console.WriteLine("3rd row");
                        if (IsElementPresent(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[4]/div[2]")))
                        {
                            //do if does not exists
                            PropertyCollection.driver.FindElement(By.XPath(".//*[@id='select-trim']//trims-filter/ul/li[4]/div[2]")).Click();
                            Console.WriteLine("4th row");
                        }
                        else
                        {
                            Console.WriteLine("4th row doesn't existed");

                        }

                    }
                    else
                    {
                        Console.WriteLine("3rd row doesn't existed");

                    }
                }
                else
                {
                    Console.WriteLine("2nd row doesn't existed");

                }

            }
            else
            {
                Console.WriteLine("Element not found!");
            }

            //can change model as per the trim id.

            //ExcelLib.PopulateInCollection(@"C:\TestDataAccess\TestData.xlsx");
            //String size = ExcelLib.ReadData(1, "firstname");
            //String query = ".//*[@id='trim-" + size + "']/div[1]//following::button";
            //IWebElement element1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(query)));
            //PropertyCollection.driver.FindElement(By.XPath(query)).Click();

            // Select Trim
            Thread.Sleep(5000);
            PropertyCollection.driver.FindElement(By.XPath(".//*[@id='trim-11906']/div[1]//following::button")).Click();

            Thread.Sleep(5000);
            // uncheck the all check boxes.
            //PropertyCollection.driver.FindElement(By.XPath(".//*[@id='select-colors']//label//*[text()='All Colors']")).Click();
            // Get the all colors inventory count.
            List<IWebElement> all = PropertyCollection.driver.FindElements(By.XPath(".//*[@id='color-grid']/li//p//following::span[@class='ng-isolate-scope']")).ToList();
            String[] allText = new String[all.Count];


            try
            {
                int i = 0;
                int value;
                foreach (IWebElement element in all)
                {
                    allText[i++] = element.Text;
                    Console.WriteLine(element.Text);

                    // Convert string to int value.
                    string no = element.Text;
                    value = Convert.ToInt32(no);
                    //if (IsElementPresent(By.XPath(".//*[@id='page-footer']/continue-arrow-indicator/div")))
                    //{
                    //    IJavaScriptExecutor js = (IJavaScriptExecutor)PropertyCollection.driver;
                    //    js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                    //}
                    if (value == 0)
                    {
                        String chb = ".//*[@id='color-grid']/li[" + i + "]//label";
                        IWebElement chkbox1 = PropertyCollection.driver.FindElement(By.XPath(chb));
                        chkbox1.Click();
                        Console.WriteLine("Matched!");
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(5000);
            // Page scroll
            var elem = PropertyCollection.driver.FindElement(By.CssSelector(".button.expand.carjojo-button.continue"));
            ((IJavaScriptExecutor)PropertyCollection.driver).ExecuteScript("arguments[0].scrollIntoView(true);", elem);

            // Choose the car color:
           
            PropertyCollection.driver.FindElement(By.CssSelector(".button.expand.carjojo-button.continue")).Click();
        }
        private static bool IsElementPresent(By by)
        {
            try
            {
                PropertyCollection.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
  }

