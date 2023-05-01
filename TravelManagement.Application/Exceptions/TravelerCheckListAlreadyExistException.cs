using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions
{
    public class TravelerCheckListAlreadyExistException : TravelerCheckListException
    {
        public string Name { get; }
        public TravelerCheckListAlreadyExistException(string name) : base($"Traveler CheckList with name '{name}' is already exist.")
        {
            Name = name;
        }
    }
}
