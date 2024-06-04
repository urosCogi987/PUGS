using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Dtos;
using TaxiApp.Infrastructure.Authentication;
using TaxiApp.Kernel.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(ILogger<AuthenticationController> logger,
                                          IMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest registerUserRequest)
        {
            Guid id = await mediator.Send(registerUserRequest.MapToRegisterUserCommand());
            logger.LogInformation($"User with id: {id} registered");
            return Ok(id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
        {
            TokensDto tokensDto = await mediator.Send(loginUserRequest.MapToLoginUserCommand());
            return Ok(new LoginUserResponse(tokensDto));
        }

        [HttpPost("logout")]
        [Authorize]
        [HasPermission(PermissionNames.TestPermission)]
        public async Task<IActionResult> Logout()
        {
            
            return Ok("radi autorizacija/autentikacija");
        }
    }
}
