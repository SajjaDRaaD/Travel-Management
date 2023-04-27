using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands
{
    public record RemoveTravelerItem(Guid travelerCheckListId, string name):ICommand;
}
