using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectHomePageEnterprisePortal
    {
        public static string menuUserProfile()
        {
            return ".user-btn";
        }

        public static string buttonLogOut()
        {
            return "ul.bz-cd-member-dropdown li:nth-child(2) a";
        }

        public static string firstSuscription()
        {
            return ".bz-grid-item:nth-child(1)";
        }
    }
}
