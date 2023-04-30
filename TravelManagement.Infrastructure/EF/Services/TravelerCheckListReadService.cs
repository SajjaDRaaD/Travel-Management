using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Services;
using TravelManagement.Infrastructure.EF.Contexts;
using TravelManagement.Infrastructure.EF.Models;

namespace TravelManagement.Infrastructure.EF.Services
{
    public class TravelerCheckListReadService : ITravelerCheckListReadService
    {
        private readonly DbSet<TravelerCheckListReadModel> _travelCheckList;

        public TravelerCheckListReadService(ReadDbContext readContext)
        {
            _travelCheckList = readContext.TravelerCheckLists;
        }

        public Task<bool> ExistByNameAsync(string name)
            => _travelCheckList.AnyAsync(x => x.Name == name);
    }
}
