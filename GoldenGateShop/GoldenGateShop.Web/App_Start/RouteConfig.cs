using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoldenGateShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "Categories/{categoryName}",
                defaults: new 
                { 
                    controller = "Categories",
                    action = "Index",                  
                }
            );

            routes.MapRoute(
                name: "Product",
                url: "Categories/{categoryName}/{productName}",
                defaults: new
                {
                    controller = "Categories",
                    action = "Product",
                    productName = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
