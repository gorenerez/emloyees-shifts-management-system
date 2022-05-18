using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class EmployeeBL
    {
        private factory54Entities db = new factory54Entities();

        public List<Employee> GetAllEmployees()
        {
            return db.Employee.ToList();  
        }

        public Employee GetEmployee(int id)
        {
            return db.Employee.Where(x => x.ID == id).First();
        }

        public void AddEmployee(Employee e)
        {
            db.Employee.Add(e);
            db.SaveChanges();
        }

        public void UpdateEmployee(int id, Employee e)
        {
            Employee emp = db.Employee.Where(x => x.ID == id).First();
            emp.FirstName = e.FirstName;
            emp.LastName = e.LastName;
            emp.StartWorkYear = e.StartWorkYear;
            emp.DepartmentID = e.DepartmentID;
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee emp = db.Employee.Where(x => x.ID == id).First();
            var oldEmployeeShifts = db.EmployeeShift.Where(x => x.EmployeeID == id).ToList();
            foreach (var shift in oldEmployeeShifts)
            {
                db.EmployeeShift.Remove(shift);
            }
            var oldEmployeeMangerDepartment = db.Department.Where(x => x.Manager == id).ToList();
            foreach (var department in oldEmployeeMangerDepartment)
            {
                department.Manager = 0;
            }
            db.Employee.Remove(emp);
            db.SaveChanges();
        }
    }
}