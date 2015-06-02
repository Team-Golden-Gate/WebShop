namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using AutoMapper.QueryableExtensions;

    using GoldenGateShop.Data;
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Areas.Administration.ViewModels.CharacteristicValues;


    public class CharacteristicValuesAdminController : BaseAdminController
    {
        // GET: Administration/CharacteristicValues
        public ActionResult Index()
        {
            var characteristicTypes = this.Data.CharacteristicTypes.All()
                .OrderBy(c => c.Position)
                .Project().To<CharacteristicTypesViewModel>()
                .ToList();

            //work around so can have default html option in the view
            var options = new List<CharacteristicTypesViewModel>();
            options.Add(new CharacteristicTypesViewModel()
            {
                Id = 0,
                Name = "Choose characteristic type"
            });

            options.AddRange(characteristicTypes);

            characteristicTypes = options;

            this.ViewBag.ChracteristicTypesList = new SelectList(characteristicTypes, "Id", "Name");

            return View(characteristicTypes);
        }

        public ActionResult GetCharacteristicValuesByCharacteristicType(int? id)
        {
            //if (!this.Request.IsAjaxRequest())
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);    
            //}

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var characteristicValues = this.Data.CharacteristicValues.All()
                .Where(c => c.CharacteristicTypeId == id.Value)
                .OrderBy(c => c.Id)
                .Project().To<CharacteristicValuesViewModel>()
                .ToList();

            return this.PartialView(@"~\Areas\Administration\Views\CharacteristicValuesAdmin\_GetCharacteristicValuesByCharacteristicType.cshtml", characteristicValues);
        }

        // GET: Administration/CharacteristicValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var characteristicValue = this.Data.CharacteristicValues.All()
                .Where(c => c.Id == id)
                .Project().To<CharacteristicValuesViewModel>()
                .FirstOrDefault();

            if (characteristicValue == null)
            {
                return HttpNotFound();
            }
            return View(characteristicValue);
        }
        /*
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
         * */
    }
}
