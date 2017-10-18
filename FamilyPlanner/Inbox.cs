using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPlanner
{
    public class Inbox
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string NewMessage { get; set; }
        public virtual Message messsage { get; set; }
    }
}