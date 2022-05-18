using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class ShiftBL
    {
        private factory54Entities db = new factory54Entities();

        public List<Shift> GetAllShifts()
        {
            return db.Shift.ToList();
        }

        public Shift GetShift(int id)
        {
            return db.Shift.Where(x => x.ID == id).First();
        }

        public void AddShift(Shift s)
        {
            db.Shift.Add(s);
            db.SaveChanges();
        }
    }
}