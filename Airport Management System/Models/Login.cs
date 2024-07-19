using Microsoft.Owin;
using Owin;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Airport_Management_System.Models.Login))]

namespace Airport_Management_System.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        public string Emp_ID {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
