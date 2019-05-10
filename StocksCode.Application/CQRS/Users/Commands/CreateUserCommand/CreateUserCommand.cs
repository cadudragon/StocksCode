using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StocksCode.Application.Interfaces;
using StocksCode.Common.Helpers;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.CQRS.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest
    {
        public string UserUserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
    }

    public class Handler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IStocksCodeDbContext _context;
        private readonly IMediator _mediator;

        public Handler(IStocksCodeDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        { 

            EncryptionHelper.CreatePasswordHash(request.UserPassword, out byte[] passwordhash, out byte[] passwordSalt);

            var entity = new User{ Username =  request.UserUserName, Email= request.Email, PasswordHash = passwordhash, PasswordSalt = passwordSalt };

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}

