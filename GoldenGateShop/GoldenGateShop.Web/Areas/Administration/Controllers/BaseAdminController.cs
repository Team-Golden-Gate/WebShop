namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GoldenGateShop.Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public abstract class BaseAdminController : BaseController
    {
        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.ViewBag.Location = "AdminArea";

            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            this.ViewBag.SubLocation = filterContext.RouteData.Values["Controller"].ToString();
            base.OnResultExecuting(filterContext);
        }
    }
}