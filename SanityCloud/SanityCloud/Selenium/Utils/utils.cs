using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SanityCloud.PagesObjects;
using System.IO;
using SanityCloud.Contracts;
using SanityCloud.Selenium.Selector;
using SanityCloud.Settings;
using SanityCloud.Selenium.OpenBrowser;
using SanityCloud.Pages;
using NUnit.Framework;

namespace SanityCloud
{
    class utils
    {
        public static object Utils { get; private set; }
        public static IWebDriver driver { get; set; }
        public static string MessageError { get; private set; }

        //Wait for element 
        public static IWebElement WaitTimeForElement(string element, int Time, string elementType)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.WaitTimeForElement(element, Time);
        }

        //Wait for element with two variables
        public static void WaitTimeForElementVar(string element, int Time, string elementType, string var)
        {

            ISelector selector = new SelectorFactory().GetInstance(elementType);
            selector.WaitTimeForElementVar(element, Time, var);
        }

        //Wait for element with two options
        public static void WaitTimeForTwoOptions(string elementType, string element, int Time, string var, string element2, string var2)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            selector.WaitTimeForTwoOptions(element, Time, var, element2, var2);
        }

        //Enter text into a textbox
        public static void EnterText(string element, string value, string elementType)
        {
            ISelector selectors = new SelectorFactory().GetInstance(elementType);
            selectors.EnterText(element, value);
        }

        public static void EnterTextWithTwoElements(string element, string element2, string element3, string elementType, string var, string var2, string value)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            selector.EnterTextWithTwoElements(element, element2, element3, var, var2, value);
        }

        //Click into a element
        public static void Click(string element, string elementType)
        {
            ISelector selectors = new SelectorFactory().GetInstance(elementType);
            selectors.Click(element);
        }

        // Clic element by Javascript
        public static void ClickCheck(string element, string elementType)
        {
            ISelector selectors = new SelectorFactory().GetInstance(elementType);
            selectors.ClicCheck(element);
        }

        //Click into element with one variable
        public static void ClickOneVariable(string element, string elementType, string var)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            selector.ClickOneVariable(element, var);
        }

        //Click into element with two elements and one variable
        public static void ClickTwoElements(string element, string element2, string elementType, string var)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            selector.ClickTwoElements(element, element2, var);
        }

        //Click into element with three elements and two variable
        public static void ClickTwoElements(string element, string element2, string element3, string elementType, string var, string var2)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            selector.ClickTwoElements(element, element2, element3, var, var2);
        }

        //Count Items 
        public static int CountItems(string element, string elementType)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.CountItems(element);
        }

        //Count Items with two elements and one variable
        public static int CountItemsTwoElementsOneVariable(string element, string element2, string elementType, string var)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.CountItemsTwoElementsOneVariable(element, element2, var);
        }

        //return a user message 
        public static string GetMessages(string element, string elementType, string attribute)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.GetMessages(element, attribute);
        }

        //return a user message method with one variable
        public static string GetMessagesVariable(string element, string elementType, string attribute, string var)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.GetMessagesVariable(element, attribute, var);
        }


        //return a user message method with two elements and one variable
        public static string GetMessagesTwoElements(string element, string elementTwo, string elementType, string attribute, string var)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.GetMessagesTwoElements(element, elementTwo, attribute, var);
        }

        //return a user message method with three elements and two variables
        public static string GetMessagesTwoVariables(string element, string elementTwo, string elementThree, string elementType, string attribute, string var, string var2)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.GetMessagesTwoVariables(element, elementTwo, elementThree, attribute, var, var2);
        }

        //Try to find a element in webApp, return true/false
        public static bool DisplayedElement(string element, string elementType)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.DisplayedElement(element);
        }

        //Try to find a element is Enabled in webApp, return true/false
        public static bool IsEnabled(string element, string elementType)
        {
            ISelector selector = new SelectorFactory().GetInstance(elementType);
            return selector.IsEnabled(element);
        }

        public static void writeLog(string Descr, string var)
        {
            try
            {
                Clog Clog = new Clog();
                string temp = (var != null) ? string.Format(Descr, var) : Descr;
                Cconf.log = Clog.InitalizeLogFile();
                Cconf.log.WriteLine(temp);
                Console.WriteLine(temp);
                Cconf.log.Close();
            }
            catch (Exception ErrorM)
            {
                Clog Clog = new Clog();
                Cconf.log = Clog.InitalizeLogFile();
                Console.WriteLine(ErrorM.Message);
                Cconf.log.WriteLine(ErrorM.Message);
                Cconf.log.Close();
            }
        }

        //Method Assert text
        public static void assertElementText(string scnearioDesc, string ExpectedMessage, string ActualMessage)
        {
            try
            {
                Assert.AreEqual(ExpectedMessage, ActualMessage);//Assert

                writeLog("\n\nScenario: {0}", scnearioDesc);
                writeLog("Assert OK: {0}", ActualMessage);
                writeLog("Data Time Execution: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            }
            catch (Exception ErrorM)
            {
                writeLog("\n\n------------ Assert Fail ------------ ", null);
                writeLog("Scenario: {0}", scnearioDesc);
                writeLog("Exception Name: {0}", ErrorM.Message);
                writeLog("--------------------------------------", null);
            }
        }


        public static void assertElementImage(string scnearioDesc, string element, string elementType, string text)
        {
                ISelector selector = new SelectorFactory().GetInstance(elementType);
                selector.assertElementImage(scnearioDesc, element, text);
        }
    }
}
