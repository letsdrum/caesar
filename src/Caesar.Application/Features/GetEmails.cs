using System.Collections.Generic;
using System.Linq;
using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Caesar.Application.Features
{
    public class GetEmails
    {
        public class Query : IRequest<IEnumerable<Email>>
        {
            public Query()
            {
            }
        }

        public class QueryHandler : RequestHandler<Query, IEnumerable<Email>>
        {
            private readonly ICaesarContext _context;

            public QueryHandler(ICaesarContext context)
            {
                _context = context;
            }

            protected override IEnumerable<Email> Handle(Query request)
            {
                var emails = _context.Emails
                    .AsNoTracking()
                    .Where(t => !t.IsDeleted)                    
                    .ToList();

                return emails;
            }
        }
    }
}