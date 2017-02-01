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
    public class AlunoController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = db.Alunos.Include(a => a.Curso);
            return View(alunos.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.Alunos.Find(id);
            if (alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.CursoID = new SelectList(db.Cursos, "Id", "Nome");
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CursoID")] AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(alunoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoID = new SelectList(db.Cursos, "Id", "Nome", alunoModel.CursoID);
            return View(alunoModel);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.Alunos.Find(id);
            if (alunoModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoID = new SelectList(db.Cursos, "Id", "Nome", alunoModel.CursoID);
            return View(alunoModel);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CursoID")] AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoID = new SelectList(db.Cursos, "Id", "Nome", alunoModel.CursoID);
            return View(alunoModel);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.Alunos.Find(id);
            if (alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoModel alunoModel = db.Alunos.Find(id);
            db.Alunos.Remove(alunoModel);
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
