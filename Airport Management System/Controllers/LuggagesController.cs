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
    public class LuggagesController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Luggages
        public ActionResult Index()
        {
            var luggages = db.Luggages.Include(l => l.Flight).Include(l => l.Passenger);
            return View(luggages.ToList());
        }

        // GET: Luggages/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luggage luggage = db.Luggages.Find(id);
            if (luggage == null)
            {
                return HttpNotFound();
            }
            return View(luggage);
        }

        // GET: Luggages/Create
        public ActionResult Create()
        {
            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID");
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC");
            return View();
        }

        // POST: Luggages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Luggage_Id,Weight,CNIC,Flight_ID")] Luggage luggage)
        {
            if (ModelState.IsValid)
            {
                db.Luggages.Add(luggage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID", luggage.Flight_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", luggage.CNIC);
            return View(luggage);
        }

        // GET: Luggages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luggage luggage = db.Luggages.Find(id);
            if (luggage == null)
            {
                return HttpNotFound();
            }
            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID", luggage.Flight_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", luggage.CNIC);
            return View(luggage);
        }

        // POST: Luggages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Luggage_Id,Weight,CNIC,Flight_ID")] Luggage luggage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luggage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID", luggage.Flight_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", luggage.CNIC);
            return View(luggage);
        }

        // GET: Luggages/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luggage luggage = db.Luggages.Find(id);
            if (luggage == null)
            {
                return HttpNotFound();
            }
            return View(luggage);
        }

        // POST: Luggages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Luggage luggage = db.Luggages.Find(id);
            db.Luggages.Remove(luggage);
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
