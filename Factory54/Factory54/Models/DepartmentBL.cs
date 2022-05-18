using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class DepartmentBL
    {
        private factory54Entities db = new factory54Entities();

        public List<Department> GetAllDepartments()
        {
            return db.Department.ToList();
        }

        public Department GetDepartment(int id)
        {
            return db.Department.Where(x => x.ID == id).First();
        }

        public void AddDepartment(Department d)
        {
            db.Department.Add(d);
            db.SaveChanges();
        }

        public void UpdateDepartment(int id, Department d)
        {
            Department dep = db.Department.Where(x => x.ID == id).First();
            dep.Name = d.Name;
            dep.Manager = d.Manager;
            db.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            Department dep = db.Department.Where(x => x.ID == id).First();
            db.Department.Remove(dep);
            db.SaveChanges();
        }
    }
}