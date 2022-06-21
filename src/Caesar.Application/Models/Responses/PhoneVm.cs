using System;

namespace Caesar.Application.Models.Responses
{
    public class PhoneVm
    {
        public Guid Id { get; set; }

        public string PhoneValue { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}