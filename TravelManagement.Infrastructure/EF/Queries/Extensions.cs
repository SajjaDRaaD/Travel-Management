using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.DTO;
using TravelManagement.Infrastructure.EF.Models;

namespace TravelManagement.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static TravelerCheckListDto AsDto(this TravelerCheckListReadModel readModel)
        {
            return new TravelerCheckListDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Destination = new DestinationDto()
                {
                    City = readModel.Destination.City,
                    Country = readModel.Destination.Country,
                },
                Items = readModel.Items?.Select(x => new TravelerItemDto
                {
                    Name = x.Name,
                    Quantity = x.Quantity,
                    IsTaken = x.IsTaken
                })
            };
        }
    }
}
