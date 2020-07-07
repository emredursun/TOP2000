using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Top2000.Models;
using PagedList;
using PagedList.Mvc;
using Newtonsoft.Json;

namespace Top2000.Controllers
{
    public class SongController : Controller
    {
        private Top2000Entities db = new Top2000Entities();

        // GET: Song
        public ActionResult Index(int? page, string currentFilter = "", string searchString = "")
        {
            if (searchString == "") currentFilter = "";
            if (searchString != "") ViewBag.CurrentFilter = searchString;
            else ViewBag.CurrentFilter = currentFilter;
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (searchString.Trim() != "")
            {
                ViewBag.CurrentFilter = searchString;
                //page = 1;
                return View(db.Song
                    .Where(a => a.Titel.ToLower().Contains(searchString.ToLower()) ||
                    a.Artiest.Naam.ToLower().Contains(searchString.ToLower()))
                    .OrderBy(a => a.Titel)
                    .ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.CurrentFilter = currentFilter;
                return View(db.Song.OrderBy(a => a.Titel)
                    .ToPagedList(pageNumber, pageSize));

            }
        }

        // GET: Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }

            var list = db.Lijst.Where(l => l.Songid == id);


            List<DataPoint> dataPoints = new List<DataPoint> { };

            foreach (var s in list)
            {
                dataPoints.Add(new DataPoint(s.Top2000jaar, s.Positie));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            ViewBag.songid = id;
            return View(song);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            ViewBag.Artiestid = new SelectList(db.Artiest, "Artiestid", "Naam");
            return View();
        }

        // POST: Song/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Songid,Artiestid,Titel,Jaar,Songtekst")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Song.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Artiestid = new SelectList(db.Artiest, "Artiestid", "Naam", song.Artiestid);
            return View(song);
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.Artiestid = new SelectList(db.Artiest, "Artiestid", "Naam", song.Artiestid);
            return View(song);
        }

        // POST: Song/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Songid,Artiestid,Titel,Jaar,Songtekst")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Artiestid = new SelectList(db.Artiest, "Artiestid", "Naam", song.Artiestid);
            return View(song);
        }

        //// GET: Song/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Song song = db.Song.Find(id);
        //    if (song == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(song);
        //}

        //// POST: Song/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Song song = db.Song.Find(id);
        //    db.Song.Remove(song);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
