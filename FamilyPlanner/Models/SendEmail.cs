﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyPlanner.Models
{
    public class SendEmail
    {
        public int Id { get; set; }
        [Display(Name = "Gmail UserName"),Required]
        
        public string From { get; set; }

        [Display(Name = "Gmail Password"), Required]
        public string Password { get; set; }
        [Display(Name = "To Email"),Required]
        public string To { get; set; }
        [Display(Name = "Message"),Required]
        public string Text { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}