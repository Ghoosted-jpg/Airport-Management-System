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
    public class CabsController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Cabs
        public ActionResult Index()
        {
            var cabs = db.Cabs.Include(c => c.Airport);
            return View(cabs.ToList());
        }

        // GET: Cabs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cab cab = db.Cabs.Find(id);
            if (cab == null)
            {
                return HttpNotFound();
            }
            return View(cab);
        }

        // GET: Cabs/Create
        public ActionResult Create()
        {
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name");
            return View();
        }

        // POST: Cabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cab_ID,Model,Company,Airport_Name")] Cab cab)
        {
            if (ModelState.IsValid)
            {
                db.Cabs.Add(cab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", cab.Airport_Name);
            return View(cab);
        }

        // GET: Cabs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cab cab = db.Cabs.Find(id);
            if (cab == null)
            {
                return HttpNotFound();
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", cab.Airport_Name);
            return View(cab);
        }

        // POST: Cabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cab_ID,Model,Company,Airport_Name")] Cab cab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", cab.Airport_Name);
            return View(cab);
        }

        // GET: Cabs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cab cab = db.Cabs.Find(id);
            if (cab == null)
            {
                return HttpNotFound();
            }
            return View(cab);
        }

        // POST: Cabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cab cab = db.Cabs.Find(id);
            db.Cabs.Remove(cab);
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
