using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StocksCode.Application.CQRS.Users.Commands.CreateUserCommand;
using StocksCode.Application.CQRS.Users.Queries.GetUser;
using StocksCode.Common.Helpers;

namespace StocksCode.Presentation.Controllers
{
    public class UserController: BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var response = await Mediator.Send(command);
            return response.GetObjectResult();
        }

        [HttpGet]
        public async Task<ActionResult<UserDetailDTO>> Login([FromQuery] LoginUserQuery command) {
            var response = await Mediator.Send(command);
            return response.GetObjectResult();

        }
    }
}
