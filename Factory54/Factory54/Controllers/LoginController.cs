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
    public class LoginController : ApiController
    {
        private static LoginBL bl = new LoginBL();

        //checks user login page if username and password same in db
        // POST: api/Login
        public string Post(CheckLogin userAndPassword)
        {
            string checkValid = bl.CheckUser(userAndPassword);
            if (checkValid == "Wrong details")
            {
                return "Wrong details";
            }
            else
            {
                return checkValid;
            }
        }

        //checks user number of action not more than allowed in db
        // POST: api/Login

        public string CheckUserActions(int id)
        {
            var status = bl.CheckUserActions(id);
            return status;
        }

        // GET: api/Login
        public IEnumerable<User> GetAllUsers()
        {
            return bl.GetAllUsers();
        }
    }
}
