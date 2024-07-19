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
    public class EmployeesController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();

        [Authorize(Roles = "Admin")]
        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Airport);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name");
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_ID,Name,DOB,Designation,Password,Gender,H_no,Area,City,Country,Salary,Phone_No,Email,Airport_Name")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", employee.Airport_Name);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", employee.Airport_Name);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_ID,Name,DOB,Designation,Password,Gender,H_no,Area,City,Country,Salary,Phone_No,Email,Airport_Name")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing employee from the database
                var Existingemployee = db.Employees.Find(employee.Emp_ID);
                // Update only the fields that were included in the form
                Existingemployee.Name = employee.Name;
                Existingemployee.DOB = employee.DOB;
                Existingemployee.Password = employee.Password;
                Existingemployee.Gender = employee.Gender;
                Existingemployee.H_no = employee.H_no;
                Existingemployee.Area = employee.Area;
                Existingemployee.City = employee.City;
                Existingemployee.Country = employee.Country;
                Existingemployee.Phone_No = employee.Phone_No;
                Existingemployee.Email = employee.Email;

                string employeeID = Session["EmployeeID"] as string;
                string employeeDesignation = Session["Designation"] as string;
                if (employeeDesignation == "Admin")
                {
                    Existingemployee.Designation = employeeDesignation;
                    Existingemployee.Salary = employee.Salary;
                    Existingemployee.Airport_Name=employee.Airport_Name;
                    // Store employee info in session
                    //if (employeeID == employee.Emp_ID)
                    //{
                    //    Session["EmployeeName"] = employee.Name;
                    //    Session["Designation"] = employee.Designation;
                    //    Session["Gender"] = employee.Gender;
                    //    System.Diagnostics.Debug.WriteLine("Employee Information Saved");
                    //}
                }
                db.Entry(Existingemployee).State = EntityState.Modified;
                db.SaveChanges();
                if (employeeID == employee.Emp_ID)
                {
                    Session["EmployeeName"] = employee.Name;
                    Session["Designation"] = employee.Designation;
                    Session["Gender"] = employee.Gender;
                    System.Diagnostics.Debug.WriteLine("Employee Information Saved");
                }
                if (employeeDesignation == "Admin")
                {
                    return RedirectToAction("Index", "Airports");
                }
                else
                {
                    return RedirectToAction("Index", "Passengers");
                }
             
            }
            ViewBag.Airport_Name = new SelectList(db.Airports, "Airport_Name", "Airport_Name", employee.Airport_Name);
            return View(employee);
        }

        [Authorize(Roles = "Admin")]
        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
