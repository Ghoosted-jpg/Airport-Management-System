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
    public class TicketsController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Flight).Include(t => t.Passenger);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID");
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ticket_No,CNIC,Flight_ID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID", ticket.Flight_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", ticket.CNIC);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID", ticket.Flight_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", ticket.CNIC);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ticket_No,CNIC,Flight_ID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Flight_ID = new SelectList(db.Flights, "Flight_ID", "Flight_ID", ticket.Flight_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", ticket.CNIC);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
