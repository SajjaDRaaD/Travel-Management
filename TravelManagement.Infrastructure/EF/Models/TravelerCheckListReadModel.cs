using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Infrastructure.EF.Models
{
    public class TravelerCheckListReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public DestinationReadModel Destination { get; set; }
        public ICollection<TravelerItemReadModel> Item { get; set; }
    }
}
