using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectHomePageOperationsPortal
    {
        public static string menuUserProfile()
        {
            return "span.bzg-user-avatar__label"; //css
        }

        public static string buttonLogaout()
        {
            return "li.bz-user-menu__item:nth-child(2)"; //css
        }

        public static string titleOperationsPortal()
        {
            return "h2.dashboard-company__header__info__title"; //css
        }

        public static string buttonCreateCompany()
        {
            return "button.bzg-button";//css
        }

        public static string firstComapany()
        {
            return ".bz-column-3:nth-child(1)";
        }

    }
}
