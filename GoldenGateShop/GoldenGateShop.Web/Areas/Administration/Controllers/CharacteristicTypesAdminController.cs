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
    public class CharacteristicTypesAdminController : BaseAdminController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Administration/CharacteristicTypes
        public ActionResult Index()
        {
            return View(db.CharacteristicTypes.ToList());
        }

        // GET: Administration/CharacteristicTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicType characteristicType = db.CharacteristicTypes.Find(id);
            if (characteristicType == null)
            {
                return HttpNotFound();
            }
            return View(characteristicType);
        }

        // GET: Administration/CharacteristicTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/CharacteristicTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position,FilterType")] CharacteristicType characteristicType)
        {
            if (ModelState.IsValid)
            {
                db.CharacteristicTypes.Add(characteristicType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(characteristicType);
        }

        // GET: Administration/CharacteristicTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicType characteristicType = db.CharacteristicTypes.Find(id);
            if (characteristicType == null)
            {
                return HttpNotFound();
            }
            return View(characteristicType);
        }

        // POST: Administration/CharacteristicTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position,FilterType")] CharacteristicType characteristicType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characteristicType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(characteristicType);
        }

        // GET: Administration/CharacteristicTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicType characteristicType = db.CharacteristicTypes.Find(id);
            if (characteristicType == null)
            {
                return HttpNotFound();
            }
            return View(characteristicType);
        }

        // POST: Administration/CharacteristicTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharacteristicType characteristicType = db.CharacteristicTypes.Find(id);
            db.CharacteristicTypes.Remove(characteristicType);
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
