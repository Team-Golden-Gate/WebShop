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
    public class CharacteristicValuesAdminController : BaseAdminController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Administration/CharacteristicValues
        public ActionResult Index()
        {
            var characteristicValues = db.CharacteristicValues.Include(c => c.CharacteristicType);
            return View(characteristicValues.ToList());
        }

        // GET: Administration/CharacteristicValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicValue characteristicValue = db.CharacteristicValues.Find(id);
            if (characteristicValue == null)
            {
                return HttpNotFound();
            }
            return View(characteristicValue);
        }

        // GET: Administration/CharacteristicValues/Create
        public ActionResult Create()
        {
            ViewBag.CharacteristicTypeId = new SelectList(db.CharacteristicTypes, "Id", "Name");
            return View();
        }

        // POST: Administration/CharacteristicValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,Description,CharacteristicTypeId")] CharacteristicValue characteristicValue)
        {
            if (ModelState.IsValid)
            {
                db.CharacteristicValues.Add(characteristicValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacteristicTypeId = new SelectList(db.CharacteristicTypes, "Id", "Name", characteristicValue.CharacteristicTypeId);
            return View(characteristicValue);
        }

        // GET: Administration/CharacteristicValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicValue characteristicValue = db.CharacteristicValues.Find(id);
            if (characteristicValue == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacteristicTypeId = new SelectList(db.CharacteristicTypes, "Id", "Name", characteristicValue.CharacteristicTypeId);
            return View(characteristicValue);
        }

        // POST: Administration/CharacteristicValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,Description,CharacteristicTypeId")] CharacteristicValue characteristicValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characteristicValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacteristicTypeId = new SelectList(db.CharacteristicTypes, "Id", "Name", characteristicValue.CharacteristicTypeId);
            return View(characteristicValue);
        }

        // GET: Administration/CharacteristicValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharacteristicValue characteristicValue = db.CharacteristicValues.Find(id);
            if (characteristicValue == null)
            {
                return HttpNotFound();
            }
            return View(characteristicValue);
        }

        // POST: Administration/CharacteristicValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharacteristicValue characteristicValue = db.CharacteristicValues.Find(id);
            db.CharacteristicValues.Remove(characteristicValue);
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
