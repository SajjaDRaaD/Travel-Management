using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Exceptions;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers
{
    public class RemoveTravelerItemHandler : ICommandHandler<RemoveTravelerItem>
    {
        private readonly ITravelerCheckListRepository _repository;

        public RemoveTravelerItemHandler(ITravelerCheckListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemoveTravelerItem command)
        {
            var travelerCheckList = await _repository.GetAsync(command.travelerCheckListId);

            if (travelerCheckList == null)
            {
                throw new TravelerCheckLlistNotFound(command.travelerCheckListId);
            }

            travelerCheckList.RemoveItem(command.name);

            await _repository.UpdateAsync(travelerCheckList);
        }
    }
}
