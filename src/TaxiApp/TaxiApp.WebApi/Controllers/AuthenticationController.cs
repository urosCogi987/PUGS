using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaxiApp.Application.Dtos;
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
    }
}
