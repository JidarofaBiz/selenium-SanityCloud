using NUnit.Framework;
using SanityCloud.Contracts;
using SanityCloud.Pages;
using SanityCloud.PagesObjects;
using SanityCloud.Selenium.OpenBrowser;
using SanityCloud.Selenium.Selector;
using SanityCloud.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SanityCloud
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            //Cconf.Serialize();
            Cconf.Deserialize();
        }

        [TestCase(TestName = "CRCT-001 - Login to Run Cloud", Category = "Run Cloud, Login Cloud Platforms")]
        public void LoginRunCloud()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCT-002 - Select personal suscription ", Category = "Run Cloud")]
        public void SelectSuscriptionRun()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCT-003 - Create new project into personal suscription", Category = "Run Cloud")]
        public void CreateProject()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.CreateProject();
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCT-004 - Create a new environment into personal suscription", Category = "Run Cloud")]
        public void CreateEnvironmentComplete()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.CreateEnviroments(CrunCloud.SearchProject(Cconf.Instance.projectName));
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCT-005 - Load bex into trial environment", Category = "Run Cloud")]
        public void LoadBex()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "loadbex");
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCT-006 -  Execute Engine trial environment", Category = "Run Cloud")]
        public void Execute()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "run");
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCT-007 -  Reset trial environment", Category = "Run Cloud")]
        public void ResetEnvironment()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "reset");
            CrunCloud.LogoutRun();
        }



        [TestCase(TestName = "CRCT-008 -  View activity monitor trial environment", Category = "Run Cloud")]
        public void Monitor()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "monitor");
            CrunCloud.LogoutRun();
        }
        [TestCase(TestName = "CRCT-009 - Delete trial environment", Category = "Run Cloud")]
        public void DeleteEnvironment()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "delete");
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCT-010 - Delete Project", Category = "Run Cloud")]
        public void DeleteProject()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.deleteProject(CrunCloud.SearchProject(Cconf.Instance.projectName));
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "CRCST-001 - Sanity Run Cloud Trial E2E", Category = "Run Cloud Sanity")]
        public void SanityRunCloudTrial()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlRunCloud);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Run");
            CrunCloud.SelectSuscription(Cconf.Instance.SuscriptionName);
            CrunCloud.CreateProject();
            CrunCloud.CreateEnviroments(CrunCloud.SearchProject(Cconf.Instance.projectName));
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "loadbex");
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "run");
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "reset");
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "monitor");
            CrunCloud.EnvironmentAction(CrunCloud.SearchProject(Cconf.Instance.projectName), CrunCloud.SearchEnviroment(CrunCloud.SearchProject(Cconf.Instance.projectName), Cconf.Instance.ListEnviroments[0, 1]), "delete");
            CrunCloud.deleteProject(CrunCloud.SearchProject(Cconf.Instance.projectName));
            CrunCloud.LogoutRun();
        }

        [TestCase(TestName = "COP-001 - Login to Operation Portal", Category = "Operations Portal, Login Cloud Platforms")]
        public void LoginOperationsPortal()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlOperationsPortal);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Operations");
            CoperationsPortal.LogoutOperations();
        }

        [TestCase(TestName = "CBI-001 - Login to Business Insights", Category = "Business Insights, Login Cloud Platforms")]
        public void LoginBusinessInsigths()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlBusinessInsigths);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Business");
            CbusinessInsigths.LogoutBusiness();
        }

        [TestCase(TestName = "CAI-001 - Login to Artificial Intelligence", Category = "Artificial Intelligence, Login Cloud Platforms")]
        public void LoginArtificialIntelligence()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlArtificialIntelligence);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Artificial");
            CartificialIntelligence.LogoutArtificial();
        }

        [TestCase(TestName = "CEP-001 - Login to Enterprise Portal", Category = "Enterprise Portal, Login Cloud Platforms")]
        public void LoginEnterprisePortal()
        {
            CopenBrowser.OpenBrowser(Cconf.Instance.browserTest, Cconf.Instance.urlEnterprisePortal);
            Caccounts.LoginAccounts(Cconf.Instance.userEmail, Cconf.Instance.userpass, "Enterprise");
            CenterprisePortal.LogoutEnterprise();
        }

        [TearDown]
        public void TearD()
        {
            CopenBrowser.driver.Quit();
        }

    }
}
