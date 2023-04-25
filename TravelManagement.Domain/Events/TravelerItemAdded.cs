using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Domain;

namespace TravelManagement.Domain.Events
{
    public record TravelerItemAdded(TravelerCheckList travelerCheckList, TravelerItem travelerItem ):IDomainEvent;
}
