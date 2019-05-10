using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StocksCode.Application.CQRS.Users.Commands.CreateUserCommand;
using StocksCode.Application.CQRS.Users.Queries.GetUser;

namespace StocksCode.Presentation.Controllers
{
    public class UserController: BaseController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserCommand command)
        {
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        [HttpGet]
        public async Task<ActionResult<UserDetailModel>> Login([FromQuery] LoginUserQuery command) { 
            var ret = await Mediator.Send(command);

            if (ret != null)
                return Ok(ret);

            return Unauthorized();
        }
    }
}
