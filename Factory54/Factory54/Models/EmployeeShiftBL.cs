using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class EmployeeShiftBL
    {
        private factory54Entities db = new factory54Entities();

        public void AddEmployeeShift(EmployeeShift e)
        {
            db.EmployeeShift.Add(e);
            db.SaveChanges();
        }

        public void DeleteEmployeeShifts(int empID)
        {
            var empWithShifts = db.EmployeeShift.Where(x => x.EmployeeID == empID).First();
            db.EmployeeShift.Remove(empWithShifts);
            db.SaveChanges();
        }
    }
}