using System;
using MediatR;

namespace StocksCode.Application.CQRS.Users.Queries.GetUser
{
    public class LoginUserQuery : IRequest<UserDetailDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
