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
    public class ReceitaController : Controller
    {
        private XPTOContext db = new XPTOContext();

        // GET: Receita
        public ActionResult Index()
        {
            var receita = db.Receita.Include(r => r.Categoria).Include(r => r.Dificuldade).Include(r => r.Utilizador);
            return View(receita.ToList());
        }

        // GET: Receita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "CategoriaNome");
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "Dificuldade");
            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "UtilizadorID", "Username");
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceitaID,ReceitaNome,Duracao,Descricao,DificuldadeID,CategoriaID,UtilizadorID")] Receita receita)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Receita.Add(receita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Problema ao salvar os dados. Tente novamente, se o problema persistir contate o administrador do sistema");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "CategoriaNome", receita.CategoriaID);
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "Dificuldade", receita.DificuldadeID);
            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "UtilizadorID", "Username", receita.UtilizadorID);
            return View(receita);
        }

        // GET: Receita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "CategoriaNome", receita.CategoriaID);
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "Dificuldade", receita.DificuldadeID);
            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "UtilizadorID", "Username", receita.UtilizadorID);
            return View(receita);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceitaID,ReceitaNome,Duracao,Descricao,DificuldadeID,CategoriaID,UtilizadorID")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "CategoriaID", "CategoriaNome", receita.CategoriaID);
            ViewBag.DificuldadeID = new SelectList(db.Dificuldade, "DificuldadeID", "Dificuldade", receita.DificuldadeID);
            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "UtilizadorID", "Username", receita.UtilizadorID);
            return View(receita);
        }

        // GET: Receita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receita.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = db.Receita.Find(id);
            db.Receita.Remove(receita);
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
