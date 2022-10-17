using Application.Common.Models;
using Application.GalleryActions.Commands;
using Application.GalleryActions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class GalleryController : ApiControllerBase
{
    public GalleryController()
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetGalleries()
    {
        IEnumerable<GalleryDto> galleries = await Mediator.Send(new GetGalleriesQuery());
        return Ok(galleries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGallery(long id)
    {
        GalleryDto gallery = await Mediator.Send(new GetGalleryQuery(id));
        return Ok(gallery);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGallery(CreateGalleryCommand command)
    {
        GalleryDto gallery = await Mediator.Send(command);
        return Ok(gallery);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGallery(long id)
    {
        await Mediator.Send(new DeleteGalleryCommand(id));
        return NoContent();
    }
}