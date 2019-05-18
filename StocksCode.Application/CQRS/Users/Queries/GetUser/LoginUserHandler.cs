using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StocksCode.Application.Interfaces;
using StocksCode.Common.Helpers;

namespace StocksCode.Application.CQRS.Users.Queries.GetUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, HttpResponseHelper>
    {
        private readonly IStocksCodeDbContext _context;
        private readonly IConfiguration _config;

        public LoginUserHandler(IStocksCodeDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<HttpResponseHelper> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p=> p.Email == request.Email.ToLower());
            if (user == null)
                return new HttpResponseHelper(System.Net.HttpStatusCode.Unauthorized);

            if (!AuthenticationHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                return new HttpResponseHelper(System.Net.HttpStatusCode.Unauthorized);

            var confHelper = ConfigurationHelper.
               GetJsonConfigurationByRelativePath("StocksCode.Presentation", "ASPNETCORE_ENVIRONMENT");

            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                 new Claim(ClaimTypes.Name, user.Username)};

            var compactToken = AuthenticationHelper.GetCompactToken(claims, confHelper.
                GetSection("AppSettings:SecretKey").Value, DateTime.Now.AddDays(5));

            return new HttpResponseHelper(new { token = compactToken }, System.Net.HttpStatusCode.OK);

        }
    }
}
