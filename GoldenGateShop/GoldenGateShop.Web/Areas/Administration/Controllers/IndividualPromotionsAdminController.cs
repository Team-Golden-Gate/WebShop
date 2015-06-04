using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoldenGateShop.Data;
using GoldenGateShop.Models;

namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    public class IndividualPromotionsAdminController : BaseAdminController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Administration/IndividualPromotions
        public ActionResult Index()
        {
            var individualPromotions = db.IndividualPromotions.Include(i => i.Product).Include(i => i.Promotion);
            return View(individualPromotions.ToList());
        }

        // GET: Administration/IndividualPromotions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPromotion individualPromotion = db.IndividualPromotions.Find(id);
            if (individualPromotion == null)
            {
                return HttpNotFound();
            }
            return View(individualPromotion);
        }

        // GET: Administration/IndividualPromotions/Create
        public virtual ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "Id");
            return View();
        }

        // POST: Administration/IndividualPromotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PromotionId,ProductId,StartedOn,EndedOn")] IndividualPromotion individualPromotion)
        {
            if (ModelState.IsValid)
            {
                db.IndividualPromotions.Add(individualPromotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", individualPromotion.ProductId);
            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "Id", individualPromotion.PromotionId);
            return View(individualPromotion);
        }

        // GET: Administration/IndividualPromotions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPromotion individualPromotion = db.IndividualPromotions.Find(id);
            if (individualPromotion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", individualPromotion.ProductId);
            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "Id", individualPromotion.PromotionId);
            return View(individualPromotion);
        }

        // POST: Administration/IndividualPromotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PromotionId,ProductId,StartedOn,EndedOn")] IndividualPromotion individualPromotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(individualPromotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", individualPromotion.ProductId);
            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "Id", individualPromotion.PromotionId);
            return View(individualPromotion);
        }

        // GET: Administration/IndividualPromotions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPromotion individualPromotion = db.IndividualPromotions.Find(id);
            if (individualPromotion == null)
            {
                return HttpNotFound();
            }
            return View(individualPromotion);
        }

        // POST: Administration/IndividualPromotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndividualPromotion individualPromotion = db.IndividualPromotions.Find(id);
            db.IndividualPromotions.Remove(individualPromotion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
