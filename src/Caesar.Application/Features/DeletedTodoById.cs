using System.Linq;
using Caesar.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Caesar.Application.Features
{
    public class DeletedTodoById
    {
        public class Command : IRequest
        {
            public Command(int todoId)
            {
                TodoId = todoId;
            }

            public int TodoId { get; }
        }

        public class CommandHandler : RequestHandler<Command>
        {
            private readonly ICaesarContext _caesarContext;

            public CommandHandler(ICaesarContext caesarContext)
            {
                _caesarContext = caesarContext;
            }

            protected override void Handle(Command request)
            {
                var todo = _caesarContext.Todos
                    .FirstOrDefault(t => t.Id == request.TodoId);

                if (todo is not null)
                {
                    todo.IsDeleted = true;

                    _caesarContext.SaveChanges();
                }
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TodoId)
                    .GreaterThan(default(int));
            }
        }
    }
}