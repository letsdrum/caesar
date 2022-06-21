using System;
using Caesar.Domain.Common;

namespace Caesar.Domain.Entities
{
    public class Service : IEntity, IAuditable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Email Email { get; set; }

        public Phone Phone { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}