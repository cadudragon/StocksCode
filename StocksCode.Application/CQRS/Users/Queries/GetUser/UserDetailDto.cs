using System;
using System.Linq.Expressions;
using System.Net;
using Newtonsoft.Json;
using StocksCode.Common.Helpers;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.CQRS.Users.Queries.GetUser
{
    public class UserDetailDTO : HttpResponseHelper
    {
        public string Username { get; set; }
        public string Email { get; set; }


        public static Expression<Func<User, UserDetailDTO>> Projection => user => new UserDetailDTO
        {
            Email = user.Email,
            Username = user.Username,
            StatusCode = HttpStatusCode.OK,
            Message = JsonConvert.SerializeObject(
                new
                {
                    user.Email,
                    user.Username
                })
        };

        public static UserDetailDTO Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}
