using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectEngine
    {
        public static string UserText()
        {
            return "user"; //id
        }

        public static string PasswordText()
        {
            return "password"; // id
        }


        public static string LoginButton()
        {

            return "btn-login"; //Id

        }

        public static string SelectNewCase()
        {
            return "li#menuListNew"; //css
        }

        public static string SelectAllProcess()
        {
            return "i.processIco.bz-icon.bz-icon-16.bz-icon-sentence-form-outline"; //css
        }

        public static string SelectProcessMC()
        {
            return "li.process:nth-child({0})"; //css
        }

        public static string CountProcess()
        {
            return "li.process"; //css
        }

        public static string DisplayLabelCase()
        {
            return "span.displayNameLabel"; //css
        }

        public static string DisplayLabelFormCase()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[9]/span/label"; //xpath
        }

        public static string CaseImageProfile()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[2]/div/div/div[1]/div/div[1]/a/div";
        }

        public static string CaseNameProfile()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[3]/div/div/div[1]/input";
        }

        public static string CaseAdressProfile()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[4]/div/div/div[1]/input";
        }

        public static string CasePhoneProfile()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[5]/div/div/div[1]/input";
        }

        public static string CaseMoneyProfile()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[6]/div/div/div[1]/input";
        }

        public static string CaseUploadProfile()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[7]/div/div/div[1]/ul/li/a/span";
        }

        public static string CaseAdressCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[2]/div/div/span/input";
        }

        public static string CaseImageCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[3]/div/div/span/div/div[1]/a/div";
        }

        public static string CaseMoneyCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[4]/div/div/span/input";
        }

        public static string CaseNameCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[5]/div/div/span/input";
        }

        public static string CasePhoneCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[6]/div/div/span/input";
        }

        public static string CaseDateCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[7]/div/div/span/span/span";
        }

        public static string CaseUploadCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[8]/div/div/span/ul/li/a/span";
        }

        public static string CaseBolleanCollection()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[9]/div/div/span/div/div[2]/label";
        }

        public static string CaseDropParametrica()
        {
            return ".//*[@id='ui-bizagi-wp-project-plan-content-dashboard']/div/div/div/div[2]/div[9]/div/div/div[1]/div/div[2]";
        }

        public static string SearchElementCaseImage()
        {
            return ".//*[@id='MC.Image']";
        }
        public static string SearchElementCollectionImage()
        {
            return ".//*[@id='Imageuser']";
        }

        public static string SearchElementCaseUpload()
        {
            return ".//*[@id='file']";
        }

        public static string SearchElementCollectionUpload()
        {
            return ".//*[@id='MC_Coleccion']/div/div[2]/div[1]/table/tbody/tr[1]/td[8]/div/div/span/ul/li/a/span";
        }

        public static string ButtonUploadFile()
        {
            return "html/body/div[6]/div[3]/div/button[1]";
        }

        public static string SaveCase()
        {
            return ".//*[@id='formButton0']";
        }

        public static string NextCase()
        {
            return ".//*[@id='formButton1']";
        }

        public static string DateTime()
        {
            return ".//*[@id='ui-datepicker-div']/table/tbody/tr[3]/td[2]/a";
        }

        public static string bizagiLogo()
        {
            return "div#ui-bizagi-wp-app-menu-logo-client";
        }

        public static string IconLogout()
        {
            return "i.adm-user.bz-icon.bz-icon-16.bz-icon-cog-outline"; //css
        }

        public static string ButtonLogout()
        {
            return "i.bz-icon.bz-icon-16.bz-icon-sign-out-outline"; //css
        }





    }
}
