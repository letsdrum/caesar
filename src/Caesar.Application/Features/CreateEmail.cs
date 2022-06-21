using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Caesar.Application.Features
{
    public class CreateEmail
    {
        public class Command : IRequest
        {
            public Command(string email)
            {
                Email = email;
            }

            public string Email { get; }
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
                var email = new Email()
                {
                    EmailValue = request.Email
                };

                _caesarContext.Emails.Add(email);

                _caesarContext.SaveChanges();
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Email)
                    .NotNull();
            }
        }
    }
}