namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GoldenGateShop.Data.UnitOfWork;
    using GoldenGateShop.Data;
    using System.Web.Routing;
    using GoldenGateShop.Models;


    public abstract class BaseController : Controller
    {
        private IShopData data;

        protected BaseController(IShopData data)
        {
            this.Data = data;
        }

        protected BaseController()
            : this(new ShopData(new ShopDbContext()))
        {
        }

        protected IShopData Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        protected CurrentUser UserProfile { get; private set; }

        protected IEnumerable<Category> Categories { get; private set; }


        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                this.UserProfile = this.Data.Users.All().Where(u => u.UserName == username)
                    .Select(x =>  new CurrentUser
                    {
                       Id =  x.Id,
                       UserName = x.UserName,
                       Email = x.Email                    
                    })
                    .FirstOrDefault();
            }

            return base.BeginExecute(requestContext, callback, state);
        }

        

    }

    public class CurrentUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}