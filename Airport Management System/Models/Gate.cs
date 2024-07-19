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

    public partial class Gate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gate()
        {
            this.Boardings = new HashSet<Boarding>();
        }

        [Required]
        [DataType(DataType.Text)]
        public string Gate_No { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Terminal_No { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Airport_Name { get; set; }
    
        public virtual Airport Airport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boarding> Boardings { get; set; }
    }
}
