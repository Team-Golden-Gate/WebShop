namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System.Collections;
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
        protected override IEnumerable GetData()
        {
            var characteristicTypes = this.Data.CharacteristicTypes.All()
                .OrderBy(c => c.Position)
                .Project().To<CharacteristicTypesViewModel>();

            return characteristicTypes;
        }

        protected override object GetById(int? id)
        {
            return this.Data.CharacteristicValues.All()
                .Where(c => c.Id == id)
                .Project().To<CharacteristicValuesViewModel>()
                .FirstOrDefault();
        }

        protected override void GetIndexLogic()
        {
            this.GetTypesForList();
            base.GetIndexLogic();
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

        protected override void GetCreatLogic()
        {
            this.GetTypesForList();
            base.GetCreatLogic();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacteristicValuesViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.Create<CharacteristicValue>(model);
                return RedirectToAction("Index");
            }

            this.GetTypesForList();
            return View(model);
        }

        protected override void GetEditLogic(object obj)
        {
            var model = (CharacteristicValuesViewModel)obj;
            this.GetTypesForList(model.CharacteristicTypeId);
            base.GetEditLogic(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CharacteristicValuesViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.Edit<CharacteristicValue>(model);
                return RedirectToAction("Index");
            }

            this.GetTypesForList(model.CharacteristicTypeId);
            return View(model);
        }
       
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.Delete<CharacteristicValue>(id);
            return RedirectToAction("Index");
        }      

        [NonAction]
        public void GetTypesForList(object selectedId = null)
        {
            var characteristicTypes = this.GetData();
            //workaround so can have default html option in the view
            var options = new List<CharacteristicTypesViewModel>();
            options.Add(new CharacteristicTypesViewModel()
            {
                Id = 0,
                Name = "Choose characteristic type"
            });

            options.AddRange(characteristicTypes.Cast<CharacteristicTypesViewModel>().ToList());

            this.ViewBag.CharacteristicTypeId = new SelectList(options, "Id", "Name", selectedId);
        }
    }
}
