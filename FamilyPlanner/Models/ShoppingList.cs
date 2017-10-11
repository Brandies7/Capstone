using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPlanner.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public bool Buy { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}