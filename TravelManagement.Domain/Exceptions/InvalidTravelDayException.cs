using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions
{
    public class InvalidTravelDayException : TravelerCheckListException
    {
        public ushort Days { get; }

        public InvalidTravelDayException(ushort days) : base($"Value '{days}' is Invalid Travel Days")
        {
            Days = days;
        }

    }
}
