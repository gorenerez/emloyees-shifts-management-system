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
    public class DepartmentController : ApiController
    {
        private static DepartmentBL bl = new DepartmentBL();
        // GET: api/Department
        public IEnumerable<Department> Get()
        {
            return bl.GetAllDepartments();
        }

        // GET: api/Department/5
        public Department Get(int id)
        {
            return bl.GetDepartment(id);
        }

        // POST: api/Department
        public string Post(Department dep)
        {
            bl.AddDepartment(dep);
            return "created";
        }

        // PUT: api/Department/5
        public string Put(int id, Department d)
        {
            bl.UpdateDepartment(id, d);
            return "Updated";
        }

        // DELETE: api/Department/5
        public string Delete(int id)
        {
            bl.DeleteDepartment(id);
            return "Deleted";
        }
    }
}
