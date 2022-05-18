using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Factory54.Models;
using System.Web.Http.Cors;
/*
namespace Factory54.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchEmployeeController : ApiController
    {
        /// <summary>
        /// tried to do it many ways didnt work
        /// </summary>
        private static SearchEmployeeBL bl = new SearchEmployeeBL();
        // GET: api/SearchEmployee
        public SearchEmployeeTable GetEmployeeSearch(string dep = "", string fname = "", string lname = "")
        {
            return bl.GetGetAllSearch(dep, fname, lname);
        }
    }
}
*/