//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Airport_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Maintenance
    {
        [Required]
        [DataType(DataType.Text)]
        public string Maintenance_ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Cost { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Airport_Name { get; set; }
    
        public virtual Airport Airport { get; set; }
    }
}