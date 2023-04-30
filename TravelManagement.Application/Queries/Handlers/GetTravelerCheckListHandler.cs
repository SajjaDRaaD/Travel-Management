using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.DTO;
using TravelManagement.Domain.Repositories;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries.Handlers
{
    public class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
    {
        private readonly ITravelerCheckListRepository _repository;

        public GetTravelerCheckListHandler(ITravelerCheckListRepository repository)
        {
            _repository = repository;
        }

        public async Task<TravelerCheckListDto> HandleAsync(GetTravelerCheckList query)
        {
            var travelerCheckList = await _repository.GetAsync(query.Id);
            return null;
        }
    }
}
