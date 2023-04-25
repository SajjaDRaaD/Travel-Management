using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Domain.Exceptions
{
    public class TravelerCheckListNameException : TravelerCheckListException
    {
        public TravelerCheckListNameException() : base("Traveler Check List Name cannot be empty.")
        {
        }
    }
}
