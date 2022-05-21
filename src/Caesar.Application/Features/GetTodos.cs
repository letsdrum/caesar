using System.Collections.Generic;
using System.Linq;
using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Caesar.Application.Features
{
    public class GetTodos
    {
        public class Query : IRequest<IEnumerable<Todo>>
        {
            public Query()
            {
            }
        }

        public class QueryHandler : RequestHandler<Query, IEnumerable<Todo>>
        {
            private readonly ICaesarContext _context;

            public QueryHandler(ICaesarContext context)
            {
                _context = context;
            }

            protected override IEnumerable<Todo> Handle(Query request)
            {
                var todos = _context.Todos
                    .Where(t => !t.IsDeleted)
                    .ToList();

                return todos;
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {

            }
        }
    }
}