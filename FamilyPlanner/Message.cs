using FamilyPlanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyPlanner
{
    public class Message
    {
        public int Id { get; set; }
        [Display(Name = "From"), Required]
        public string Sender { get; set; }
        [Display(Name = "To"), Required]
        public string Receiver { get; set; }
        [Display(Name = "Message"), Required]
        public string Text { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}