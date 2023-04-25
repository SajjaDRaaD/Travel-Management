using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies
{
    public record PolicyData(TravelDays days, Consts.Gender Gender, ValueObjects.Temperature Temperature, Destination destination);
}
