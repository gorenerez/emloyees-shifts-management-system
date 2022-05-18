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
    public class EmployeeDataWithShiftTimeController : ApiController
    {
        private static EmployeeDataWithShiftTimeBL bl = new EmployeeDataWithShiftTimeBL();
        // GET: api/EmployeeDataWithShiftTime
        public IEnumerable<EmployeeDataWithShiftTime> Get()
        {
            return bl.GetEmployeeDataWithShifts();
        }
    }
}
