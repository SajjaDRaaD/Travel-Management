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
    public class RemoveTravelerCheckListHandler : ICommandHandler<RemoveTravelerCheckList>
    {
        private readonly ITravelerCheckListRepository _repository;

        public RemoveTravelerCheckListHandler(ITravelerCheckListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemoveTravelerCheckList command)
        {
            var travelerCheckList = await _repository.GetAsync(command.id);

            if (travelerCheckList == null)
            {
                throw new TravelerCheckLlistNotFound(command.id);
            }

            await _repository.DeleteAsync(travelerCheckList);
        }
    }
}
