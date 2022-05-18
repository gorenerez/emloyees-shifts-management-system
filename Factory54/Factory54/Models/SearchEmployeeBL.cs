using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
namespace Factory54.Models
{

    /// <summary>
    /// tried to do it many ways didnt work
    /// </summary>
    
    public class SearchEmployeeBL
    {
        private factory54Entities db = new factory54Entities();
        public SearchEmployeeTable GetGetAllSearch(string dep, string fname, string lname)
        {

            if(dep != null && fname == "null" && lname == "null")
            {
                var depResponse = db.Department.Where(x => x.Name == dep).First();
                var empResponse = db.Employee.Where(x => x.DepartmentID == depResponse.ID).ToList();
                foreach(var item in empResponse)
                {
                    SearchEmployeeTable emp = new SearchEmployeeTable();
                    emp.FirstName = item.FirstName;
                    emp.LastName = item.LastName;
                    emp.StartWorkYear = item.StartWorkYear;

                    return emp;
                }
                
            }

            if (dep == "null" && fname == "null" && lname!= null)
            {
                var emp2Response = db.Employee.Where(x => x.LastName == lname).ToList();
                foreach(var item in emp2Response)
                {
                    SearchEmployeeTable emp = new SearchEmployeeTable();
                    emp.FirstName = item.FirstName;
                    emp.LastName = item.LastName;
                    emp.StartWorkYear = item.StartWorkYear;

                    return emp;
                }
                
            }

            if (dep == "null" && fname != null && lname == "null")
            {
                var emp3Response = db.Employee.Where(x => x.FirstName == fname).ToList();
                foreach (var item in emp3Response)
                {
                    SearchEmployeeTable emp = new SearchEmployeeTable();
                    emp.FirstName = item.FirstName;
                    emp.LastName = item.LastName;
                    emp.StartWorkYear = item.StartWorkYear;

                    return emp;
                }
               
            }
        }
    }
}
*/