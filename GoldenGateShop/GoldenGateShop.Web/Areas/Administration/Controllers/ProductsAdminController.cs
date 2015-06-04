namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using GoldenGateShop.Data;
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Areas.Administration.ViewModels.Categories;

    public class ProductsAdminController : BaseAdminController
    {
        private ShopDbContext db = new ShopDbContext();

        protected override IEnumerable GetData()
        {
            return this.Data.Categories.All()
                .OrderBy(c => c.Position)
                .Project().To<CategoriesViewModel>();
        }


        protected override void GetCreatLogic()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.TradeId = new SelectList(db.Trades, "Id", "Name");
            base.GetCreatLogic();
        }
        /*
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "Id,Name,Picture,Price,Quantity,CreatedAt,CategoryId,TradeId")] Product product)
         {
             if (ModelState.IsValid)
             {
                 db.Products.Add(product);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
             ViewBag.TradeId = new SelectList(db.Trades, "Id", "Name", product.TradeId);
             return View(product);
         }
        */
        // GET: Administration/Products/Edit/5


        protected override void GetEditLogic(object obj)
        {
            base.GetEditLogic(obj);
        }

        public override ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.TradeId = new SelectList(db.Trades, "Id", "Name", product.TradeId);
            return View(product);
        }

        // POST: Administration/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Picture,Price,Quantity,CreatedAt,CategoryId,TradeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.TradeId = new SelectList(db.Trades, "Id", "Name", product.TradeId);
            return View(product);
        }
        /*
         // POST: Administration/Products/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             Product product = db.Products.Find(id);
             db.Products.Remove(product);
             db.SaveChanges();
             return RedirectToAction("Index");
         }*/
    }
}
