using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies.Gender
{
    internal sealed class MaleGenderPolicy
    {
        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
            => new List<TravelerItem>
            {
                new("Laptop",1),
                new("Drink",10),
                new("Book",(uint)Math.Ceiling(data.days/7m)),
            };

        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Male;
    }
}
