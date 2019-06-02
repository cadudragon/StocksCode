using System;
using System.Linq.Expressions;
using System.Net;
using Newtonsoft.Json;
using StocksCode.Common.Helpers;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.CQRS.Users.Models
{
    public class UserDetailDTO 
    {
        public string Username { get; set; }
        public string Email { get; set; }


        public static Expression<Func<User, UserDetailDTO>> Projection => user => new UserDetailDTO
        {
            Email = user.Email,
            Username = user.Username
        };

        public static UserDetailDTO Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}
