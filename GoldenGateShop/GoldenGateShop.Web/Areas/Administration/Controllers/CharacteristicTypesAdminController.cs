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
    using System.Collections;

    public class CharacteristicTypesAdminController : BaseAdminController
    {
        protected override IEnumerable GetData()
        {
            return this.Data.CharacteristicTypes.All()
                 .OrderBy(c => c.Position)
                 .Project().To<CharacteristicTypesViewModel>();
        }

        protected override object GetById(int? id)
        {
            return this.Data.CharacteristicTypes.All()
                 .Where(c => c.Id == id)
                 .Project().To<CharacteristicTypesViewModel>()
                 .FirstOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacteristicTypesViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.Create<CharacteristicType>(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharacteristicTypesViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.Edit<CharacteristicType>(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // POST: Administration/CharacteristicTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.Delete<CharacteristicType>(id);
            return RedirectToAction("Index");
        }
    }
}
