using System;
using Caesar.Domain.Common;

namespace Caesar.Domain.Entities
{
    public class EmailTemplate : IEntity, IAuditable
    {
        public Guid Id { get; set; }

        public string TemplateValue { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}