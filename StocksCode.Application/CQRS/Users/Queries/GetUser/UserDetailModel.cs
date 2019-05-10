using System;
using System.Linq.Expressions;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.CQRS.Users.Queries.GetUser
{
    public class UserDetailModel
    {
        public string Username { get; set; }
        public string Email { get; set; }


        public static Expression<Func<User, UserDetailModel>> Projection
        {
            get
            {
                return user => new UserDetailModel
                {
                    Email = user.Email,
                    Username = user.Username
                };
            }
        }

        public static UserDetailModel Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}
