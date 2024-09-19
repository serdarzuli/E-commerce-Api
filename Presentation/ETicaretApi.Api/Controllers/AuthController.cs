using ETicaretApi.Application.Features.Commands.AppUsers.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace ETicaretApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
    }
}