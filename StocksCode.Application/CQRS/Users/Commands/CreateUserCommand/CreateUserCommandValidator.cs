using System;
using FluentValidation;

namespace StocksCode.Application.CQRS.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName).MinimumLength(6).NotEmpty().WithMessage("User Name is Required");
            RuleFor(x => x.Password).MinimumLength(8).NotEmpty().WithMessage("Password minimun Length is 8");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Invalid email");
        }
    }
}
