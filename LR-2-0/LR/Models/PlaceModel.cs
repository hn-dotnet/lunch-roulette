using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR.Models
{
    public class PlaceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Latitute { get; set; }

        public double Longitute { get; set; }

        public int Capacity { get; set; }
    }
}
