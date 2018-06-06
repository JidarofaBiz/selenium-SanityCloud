using AutoItX3Lib;
using OpenQA.Selenium;
using SanityCloud.Contracts;
using SanityCloud.PagesObjects;
using SanityCloud.Selenium.OpenBrowser;
using SanityCloud.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SanityCloud.Pages
{
    class CrunCloud
    {
        public static string selectCategory { get; set; }
        public static string selectType { get; set; }

        //Logout Run Cloud
        public static void LogoutRun()
        {
            try
            {
                utils.WaitTimeForElement(PageObjectHomePage.UserProfileIcon(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]); // Css
                utils.Click(PageObjectHomePage.UserProfileIcon(), Cconf.Instance.elemenType[1]); //css
                utils.Click(PageObjectHomePage.LogoutButton(), Cconf.Instance.elemenType[1]); //css
                utils.WaitTimeForElement(PageObjectLogin.EmailText(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[0]); //id
                utils.assertElementText(Cconf.Instance.scenaryLogout, Cconf.Instance.copyBizagiCommunityAccounts, utils.GetMessages(PageObjectLogin.copyComunity(), Cconf.Instance.elemenType[1], null));
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Select suscription, only you need name of the suscription
        public static void SelectSuscription(string selectItemName)
        {
            try
            {
                utils.WaitTimeForElementVar(PageObjectHomePage.SuscriptionSelectorName(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], "1");

                utils.assertElementText(Cconf.Instance.scenaryWelcomeToBizagi, Cconf.Instance.copyWelcomeToHomePage, utils.GetMessages(PageObjectHomePage.assertWelcomeToBizagi(), Cconf.Instance.elemenType[1], null));
                utils.assertElementText(Cconf.Instance.scenarySelectTheSuscription, Cconf.Instance.copySelecttheSuscription, utils.GetMessages(PageObjectHomePage.assertSelectSuscription(), Cconf.Instance.elemenType[1], null));
                utils.assertElementText(Cconf.Instance.scenaryGiveUsFeedback, Cconf.Instance.copyGiveUsToFeedback, utils.GetMessages(PageObjectHomePage.assertGiveYourFeedback(), Cconf.Instance.elemenType[1], null));

                utils.assertElementImage(Cconf.Instance.scenaryLogoRun, PageObjectHomePage.assertLogoRun(), Cconf.Instance.elemenType[1], Cconf.Instance.copyLogoHomePageRun);

                int elementCounter = 1;
                int nElements = utils.CountItems(PageObjectHomePage.SuscriptionSelector(), Cconf.Instance.elemenType[1]); //css

                while (elementCounter <= nElements)
                {
                    string id = elementCounter.ToString();
                    id = Convert.ToString(elementCounter);
                    Thread.Sleep(500); //Wait fot set variable

                    string CopyName = utils.GetMessagesVariable(PageObjectHomePage.SuscriptionSelectorName(), Cconf.Instance.elemenType[1], null, id);
                    if (CopyName == selectItemName)
                    {
                        utils.assertElementText(Cconf.Instance.scenarySuscriptionName, Cconf.Instance.SuscriptionName, CopyName);

                        if (Cconf.Instance.browserTest == "ie11")
                        {
                            utils.ClickOneVariable(PageObjectHomePage.SuscriptionSelectorNameIE(), Cconf.Instance.elemenType[1], id);
                        }
                        else
                        {
                            utils.ClickOneVariable(PageObjectHomePage.SuscriptionSelectorNameIE(), Cconf.Instance.elemenType[1], id);
                        }
                        utils.WaitTimeForTwoOptions(Cconf.Instance.elemenType[1], PageObjectRun.iconProject(), Cconf.Instance.userTimeWait, "1", PageObjectRun.IconProjectEmpty(), null);
                        break;
                    }

                    if (elementCounter == nElements && CopyName != selectItemName)
                    {

                        utils.writeLog("\n----------------------------------Not found suscription-----------------------------", null);
                        utils.writeLog("\n--------------------------------------------------------------------------------", null);
                        utils.writeLog("----There aren't suscription with this name, please check your settings.----", null);
                        utils.writeLog("--------------------------------------------------------------------------------", null);
                        break;
                    }

                    elementCounter++;
                }
                
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        // Method for created project
        public static void CreateProject()
        {
            try
            {
                utils.assertElementText(Cconf.Instance.scenaryIntoSuscriptionName, Cconf.Instance.SuscriptionName, utils.GetMessages(PageObjectRun.labelSuscription(), Cconf.Instance.elemenType[1], null));

                utils.Click(PageObjectRun.ButtonCreateProject(), Cconf.Instance.elemenType[1]);
                utils.EnterText(PageObjectRun.ProjectName(), Cconf.Instance.projectName, Cconf.Instance.elemenType[1]);
                utils.EnterText(PageObjectRun.ProjectSumary(), Cconf.Instance.projectSumary, Cconf.Instance.elemenType[1]);
                utils.Click(PageObjectRun.ProjectButton(), Cconf.Instance.elemenType[1]);
                Thread.Sleep(1000);// Wait apper element in the web

                utils.WaitTimeForElementVar(PageObjectRun.MenuCreateProject(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], "1");
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Search project
        public static string SearchProject(string Projectname)
        {
            try
            {
                int elementCounter = 1;
                int nElements = utils.CountItems(PageObjectRun.CountElementProject(), Cconf.Instance.elemenType[1]); //css

                while (elementCounter <= nElements)
                {
                    string id = Convert.ToString(elementCounter.ToString());
                    Thread.Sleep(500); //Wait fot set variable

                    string CopyName = utils.GetMessagesTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.CopyNameProject(), Cconf.Instance.elemenType[1], null, id);
                    if (CopyName == Projectname)
                    {
                        return elementCounter.ToString();
                    }

                    if (elementCounter == nElements && CopyName != Projectname)
                    {
                        utils.writeLog("\n----------------------------------Not found project-----------------------------", null);
                        utils.writeLog("\n--------------------------------------------------------------------------------", null);
                        utils.writeLog("----There aren't project with this name, please check your settings.----", null);
                        utils.writeLog("--------------------------------------------------------------------------------", null);
                        break;
                    }

                    elementCounter++;
                }
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }
            return "There aren't project";
        }

        //Method for create enviroment in especific project
        public static void CreateEnviroments(string indexProject)
        {
            try
            {
                Thread.Sleep(500); //Set variable
                utils.assertElementText(Cconf.Instance.scenaryProjectName, Cconf.Instance.projectName, utils.GetMessagesTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.CopyNameProject(), Cconf.Instance.elemenType[1], null, CrunCloud.SearchProject(Cconf.Instance.projectName)));

                if (indexProject != "There aren't project")
                {

                    string id = Convert.ToString(indexProject);
                    int CountEnvToCreate = 0;
                    string EnvCreate = Cconf.Instance.waitVar;
                    int dimensionArray = 0;

                    while (CountEnvToCreate < Cconf.Instance.ListEnviroments.GetLength(dimensionArray))
                    {
                        switch (Cconf.Instance.ListEnviroments[(CountEnvToCreate), 0].ToLower())
                        {
                            case "trial":
                                selectCategory = "1";
                                break;
                            case "basic b":
                                selectCategory = "2";
                                break;
                            case "standard s0":
                                selectCategory = "3";
                                break;
                            case "standard s1":
                                selectCategory = "4";
                                break;
                            case "standard s2":
                                selectCategory = "5";
                                break;
                            case "premium p1":
                                selectCategory = "5";
                                break;
                            case "premium p2":
                                selectCategory = "6";
                                break;
                            default:
                                selectCategory = "1";
                                break;

                        }

                        switch (Cconf.Instance.ListEnviroments[(CountEnvToCreate), 2].ToLower())
                        {
                            case "dev":
                                selectType = "1";
                                break;
                            case "test":
                                selectType = "2";
                                break;
                            case "stage":
                                selectType = "3";
                                break;
                            case "produccion":
                                selectType = "4";
                                break;
                            default:
                                selectType = "2";
                                break;
                        }

                        utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.MenuProject(), Cconf.Instance.elemenType[1], id);

                        utils.WaitTimeForElementVar(PageObjectRun.ElementSelectProject(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], id);
                        utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.ItemCreateEnviroment(), Cconf.Instance.elemenType[1], id);

                        utils.WaitTimeForElementVar(PageObjectRun.SelectCategoryEnviroment(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], selectCategory);
                        utils.ClickOneVariable(PageObjectRun.SelectCategoryEnviroment(), Cconf.Instance.elemenType[1], selectCategory);

                        utils.WaitTimeForElement(PageObjectRun.ButtonNextCategory(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                        utils.Click(PageObjectRun.ButtonNextCategory(), Cconf.Instance.elemenType[1]);

                        utils.WaitTimeForElement(PageObjectRun.EnviromentName(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                        utils.EnterText(PageObjectRun.EnviromentName(), Cconf.Instance.ListEnviroments[(CountEnvToCreate), 1], Cconf.Instance.elemenType[1]);

                        utils.WaitTimeForElementVar(PageObjectRun.EnviromentType(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], selectType);
                        utils.ClickOneVariable(PageObjectRun.EnviromentType(), Cconf.Instance.elemenType[1], selectType);

                        utils.WaitTimeForElement(PageObjectRun.ButtonNextType(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                        utils.Click(PageObjectRun.ButtonNextType(), Cconf.Instance.elemenType[1]);


                        utils.WaitTimeForElement(PageObjectRun.ButtonCreateEnviroment(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                        utils.Click(PageObjectRun.ButtonCreateEnviroment(), Cconf.Instance.elemenType[1]);


                        utils.WaitTimeForElement(PageObjectRun.LoadCreatedEnvironment(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                        string Waiting = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.StatusEnviroment(), Cconf.Instance.elemenType[1], null, id, EnvCreate);

                        Thread.Sleep(1000);

                        while (Waiting == "Creating")
                        {

                            utils.writeLog("{0} Environment... \n", Waiting);
                            Waiting = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.StatusEnviroment(), Cconf.Instance.elemenType[1], null, id, EnvCreate);
                            Thread.Sleep(5000); // wait for validate environment status

                        }

                        if (Waiting == "Created")
                        {
                            Clog Clog = new Clog();
                            Cconf.log = Clog.InitalizeLogFile();
                            Cconf.log.WriteLine("\nThe environment " + Cconf.Instance.ListEnviroments[(CountEnvToCreate), 1] + " finished with state: " + Waiting + "\n\n");
                            Console.Write("\nThe environment " + Cconf.Instance.ListEnviroments[(CountEnvToCreate), 1] + " finished with state: " + Waiting + "\n\n");
                            Cconf.log.Close();
                        }
                        else
                        {
                            utils.writeLog("\n----Can't created environments end with state: {0} ----\n\n", Waiting);
                        }

                        CountEnvToCreate++;
                    }

                }

                else
                {
                    utils.writeLog("\n----There aren't project with this especific name: {0} ----", Cconf.Instance.projectName);

                }
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }
        }

        //Search enviroment
        public static string SearchEnviroment(string indexProject, string enviromentName)
        {
            try
            {
                int elementCounter = 1;
                string IdProject = Convert.ToString(indexProject);
                Thread.Sleep(500); //wait set variable

                int nElementsEnviroments = utils.CountItemsTwoElementsOneVariable(PageObjectRun.CountElementProject(), PageObjectRun.ElementSelectEnviromentCount(), Cconf.Instance.elemenType[1], IdProject); //css

                while (elementCounter <= nElementsEnviroments)
                {
                    string idEnviroment = elementCounter.ToString();
                    idEnviroment = Convert.ToString(elementCounter);

                    Thread.Sleep(500); //Wait fot set variable
                    string CopyName = utils.GetMessagesTwoVariables(PagesObjects.PageObjectRun.ElementSelectProject(), PagesObjects.PageObjectRun.ElementSelectEnviroment(), PagesObjects.PageObjectRun.ElementSelectEnviromentName(), Cconf.Instance.elemenType[1], null, IdProject, idEnviroment);
                    if (CopyName == enviromentName)
                    {
                        return Convert.ToString(elementCounter);
                    }
                    if (elementCounter == nElementsEnviroments && CopyName != enviromentName)
                    {
                        utils.writeLog("\n----------------------------------Not found environment-----------------------------", null);
                        utils.writeLog("\n--------------------------------------------------------------------------------", null);
                        utils.writeLog("----There aren't environment with this name, please check your settings.----", null);
                        utils.writeLog("--------------------------------------------------------------------------------", null);
                        break;
                    }

                    elementCounter++;
                }
                utils.writeLog("\n----------------------------------Not found environment-----------------------------", null);
                utils.writeLog("\n--------------------------------------------------------------------------------", null);
                utils.writeLog("----There aren't environment with this name, please check your settings.----", null);
                utils.writeLog("--------------------------------------------------------------------------------", null);
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }

            return "----There aren't environment----";
        }

        //Method delete project
        public static void deleteProject(string indexProject)
        {
            string IdProject = Convert.ToString(indexProject);

            if (indexProject != "There aren't environment")
            {
                utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.MenuProject(), Cconf.Instance.elemenType[1], IdProject);
                utils.WaitTimeForElement(PageObjectRun.deleteProject(), Cconf.Instance.userTimeWait,Cconf.Instance.elemenType[1]);
                utils.Click(PageObjectRun.deleteProject(), Cconf.Instance.elemenType[1]);
                utils.EnterText(PageObjectRun.SetTextTrashEviroment(), Cconf.Instance.projectName, Cconf.Instance.elemenType[1]);
                utils.ClickCheck(PageObjectRun.SetCheckTrashEnviroment(), Cconf.Instance.elemenType[1]);
                utils.WaitTimeForElement(PageObjectRun.ButtonDelete(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                utils.Click(PageObjectRun.ButtonDelete(), Cconf.Instance.elemenType[1]);
            }
            else
            {
                utils.writeLog("\n----Project not found----", null);
            }
        }

        //Method unfold acivity monitor

        public static void unfoldActivity()
        {

        }

        //Method for upload .bex enviroment into especific enviroment
        public static void EnvironmentAction(string indexPro, string indexEnv, string actionType)          
        {
            try
            {
                Clog Clog = new Clog();

                Thread.Sleep(500); //wait set variables

                if (indexPro != "There aren't project")
                {
                    Thread.Sleep(5000);
                    //utils.WaitTimeForElement(PageObjectRun.ButtonCreateProject(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                    string idProject = Convert.ToString(indexPro);

                    if (indexEnv != "There aren't environment")
                    {
                        string idEnviroment = Convert.ToString(indexEnv);
                        string NewUrl;
                        switch (actionType)
                        {             
                            case "loadbex":
                               
                                utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.SelectMenuEnviroment(), Cconf.Instance.elemenType[1], idProject, idEnviroment);
                                AutoItX3 autoIt = new AutoItX3();                            
                                autoIt.WinActivate("File Upload");
                                autoIt.ControlGetFocus("File Upload");
                                Thread.Sleep(500);
                                autoIt.Send(Cconf.Instance.ListEnviromentsLoadBex[0, 1]);
                                Thread.Sleep(2000); //wait write path .bex
                                autoIt.Send("{ENTER}");
                                Thread.Sleep(1000);  //come back run cloud
                                utils.Click(PageObjectRun.ButtonloadBex(), Cconf.Instance.elemenType[1]);                              
                                utils.WaitTimeForElement(PageObjectRun.LoadCreatedEnvironment(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                string Waiting = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.SelectStatusEnviroment(), Cconf.Instance.elemenType[1], null, idProject, idEnviroment);


                                while (Waiting == "Applying")
                                {
                                    utils.writeLog("{0} upload package... \n", Waiting);
                                    Waiting = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.SelectStatusEnviroment(), Cconf.Instance.elemenType[1], null, idProject, idEnviroment);
                                    Thread.Sleep(5000);//wait to write log
                                }

                                if (Waiting == "Active")
                                {
                                    utils.writeLog("The package has been upload successfully with state: {0} \n\n\n", Waiting);
                                    utils.WaitTimeForElement(PageObjectRun.ButtonCloseAlert(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                    utils.Click(PageObjectRun.ButtonCloseAlert(), Cconf.Instance.elemenType[1]);
                                    break;
                                }
                                else
                                {
                                    utils.writeLog("\n----Can't upload package state: {0} ----\n\n", Waiting);
                                    break;
                                }

                            case "delete":
                                utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.SelectTrashEnviroment(), Cconf.Instance.elemenType[1], idProject, idEnviroment);

                                utils.WaitTimeForElement(PageObjectRun.SetTextTrashEviroment(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                utils.EnterText(PageObjectRun.SetTextTrashEviroment(), Cconf.Instance.ListEnviroments[0, 1], Cconf.Instance.elemenType[1]);
                                utils.ClickCheck(PageObjectRun.SetCheckTrashEnviroment(), Cconf.Instance.elemenType[1]);

                                utils.WaitTimeForElement(PageObjectRun.ButtonDelete(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                utils.Click(PageObjectRun.ButtonDelete(), Cconf.Instance.elemenType[1]);
                                break;

                            case "run":
                                NewUrl = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.GetUrlEnviroment(), Cconf.Instance.elemenType[1], "href", idProject, idEnviroment);
                                utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.ClickButtonRunEnviroment(), Cconf.Instance.elemenType[1], idProject, idEnviroment);
                                CopenBrowser.driver.SwitchTo().Window(CopenBrowser.driver.WindowHandles.Last());
                                utils.WaitTimeForElement(PageObjectEngine.LoginButton(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[0]);
                                utils.EnterText(PageObjectEngine.UserText(), Cconf.Instance.ListEnviromentsLoadBex[0, 2], Cconf.Instance.elemenType[0]);
                                utils.EnterText(PageObjectEngine.PasswordText(), Cconf.Instance.ListEnviromentsLoadBex[0, 3], Cconf.Instance.elemenType[0]);
                                utils.Click(PageObjectEngine.LoginButton(), Cconf.Instance.elemenType[0]);
                                utils.WaitTimeForElement(PageObjectEngine.bizagiLogo(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                utils.assertElementImage(Cconf.Instance.scenaryLogoEngine, PageObjectEngine.bizagiLogo(), Cconf.Instance.elemenType[1], Cconf.Instance.copyLogoEngine);
                                CengineCloud.NewCase(CengineCloud.SearchCase(Cconf.Instance.ListEnviromentsLoadBex[0, 4]));
                                CengineCloud.LogoutEngine();
                                CopenBrowser.driver.Close();
                                CopenBrowser.driver.SwitchTo().Window(CopenBrowser.driver.WindowHandles.Last());
                                break;

                            case "reset":

                                utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.MenuEnvironment(), Cconf.Instance.elemenType[1], idProject, idEnviroment);
                                utils.Click(PageObjectRun.SelectResetEnvironment(), Cconf.Instance.elemenType[1]);
                                utils.WaitTimeForElement(PageObjectRun.textReset(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                utils.ClickCheck(PageObjectRun.SetCheckTrashEnviroment(), Cconf.Instance.elemenType[1]);
                                utils.WaitTimeForElement(PageObjectRun.ButtonDelete(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                utils.Click(PageObjectRun.ButtonDelete(), Cconf.Instance.elemenType[1]);
                                utils.WaitTimeForElement(PageObjectRun.LoadCreatedEnvironment(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                string reseting = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.StatusEnviroment(), Cconf.Instance.elemenType[1], null, idProject, idEnviroment);

                                Thread.Sleep(1000);
                                reseting = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.StatusEnviroment(), Cconf.Instance.elemenType[1], null, idProject, idEnviroment);

                                while (reseting == "Resetting IIS")
                                {

                                    utils.writeLog("{0} Environment... \n", reseting);
                                    reseting = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.StatusEnviroment(), Cconf.Instance.elemenType[1], null, idProject, idEnviroment);
                                    Thread.Sleep(5000); // wait for validate environment status

                                }

                                if (reseting == "Active")
                                {
                                    utils.writeLog("\nThe environment was reseted correctly", null);
                                }
                                else
                                {
                                    utils.writeLog("\n----Can't reset environment state is {0}----\n\n", reseting);
                                }                           

                                NewUrl = utils.GetMessagesTwoVariables(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.GetUrlEnviroment(), Cconf.Instance.elemenType[1], "href", idProject, idEnviroment);
                                utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.ClickButtonRunEnviroment(), Cconf.Instance.elemenType[1], idProject, idEnviroment);
                                CopenBrowser.driver.SwitchTo().Window(CopenBrowser.driver.WindowHandles.Last());
                                utils.WaitTimeForElement(PageObjectEngine.LoginButton(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[0]);
                                utils.EnterText(PageObjectEngine.UserText(), Cconf.Instance.ListEnviromentsLoadBex[0, 2], Cconf.Instance.elemenType[0]);
                                utils.EnterText(PageObjectEngine.PasswordText(), Cconf.Instance.ListEnviromentsLoadBex[0, 3], Cconf.Instance.elemenType[0]);
                                utils.Click(PageObjectEngine.LoginButton(), Cconf.Instance.elemenType[0]);
                                utils.WaitTimeForElement(PageObjectEngine.bizagiLogo(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
                                utils.assertElementImage(Cconf.Instance.scenaryLogoEngine, PageObjectEngine.bizagiLogo(), Cconf.Instance.elemenType[1], Cconf.Instance.copyLogoEngine);
                                CengineCloud.NewCase(CengineCloud.SearchCase(Cconf.Instance.ListEnviromentsLoadBex[0, 4]));
                                CengineCloud.LogoutEngine();
                                CopenBrowser.driver.Close();
                                CopenBrowser.driver.SwitchTo().Window(CopenBrowser.driver.WindowHandles.Last());
                                break;

                            case "monitor":
                                utils.ClickTwoElements(PageObjectRun.ElementSelectProject(), PageObjectRun.ElementSelectEnviroment(), PageObjectRun.activityMonitor(), Cconf.Instance.elemenType[1], idProject, idEnviroment);
                                utils.WaitTimeForElement(PageObjectRun.buttonCloseMonitor(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);

                                utils.Click(PageObjectRun.buttonCloseMonitor(), Cconf.Instance.elemenType[1]);

                           
                                
                                break;

                            default:
                                utils.writeLog("\n----There aren't option to environment----", null);
                                break;
                        }
                    }
                    else
                    {
                        utils.writeLog("\n----Enviroment not found----", null);
                    }
                }
                else
                {
                    utils.writeLog("\n----Project not found----", null);
                }              
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }
        }
        }
}
