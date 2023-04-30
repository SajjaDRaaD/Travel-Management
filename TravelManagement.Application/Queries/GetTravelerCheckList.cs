using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.DTO;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries
{
    public class GetTravelerCheckList : IQuery<TravelerCheckListDto>
    {
        public Guid Id { get; set; }
    }
}
