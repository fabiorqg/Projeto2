using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Receitas_XPTO.DAL;
using Receitas_XPTO.Models;

namespace Receitas_XPTO.Controllers
{
    public class GrauDificuldadeController : Controller
    {
        private XPTOContext db = new XPTOContext();

        // GET: GrauDificuldade
        public ActionResult Index()
        {
            return View(db.Dificuldade.ToList());
        }

        // GET: GrauDificuldade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrauDificuldade grauDificuldade = db.Dificuldade.Find(id);
            if (grauDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(grauDificuldade);
        }

        // GET: GrauDificuldade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrauDificuldade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DificuldadeID,Dificuldade")] GrauDificuldade grauDificuldade)
        {
            try
            {

                if (ModelState.IsValid)
            {
                db.Dificuldade.Add(grauDificuldade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Problema ao salvar os dados. Tente novamente, se o problema persistir contate o administrador do sistema");
            }

            return View(grauDificuldade);
        }

        // GET: GrauDificuldade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrauDificuldade grauDificuldade = db.Dificuldade.Find(id);
            if (grauDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(grauDificuldade);
        }

        // POST: GrauDificuldade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DificuldadeID,Dificuldade")] GrauDificuldade grauDificuldade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grauDificuldade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grauDificuldade);
        }

        // GET: GrauDificuldade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrauDificuldade grauDificuldade = db.Dificuldade.Find(id);
            if (grauDificuldade == null)
            {
                return HttpNotFound();
            }
            return View(grauDificuldade);
        }

        // POST: GrauDificuldade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrauDificuldade grauDificuldade = db.Dificuldade.Find(id);
            db.Dificuldade.Remove(grauDificuldade);
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
