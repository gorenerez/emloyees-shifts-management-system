using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Factory54.Models;
using System.Web.Http.Cors;

namespace Factory54.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        private static EmployeeBL bl = new EmployeeBL();
        // GET: api/Employee

        public IEnumerable<Employee> Get()
        {
            return bl.GetAllEmployees();
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            return bl.GetEmployee(id);
        }

        // POST: api/Employee
        public string Post(Employee emp)
        {
            bl.AddEmployee(emp);
            return "created";
        }

        // PUT: api/Employee/5
        public string Put(int id, Employee e)
        {
            bl.UpdateEmployee(id, e);
            return "Updated";
        }

        // DELETE: api/Employee/5
        public string Delete(int id)
        {
            bl.DeleteEmployee(id);
            return "Deleted";
        }
    }
}
