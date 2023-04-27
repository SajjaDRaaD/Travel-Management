using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers
{
    public class AddTravelerItemHandler : ICommandHandler<AddTravelerItem>
    {
        private readonly ITravelerCheckListRepository _repository;

        public AddTravelerItemHandler(ITravelerCheckListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddTravelerItem command)
        {
            var travelerCheckList = await _repository.GetAsync(command.travelerCheckListId);

            if (travelerCheckList is null)
            {
                throw new TravelerCheckLlistNotFound(command.travelerCheckListId);
            }

            var travelerItem = new TravelerItem(command.Name, command.Quantitiy);
            travelerCheckList.AddItem(travelerItem);

            await _repository.UpdateAsync(travelerCheckList);
        }
    }
}
