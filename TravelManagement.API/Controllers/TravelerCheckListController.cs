 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelManagement.Application.Commands;
using TravelManagement.Application.DTO;
using TravelManagement.Application.Queries;
using TravelManagement.Shared.Abstractions.Commands;
using TravelManagement.Shared.Abstractions.Queries;

namespace TravelManagement.API.Controllers
{

    public class TravelerCheckListController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public TravelerCheckListController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TravelerCheckListDto>> Get([FromRoute] GetTravelerCheckList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelerCheckListDto>>> Get([FromQuery] SearchTravelerCheckList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTravelerCheckListWithItem command)
        {
            await _commandDispatcher.DispacheAsync(command);
            return CreatedAtAction(nameof(Get), new { Id = command.id }, null);
        }

        [HttpPut("{TravelerCheckListId:guid}/items/")]
        public async Task<IActionResult> Put([FromBody] AddTravelerItem command)
        {
            await _commandDispatcher.DispacheAsync(command);
            return Ok();
        }


        [HttpPut("{TravelerCheckListId:guid}/items/{name}/Take")]
        public async Task<IActionResult> Put([FromBody] TakeItem command)
        {
            await _commandDispatcher.DispacheAsync(command);
            return Ok();
        }

        [HttpDelete("{TravelerCheckListId:guid}/items/{name}/")]
        public async Task<IActionResult> Delete([FromBody] RemoveTravelerItem command)
        {
            await _commandDispatcher.DispacheAsync(command);
            return Ok();
        }
    }
}
