using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Airport_Management_System.Models;

namespace Airport_Management_System.Controllers
{
    public class BoardingsController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Boardings
        public ActionResult Index()
        {
            var boardings = db.Boardings.Include(b => b.Gate).Include(b => b.Schedule);
            return View(boardings.ToList());
        }

        // GET: Boardings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boarding boarding = db.Boardings.Find(id);
            if (boarding == null)
            {
                return HttpNotFound();
            }
            return View(boarding);
        }

        // GET: Boardings/Create
        public ActionResult Create()
        {
            ViewBag.Gate_No = new SelectList(db.Gates, "Gate_No", "Gate_No");
            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No");
            return View();
        }

        // POST: Boardings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Boarding_ID,Time,Schedule_No,Gate_No")] Boarding boarding)
        {
            if (ModelState.IsValid)
            {
                string rawDateTime = boarding.Time;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedDateTime = rawDateTime.Replace("T", " ");
                boarding.Time = formattedDateTime;
                db.Boardings.Add(boarding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gate_No = new SelectList(db.Gates, "Gate_No", "Gate_No", boarding.Gate_No);
            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No", boarding.Schedule_No);
            return View(boarding);
        }

        // GET: Boardings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boarding boarding = db.Boardings.Find(id);
            if (boarding == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gate_No = new SelectList(db.Gates, "Gate_No", "Gate_No", boarding.Gate_No);
            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No", boarding.Schedule_No);
            return View(boarding);
        }

        // POST: Boardings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Boarding_ID,Time,Schedule_No,Gate_No")] Boarding boarding)
        {
            if (ModelState.IsValid)
            {
                string rawDateTime = boarding.Time;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedDateTime = rawDateTime.Replace("T", " ");
                boarding.Time = formattedDateTime;
                db.Entry(boarding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gate_No = new SelectList(db.Gates, "Gate_No", "Gate_No", boarding.Gate_No);
            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No", boarding.Schedule_No);
            return View(boarding);
        }

        // GET: Boardings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boarding boarding = db.Boardings.Find(id);
            if (boarding == null)
            {
                return HttpNotFound();
            }
            return View(boarding);
        }

        // POST: Boardings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Boarding boarding = db.Boardings.Find(id);
            db.Boardings.Remove(boarding);
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
