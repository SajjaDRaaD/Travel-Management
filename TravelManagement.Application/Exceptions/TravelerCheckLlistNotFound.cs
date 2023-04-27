using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Exceptions;

namespace TravelManagement.Application.Exceptions
{
    public class TravelerCheckLlistNotFound : TravelerCheckListException
    {
        public Guid Id { get; }
        public TravelerCheckLlistNotFound(Guid id) : base($"Traveler Check List with Id '{id}' Not Found")
            => id = Id;
    }
}
