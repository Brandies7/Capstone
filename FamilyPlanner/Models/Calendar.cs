using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyPlanner.Models
{
    public class Calendar
    {
        public int Id { get; set; }

        [Display(Name = "Event")]
        public string Event { get; set; }

        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "End Date")]
        public string EndDate { get; set; }
    }
}