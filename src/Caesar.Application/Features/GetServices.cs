using System.Collections.Generic;
using System.Linq;
using Caesar.Application.Common.Interfaces;
using Caesar.Application.Models.Responses;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Caesar.Application.Features
{
    public class GetServices
    {
        public class Query : IRequest<IEnumerable<ServiceVm>>
        {
            public Query()
            {
            }
        }

        public class QueryHandler : RequestHandler<Query, IEnumerable<ServiceVm>>
        {
            private readonly ICaesarContext _context;

            public QueryHandler(ICaesarContext context)
            {
                _context = context;
            }

            protected override IEnumerable<ServiceVm> Handle(Query request)
            {
                var services = _context.Services
                    .Where(t => !t.IsDeleted)
                    .Include(s => s.Email)
                    .Include(s => s.Phone)
                    .ToList();

                var servicVms = MapToServiceListVm(services);

                return servicVms;
            }

            private IEnumerable<ServiceVm> MapToServiceListVm(IEnumerable<Service> services)
            {
                foreach(var service in services)
                {
                    var vm = new ServiceVm()
                    {
                        Id = service.Id,
                        Name = service.Name,
                        CreatedAt = service.CreatedAt,
                        ModifiedAt = service.ModifiedAt,
                        Email = new EmailVm()
                        {
                            Id = service.Email.Id,
                            EmailValue = service.Email.EmailValue,
                            CreatedAt = service.Email.CreatedAt,
                            ModifiedAt = service.Email.ModifiedAt
                        },
                        Phone = new PhoneVm()
                        {
                            Id = service.Phone.Id,
                            PhoneValue = service.Phone.PhoneValue,
                            CreatedAt = service.Phone.CreatedAt,
                            ModifiedAt = service.Phone.ModifiedAt
                        }
                    };

                    yield return vm;
                }
            }
        }
    }
}