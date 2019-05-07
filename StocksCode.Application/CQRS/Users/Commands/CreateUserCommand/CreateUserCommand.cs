using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StocksCode.Application.Interfaces;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.CQRS.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest
    {
        public string UserUserName { get; set; }
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
            var entity = new User{ Username =  request.UserUserName };
            _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}

