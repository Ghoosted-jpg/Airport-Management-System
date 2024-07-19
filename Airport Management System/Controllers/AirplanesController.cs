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
    public class AirplanesController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Airplanes
        public ActionResult Index()
        {
            var airplanes = db.Airplanes.Include(a => a.Airline);
            return View(airplanes.ToList());
        }

        // GET: Airplanes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            return View(airplane);
        }

        // GET: Airplanes/Create
        public ActionResult Create()
        {
            ViewBag.Airline_Name = new SelectList(db.Airlines, "Airline_Name", "Airline_Name");
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Model_No,Capacity,Fuel_Capacity,Airline_Name")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                db.Airplanes.Add(airplane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Airline_Name = new SelectList(db.Airlines, "Airline_Name", "Airline_Name", airplane.Airline_Name);
            return View(airplane);
        }

        // GET: Airplanes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            ViewBag.Airline_Name = new SelectList(db.Airlines, "Airline_Name", "Airline_Name", airplane.Airline_Name);
            return View(airplane);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Model_No,Capacity,Fuel_Capacity,Airline_Name")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airplane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Airline_Name = new SelectList(db.Airlines, "Airline_Name", "Airline_Name", airplane.Airline_Name);
            return View(airplane);
        }

        // GET: Airplanes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            return View(airplane);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            db.Airplanes.Remove(airplane);
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
