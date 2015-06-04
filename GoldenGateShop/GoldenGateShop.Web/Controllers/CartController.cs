namespace GoldenGateShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Net;

    using LinqKit;

    using GoldenGateShop.Web.ViewModels.Categories;
    using GoldenGateShop.Web.BindingModels;
    using GoldenGateShop.Models;
    using System.Web.UI;

    public class CartController : BaseController
    {
        public void Add(Product product)
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Product>();
            }
            var cart = (List<Product>)Session["cart"];
            cart.Add(product);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public void Remove(Product product)
        {
            var cart = (List<Product>)Session["cart"];
            cart.Remove(product);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Index()
        {
            var products = (List<Product>)this.Session["cart"];
            //products = products.OrderBy(p => p.Id);
            var totalPrice = products.Sum(p => p.Price);
            return this.View(products);
        }

        public void Buy()
        {
            var products = (List<Product>)this.Session["cart"];
            foreach (var product in products)
            {
                var order = new Order();
                order.Product = product;
                order.OrderedOn = DateTime.Now;
                order.TotalPrice = product.Price;
                this.Data.Orders.Add(order);
            }
            Redirect("home");
        }
    }
}