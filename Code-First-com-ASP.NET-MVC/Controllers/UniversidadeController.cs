using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Code_First_com_ASP.NET_MVC.Context;
using Code_First_com_ASP.NET_MVC.Models;

namespace Code_First_com_ASP.NET_MVC.Controllers
{
    public class UniversidadeController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Universidade
        public ActionResult Index()
        {
            return View(db.Universidades.ToList());
        }

        // GET: Universidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversidadeModel universidadeModel = db.Universidades.Find(id);
            if (universidadeModel == null)
            {
                return HttpNotFound();
            }
            return View(universidadeModel);
        }

        // GET: Universidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cidade,UF")] UniversidadeModel universidadeModel)
        {
            if (ModelState.IsValid)
            {
                db.Universidades.Add(universidadeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universidadeModel);
        }

        // GET: Universidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversidadeModel universidadeModel = db.Universidades.Find(id);
            if (universidadeModel == null)
            {
                return HttpNotFound();
            }
            return View(universidadeModel);
        }

        // POST: Universidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cidade,UF")] UniversidadeModel universidadeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universidadeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universidadeModel);
        }

        // GET: Universidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversidadeModel universidadeModel = db.Universidades.Find(id);
            if (universidadeModel == null)
            {
                return HttpNotFound();
            }
            return View(universidadeModel);
        }

        // POST: Universidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UniversidadeModel universidadeModel = db.Universidades.Find(id);
            db.Universidades.Remove(universidadeModel);
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
