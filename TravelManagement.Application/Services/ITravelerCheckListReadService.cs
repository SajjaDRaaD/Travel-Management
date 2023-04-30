using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Services
{
    public interface ITravelerCheckListReadService
    {
        Task<bool> ExistByNameAsync(string name);
    }
}
