using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task DispacheAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
