using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Top2000.Models;

namespace Top2000.Controllers
{
    public class StatsController : Controller
    {
        Top2000Entities db = new Top2000Entities();
        // GET: Jaarlijst
        public ActionResult Yearlist(int? page, int selectYear = 0, string currentFilter = "", string searchString = "", string sortOrder = "")
        {
            if (selectYear == 0)
            {
                selectYear = db.Top2000Jaar.Max(j => j.Jaar); // highest value of year
                ViewBag.year = selectYear;
            }

            ViewBag.year = selectYear;
            ViewBag.selectYear = new SelectList(db.Top2000Jaar, "Jaar", "Titel", selectYear);

            if (searchString == "") currentFilter = "";
            if (searchString != "") ViewBag.CurrentFilter = searchString;
            else ViewBag.CurrentFilter = currentFilter;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IPagedList items;

            switch (sortOrder)
            {
                case "positie_desc":
                    items = db.fsspTOP2000Year(selectYear, 2000).OrderByDescending(a => a.POSITIE).ToList().ToPagedList(pageNumber, pageSize);
                    ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Count();
                    return View(items);

                case "positie_ascc":
                    items = db.fsspTOP2000Year(selectYear, 2000).OrderBy(a => a.POSITIE).ToList().ToPagedList(pageNumber, pageSize);
                    ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Count();
                    return View(items);


                case "name_desc":

                    if (searchString.Trim() != "")
                    {
                        //page = 1;
                        items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).OrderByDescending(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                        ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).Count();
                        return View(items);
                    }
                    else
                    {
                        ViewBag.CurrentFilter = currentFilter;
                        if (currentFilter != "")
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).OrderByDescending(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).Count();
                            return View(items);
                        }
                        else
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).OrderByDescending(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Count();
                            return View(items);
                        }
                    }
                case "name_ascc":
                    if (searchString.Trim() != "")
                    {
                        //page = 1;
                        items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).OrderBy(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                        ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).Count();
                        return View(items);
                    }
                    else
                    {
                        ViewBag.CurrentFilter = currentFilter;
                        if (currentFilter != "")
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).OrderBy(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).Count();
                            return View(items);
                        }
                        else
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).OrderBy(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Count();
                            return View(items);
                        }
                    }
                case "title_desc":
                    if (searchString.Trim() != "")
                    {
                        //page = 1;
                        items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).OrderByDescending(a => a.TITEL).ToList().ToPagedList(pageNumber, pageSize);
                        ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).Count();
                        return View(items);
                    }
                    else
                    {
                        ViewBag.CurrentFilter = currentFilter;
                        if (currentFilter != "")
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).OrderByDescending(a => a.TITEL).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).Count();
                            return View(items);
                        }
                        else
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).OrderByDescending(a => a.TITEL).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Count();
                            return View(items);
                        }
                    }
                case "title_ascc":
                    if (searchString.Trim() != "")
                    {
                        //page = 1;
                        items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).OrderBy(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                        ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).Count();
                        return View(items);
                    }
                    else
                    {
                        ViewBag.CurrentFilter = currentFilter;
                        if (currentFilter != "")
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).OrderBy(a => a.NAAM).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                                a.NAAM.ToLower().Contains(currentFilter.ToLower())).Count();
                            return View(items);
                        }
                        else
                        {
                            items = db.fsspTOP2000Year(selectYear, 2000).OrderBy(a => a.TITEL).ToList().ToPagedList(pageNumber, pageSize);
                            ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Count();
                            return View(items);
                        }
                    }
                default:
                    if (searchString.Trim() != "")
                    {
                        //page = 1;
                        ViewBag.CurrentFilter = searchString;
                        items = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).OrderBy(a => a.POSITIE).ToList().ToPagedList(pageNumber, pageSize);
                        ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Where(a => a.TITEL.ToLower().Contains(searchString.ToLower()) ||
                            a.NAAM.ToLower().Contains(searchString.ToLower())).Count();
                        return View(items);
                    }
                    else
                    {
                        ViewBag.CurrentFilter = currentFilter;
                        items = db.fsspTOP2000Year(selectYear, 2000).OrderBy(a => a.POSITIE).ToList().ToPagedList(pageNumber, pageSize);
                        ViewBag.countResults = db.fsspTOP2000Year(selectYear, 2000).Count();
                        return View(items);

                    }


            }

            
        }

        public ActionResult SongDetails(int? id)
        {
            id = id ?? 1000;

            var list = db.Lijst.Where(l => l.Songid == id);


            List<DataPoint> dataPoints = new List<DataPoint> { };

            foreach (var s in list)
            {
                dataPoints.Add(new DataPoint(s.Top2000jaar, s.Positie));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            ViewBag.songid = id;

            var song = db.Song.Where(l => l.Songid == id);
            ViewBag.songTitel = song.First();

            return View(song.ToList());
        }
    }
}