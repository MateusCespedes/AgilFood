using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgilFoods.Context;
using AgilFoods.Models;

namespace AgilFoods.Controllers
{
    public class GeraCardapiosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: GeraCardapios
        public ActionResult Index()
        {
            var geraCardapio = db.GeraCardapio.Include(g => g.Fornecedor);
            return View(geraCardapio.ToList());
        }

        // GET: GeraCardapios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeraCardapio geraCardapio = db.GeraCardapio.Find(id);
            if (geraCardapio == null)
            {
                return HttpNotFound();
            }
            return View(geraCardapio);
        }

        // GET: GeraCardapios/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "RazaoSocial");
            return View();
        }

        // POST: GeraCardapios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DiaSemana,FornecedorId")] GeraCardapio geraCardapio)
        {
            if (ModelState.IsValid)
            {
                db.GeraCardapio.Add(geraCardapio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "RazaoSocial", geraCardapio.FornecedorId);
            return View(geraCardapio);
        }

        // GET: GeraCardapios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeraCardapio geraCardapio = db.GeraCardapio.Find(id);
            if (geraCardapio == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "RazaoSocial", geraCardapio.FornecedorId);
            return View(geraCardapio);
        }

        // POST: GeraCardapios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DiaSemana,FornecedorId")] GeraCardapio geraCardapio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geraCardapio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "RazaoSocial", geraCardapio.FornecedorId);
            return View(geraCardapio);
        }

        // GET: GeraCardapios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeraCardapio geraCardapio = db.GeraCardapio.Find(id);
            if (geraCardapio == null)
            {
                return HttpNotFound();
            }
            return View(geraCardapio);
        }

        // POST: GeraCardapios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeraCardapio geraCardapio = db.GeraCardapio.Find(id);
            db.GeraCardapio.Remove(geraCardapio);
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
