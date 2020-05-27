using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dari.Data;
using Dari.Domain.Entities;

namespace Dari.web.Controllers
{
    public class MeublesController : Controller
    {
        private DariContext db = new DariContext();

        // GET: Meubles
        public ActionResult Index()
        {
            var meubles = db.Meubles.Include(m => m.Client);
            return View(meubles.ToList());
        }

        // GET: Meubles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meuble meuble = db.Meubles.Find(id);
            if (meuble == null)
            {
                return HttpNotFound();
            }
            return View(meuble);
        }

        // GET: Meubles/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom");
            return View();
        }

        // POST: Meubles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMeuble,Titre,Category,Image,Description,Prix,Livraison,Etat,Disponibilite,dateAnn,IdClient")] Meuble meuble)
        {
            if (ModelState.IsValid)
            {
                db.Meubles.Add(meuble);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom", meuble.IdClient);
            return View(meuble);
        }

        // GET: Meubles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meuble meuble = db.Meubles.Find(id);
            if (meuble == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom", meuble.IdClient);
            return View(meuble);
        }

        // POST: Meubles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMeuble,Titre,Category,Image,Description,Prix,Livraison,Etat,Disponibilite,dateAnn,IdClient")] Meuble meuble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meuble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom", meuble.IdClient);
            return View(meuble);
        }

        // GET: Meubles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meuble meuble = db.Meubles.Find(id);
            if (meuble == null)
            {
                return HttpNotFound();
            }
            return View(meuble);
        }

        // POST: Meubles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meuble meuble = db.Meubles.Find(id);
            db.Meubles.Remove(meuble);
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
