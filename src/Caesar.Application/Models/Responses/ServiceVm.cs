using System;

namespace Caesar.Application.Models.Responses
{
    public class ServiceVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public PhoneVm Phone { get; set; }

        public EmailVm Email { get; set; }
    }
}