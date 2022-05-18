using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class ShiftsWithEmployeeNamesBL
    {
        private factory54Entities db = new factory54Entities();

        public List<ShiftsWithEmployeeNames> GetShiftsWithEmployeeNames()
        {
            List<ShiftsWithEmployeeNames> shfts = new List<ShiftsWithEmployeeNames>();
            foreach(var shft in db.Shift)
            {
                ShiftsWithEmployeeNames shiftWithName = new ShiftsWithEmployeeNames();
                shiftWithName.Date = shft.Date;
                shiftWithName.StartTime = shft.StartTime;
                shiftWithName.EndTime = shft.EndTime;

                shiftWithName.employees = new List<string>();

                var employees1 = db.EmployeeShift.Where(x => x.ShiftID == shft.ID);

                foreach(var emp in employees1)
                {
                    var employees2 = db.Employee.Where(x => x.ID == emp.EmployeeID);
                    foreach(var emp2 in employees2)
                    {
                        shiftWithName.empID = emp2.ID;
                        shiftWithName.employees.Add(emp2.FirstName + " " + emp2.LastName);
                    }
                }
                shfts.Add(shiftWithName);
            }
            return shfts;
        }

    }
}