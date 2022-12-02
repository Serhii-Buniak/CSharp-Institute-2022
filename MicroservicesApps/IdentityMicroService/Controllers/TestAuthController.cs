using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static IdentityMicroService.Constants.AuthorizationConfigs;

namespace IdentityMicroService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestAuthController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Authorize()
    {
        return Ok();
    }    
    
    [HttpGet]
    [Authorize(Roles = $"{Moderator}")]
    public IActionResult AuthorizeModerator()
    {
        return Ok();
    }
}
