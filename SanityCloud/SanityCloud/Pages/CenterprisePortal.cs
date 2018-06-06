using SanityCloud.PagesObjects;
using SanityCloud.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.Pages
{
    class CenterprisePortal
    {
        public static void LogoutEnterprise()
        {
            try
            {
                utils.WaitTimeForElement(PageObjectHomePageEnterprisePortal.menuUserProfile(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[1]); // Css
                utils.Click(PageObjectHomePageEnterprisePortal.menuUserProfile(), Cconf.Instance.elemenType[1]); //css
                utils.Click(PageObjectHomePageEnterprisePortal.buttonLogOut(), Cconf.Instance.elemenType[1]); //css
                utils.WaitTimeForElement(PageObjectLogin.EmailText(), Cconf.Instance.userTimeWait, Cconf.Instance.elemenType[0]); //id
                utils.assertElementText(Cconf.Instance.scenaryLogout, Cconf.Instance.copyBizagiCommunityAccounts, utils.GetMessages(PageObjectLogin.copyComunity(), Cconf.Instance.elemenType[1], null));
            }
            catch (Exception ErrorM)
            {
                utils.writeLog("{0}", ErrorM.Message);
            }
        }
    }
}
