using Airport_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Airport_Management_System.Controllers
{
    public class LoginController : Controller
    {
        private AMSEntities3 db = new AMSEntities3();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Emp_ID, string Password, Login model, string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            // Retrieve the employee data (case-insensitive comparison)
            var employee = db.Employees.FirstOrDefault(e => e.Emp_ID.Equals(Emp_ID, StringComparison.OrdinalIgnoreCase));
            // Now, perform a case-sensitive comparison in LINQ to Objects
            var matchingEmployee = db.Employees.AsEnumerable().FirstOrDefault(e => e.Emp_ID == Emp_ID);

            if (matchingEmployee != null)
            {
                if (matchingEmployee != null && matchingEmployee.Password == Password)
                {
                    Debug.WriteLine($"Creating authentication ticket for user: {Emp_ID}");
                    // Authentication succeeded
                    FormsAuthentication.SetAuthCookie(model.Emp_ID, false);
                    if (Url.IsLocalUrl(ReturnUrl) && !string.IsNullOrEmpty(ReturnUrl))
                    {
                        Session["EmployeeName"] = employee.Name;
                        Session["EmployeeID"] = employee.Emp_ID;
                        Session["Designation"] = employee.Designation;
                        Session["Gender"] = employee.Gender;
                        //System.Diagnostics.Debug.WriteLine("Employee ID: " + Session["EmployeeID"]);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        if (employee.Designation == "Admin")
                        {
                            // Store employee info in session
                            Session["EmployeeName"] = employee.Name;
                            Session["EmployeeID"] = employee.Emp_ID;
                            Session["Designation"] = employee.Designation;
                            Session["Gender"] = employee.Gender;
                            //System.Diagnostics.Debug.WriteLine("Employee ID: " + Session["EmployeeID"]);
                            // Redirect to Admin dashboard or view

                            return RedirectToAction("Index", "Airports"); // Replace with your admin action and controller
                        }
                        else
                        {
                            // Store employee info in session
                            Session["EmployeeName"] = employee.Name;
                            Session["EmployeeID"] = employee.Emp_ID;
                            Session["Designation"] = employee.Designation;
                            Session["Gender"] = employee.Gender;
                            //System.Diagnostics.Debug.WriteLine("Employee ID: " + Session["EmployeeID"]);
                            // Redirect to regular user dashboard or view

                            return RedirectToAction("Index", "Passengers"); // Replace with your regular user action and controller
                        }
                    }
                }
                else
                {
                    // Authentication failed, return to login page with an error message
                    ViewBag.ErrorMessage = "Invalid Password. Please try again.";
                    return View();
                }
            }
            else
            {
                // Authentication failed, return to login page with an error message
                ViewBag.ErrorMessage = "Invalid credentials. Please try again.";
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        [ActionName("Logout")]
        public ActionResult AutomaticLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}