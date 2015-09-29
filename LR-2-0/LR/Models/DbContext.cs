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
        public DbSet<PlaceModel> Places { get; set; }

        public DbSet<UserModel> Users { get; set; }

    }
}
