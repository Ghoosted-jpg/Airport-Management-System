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
    public class MaintenancesController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Maintenances
        public ActionResult Index()
        {
            var maintenances = db.Maintenances.Include(m => m.Airport);
            return View(maintenances.ToList());
        }

        // GET: Maintenances/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // GET: Maintenances/Create
        public ActionResult Create()
        {
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name");
            return View();
        }

        // POST: Maintenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maintenance_ID,Date,Cost,Airport_Name")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Maintenances.Add(maintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", maintenance.Airport_Name);
            return View(maintenance);
        }

        // GET: Maintenances/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", maintenance.Airport_Name);
            return View(maintenance);
        }

        // POST: Maintenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maintenance_ID,Date,Cost,Airport_Name")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", maintenance.Airport_Name);
            return View(maintenance);
        }

        // GET: Maintenances/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintenance maintenance = db.Maintenances.Find(id);
            if (maintenance == null)
            {
                return HttpNotFound();
            }
            return View(maintenance);
        }

        // POST: Maintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            db.Maintenances.Remove(maintenance);
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
