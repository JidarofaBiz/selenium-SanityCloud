using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityCloud.PagesObjects
{
    class PageObjectRun
    {

        //Project elements
        public static string MenuProject() {

            return "a#simple-dropdown"; //css

        }

        public static string MenuCreateProject()
        {
            return "i.bz-icon.bz-icon-menu-items.bz-cd-icon-20"; //css
        }

        public static string ButtonCreateProject()
        {
            return "a.pull-right.plus-btn"; //css
        }

        public static string ProjectName()
        {
            return "input#name"; //css
        }

        public static string ProjectSumary()
        {
            return "input#description"; //css
        }

        public static string ProjectButton() 
        {
            return "button.bz-button.bz-button-accept.ng-binding.ng-scope"; //css
        }

        public static string CountElementProject()
        {

            return ".project-content"; //css
        }

        public static string ElementSelectProject()
        {
            return "project.brick.ng-scope.ng-isolate-scope.masonry-grid-item:nth-child({0})"; //css
        }

        public static string CopyNameProject()
        {
            return "h.name.ng-binding"; //css
        }

        public static string iconProject()
        {
            return "i.bz-icon.bz-icon-cloud.bz-cd-icon-24"; //css
        }

        public static string IconProjectEmpty()
        {
            return "i.bz-icon.bz-icon-hexagon-empty"; //css
        }

        public static string deleteProject()
        {
            return "i.bz-icon.bz-icon-trash"; //css
        }



        //Enviroments Elements


        public static string labelSuscription()
        {
            return "label.ng-binding";//css
        }

        public static string ElementSelectEnviromentCount()
        {
            return "environment.ng-scope.ng-isolate-scope.open";  //css
        }

        public static string ElementSelectEnviroment()
        {
            return "environment.ng-scope.ng-isolate-scope.open:nth-child({0})";  //css
        }

        public static string ItemCreateEnviroment()
        {
            return "a#a_create_environment"; //css 
        }

        public static string SelectCategoryEnviroment()
        {
            return ".category-item-wrapper.col-xs-6.col-sm-4.col-md-4.col-lg-3.ng-scope:nth-child({0})"; //css
        }

        public static string ButtonNextCategory()
        {
            return "button.bz-button.bz-button-accept.ng-binding.ng-scope"; //css
        }

        public static string EnviromentName()
        {
            return "input#name"; //css
        }

        public static string EnviromentType()
        {
            return ".type-item-wrapper.col-xs-12.col-sm-3.col-md-3.col-lg-3.ng-scope:nth-child({0})"; //css
        }

        public static string ButtonNextType()
        {
            return "button.bz-button.bz-button-accept.ng-binding.ng-scope"; //css
        }

        public static string ButtonCreateEnviroment()
        {
            return "button.bz-button.bz-button-accept.ng-binding.ng-scope"; //css
        }

        public static string StatusEnviroment()
        {
            return ".environment-deploy-status";   //css
        }

        public static string LoadCreatedEnvironment()
        {
            return ".transitive-overlay";
        }

        public static string ElementSelectEnviromentName()
        {
            return "span.environment__content__information__item--name.ng-binding";  //css
        }

        public static string SelectMenuEnviroment()
        {
            return "i.bz-icon.bz-cd-icon-17.bz-icon-hexagon-upload";  //css
        }

        public static string SelectTrashEnviroment()
        {
            return "i.bz-icon.bz-cd-icon-17.bz-icon-trash-outline";  //css
        }

        public static string SelectResetEnvironment()
        {
            return "i.bz-icon.bz-icon-reload";
        }

        public static string SelectStatusEnviroment()
        {
            return ".environment-deploy-status";  //css
        }

        public static string SetTextTrashEviroment()
        {
            return "input.input_confirmation_key.ng-pristine.ng-untouched.ng-valid.ng-empty.ng-valid-maxlength";  //css
        }

        public static string textReset()
        {
            return "h4.modal-title.bz-modal-title.ng-binding"; //css
        }

        public static string SetCheckTrashEnviroment()
        {
            return "input#test1";  //css
        }

        public static string ClickButtonTrashEnviroment()
        {
            return "button.bz-button.bz-button-accept.ng-binding";  //css
        }

        public static string GetUrlEnviroment() {

            return "a.bz-cd-shape-enabled:nth-child(2)";  //css

        }

        public static string ClickButtonRunEnviroment()
        {

            return "i.bz-icon.bz-cd-icon-17.bz-icon-hexagon-execute";  //css

        }

        public static string ButtonloadBex()
        {
            return "button.bz-button.bz-button-accept.ng-binding"; //css
        }

        public static string ButtonCloseAlert()
        {
            return "button.close"; //css
        }

        public static string ButtonDelete()
        {
            return "button.bz-button.bz-button-accept.ng-binding"; //css
        }

        public static string MenuEnvironment()
        {
            return ".environment-menu.dropdown"; //css
        }

        public static string activityMonitor()
        {
            return "i.bz-icon.bz-cd-icon-17.bz-icon-activity-outline"; //css
        }

        public static string buttonCloseMonitor()
        {
            return "button.close"; //css
        }


    }
}
