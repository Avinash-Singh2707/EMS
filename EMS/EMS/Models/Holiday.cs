//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Holiday
    {
        public int HolidayID { get; set; }
        [Required(ErrorMessage = "Holiday Name is required")]
        public string HolidayName { get; set; }
        public System.DateTime HolidayDate { get; set; }
    }
}
