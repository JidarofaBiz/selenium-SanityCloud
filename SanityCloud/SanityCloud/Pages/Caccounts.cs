using SanityCloud.Contracts;
using SanityCloud.PagesObjects;
using SanityCloud.Selenium.Selector;
using SanityCloud.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SanityCloud.Pages
{
    class Caccounts
    {

        //Login accounts
        public  static void LoginAccounts(string email, string password, string product)
        {
            try
            {
                utils.WaitTimeForElement(PageObjectLogin.EmailText(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[0]); //id

                utils.assertElementText(Cconf.Instance.scenaryAccounts, Cconf.Instance.copyBizagiCommunityAccounts, utils.GetMessages(PageObjectLogin.copyComunity(), Cconf.Instance.elemenType[1], null));

                utils.EnterText(PageObjectLogin.EmailText(), Cconf.Instance.userEmail, Cconf.Instance.elemenType[0]);
                utils.EnterText(PageObjectLogin.PasswordText(), Cconf.Instance.userpass, Cconf.Instance.elemenType[0]);
                utils.Click(PageObjectLogin.LoginButton(), Cconf.Instance.elemenType[1]);

                switch (product)
                {
                    case "Business":
                        utils.WaitTimeForElementVar(PageObjectHomePageDataSets.menuUserProfile(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css
                        utils.WaitTimeForElementVar(PageObjectHomePageDataSets.firstSuscription(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css
                        break;
                    case "Artificial":
                        utils.WaitTimeForElementVar(PageObjectHomePageArtificialIntelligence.menuUserProfile(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css 
                        utils.WaitTimeForElementVar(PageObjectHomePageArtificialIntelligence.firstSuscription(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css 
                        break;
                    case "Operations":
                        utils.WaitTimeForElementVar(PageObjectHomePageOperationsPortal.buttonCreateCompany(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css
                        utils.WaitTimeForElementVar(PageObjectHomePageOperationsPortal.firstComapany(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css
                        break;
                    case "Enterprise":
                        utils.WaitTimeForElementVar(PageObjectHomePageEnterprisePortal.menuUserProfile(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css
                        utils.WaitTimeForElementVar(PageObjectHomePageEnterprisePortal.firstSuscription(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css
                        break;
                    case "Run":
                        utils.WaitTimeForElementVar(PageObjectHomePage.SuscriptionSelectorName(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css 
                        utils.WaitTimeForElementVar(PageObjectHomePage.firstSuscription(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1], Cconf.Instance.waitVar); //css 
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }

        }
    }
}
