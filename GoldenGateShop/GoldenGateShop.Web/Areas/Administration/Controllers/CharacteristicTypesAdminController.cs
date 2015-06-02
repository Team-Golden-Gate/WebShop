namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using GoldenGateShop.Data;
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Areas.Administration.ViewModels.CharcacteristicTypes;

    public class CharacteristicTypesAdminController : BaseAdminController
    {
        // GET: Administration/CharacteristicTypes
        public ActionResult Index()
        {
            var characteristicTypes = this.Data.CharacteristicTypes.All()
                .OrderBy(c => c.Position)
                .Project().To<CharacteristicTypesViewModel>()
                .ToList();

            return View(characteristicTypes);
        }

        // GET: Administration/CharacteristicTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var characteristicType = this.Data.CharacteristicTypes.All()
                 .Where(c => c.Id == id)
                 .Project().To<CharacteristicTypesViewModel>()
                 .FirstOrDefault();

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
                this.Data.CharacteristicTypes.Add(characteristicType);
                this.Data.SaveChanges();
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
            var characteristicType = this.Data.CharacteristicTypes.GetById(id);

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
                this.Data.CharacteristicTypes.Update(characteristicType);
                this.Data.SaveChanges();
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
            var characteristicType = this.Data.CharacteristicTypes.GetById(id);
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
            CharacteristicType characteristicType = this.Data.CharacteristicTypes.GetById(id);
            this.Data.CharacteristicTypes.Delete(characteristicType);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
