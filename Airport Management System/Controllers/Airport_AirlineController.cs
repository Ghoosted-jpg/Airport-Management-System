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
    [Authorize(Roles = "Admin")]
    public class Airport_AirlineController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Airport_Airline
        public ActionResult Index()
        {
            var airport_Airline = db.Airport_Airline.Include(a => a.Airline).Include(a => a.Airport);
            return View(airport_Airline.ToList());
        }

        // GET: Airport_Airline/Details/5
        public ActionResult Details(string airportName, string airlineName)
        {
            if (airportName == null || airlineName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var airportAirline = db.Airport_Airline.Find(airportName, airlineName);
            if (airportAirline == null)
            {
                return HttpNotFound();
            }
            return View(airportAirline);
        }

        // GET: Airport_Airline/Create
        public ActionResult Create()
        {
            ViewBag.Airline_Name = new SelectList(db.Airlines, "Airline_Name", "Airline_Name");
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name");
            return View();
        }

        // POST: Airport_Airline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Airport_Name,Airline_Name,Date")] Airport_Airline airport_Airline)
        {
            if (ModelState.IsValid)
            {
                db.Airport_Airline.Add(airport_Airline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Airline_Name = new SelectList(db.Airlines, "Airline_Name", "Airline_Name", airport_Airline.Airline_Name);
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", airport_Airline.Airport_Name);
            return View(airport_Airline);
        }

        // GET: Airport_Airline/Edit/5
        public ActionResult Edit(string airportName, string airlineName)
        {
            if (airportName == null || airlineName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var airportAirline = db.Airport_Airline.Find(airportName, airlineName);
            if (airportAirline == null)
            {
                return HttpNotFound();
            }
            ViewBag.Airports = new SelectList(db.Airports, "Airport_Name", "Airport_Name", airportAirline.Airport_Name);
            ViewBag.Airlines = new SelectList(db.Airlines, "Airline_Name", "Airline_Name", airportAirline.Airline_Name);
            return View(airportAirline);
        }

        // POST: Airport_Airline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Airport_Name,Airline_Name,Date")] Airport_Airline airport_Airline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airport_Airline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Airports = new SelectList(db.Airports, "Airport_Name", "Airport_Name", airport_Airline.Airport_Name);
            ViewBag.Airlines = new SelectList(db.Airlines, "Airline_Name", "Airline_Name", airport_Airline.Airline_Name);
            return View(airport_Airline);
        }

        // GET: Airport_Airline/Delete/5
        public ActionResult Delete(string airportName, string airlineName)
        {
            if (airportName == null || airlineName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var airportAirline = db.Airport_Airline.Find(airportName, airlineName);
            if (airportAirline == null)
            {
                return HttpNotFound();
            }
            return View(airportAirline);
        }

        // POST: Airport_Airline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string airportName, string airlineName)
        {
            var airportAirline = db.Airport_Airline.Find(airportName, airlineName);
            db.Airport_Airline.Remove(airportAirline);
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
        public JsonResult GetAirlineStartDate(string airlineName)
        {
            var airline = db.Airlines.FirstOrDefault(a => a.Airline_Name == airlineName);
            if (airline != null && DateTime.TryParse(airline.Since, out DateTime startDate))
            {
                return Json(new { startDate = startDate.ToString("yyyy-MM-dd") }, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

    }
}
