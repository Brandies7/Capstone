using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPlanner.Models
{
    public class Chores
    {
        public int Id { get; set; }

        public string Chore { get; set; }
        public bool IsDone { get; set; }
        public int PointValue { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}