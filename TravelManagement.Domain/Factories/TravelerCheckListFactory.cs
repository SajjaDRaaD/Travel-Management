using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Policies;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories
{
    public class TravelerCheckListFactory : ITravelerCheckListFactory
    {
        private readonly IEnumerable<ITravelerItemPolicy> _policies;

        public TravelerCheckListFactory(IEnumerable<ITravelerItemPolicy> policies)
        {
            _policies = policies;
        }

        public TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, Destination destination)
            => new(id, name, destination);

        public TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, Destination destination, Temperature temperature, TravelDays days, Gender gender)
        {

            var data = new PolicyData(days,gender,temperature,destination);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

            var items = applicablePolicies.SelectMany(x => x.GenerateItems(data));
            var travelerCheckList = Create(id, name, destination);

            travelerCheckList.AddItems(items);

            return travelerCheckList;
        
        }
    }
}
