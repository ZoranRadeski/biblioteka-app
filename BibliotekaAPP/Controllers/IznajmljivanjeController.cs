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
    public class IznajmljivanjeController : Controller
    {
        private BibliotekaDBEntities db = new BibliotekaDBEntities();

        // GET: Iznajmljivanje
        public ActionResult Index()
        {
            var iznajmljivanjes = db.Iznajmljivanjes.Include(i => i.Knjige).Include(i => i.Korisnici);
            return View(iznajmljivanjes.ToList());
        }

        // GET: Iznajmljivanje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iznajmljivanje iznajmljivanje = db.Iznajmljivanjes.Find(id);
            if (iznajmljivanje == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljivanje);
        }

        // GET: Iznajmljivanje/Create
        public ActionResult Create()
        {
            ViewBag.KnjigaID = new SelectList(db.Knjiges, "KnjigaID", "Naslov");
            ViewBag.KorisnikID = new SelectList(db.Korisnicis, "KorisnikID", "Ime");
            return View();
        }

        // POST: Iznajmljivanje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IznajmljivanjeID,KorisnikID,KnjigaID,DatumIznajmljivanja")] Iznajmljivanje iznajmljivanje)
        {
            if (ModelState.IsValid)
            {
                db.Iznajmljivanjes.Add(iznajmljivanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KnjigaID = new SelectList(db.Knjiges, "KnjigaID", "Naslov", iznajmljivanje.KnjigaID);
            ViewBag.KorisnikID = new SelectList(db.Korisnicis, "KorisnikID", "Ime", iznajmljivanje.KorisnikID);
            return View(iznajmljivanje);
        }

        // GET: Iznajmljivanje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iznajmljivanje iznajmljivanje = db.Iznajmljivanjes.Find(id);
            if (iznajmljivanje == null)
            {
                return HttpNotFound();
            }
            ViewBag.KnjigaID = new SelectList(db.Knjiges, "KnjigaID", "Naslov", iznajmljivanje.KnjigaID);
            ViewBag.KorisnikID = new SelectList(db.Korisnicis, "KorisnikID", "Ime", iznajmljivanje.KorisnikID);
            return View(iznajmljivanje);
        }

        // POST: Iznajmljivanje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IznajmljivanjeID,KorisnikID,KnjigaID,DatumIznajmljivanja")] Iznajmljivanje iznajmljivanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iznajmljivanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KnjigaID = new SelectList(db.Knjiges, "KnjigaID", "Naslov", iznajmljivanje.KnjigaID);
            ViewBag.KorisnikID = new SelectList(db.Korisnicis, "KorisnikID", "Ime", iznajmljivanje.KorisnikID);
            return View(iznajmljivanje);
        }

        // GET: Iznajmljivanje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iznajmljivanje iznajmljivanje = db.Iznajmljivanjes.Find(id);
            if (iznajmljivanje == null)
            {
                return HttpNotFound();
            }
            return View(iznajmljivanje);
        }

        // POST: Iznajmljivanje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iznajmljivanje iznajmljivanje = db.Iznajmljivanjes.Find(id);
            db.Iznajmljivanjes.Remove(iznajmljivanje);
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
