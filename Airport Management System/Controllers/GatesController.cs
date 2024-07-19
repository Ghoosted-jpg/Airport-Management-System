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
    public class GatesController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Gates
        public ActionResult Index()
        {
            var gates = db.Gates.Include(g => g.Airport);
            return View(gates.ToList());
        }

        // GET: Gates/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gate gate = db.Gates.Find(id);
            if (gate == null)
            {
                return HttpNotFound();
            }
            return View(gate);
        }

        // GET: Gates/Create
        public ActionResult Create()
        {
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name");
            return View();
        }

        // POST: Gates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gate_No,Terminal_No,Airport_Name")] Gate gate)
        {
            if (ModelState.IsValid)
            {
                db.Gates.Add(gate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", gate.Airport_Name);
            return View(gate);
        }

        // GET: Gates/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gate gate = db.Gates.Find(id);
            if (gate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", gate.Airport_Name);
            return View(gate);
        }

        // POST: Gates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gate_No,Terminal_No,Airport_Name")] Gate gate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", gate.Airport_Name);
            return View(gate);
        }

        // GET: Gates/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gate gate = db.Gates.Find(id);
            if (gate == null)
            {
                return HttpNotFound();
            }
            return View(gate);
        }

        // POST: Gates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Gate gate = db.Gates.Find(id);
            db.Gates.Remove(gate);
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
