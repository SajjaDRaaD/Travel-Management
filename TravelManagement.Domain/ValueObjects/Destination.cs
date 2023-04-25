using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Domain.ValueObjects
{
    public record Destination(string city, string country)
    {
        public static Destination Create(string value)
        {
            var splitDestination = value.Split(',');
            return new Destination(splitDestination.First(), splitDestination.Last());
        }

        public override string ToString()
            => $"{city},{country}";
    }
}
