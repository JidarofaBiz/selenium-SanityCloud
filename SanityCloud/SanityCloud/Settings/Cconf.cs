using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SanityCloud.Contracts;
using SanityCloud.Selenium.Selector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.Settings
{
    class Cconf
    {
        //Variables Run Cloud
        public string urlRunCloud {get; set;}
        public string urlOperationsPortal { get; set; }
        public string urlBusinessInsigths { get; set; }
        public string urlArtificialIntelligence { get; set; }
        public string urlEnterprisePortal { get; set; }
        public string browserTest {get; set;}
        public string userEmail {get; set;}
        public string userpass {get; set;}
        public string SuscriptionName {get; set;}
        public string projectName {get; set;}
        public string projectSumary {get; set;}
        public string[,] ListEnviroments {get; set;}
        public string[,] ListEnviromentsLoadBex {get; set;}
        public string[,] ListValuesCase {get; set;}

        //Variables development
        public string[] elemenType {get; set;}
        public string[] listBrowserTest {get; set;}
        public string[] pathLog {get; set;}
        public string waitVar {get; set;}
        public int CounItem {get; set;}
        public int userTimeWait {get; set;}

        //Variables asserts
        public string scenaryAccounts { get; set; }
        public string copyBizagiCommunityAccounts { get; set; }
        public string scenaryLogoRun { get; set; }
        public string copyLogoHomePageRun { get; set; }
        public string scenaryWelcomeToBizagi { get; set; }
        public string copyWelcomeToHomePage { get; set; }
        public string scenaryGiveUsFeedback { get; set; }
        public string copyGiveUsToFeedback { get; set; }
        public string scenarySelectTheSuscription { get; set; }
        public string copySelecttheSuscription { get; set; }
        public string scenarySuscriptionName { get; set; }
        public string scenaryIntoSuscriptionName { get; set; }
        public string scenaryProjectName { get; set; }
        public string scenaryLogout { get; set; }
        public string scenaryLogoEngine { get; set; }
        public string copyLogoEngine { get; set; }


        public static StreamWriter log {get; set;}
        public static ISelector selector { get; set; }
        public static Cconf Instance {get; private set;}

    // Serialize json with newtonsoft, save document on IDE C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\docs
    public static void Serialize() {

            Cconf setvalues = new Cconf
            {
                //Variables Run Cloud
                urlRunCloud = "xxxxxxxx",
                urlOperationsPortal = "xxxxxxxx",
                urlBusinessInsigths = "xxxxxxxx",
                urlArtificialIntelligence = "xxxxxxxx",
                urlEnterprisePortal = "xxxxxxxx",
                browserTest = "xxxxx",
                userEmail = "xxxxx@xxxx.xxx",
                userpass = "xxxxxxx",
                SuscriptionName = "ABC DEF GHI",
                projectName = "xxxxxxx",
                projectSumary = "xxxxxxxx",
                ListEnviroments = new string[,] { { "xxx", "xxx", "xxx" }, { "xxx", "xxx", "xxx" } },
                ListEnviromentsLoadBex = new string[,] { { "xx", @"xxxxxx", "xxx", "xxx", "xx" } },
                ListValuesCase = new string[,] { { @"xxx", "xxx", "xxxx", "12345", "99999", @"xxxxxxxx", "99999", "xxxxx", "1234567", @"xxxxxxxxxx" } },

                //Variables development
                elemenType = new string[] { "xx", "xxx", "xxxx" },
                listBrowserTest = new string[] { "xxx", "xxx", "xxx" },
                pathLog = new string[] { "xxxxx", "xxxxx", "xxxxx" },
                waitVar = "0",
                CounItem = 0,
                userTimeWait = 0,

            };

            string outputJSON = JsonConvert.SerializeObject(setvalues);
            File.WriteAllText("docs/conf.json", outputJSON);
            Console.WriteLine(outputJSON);
        }

        //Deserialize json with newtonsoft from IDE C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\docs
        public static void Deserialize()
        {
                string outputJSON = File.ReadAllText("docs/conf.json");
                Instance = JsonConvert.DeserializeObject<Cconf>(outputJSON);
                selector = null;
        }


    }
}
