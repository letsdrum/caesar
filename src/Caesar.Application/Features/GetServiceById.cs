using System;
using System.Linq;
using Caesar.Application.Common.Interfaces;
using Caesar.Application.Models.Responses;
using Caesar.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Caesar.Application.Features
{
    public class GetServiceById
    {
        public class Query : IRequest<ServiceVm>
        {
            public Query(Guid serviceId)
            {
                ServiceId = serviceId;
            }

            public Guid ServiceId { get; }
        }

        public class QueryHandler : RequestHandler<Query, ServiceVm>
        {
            private readonly ICaesarContext _context;

            public QueryHandler(ICaesarContext context)
            {
                _context = context;
            }

            protected override ServiceVm Handle(Query request)
            {
                var service = _context.Services
                    .Where(t => !t.IsDeleted)
                    .Include(s => s.Email)
                    .Include(s => s.Phone)
                    .Single(s => s.Id == request.ServiceId);

                var servicVms = MapToServiceVm(service);

                return servicVms;

            }

            private ServiceVm MapToServiceVm(Service service)
            {
                var vm = service is not null
                    ? new ServiceVm()
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
                    }
                    : null;

                return vm;
            }
        }
    }
}