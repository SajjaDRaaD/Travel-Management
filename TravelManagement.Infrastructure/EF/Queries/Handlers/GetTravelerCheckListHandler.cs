using Microsoft.EntityFrameworkCore;
using TravelManagement.Application.DTO;
using TravelManagement.Domain.Repositories;
using TravelManagement.Infrastructure.EF.Contexts;
using TravelManagement.Infrastructure.EF.Models;
using TravelManagement.Infrastructure.EF.Queries;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries.Handlers
{
    public class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
    {
        private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

        public GetTravelerCheckListHandler(ReadDbContext context)
        {
            _travelerCheckList = context.TravelerCheckLists;
        }

        public Task<TravelerCheckListDto> HandleAsync(GetTravelerCheckList query)
            => _travelerCheckList
                .Include(pl => pl.Items)
                .Where(pl => pl.Id == query.Id)
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
}
}
