namespace GoldenGateShop.Web.Areas.Administration.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

   
    using GoldenGateShop.Web.Areas.Administration.Controllers;
    using GoldenGateShop.Common;


    public static class AdminMenu
    {
        private static IEnumerable<string> controllers;

        public static IEnumerable<string> Items
        {
            get
            {
                return controllers ?? (controllers = GetControllerNames());
            }
        }

        private static IEnumerable<string> GetControllerNames()
        {
            return ReflectionHelper.GetSubClasses<BaseAdminController>().Select(c => c.Name.Replace("AdminController", string.Empty));
        }
    }
}