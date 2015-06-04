namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GoldenGateShop.Web.Areas.Administration.Helpers;
    using System.Collections;

    public class HomeAdminController : BaseAdminController
    {       

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView("_AdminMenu", AdminMenu.Items);
        }
    }
}