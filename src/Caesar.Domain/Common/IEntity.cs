using System;

namespace Caesar.Domain.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}