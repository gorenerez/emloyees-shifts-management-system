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
    public class EmployeeShiftController : ApiController
    {
        private static EmployeeShiftBL bl = new EmployeeShiftBL();

        // POST: api/EmployeeShift

        public string Post(EmployeeShift emp)
            {
                bl.AddEmployeeShift(emp);
                return "created";
            }

        // DELETE: api/EmployeeShift
        public string DeletaEployeeWithShifts(int empID)
        {
            bl.DeleteEmployeeShifts(empID);
            return "Deleted";
        }
        

    }
}
