using Airport_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Airport_Management_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private AMSEntities3 db = new AMSEntities3();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var roles = new List<string>();

                // Fetch roles based on user's designation
                var emp_ID = HttpContext.Current.User.Identity.Name;
                var employee = db.Employees.FirstOrDefault(model => model.Emp_ID == emp_ID);

                if (employee != null)
                {
                    roles.Add(employee.Designation);
                }

                // Assign roles to current user
                var principal = new GenericPrincipal(HttpContext.Current.User.Identity, roles.ToArray());
                HttpContext.Current.User = principal;
            }
        }
    }
}
