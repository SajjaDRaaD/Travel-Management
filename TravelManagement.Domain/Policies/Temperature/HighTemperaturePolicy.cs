using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies.Temperature
{
    internal sealed class HighTemperaturePolicy : ITravelerItemPolicy
    {
        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
            => new List<TravelerItem>
            {
                new("Hat",1),
                new("Sunglasses",1),
                new("Cream with UV filter",1),
            };

        public bool IsApplicable(PolicyData data)
            => data.temperature > 25D;
    }
}
