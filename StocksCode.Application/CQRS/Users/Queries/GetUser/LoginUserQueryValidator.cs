using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StocksCode.Application.Interfaces;

namespace StocksCode.Application.CQRS.Users.Queries.GetUser
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.Password).MinimumLength(8).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }

    }
}
