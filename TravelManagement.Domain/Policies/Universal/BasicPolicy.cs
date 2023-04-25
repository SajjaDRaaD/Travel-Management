using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies.Universal
{
    internal sealed class BasicPolicy : ITravelerItemPolicy
    {
        private const uint MaximumQuantityOfClothes = 7;
        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
            => new List<TravelerItem>
            {
                new("Pants",Math.Min(data.days,MaximumQuantityOfClothes)),
                new("Socks",Math.Min(data.days,MaximumQuantityOfClothes)),
                new("T-shirt",Math.Min(data.days,MaximumQuantityOfClothes)),
                new("Trousers",1),
                new("Shampoo",1),
                new("Toothbrush",1),
                new("Toothpaste",1),
                new("Towel",1),
                new("Bag pack",1),
                new("Passport",1),
                new("Phone Charger",1),
            };
          
        public bool IsApplicable(PolicyData data)
            => true;
    }
}
