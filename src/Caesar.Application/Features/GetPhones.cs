using System.Collections.Generic;
using System.Linq;
using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Caesar.Application.Features
{
    public class GetPhones
    {
        public class Query : IRequest<IEnumerable<Phone>>
        {
            public Query()
            {
            }
        }

        public class QueryHandler : RequestHandler<Query, IEnumerable<Phone>>
        {
            private readonly ICaesarContext _context;

            public QueryHandler(ICaesarContext context)
            {
                _context = context;
            }

            protected override IEnumerable<Phone> Handle(Query request)
            {
                var phones = _context.Phones      
                    .AsNoTracking()
                    .Where(t => !t.IsDeleted)                    
                    .ToList();

                return phones;
            }
        }
    }
}