using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands
{
    public record RemoveTravelerCheckList(Guid id) : ICommand;
}
