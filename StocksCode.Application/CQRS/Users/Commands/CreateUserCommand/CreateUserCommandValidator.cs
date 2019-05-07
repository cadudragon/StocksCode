using System;
using FluentValidation;

namespace StocksCode.Application.CQRS.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserUserName).MinimumLength(6).NotEmpty();
            RuleFor(x => x.UserPassword).MinimumLength(8).NotEmpty();
        }
    }
}
