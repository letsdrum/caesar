using System;
using System.Collections.Generic;
using Caesar.Domain.Common;

namespace Caesar.Domain.Entities
{
    public class Email : IEntity, IAuditable
    {
        public Email()
        {
            Services = new HashSet<Service>();
        }

        public Guid Id { get ; set; }

        public string EmailValue { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}