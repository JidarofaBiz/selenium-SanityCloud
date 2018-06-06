using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectHomePage
    {

        //Home page elements
        public static string firstSuscription()
        {
            return ".col-xs-12.col-sm-4.subscription-option.ng-scope:nth-child(1)";
        }

        //wrapper ie11
        public static string WrapperSuscriptionsie11()
        {
            return ".bz-cd-wrapper"; //css
        }

        public static string UserProfileIcon()
        {
            return "i.bz-wp-avatar-adm.bz-icon.bz-cd-icon-16.bz-icon-cog-outline"; //css
        }

        public static string LogoutButton()
        {
            return "i.bz-icon.bz-icon-log-out"; //css
        }

        public static string SuscriptionSelector()
        {
            return "a.option-content"; //css
        }

        public static string SuscriptionSelectorName()
        {
            return ".col-xs-12.col-sm-4.subscription-option.ng-scope:nth-child({0})"; //css
        }

        //Clic container IE suscription 
        public static string SuscriptionSelectorNameIE()
        {
            return ".col-xs-12.col-sm-4.subscription-option.ng-scope:nth-child({0}) a.option-content"; //css
        }

        public static string assertWelcomeToBizagi()
        {
            return "h4"; //Css
        }

        public static string assertSelectSuscription()
        {
            return "h5.ng-scope";
        }

        public static string assertGiveYourFeedback()
        {
            return "a.bz-footer-item.ng-binding";
        }

        public static string assertLogoRun()
        {
            return "i.logo-image";
        }

        public static string ContainerSuscription()
        {
            return ".selector.row.title";
        }
    }
}
