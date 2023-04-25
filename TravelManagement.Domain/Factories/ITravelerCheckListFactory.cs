using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Factories
{
    public interface ITravelerCheckListFactory
    {
        TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, Destination destination);
        TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, Destination destination, Temperature temperature , TravelDays days, Gender gender);
    }
}
