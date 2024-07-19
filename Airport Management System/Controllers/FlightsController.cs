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
    public class FlightsController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Flights
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.Schedule);
            return View(flights.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Flight_ID,Departure,Arrival,Source,Destination,Schedule_No")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                string rawDeparture = flight.Departure;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedDeparture = rawDeparture.Replace("T", " ");
                flight.Departure = formattedDeparture;

                string rawArrival = flight.Arrival;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedArrival = rawArrival.Replace("T", " ");
                flight.Arrival = formattedArrival;
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No", flight.Schedule_No);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No", flight.Schedule_No);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Flight_ID,Departure,Arrival,Source,Destination,Schedule_No")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                string rawDeparture = flight.Departure;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedDeparture = rawDeparture.Replace("T", " ");
                flight.Departure = formattedDeparture;

                string rawArrival = flight.Arrival;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedArrival = rawArrival.Replace("T", " ");
                flight.Arrival = formattedArrival;
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Schedule_No = new SelectList(db.Schedules, "Schedule_No", "Schedule_No", flight.Schedule_No);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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
