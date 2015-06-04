namespace GoldenGateShop.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Net;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using GoldenGateShop.Web.Controllers;
    using GoldenGateShop.Web.Areas.Administration.ViewModels.Categories;
    using GoldenGateShop.Contracts;


    [Authorize(Roles = "Administrator")]
    public abstract class BaseAdminController : BaseController
    {
        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.ViewBag.Location = "AdminArea";
            return base.BeginExecute(requestContext, callback, state);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            this.ViewBag.SubLocation = filterContext.RouteData.Values["Controller"].ToString();
            base.OnResultExecuting(filterContext);
        }

        protected virtual IEnumerable GetData() { return null; }

        protected virtual object GetById(int? id) { return null; }

        protected virtual void GetIndexLogic() { }

        protected virtual void GetCreatLogic() { }

        protected virtual void GetEditLogic(object obj) { }

        protected virtual void GetDetailsLogic() { }

        protected virtual void GetDeleteLogic() { }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var data = this.GetData();
            this.GetIndexLogic();
            return this.View(data);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            this.GetCreatLogic();
            return this.View();
        }

        [HttpGet]
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var obj = this.GetById(id.Value);

            if (obj == null)
            {
                return HttpNotFound();
            }

            this.GetDetailsLogic();
            return this.View(obj);
        }

        [HttpGet]
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var obj = this.GetById(id.Value);

            if (obj == null)
            {
                return HttpNotFound();
            }

            this.GetEditLogic(obj);
            return this.View(obj);
        }

        [HttpGet]
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var obj = this.GetById(id.Value);

            if (obj == null)
            {
                return HttpNotFound();
            }

            this.GetDeleteLogic();
            return this.View(obj);
        }



        [NonAction]
        protected virtual void Create<T>(object model) where T : class
        {
            var dbModel = Mapper.Map<T>(model);
            this.ChangeEntityStateAndSave(dbModel, EntityState.Added);
        }

        [NonAction]
        protected virtual void Edit<T>(object model) where T : class
        {
            var dbModel = Mapper.Map<T>(model);
            this.ChangeEntityStateAndSave(dbModel, EntityState.Modified);

        }

        [NonAction]
        public virtual void Delete<T>(int id)
        {
            var obj = this.GetById(id);
            var dbModel = Mapper.Map<T>(obj);
            this.ChangeEntityStateAndSave(dbModel, EntityState.Deleted);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }

            base.Dispose(disposing);
        }

        private void ChangeEntityStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dbModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}