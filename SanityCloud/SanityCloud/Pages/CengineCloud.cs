using AutoItX3Lib;
using SanityCloud.PagesObjects;
using SanityCloud.Settings;
using System;
using System.Threading;

namespace SanityCloud.Pages
{
    class CengineCloud
    {
        //Search especific case
        
        public static int SearchCase(string casename)
        {
            utils.Click(PageObjectEngine.SelectNewCase(), Cconf.Instance.elemenType[1]);
            utils.WaitTimeForElement(PageObjectEngine.SelectAllProcess(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]);
            utils.Click(PageObjectEngine.SelectAllProcess(), Cconf.Instance.elemenType[1]);
            Thread.Sleep(2000);

            int elementCounter = 1;
            int nElements = utils.CountItems(PageObjectEngine.CountProcess(), Cconf.Instance.elemenType[1]); //css

            while (elementCounter <= nElements)
            {
                string id = elementCounter.ToString();
                id = Convert.ToString(elementCounter);

                Thread.Sleep(500); //Wait fot set variable
                string CopyName = utils.GetMessagesVariable(PageObjectEngine.SelectProcessMC(), Cconf.Instance.elemenType[1], null, id);
                if (CopyName == casename)
                {
                    return elementCounter;
                }
                elementCounter++;
            }
            return -1;
        }

        public static void NewCase(int casenumber)
        {
            int Case = casenumber;

            if (Case != -1)
            {
                string idCase = Case.ToString();
                Thread.Sleep(500);
                utils.WaitTimeForElementVar(PageObjectEngine.SelectProcessMC(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], idCase);
                utils.ClickOneVariable(PageObjectEngine.SelectProcessMC(), Cconf.Instance.elemenType[1], idCase);
                utils.WaitTimeForElement(PageObjectEngine.CaseImageProfile(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.CaseImageProfile(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.SearchElementCaseImage(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                AutoItX3 autoIt = new AutoItX3();
                autoIt.WinActivate("File Upload");
                autoIt.ControlGetFocus("File Upload");
                Thread.Sleep(1000);
                autoIt.Send(Cconf.Instance.ListValuesCase[0, 0]); //Ruta del archivo
                Thread.Sleep(2000);
                autoIt.Send("{ENTER}");
                Thread.Sleep(1000);
                utils.Click(PageObjectEngine.ButtonUploadFile(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(4000);
                utils.EnterText(PageObjectEngine.CaseNameProfile(), Cconf.Instance.ListValuesCase[0, 1], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.EnterText(PageObjectEngine.CaseAdressProfile(), Cconf.Instance.ListValuesCase[0, 2], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.EnterText(PageObjectEngine.CasePhoneProfile(), Cconf.Instance.ListValuesCase[0, 3], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.EnterText(PageObjectEngine.CaseMoneyProfile(), Cconf.Instance.ListValuesCase[0, 4], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.CaseUploadProfile(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.SearchElementCaseUpload(), Cconf.Instance.elemenType[2]);
                autoIt.WinActivate("File Upload");
                autoIt.ControlGetFocus("File Upload");
                Thread.Sleep(1000);
                autoIt.Send(Cconf.Instance.ListValuesCase[0, 5]);
                Thread.Sleep(2000);
                autoIt.Send("{ENTER}");
                Thread.Sleep(1000);
                utils.Click(PageObjectEngine.ButtonUploadFile(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(4000);

                //Collection

                utils.EnterText(PageObjectEngine.CaseAdressCollection(), Cconf.Instance.ListValuesCase[0, 6], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.CaseImageCollection(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.SearchElementCollectionImage(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(2000);
                autoIt.WinActivate("File Upload");
                autoIt.ControlGetFocus("File Upload");
                Thread.Sleep(1000);
                autoIt.Send(Cconf.Instance.ListValuesCase[0, 7]); // Ruta del archivo
                Thread.Sleep(2000);
                autoIt.Send("{ENTER}");
                Thread.Sleep(2000);
                utils.Click(PageObjectEngine.ButtonUploadFile(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(4000);
                utils.EnterText(PageObjectEngine.CaseMoneyCollection(), Cconf.Instance.ListValuesCase[0, 8], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.EnterText(PageObjectEngine.CaseNameCollection(), Cconf.Instance.ListValuesCase[0, 9], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.EnterText(PageObjectEngine.CasePhoneCollection(), Cconf.Instance.ListValuesCase[0, 10], Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.CaseDateCollection(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.DateTime(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.CaseUploadCollection(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.SearchElementCaseUpload(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(2000);
                autoIt.WinActivate("File Upload");
                autoIt.ControlGetFocus("File Upload");
                Thread.Sleep(1000);
                autoIt.Send(Cconf.Instance.ListValuesCase[0, 11]);
                Thread.Sleep(2000);
                autoIt.Send("{ENTER}");
                Thread.Sleep(1000);
                utils.Click(PageObjectEngine.ButtonUploadFile(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(4000);
                utils.Click(PageObjectEngine.CaseBolleanCollection(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(500);
                utils.Click(PageObjectEngine.SaveCase(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(4000);
                utils.Click(PageObjectEngine.NextCase(), Cconf.Instance.elemenType[2]);
                Thread.Sleep(1000);
            }
            else
            {
                utils.writeLog("There aren't csse with this name", null);
            }
        }

        public static void LogoutEngine()
        {
            Thread.Sleep(5000);
            utils.Click(PageObjectEngine.IconLogout(), Cconf.Instance.elemenType[1]);
            Thread.Sleep(500);
            utils.Click(PageObjectEngine.ButtonLogout(), Cconf.Instance.elemenType[1]);
            utils.WaitTimeForElement(PageObjectEngine.LoginButton(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[0]);
        }
    }
}