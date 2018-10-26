using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotekaAPP.Models;

namespace BibliotekaAPP.Controllers
{
    public class KnjigeController : Controller
    {
        private BibliotekaDBEntities db = new BibliotekaDBEntities();

        // GET: Knjige
        public ActionResult Index()
        {
            return View(db.Knjiges.ToList());
        }

        // GET: Knjige/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjige knjige = db.Knjiges.Find(id);
            if (knjige == null)
            {
                return HttpNotFound();
            }
            return View(knjige);
        }

        // GET: Knjige/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Knjige/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KnjigaID,Naslov,Pisac,Kategorija")] Knjige knjige)
        {
            if (ModelState.IsValid)
            {
                db.Knjiges.Add(knjige);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knjige);
        }

        // GET: Knjige/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjige knjige = db.Knjiges.Find(id);
            if (knjige == null)
            {
                return HttpNotFound();
            }
            return View(knjige);
        }

        // POST: Knjige/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KnjigaID,Naslov,Pisac,Kategorija")] Knjige knjige)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjige).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knjige);
        }

        // GET: Knjige/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjige knjige = db.Knjiges.Find(id);
            if (knjige == null)
            {
                return HttpNotFound();
            }
            return View(knjige);
        }

        // POST: Knjige/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knjige knjige = db.Knjiges.Find(id);
            db.Knjiges.Remove(knjige);
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
