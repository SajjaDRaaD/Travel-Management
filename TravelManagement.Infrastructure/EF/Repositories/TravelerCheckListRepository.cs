using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Infrastructure.EF.Contexts;
using TravelManagement.Infrastructure.EF.Models;

namespace TravelManagement.Infrastructure.EF.Repositories
{
    public sealed class TravelerCheckListRepository : ITravelerCheckListRepository
    {
        private readonly DbSet<TravelerCheckList> _travelerCheckList;
        private readonly WriteDbContext _writeDbContext;

        public TravelerCheckListRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _travelerCheckList = writeDbContext.TravelerCheckLists;
        }

        public async Task AddAsync(TravelerCheckList travelerCheckList)
        {
            await _travelerCheckList.AddAsync(travelerCheckList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TravelerCheckList travelerCheckList)
        {
            _travelerCheckList.Remove(travelerCheckList);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<TravelerCheckList> GetAsync(TravelerCheckListId id)
            => _travelerCheckList.Include("_items").SingleOrDefaultAsync(pl=> pl.Id == id);

        public async Task UpdateAsync(TravelerCheckList travelerCheckList)
        {
            _travelerCheckList.Update(travelerCheckList);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
