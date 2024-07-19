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

    public partial class Luggage
    {
        [Required]
        [DataType(DataType.Text)]
        public string Luggage_Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Range(0, 50, ErrorMessage = "Weight must be between 0 and 50.")]
        public string Weight { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string CNIC { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Flight_ID { get; set; }
    
        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}