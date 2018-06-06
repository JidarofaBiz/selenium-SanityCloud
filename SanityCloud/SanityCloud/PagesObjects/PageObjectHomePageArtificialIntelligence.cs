using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectHomePageArtificialIntelligence
    {
       public static string menuUserProfile()
       {
            return ".bz-user__avatar";
       }

        public static string buttonLogOut()
        {
            return "ul.bz-nav-panel.show li:nth-child(2) a";
        }

        public static string firstSuscription()
        {
            return ".bz-grid-item:nth-child(1)";
        }

    }
}
