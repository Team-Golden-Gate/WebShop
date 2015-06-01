namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
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
        // GET: Administration/Trades
        public ActionResult Index()
        {
            var trades = this.Data.Trades.All()
                .OrderBy(t => t.Position)
                .Project().To<TradesViewModel>()
                .ToList();

            return this.View(trades);
        }

        // GET: Administration/Trades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var trade = this.Data.Trades.All()
                .Where(x => x.Id == id)
                  .Project().To<TradesViewModel>()
                  .FirstOrDefault();

            if (trade == null)
            {
                return this.HttpNotFound();
            }

            return this.View(trade);
        }

        // GET: Administration/Trades/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Trades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                this.Data.Trades.Add(trade);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return this.View(trade);
        }

        // GET: Administration/Trades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Trade trade = this.Data.Trades.GetById(id);

            if (trade == null)
            {
                return HttpNotFound();
            }

            return this.View(trade);
        }

        // POST: Administration/Trades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                this.Data.Trades.Update(trade);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return this.View(trade);
        }

        // GET: Administration/Trades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Trade trade = this.Data.Trades.GetById(id);

            if (trade == null)
            {
                return this.HttpNotFound();
            }

            return this.View(trade);
        }

        // POST: Administration/Trades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trade trade = this.Data.Trades.GetById(id);
            this.Data.Trades.Delete(trade);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
