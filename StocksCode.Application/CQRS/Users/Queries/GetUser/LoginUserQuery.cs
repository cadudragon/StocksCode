using System;
using MediatR;
using StocksCode.Common.Helpers;

namespace StocksCode.Application.CQRS.Users.Queries.GetUser
{
    public class LoginUserQuery : IRequest<HttpResponseHelper>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
