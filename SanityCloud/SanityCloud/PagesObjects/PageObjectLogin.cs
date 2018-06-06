using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectLogin
    {

        public static string EmailText()
        {
            return "email"; //id 
        }

        public static string PasswordText()
        {
            return "password"; //id 
        }

        public static string LoginButton()
        {
            return ".call-to-action.bz-ms-login-btn"; //css
        }

        public static string copyComunity()
        {
            return "h3.bz-subtitle.ng-binding";// css
        }
    }
}
