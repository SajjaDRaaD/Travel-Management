using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Infrastructure.EF.Models
{
    public class DestinationReadModel
    {
        public string Country { get; set; }
        public string City { get; set; }

        public static DestinationReadModel Create(string value)
        {
            var splitLocalization = value.Split(',');
            return new DestinationReadModel
            {
                City = splitLocalization.First(),
                Country = splitLocalization.Last(),
            };
        }

        public override string ToString()
        {
            return $"{City},{Country}";
        }
    }
}
