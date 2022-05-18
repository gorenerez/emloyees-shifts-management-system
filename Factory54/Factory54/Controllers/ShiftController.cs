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
    public class ShiftController : ApiController
    {
        private static ShiftBL bl = new ShiftBL();
        // GET: api/Shift
        public IEnumerable<Shift> Get()
        {
            return bl.GetAllShifts().ToList();
        }

        // GET: api/Shift/5
        public Shift Get(int id)
        {
            return bl.GetShift(id);
        }

        // POST: api/Shift
        public string Post(Shift shft)
        {
            bl.AddShift(shft);
            return "created";
        }
    }
}
