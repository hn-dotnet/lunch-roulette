using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR.Models
{
    public class Db : DbContext
    {
        public DbSet<AttendeeModel> Attendees { get; set; }

        public DbSet<FoodstoreModel> Foodstores { get; set; }

    }
}
