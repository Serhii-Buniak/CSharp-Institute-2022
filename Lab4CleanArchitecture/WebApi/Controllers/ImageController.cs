using Application.Common.Models;
using Application.ImageActions.Commands;
using Application.ImageActions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ImageController : ApiControllerBase
{
    public ImageController()
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetImages()
    {
        IEnumerable<ImageDto> images = await Mediator.Send(new GetImagesQuery());
        return Ok(images);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetImage(long id)
    {
        ImageDto image = await Mediator.Send(new GetImageQuery(id));
        return Ok(image);
    }

    [HttpPost]
    public async Task<IActionResult> CreateImage(CreateImageCommand command)
    {
        ImageDto image = await Mediator.Send(command);
        return Ok(image);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(long id)
    {
        await Mediator.Send(new DeleteImageCommand(id));
        return NoContent();
    }   
    
    [HttpPatch("[action]")]
    public async Task<IActionResult> ChangeGallery(ChangeImageGalleryCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
}