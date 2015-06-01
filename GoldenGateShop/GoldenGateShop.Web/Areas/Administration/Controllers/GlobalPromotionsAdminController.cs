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
    public class GlobalPromotionsAdminController : BaseAdminController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Administration/GlobalPromotions
        public ActionResult Index()
        {
            return View(db.GlobalPromotions.ToList());
        }

        // GET: Administration/GlobalPromotions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalPromotion globalPromotion = db.GlobalPromotions.Find(id);
            if (globalPromotion == null)
            {
                return HttpNotFound();
            }
            return View(globalPromotion);
        }

        // GET: Administration/GlobalPromotions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/GlobalPromotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartedOn,EndedOn")] GlobalPromotion globalPromotion)
        {
            if (ModelState.IsValid)
            {
                db.GlobalPromotions.Add(globalPromotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(globalPromotion);
        }

        // GET: Administration/GlobalPromotions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalPromotion globalPromotion = db.GlobalPromotions.Find(id);
            if (globalPromotion == null)
            {
                return HttpNotFound();
            }
            return View(globalPromotion);
        }

        // POST: Administration/GlobalPromotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartedOn,EndedOn")] GlobalPromotion globalPromotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(globalPromotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(globalPromotion);
        }

        // GET: Administration/GlobalPromotions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalPromotion globalPromotion = db.GlobalPromotions.Find(id);
            if (globalPromotion == null)
            {
                return HttpNotFound();
            }
            return View(globalPromotion);
        }

        // POST: Administration/GlobalPromotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlobalPromotion globalPromotion = db.GlobalPromotions.Find(id);
            db.GlobalPromotions.Remove(globalPromotion);
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
