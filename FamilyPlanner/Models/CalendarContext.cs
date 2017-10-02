using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FamilyPlanner.Models
{
    public class CalendarContext: DbContext
    {
        public CalendarContext()
            : base()
        { }
        
        public DbSet<Events> Events { get; set; }
    }
}
