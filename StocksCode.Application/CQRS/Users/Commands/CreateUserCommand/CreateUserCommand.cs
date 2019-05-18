﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StocksCode.Application.Interfaces;
using StocksCode.Common.Helpers;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.CQRS.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<HttpResponseHelper>
    {
        public string UserUserName { get; set; }
        public string Email {
            get { return Email; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Email = value.ToLower();
                else
                    Email = value;
            }
        }
        public string UserPassword { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, HttpResponseHelper>
    {
        private readonly IStocksCodeDbContext _context;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IStocksCodeDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;

        }

        public async Task<HttpResponseHelper> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AuthenticationHelper.CreatePasswordHash(request.UserPassword, out byte[] passwordhash, out byte[] passwordSalt);

                var entity = new User { Username = request.UserUserName, Email = request.Email, PasswordHash = passwordhash, PasswordSalt = passwordSalt };

                await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);


                return new HttpResponseHelper (HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                switch (ex.HResult)
                {
                    case -2146233088:
                        return new HttpResponseHelper(HttpStatusCode.Conflict);
                    default:
                        return new HttpResponseHelper(HttpStatusCode.InternalServerError);

                }
            }
        }
    }


}

