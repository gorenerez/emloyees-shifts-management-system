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
    public class ShiftsWithEmployeeNamesController : ApiController
    {
        private static ShiftsWithEmployeeNamesBL bl = new ShiftsWithEmployeeNamesBL();
        // GET: api/ShiftsWithEmployeeNames
        public IEnumerable<ShiftsWithEmployeeNames> Get()
        {
            return bl.GetShiftsWithEmployeeNames();
        }

    }
}
