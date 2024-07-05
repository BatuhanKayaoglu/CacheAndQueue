using CacheNQueue.Application.Med.AppUserMed.LoginUser;
using CacheNQueue.Application.Med.ProductMed.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CacheNQueue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {

            CreateUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> UserLogin(LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
