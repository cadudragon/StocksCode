using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StocksCode.Application.CQRS.Users.Commands.CreateUserCommand;

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
    }
}
