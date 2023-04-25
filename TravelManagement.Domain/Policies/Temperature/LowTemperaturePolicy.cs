using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies.Temperature
{
    internal sealed class LowTemperaturePolicy
    {
        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
            => new List<TravelerItem>
            {
                new("Winter Hat",1),
                new("Scarf",1),
                new("Hoodies",1),
                new("Warm jacket",1),
            };

        public bool IsApplicable(PolicyData data)
            => data.temperature < 10D;
    }
}
