namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using GoldenGateShop.Data;
    using GoldenGateShop.Models;
    using GoldenGateShop.Web.Areas.Administration.ViewModels.Trades;

    public class TradesAdminController : BaseAdminController
    {

        protected override IEnumerable GetData()
        {
            return this.Data.Trades.All()
                .OrderBy(t => t.Position)
                .Project().To<TradesViewModel>();
        }

        protected override object GetById(int? id)
        {
            return this.Data.Trades.All()
                .Where(x => x.Id == id)
                  .Project().To<TradesViewModel>()
                  .FirstOrDefault();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TradesViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.Create<Trade>(model);
                return RedirectToAction("Index");
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TradesViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.Edit<Trade>(model);
                return RedirectToAction("Index");
            }

            return this.View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.Delete<Trade>(id);
            return this.RedirectToAction("Index");
        }
    }
}
