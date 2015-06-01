namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GoldenGateShop.Web.Areas.Administration.Helpers;
    using GoldenGateShop.Web.Helpers;

    public class HomeAdminController : BaseAdminController
    {
        // GET: Administration/Home
        public ActionResult Index()
        {
            this.ViewBag.SubLocation = "Home";
            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView("_AdminMenu", AdminMenu.Items);
        }
    }
}