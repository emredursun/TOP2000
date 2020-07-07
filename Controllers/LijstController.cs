using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Top2000.Models;


namespace Top2000.Controllers
{
    public class LijstController : Controller
    {
        private Top2000Entities db = new Top2000Entities();

        // GET: Lijst
        public ActionResult Index(int year = 0, int amount = 2000)
        {
            if (year == 0)
            {
                year = db.Top2000Jaar.Max(j => j.Jaar); // highest value for year
            }
            var list = db.fsspTOP2000Year(year, amount);
            return View(list.ToList());
            //var lijst = db.Lijst.Where(l => l.Top2000jaar == 2010).OrderBy(l => l.Positie);

        }

        // GET: Lijst/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lijst lijst = db.Lijst.Find(id);
            if (lijst == null)
            {
                return HttpNotFound();
            }
            return View(lijst);
        }

        // GET: Lijst/Create
        public ActionResult Create()
        {
            ViewBag.Songid = new SelectList(db.Song, "Songid", "Titel");
            ViewBag.Top2000jaar = new SelectList(db.Top2000Jaar, "Jaar", "Titel");
            return View();
        }

        // POST: Lijst/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Songid,Top2000jaar,Positie")] Lijst lijst)
        {
            if (ModelState.IsValid)
            {
                db.Lijst.Add(lijst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Songid = new SelectList(db.Song, "Songid", "Titel", lijst.Songid);
            ViewBag.Top2000jaar = new SelectList(db.Top2000Jaar, "Jaar", "Titel", lijst.Top2000jaar);
            return View(lijst);
        }

        // GET: Lijst/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lijst lijst = db.Lijst.Find(id);
            if (lijst == null)
            {
                return HttpNotFound();
            }
            ViewBag.Songid = new SelectList(db.Song, "Songid", "Titel", lijst.Songid);
            ViewBag.Top2000jaar = new SelectList(db.Top2000Jaar, "Jaar", "Titel", lijst.Top2000jaar);
            return View(lijst);
        }

        // POST: Lijst/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Songid,Top2000jaar,Positie")] Lijst lijst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lijst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Songid = new SelectList(db.Song, "Songid", "Titel", lijst.Songid);
            ViewBag.Top2000jaar = new SelectList(db.Top2000Jaar, "Jaar", "Titel", lijst.Top2000jaar);
            return View(lijst);
        }

        // GET: Lijst/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lijst lijst = db.Lijst.Find(id);
            if (lijst == null)
            {
                return HttpNotFound();
            }
            return View(lijst);
        }

        // POST: Lijst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lijst lijst = db.Lijst.Find(id);
            db.Lijst.Remove(lijst);
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
