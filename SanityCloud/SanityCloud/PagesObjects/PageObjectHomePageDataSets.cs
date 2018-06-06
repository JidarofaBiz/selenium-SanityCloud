using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectHomePageDataSets
    {
        public static string menuUserProfile()
        {
            return ".user-btn";
        }

        public static string buttonLogOut()
        {
            return "i.bz-icon.bz-icon-logout-outline";
        }

        public static string TitleCompanyName()
        {

            return "h3.be-company-name"; //css

        }

        public static string TitleSuscriptions()
        {

            return "h2.be-subscription-name"; //css

        }

        public static string firstSuscription()
        {
            return ".bz-grid-item:nth-child(1)";
        }
    }
}
