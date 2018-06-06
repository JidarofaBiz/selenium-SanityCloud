using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.Contracts
{
    internal interface ISelector
    {
        IWebElement Select(string elemenType);

        IWebElement WaitTimeForElement(string element, int Time);
        IWebElement WaitTimeForElementVar(string element, int Time, string var);
        IWebElement WaitTimeForTwoOptions(string element, int Time, string var, string element2, string var2);
        void Click(string element);
        void ClicCheck(string element);
        void EnterText(string element, string value);
        void EnterTextWithTwoElements(string element, string element2, string element3, string var, string var2, string value);
        void ClickOneVariable(string element, string var);
        void ClickTwoElements(string element, string element2, string var);
        void ClickTwoElements(string element, string element2, string element3, string var, string var2);
        int CountItemsTwoElementsOneVariable(string element, string element2, string var);
        string GetMessagesVariable(string element, string attribute, string var);
        int CountItems(string element);
        string GetMessagesTwoElements(string element, string elementTwo, string attribute, string var);
        string GetMessagesTwoVariables(string element, string elementTwo, string elementThree, string attribute, string var, string var2);
        string GetMessages(string element, string attribute);
        bool DisplayedElement(string element);
        bool IsEnabled(string element);
        void assertElementImage(string scnearioDesc, string element, string text);
    }
}
