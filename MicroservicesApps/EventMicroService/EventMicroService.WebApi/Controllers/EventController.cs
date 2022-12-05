using AutoMapper;
using EventMicroService.Application.Common.Dtos;
using EventMicroService.Application.EventCQRS.Commands;
using EventMicroService.Application.EventCQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EventMicroService.WebApi.Controllers;

public class EventController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        return Ok(await Mediator.Send(new GetAllEventQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(long id)
    {
        return Ok(await Mediator.Send(new GetEventQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent(CreateEventCommand createEventCommand)
    {
        EventReadDto @event = await Mediator.Send(createEventCommand);
        return CreatedAtAction(nameof(GetEvent), new { @event.Id }, @event);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(long id, UpdateEventCommand updateEventCommand)
    {
        updateEventCommand.SetId(id);
        EventReadDto @event = await Mediator.Send(updateEventCommand);
        return CreatedAtAction(nameof(GetEvent), new { @event.Id }, @event);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(long id)
    {
        await Mediator.Send(new DeleteEventCommand(id));
        return NoContent();
    }

    [HttpPost("{eventId}/Category/{categoryId}")]
    public async Task<IActionResult> AddCategory(long eventId, long categoryId)
    {
        await Mediator.Send(new AddCategoryToEventCommand(eventId, categoryId));
        return Ok();
    }

    [HttpDelete("{eventId}/Category/{categoryId}")]
    public async Task<IActionResult> RemoveCategory(long eventId, long categoryId)
    {
        await Mediator.Send(new RemoveCategoryToEventCommand(eventId, categoryId));
        return Ok();
    }
}
