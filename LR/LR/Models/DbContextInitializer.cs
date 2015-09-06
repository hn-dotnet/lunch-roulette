using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR.Models
{
    public class DbContextInitializer : DropCreateDatabaseAlways<Db>
    {
        protected override void Seed(Db context)
        {
            base.Seed(context);

            var places = new List<PlaceModel>()
            {
                new PlaceModel() { Id = Guid.NewGuid(), Name = "Subway Hauptbahnhof", Capacity = 10, Latitute = 49.1426362, Longitute = 9.2083295, Description = "Kleine SUBWAY-Filiale im Bahnhof Heilbronn" },
                new PlaceModel() { Id = Guid.NewGuid(), Name = "Lehner's Wirtshaus", Capacity = 50, Latitute = 49.1425051, Longitute = 9.2146555, Description = "Gutes Essen und Trinken, Abends kann man schön draußen am Neckar sitzen." }
            };

            context.Places.AddRange(places);

            var user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = "Jonathan Günz",
                Email = "jonathan.guenz@outlook.com",
                Place = places.First(),
                Time = DateTime.Now.AddDays(1)
            };
            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
