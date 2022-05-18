using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class LoginBL
    {
        private factory54Entities db = new factory54Entities();

        //checks user login page if username and password same in db 
        public string CheckUser(CheckLogin userAndPassword)
        {
            var loginUser = db.User.Where(x => x.UserName == userAndPassword.User).FirstOrDefault();
            var loginPass = db.User.Where(x => x.Password == userAndPassword.Password).FirstOrDefault();

            if (loginUser != null && loginPass != null)
            {
                return loginUser.FullName;
            }
            else
            {
                return "Wrong Details";
            }
        }

        //checks user number of action not more than allowed in db
        public string CheckUserActions(int id)
        {
            var status = "";

            var response = db.User.Where(x => x.ID == id).First();
            if(response.Date == DateTime.Today && response.CounterOfActions <= response.NumOfActionsAllowed)
            {
                response.CounterOfActions += 1;
                status = response.CounterOfActions + " from " + response.NumOfActionsAllowed;
                db.SaveChanges();
            }
            else
            {
                response.Date = DateTime.Today;
                response.CounterOfActions = 0;
                status = "You reached to your limit today - Thank you!";
                db.SaveChanges();
            }
            return status;
            
        }
        public List<User> GetAllUsers()
        {
            return db.User.ToList();
        }

    }
}