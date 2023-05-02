using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Shared.Abstractions.Commands;

namespace TravelManagement.Shared.Commands
{
    internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        async Task ICommandDispatcher.DispacheAsync<TCommand>(TCommand command)
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

            await handler.HandleAsync(command);
        }
    }
}
