using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.DTO;
using TravelManagement.Application.Queries;
using TravelManagement.Domain.Entities;
using TravelManagement.Infrastructure.EF.Contexts;
using TravelManagement.Infrastructure.EF.Models;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Infrastructure.EF.Queries.Handlers
{
    internal sealed class SearchPackingListsHandler : IQueryHandler<SearchTravelerCheckList, IEnumerable<TravelerCheckListDto>>
    {
        private readonly DbSet<TravelerCheckListReadModel> _travelerCheckLists;

        public SearchPackingListsHandler(ReadDbContext context)
        {
            _travelerCheckLists = context.TravelerCheckLists;
        }

        public async Task<IEnumerable<TravelerCheckListDto>> HandleAsync(SearchTravelerCheckList query)
        {
            var dbQuery = _travelerCheckLists.
                Include(pl => pl.Items)
                .AsQueryable();

            if (query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(pl =>
                    Microsoft.EntityFrameworkCore.EF.Functions.Like(pl.Name, $"%{query.SearchPhrase}%"));
            }

            return await dbQuery
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
