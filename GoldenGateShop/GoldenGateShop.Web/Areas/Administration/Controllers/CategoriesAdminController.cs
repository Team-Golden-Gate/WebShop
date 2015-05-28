namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CategoriesAdminController : BaseAdminController
    {
        // GET: Administration/Categories
        public ActionResult Index()
        {
            return View();
        }
    }
}