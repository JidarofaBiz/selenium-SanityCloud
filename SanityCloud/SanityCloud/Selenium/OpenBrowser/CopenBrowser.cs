using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SanityCloud.Settings;

namespace SanityCloud.Selenium.OpenBrowser
{
    class CopenBrowser
    {
        public static IWebDriver driver { get; set; }

        //Method open browser
        public static void OpenBrowser(string browser, string url)
        {
            if (browser.ToLower() == Cconf.Instance.listBrowserTest[0]) //chrome
                driver = new ChromeDriver();

            if (browser.ToLower() == Cconf.Instance.listBrowserTest[1]) //firefox
                driver = new FirefoxDriver();

            if (browser.ToLower() == Cconf.Instance.listBrowserTest[2]) //ie11
                driver = new InternetExplorerDriver();

            driver.Url = url;
            driver.Manage().Window.Maximize();          
        }
    }
}
