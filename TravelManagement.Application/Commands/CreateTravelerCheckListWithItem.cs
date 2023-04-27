using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Consts;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands
{
    public record CreateTravelerCheckListWithItem(Guid id, string name, ushort days, Gender gender, DestinationWriteModel destination):ICommand;

    public record DestinationWriteModel(string city, string country);
}
