using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Caesar.Application.Features
{
    public class CreatePhone
    {
        public class Command : IRequest
        {
            public Command(string phone)
            {
                Phone = phone;
            }

            public string Phone { get; }
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
                var phone = new Phone()
                {
                    PhoneValue = request.Phone
                };

                _caesarContext.Phones.Add(phone);

                _caesarContext.SaveChanges();
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {

            }
        }
    }
}