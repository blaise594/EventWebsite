using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UpcomingEvents.Models;

namespace UpcomingEvents.Controllers
{
    [Authorize]
    public class EventModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        string eventCacheKey = "events";

       

        // GET: EventModels
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Genre).Include(e => e.Venue);
            return View(events.ToList());
        }

        // GET: EventModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // GET: EventModels/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "id", "type");
            ViewBag.VenueId = new SelectList(db.Venues, "id", "name");
            return View();
        }

        // POST: EventModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,description,starttime,endtime,VenueId,GenreId")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(eventModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "id", "type", eventModel.GenreId);
            ViewBag.VenueId = new SelectList(db.Venues, "id", "name", eventModel.VenueId);
            return View(eventModel);
        }

        // GET: EventModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "id", "type", eventModel.GenreId);
            ViewBag.VenueId = new SelectList(db.Venues, "id", "name", eventModel.VenueId);
            return View(eventModel);
        }

        // POST: EventModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,description,starttime,endtime,VenueId,GenreId")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventModel).State = EntityState.Modified;
                db.SaveChanges();
                HttpRuntime.Cache.Remove(eventCacheKey);
                // re-add to the my cache
                var data = new ApplicationDbContext().Events.Include(i => i.Genre).Include(i => i.Venue).ToList();
                HttpRuntime.Cache.Add(
                  eventCacheKey,
                  data,
                  null,
                  DateTime.Now.AddDays(13),
                  new TimeSpan(),
                  System.Web.Caching.CacheItemPriority.High,
                  null
                  );
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "id", "type", eventModel.GenreId);
            ViewBag.VenueId = new SelectList(db.Venues, "id", "name", eventModel.VenueId);
            return View(eventModel);
        }

        // GET: EventModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // POST: EventModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventModel eventModel = db.Events.Find(id);
            db.Events.Remove(eventModel);
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
