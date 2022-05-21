using System.Linq;
using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Caesar.Application.Features
{
    public class GetTodoById
    {
        public class Query : IRequest<Todo>
        {
            public Query(int todoId)
            {
                TodoId = todoId;
            }

            public int TodoId { get; }
        }

        public class QueryHandler : RequestHandler<Query, Todo>
        {
            private readonly ICaesarContext _caesarContext;

            public QueryHandler(ICaesarContext caesarContext)
            {
                _caesarContext = caesarContext;
            }

            protected override Todo Handle(Query request)
            {
                var todo = _caesarContext.Todos
                    .FirstOrDefault(t => t.Id == request.TodoId &&
                                         !t.IsDeleted);

                return todo;
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.TodoId)
                    .GreaterThan(default(int));
            }
        }
    }
}