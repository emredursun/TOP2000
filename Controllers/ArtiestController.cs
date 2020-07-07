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

namespace Top2000.Controllers
{
    public class ArtiestController : Controller
    {
        private Top2000Entities db = new Top2000Entities();

        // GET: Artiest
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // sorting for pages sortOrder
            ViewBag.CurrentSort = sortOrder;

            //sorting
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            //declare variable for sortOrder
            var artiests = from s in db.Artiest
                           select s;

            //paging check
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;




            // add a search box
            if (!String.IsNullOrEmpty(searchString))
            {
                artiests = artiests.Where(s => s.Naam.Contains(searchString));

            }

            // add column sort links
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    artiests = artiests.OrderByDescending(s => s.Naam);
                    break;
                default:
                    artiests = artiests.OrderBy(s => s.Naam);
                    break;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(artiests.ToPagedList(pageNumber, pageSize));
        }

        // GET: Artiest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiest artiest = db.Artiest.Find(id);
            if (artiest == null)
            {
                return HttpNotFound();
            }
            return View(artiest);
        }

        // GET: Artiest/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artiest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Artiestid,Naam,Afbeelding,Biografie,Wikipedialink")] Artiest artiest)
        {
            if (ModelState.IsValid)
            {
                db.Artiest.Add(artiest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artiest);
        }

        // GET: Artiest/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiest artiest = db.Artiest.Find(id);
            if (artiest == null)
            {
                return HttpNotFound();
            }
            return View(artiest);
        }

        // POST: Artiest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Artiestid,Naam,Afbeelding,Biografie,Wikipedialink")] Artiest artiest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artiest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artiest);
        }

        // GET: Artiest/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiest artiest = db.Artiest.Find(id);
            if (artiest == null)
            {
                return HttpNotFound();
            }
            return View(artiest);
        }

        // POST: Artiest/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artiest artiest = db.Artiest.Find(id);
            db.Artiest.Remove(artiest);
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
