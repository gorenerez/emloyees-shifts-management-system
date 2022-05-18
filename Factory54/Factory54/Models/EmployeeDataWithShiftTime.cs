using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class EmployeeDataWithShiftTime
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StartWorkYear { get; set; }
        public int DepartmentID { get; set; }

        public List<string> ShiftsTimeDate { get; set; }
    }
}