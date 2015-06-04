namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using GoldenGateShop.Data;
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Areas.Administration.ViewModels.Categories;

    public class CategoriesAdminController : BaseAdminController
    {
        protected override IEnumerable GetData()
        {
            return this.Data.Categories.All()
                .OrderBy(c => c.Position)
                .Project().To<CategoriesViewModel>();
        }

        protected override object GetById(int? id)
        {
            return this.Data.Categories.All()
                .Where(c => c.Id == id.Value)
                .Project().To<CategoriesViewModel>()
                .FirstOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                this.Create<Category>(model);
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                this.Edit<Category>(model);
                return this.RedirectToAction("Index");
            }
            return this.View(model);
        }

        // POST: Administration/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.Delete<Category>(id);
            return this.RedirectToAction("Index");
        }
    }
}
