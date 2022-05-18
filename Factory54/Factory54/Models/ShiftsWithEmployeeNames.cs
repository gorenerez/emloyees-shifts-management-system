using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class ShiftsWithEmployeeNames
    {
        public int empID { get; set; }
        public System.DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public List<string> employees { get; set; }
    }
}