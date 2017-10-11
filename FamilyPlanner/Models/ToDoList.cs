using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPlanner.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        public string MyToDoList { get; set; }

        public bool Completed { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}