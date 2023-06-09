﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Application.Exceptions;
using TravelManagement.Application.Services;
using TravelManagement.Domain.Entities;
using TravelManagement.Domain.Factories;
using TravelManagement.Domain.Repositories;
using TravelManagement.Domain.ValueObjects;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Application.Commands.Handlers
{
    public class CreateTravelerCheckListWithItemHandler : ICommandHandler<CreateTravelerCheckListWithItem>
    {
        private readonly ITravelerCheckListRepository _repository;
        private readonly ITravelerCheckListFactory _factory;
        private readonly IWeatherService _weatherService;
        private readonly ITravelerCheckListReadService _readService;

        public CreateTravelerCheckListWithItemHandler(ITravelerCheckListRepository repository, IWeatherService weatherService, ITravelerCheckListFactory factory, ITravelerCheckListReadService readService)
        {
            _repository = repository;
            _weatherService = weatherService;
            _factory = factory;
            _readService = readService;
        }

        public async Task HandleAsync(CreateTravelerCheckListWithItem command)
        {
            var (id, name, days, gender, destinationWriteModel) = command;

            if (await _readService.ExistByNameAsync(name))
            {
                throw new TravelerCheckListAlreadyExistException(name);
            }

            var destination = new Destination(destinationWriteModel.city, destinationWriteModel.country);
            var weather = await _weatherService.GetWeatherAsync(destination);

            if (weather is null)
            {
                throw new MissingDestinationWeatherException(destination);
            }

            var travelerCheckList = _factory.CreateWithDefaultItems(id, name, destination, weather.temperature, days, gender);

            await _repository.AddAsync(travelerCheckList);
        }
    }
}
