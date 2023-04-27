using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions
{
    internal class MissingDestinationWeatherException : TravelerCheckListException
    {
        public Destination Destination { get; }
        public MissingDestinationWeatherException(Destination destination) : base($"Couldn't fetch weather data for Destination '{destination.city}/{destination.country}'.")
            => Destination = destination;
    }
}
