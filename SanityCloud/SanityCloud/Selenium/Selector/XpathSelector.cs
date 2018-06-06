using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanityCloud.Contracts;
using System.IO;
using OpenQA.Selenium.Support.UI;
using SanityCloud.PagesObjects;
using System.Threading;
using SanityCloud.Settings;
using SanityCloud.Selenium.OpenBrowser;
using SanityCloud.Pages;
using NUnit.Framework;

namespace SanityCloud.Selenium.Selector
{
    internal class XpathSelector : ISelector
    {
        
        public static WebDriverWait wait;
        public static object Utils { get; private set; }
        public static string MessageError { get; private set; }
        public static StreamWriter log { get; set; }

        public IWebElement Select(string element)
        {
            return CopenBrowser.driver.FindElement(By.XPath(element));
        }

        public IWebElement WaitTimeForElement(string element, int Time)
        {
            return WaitTimeForElementVar(element, Time, null);
        }

        public IWebElement WaitTimeForElementVar(string element, int Time, string var)
        {
            try
            {
                string temp = (var != null) ? string.Format(element, var) : element;

                By ByTemp = null;

                ByTemp = By.XPath(temp);

                return new WebDriverWait(CopenBrowser.driver, TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.ElementIsVisible(ByTemp));
              
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element -----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                log.Close();
                return new WebDriverWait(CopenBrowser.driver, TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.ElementIsVisible(By.XPath("")));
            }
        }

        public IWebElement WaitTimeForTwoOptions(string element, int Time, string var, string element2, string var2)
        {
            try
            {
                string temp = (var != null) ? string.Format(element, var) : element;
                string temp2 = (var != null) ? string.Format(element2, var2) : element2;

                By ByTemp = null;

                ByTemp = By.CssSelector(temp + "," + temp2);

                return new WebDriverWait(CopenBrowser.driver, TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.ElementIsVisible(ByTemp));

            }

            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found elment -----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return new WebDriverWait(CopenBrowser.driver, TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("")));
            }
        }

        public void EnterText(string element, string value)
        {
            try
            {
                CopenBrowser.driver.FindElement(By.XPath(element)).Clear();
                CopenBrowser.driver.FindElement(By.XPath(element)).SendKeys(value); 
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element text -----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Enter text with two elements for IE11
        public void EnterTextWithTwoElements(string element, string element2, string element3, string var, string var2, string value)
        {
            try
            {
                CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(string.Format(element2, var2))).FindElement(By.XPath(element3)).SendKeys(value);
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element text -----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Click into a element
        public void Click(string element)
        {
            try
            {
                if (Cconf.Instance.browserTest == "ie11")
                {
                    Thread.Sleep(500);//wait for set ariable
                    IWebElement ClickCheck = CopenBrowser.driver.FindElement(By.XPath(element));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)CopenBrowser.driver;
                    executor.ExecuteScript("arguments[0].click();", ClickCheck);
                }
                else {
                    CopenBrowser.driver.FindElement(By.XPath(element)).Click();
                }
                
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to click -----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        // Clic element by Javascript
        public void ClicCheck(string element)
        {
            try
            {
                IWebElement ClickCheck = CopenBrowser.driver.FindElement(By.XPath(element));
                IJavaScriptExecutor executor = (IJavaScriptExecutor)CopenBrowser.driver;
                executor.ExecuteScript("arguments[0].click();", ClickCheck);
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to click-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Click into element with one variable
        public void ClickOneVariable(string element, string var)
        {
            try
            {
                Thread.Sleep(500); //Wait fot set variable
                CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).Click();             
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to click-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
            }

        }

        //Click into element with two elements and one variable
        public void ClickTwoElements(string element, string element2, string var)
        {
            try
            {
                CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(element2)).Click();
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to click-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Click into element with three elements and two variable
        public void ClickTwoElements(string element, string element2, string element3, string elementType, string var, string var2)
        {
            try
            {
                CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(string.Format(element2, var2))).FindElement(By.XPath(element3)).Click();
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to click-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Count Items 
        public int CountItems(string element, string elementType)
        {
            try
            {
                Cconf.Instance.CounItem = CopenBrowser.driver.FindElements(By.XPath(element)).Count;
                return Cconf.Instance.CounItem;
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to count-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return Cconf.Instance.CounItem = -1;
            }
        }

        //Count Items with two elements and one variable
        public int CountItemsTwoElementsOneVariable(string element, string element2, string elementType, string var)
        {
            try
            {
                Cconf.Instance.CounItem = CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElements(By.XPath(element2)).Count;
                return Cconf.Instance.CounItem;
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to count-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return Cconf.Instance.CounItem = -1;
            }
        }

        //return a user message method with one variable
        public string GetMessagesVariable(string element, string attribute, string var)
        {
            try
            {
                if (attribute == null)
                    return CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).Text;
                else
                    return CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).GetAttribute(attribute);
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to Getmessages-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return String.Empty;
            }
        }

        //Count Items 
        public int CountItems(string element)
        {
            try
            {
                Cconf.Instance.CounItem = CopenBrowser.driver.FindElements(By.XPath(element)).Count;
                return Cconf.Instance.CounItem;
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to count-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return Cconf.Instance.CounItem = -1;
            }

        }

        //return a user message method with two elements and one variable
        public string GetMessagesTwoElements(string element, string elementTwo, string attribute, string var)
        {
            try
            {
                if (attribute == null)
                    return CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(elementTwo)).Text;
                else
                    return CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(elementTwo)).GetAttribute(attribute);
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to Getmessages-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return String.Empty;
            }
        }

        //Click into element with three elements and two variable
        public void ClickTwoElements(string element, string element2, string element3, string var, string var2)
        {
            try
            {
                CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(string.Format(element2, var2))).FindElement(By.XPath(element3)).Click();
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to Getmessages-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);               
            }
        }

        //return a user message method with three elements and two variables
        public string GetMessagesTwoVariables(string element, string elementTwo, string elementThree, string attribute, string var, string var2)
        {
            try
            {
                if (attribute == null)
                    return CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(string.Format(elementTwo, var2))).FindElement(By.XPath(elementThree)).Text;
                else
                    return CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElement(By.XPath(string.Format(elementTwo, var2))).FindElement(By.XPath(elementThree)).GetAttribute(attribute);
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to Getmessages-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return String.Empty;
            }
        }

        //Count Items with two elements and one variable
        public int CountItemsTwoElementsOneVariable(string element, string element2, string var)
        {
            try
            {
                Cconf.Instance.CounItem = CopenBrowser.driver.FindElement(By.XPath(string.Format(element, var))).FindElements(By.XPath(element2)).Count;
                return Cconf.Instance.CounItem;
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to count-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return Cconf.Instance.CounItem = -1;
            }
        }

        //return a user message 
        public string GetMessages(string element, string attribute)
        {
            try
            {
                if (attribute == null)
                    return CopenBrowser.driver.FindElement(By.XPath(element)).Text;
                else
                    return CopenBrowser.driver.FindElement(By.XPath(element)).GetAttribute(attribute);
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to Getmessages-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return String.Empty;
            }
        }

        //Try to find a element in webApp, return true/false
        public bool DisplayedElement(string element)
        {
            try
            {
                return CopenBrowser.driver.FindElement(By.XPath(element)).Displayed;
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element to Getmessages-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return false;
            }
        }

        //Try to find a element is Enabled in webApp, return true/false
        public bool IsEnabled(string element)
        {
            try
            {
                return CopenBrowser.driver.FindElement(By.XPath(element)).Enabled;
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n----- Not found element enbled-----\n", null);
                utils.writeLog("{0}", ErrorM.Message);
                return true;
            }
        }

        //assert image
        public void assertElementImage(string scnearioDesc, string element, string text)
        {
            try
            {

                Assert.IsTrue(CopenBrowser.driver.FindElement(By.CssSelector(element)).Displayed);

                utils.writeLog("\n\nScenario: {0}", scnearioDesc);
                utils.writeLog("Assert OK: {0}", text);
                utils.writeLog("Data Time Execution: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            }
            catch (Exception ErrorM)
            {
                utils.writeLog("\n\n------------ Assert Fail ------------ ", null);
                utils.writeLog("Scenario: {0}", scnearioDesc);
                utils.writeLog("Exception Name: {0}", ErrorM.Message);
                utils.writeLog("--------------------------------------", null);
            }
        }
    }
}
