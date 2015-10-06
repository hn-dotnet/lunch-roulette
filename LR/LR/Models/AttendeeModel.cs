using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR.Models
{
    public class AttendeeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Mealtime { get; set; }

        public FoodstoreModel Foodstore { get; set; }
    }
}
