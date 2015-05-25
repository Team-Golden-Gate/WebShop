namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using GoldenGateShop.Data.UnitOfWork;
    using GoldenGateShop.Data;


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
    }
}