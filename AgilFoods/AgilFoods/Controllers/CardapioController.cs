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
    public class CardapioController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Cardapios
        public ActionResult Index()
        {
            return View(db.Cardapio.ToList());
        }

        // GET: Cardapios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cardapio cardapio = db.Cardapio.Find(id);
            if (cardapio == null)
            {
                return HttpNotFound();
            }
            return View(cardapio);
        }

        // GET: Cardapios/Create
        public ActionResult Create()
        {
            DBContext db = new DBContext();
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "RazaoSocial");
            return View();
        }

        // POST: Cardapios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescricaoItem,FornecedorId")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                db.Cardapio.Add(cardapio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cardapio);
        }

        // GET: Cardapios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cardapio cardapio = db.Cardapio.Find(id);
            DBContext dbFornecedor = new DBContext();
            ViewBag.FornecedorId = new SelectList(dbFornecedor.Fornecedor, "Id", "RazaoSocial", cardapio.FornecedorId);
            if (cardapio == null)
            {
                return HttpNotFound();
            }
            return View(cardapio);
        }

        // POST: Cardapios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescricaoItem,FornecedorId")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardapio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardapio);
        }

        // GET: Cardapios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cardapio cardapio = db.Cardapio.Find(id);
            if (cardapio == null)
            {
                return HttpNotFound();
            }
            return View(cardapio);
        }

        // POST: Cardapios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cardapio cardapio = db.Cardapio.Find(id);
            db.Cardapio.Remove(cardapio);
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
