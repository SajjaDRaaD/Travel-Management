using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Domain.ValueObjects;

namespace TravelManagement.Domain.Policies
{
    public record PolicyData(TravelDays days, Gender gender, Temperature temperature, Destination destination)
}
