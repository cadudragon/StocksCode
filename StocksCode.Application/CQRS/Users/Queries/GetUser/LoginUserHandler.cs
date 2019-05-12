using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StocksCode.Application.Interfaces;
using StocksCode.Common.Helpers;

namespace StocksCode.Application.CQRS.Users.Queries.GetUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, UserDetailDTO>
    {
        private readonly IStocksCodeDbContext _context;

        public LoginUserHandler(IStocksCodeDbContext context)
        {
            _context = context;
        }

        public async Task<UserDetailDTO> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user == null)
                return new UserDetailDTO { StatusCode = System.Net.HttpStatusCode.Unauthorized, Message = "Invalid Credentials."};

            if (!EncryptionHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                return new UserDetailDTO { StatusCode = System.Net.HttpStatusCode.Unauthorized, Message = "Invalid Credentials." };

            return UserDetailDTO.Create(user);

        }
    }
}
