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
    public class Employee_PassengerController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        // GET: Employee_Passenger
        public ActionResult Index()
        {
            var employee_Passenger = db.Employee_Passenger.Include(e => e.Employee).Include(e => e.Passenger);
            return View(employee_Passenger.ToList());
        }

        // GET: Employee_Passenger/Details/5
        public ActionResult Details(string passenger, string employee)
        {
            if (passenger == null || employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var EmpPass = db.Employee_Passenger.Find(passenger, employee);
            //Employee_Passenger employee_Passenger = db.Employee_Passenger.Find(id);
            if (EmpPass == null)
            {
                return HttpNotFound();
            }
            return View(EmpPass);
        }

        // GET: Employee_Passenger/Create
        public ActionResult Create()
        {
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_ID");
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC");
            return View();
        }

        // POST: Employee_Passenger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNIC,Emp_ID,Date")] Employee_Passenger employee_Passenger)
        {
            if (ModelState.IsValid)
            {
                string rawDateTime = employee_Passenger.Date;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedDateTime = rawDateTime.Replace("T", " ");
                employee_Passenger.Date = formattedDateTime;
                db.Employee_Passenger.Add(employee_Passenger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_ID", employee_Passenger.Emp_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "Emp_ID", employee_Passenger.CNIC);
            return View(employee_Passenger);
        }

        // GET: Employee_Passenger/Edit/5
        public ActionResult Edit(string passenger, string employee)
        {
            if (passenger == null || employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var EmpPass = db.Employee_Passenger.Find(passenger, employee);
            //Employee_Passenger employee_Passenger = db.Employee_Passenger.Find(id);
            if (EmpPass == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_ID", EmpPass.Emp_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", EmpPass.CNIC);
            return View(EmpPass);
        }

        // POST: Employee_Passenger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNIC,Emp_ID,Date")] Employee_Passenger employee_Passenger)
        {
            if (ModelState.IsValid)
            {
                string rawDateTime = employee_Passenger.Date;

                // Convert to "yyyy-MM-dd HH:mm" format by replacing "T" with a space
                string formattedDateTime = rawDateTime.Replace("T", " ");
                employee_Passenger.Date = formattedDateTime;
                db.Entry(employee_Passenger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Emp_ID = new SelectList(db.Employees, "Emp_ID", "Emp_ID", employee_Passenger.Emp_ID);
            ViewBag.CNIC = new SelectList(db.Passengers, "CNIC", "CNIC", employee_Passenger.CNIC);
            return View(employee_Passenger);
        }

        // GET: Employee_Passenger/Delete/5
        public ActionResult Delete(string passenger, string employee)
        {
            if (passenger == null || employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var EmpPass = db.Employee_Passenger.Find(passenger, employee);
            //Employee_Passenger employee_Passenger = db.Employee_Passenger.Find(id);
            if (EmpPass == null)
            {
                return HttpNotFound();
            }
            return View(EmpPass);
        }

        // POST: Employee_Passenger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string passenger, string employee)
        {
            var EmpPass = db.Employee_Passenger.Find(passenger, employee);
            db.Employee_Passenger.Remove(EmpPass);
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
