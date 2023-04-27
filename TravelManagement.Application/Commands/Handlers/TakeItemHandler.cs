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
    public class TakeItemHandler : ICommandHandler<TakeItem>
    {
        private readonly ITravelerCheckListRepository _repository;

        public TakeItemHandler(ITravelerCheckListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(TakeItem command)
        {
            var travelerCheckList = await _repository.GetAsync(command.travelerCheckListId);

            if (travelerCheckList == null)
            {
                throw new TravelerCheckLlistNotFound(command.travelerCheckListId);
            }

            travelerCheckList.TakeItem(command.name);

            await _repository.UpdateAsync(travelerCheckList);
        }
    }
}
