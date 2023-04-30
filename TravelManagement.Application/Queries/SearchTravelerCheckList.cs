using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.DTO;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.Application.Queries
{
    public class SearchTravelerCheckList : IQuery<IEnumerable<TravelerCheckListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
