using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class EmployeeDataWithShiftTimeBL
    {
        private factory54Entities db = new factory54Entities();
        public List<EmployeeDataWithShiftTime> GetEmployeeDataWithShifts()
        {
            List<EmployeeDataWithShiftTime> employees = new List<EmployeeDataWithShiftTime>();
            foreach (var emp in db.Employee)
            {
                EmployeeDataWithShiftTime employeeWithDataShifts = new EmployeeDataWithShiftTime();
                employeeWithDataShifts.EmpID = emp.ID;
                employeeWithDataShifts.FirstName = emp.FirstName;
                employeeWithDataShifts.LastName = emp.LastName;
                employeeWithDataShifts.StartWorkYear = emp.StartWorkYear;
                employeeWithDataShifts.DepartmentID = emp.DepartmentID;

                employeeWithDataShifts.ShiftsTimeDate = new List<string>();

                var employees1 = db.EmployeeShift.Where(x => x.EmployeeID == emp.ID);

                foreach (var emp1 in employees1)
                {
                    var employees2 = db.Shift.Where(x => x.ID == emp1.ShiftID);
                    foreach (var emp2 in employees2)
                    {
                        employeeWithDataShifts.ShiftsTimeDate.Add(emp2.Date + " " + emp2.StartTime + " - " + emp2.EndTime);
                    }
                }
                employees.Add(employeeWithDataShifts);
            }
            return employees;
        }

    }
}