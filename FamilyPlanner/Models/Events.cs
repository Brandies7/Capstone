using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FamilyPlanner.Models
{
    public class Events
    {
        
        public int id { get; set; }

        [Display(Name = "Text")]
        public string text { get; set; }

        [Display(Name = "StartDate")]
        public string start_date { get; set; }

        [Display(Name = "EndDate")]
        public string end_date { get; set; }

        [Display(Name = "StartTime")]
        public string start_time { get; set; }

        [Display(Name = "EndTime")]
        public string end_time { get; set; }

        [Display(Name = "Location")]
        public string location { get; set; }

        [Display(Name = "Latitude")]
        public float lat { get; set; }

        [Display(Name = "Longitude")]
        public float lng { get; set; }
        
    }
}