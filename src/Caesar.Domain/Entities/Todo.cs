using System;
using Caesar.Domain.Common;

namespace Caesar.Domain.Entities
{
    public class Todo : IAuditable, IDeletable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set ; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}