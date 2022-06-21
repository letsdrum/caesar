using System;
using System.Linq;
using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Caesar.Application.Features
{
    public class CreateService
    {
        public class Command : IRequest
        {
            public Command(
                string serviceName, 
                Guid emailId, 
                Guid phoneId)
            {
                ServiceName = serviceName;
                EmailId = emailId;
                PhoneId = phoneId;
            }

            public string ServiceName { get; }

            public Guid EmailId { get; }

            public Guid PhoneId { get; }
        }

        public class CommandHandler : RequestHandler<Command>
        {
            private readonly ICaesarContext _caesarContext;

            public CommandHandler(ICaesarContext context)
            {
                _caesarContext = context;
            }

            protected override void Handle(Command request)
            {
                var phone = _caesarContext.Phones
                    .SingleOrDefault(p => p.Id == request.PhoneId);

                var email = _caesarContext.Emails
                    .SingleOrDefault(p => p.Id == request.EmailId);

                var service = new Service()
                {
                    Name = request.ServiceName,
                    Email = email,
                    Phone = phone
                };

                _caesarContext.Services.Add(service);

                _caesarContext.SaveChanges();
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ServiceName)
                    .NotNull();

                RuleFor(x => x.EmailId)
                    .NotNull();

                RuleFor(x => x.PhoneId)
                    .NotNull();
            }
        }
    }
}