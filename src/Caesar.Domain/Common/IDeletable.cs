namespace Caesar.Domain.Common
{
    public interface IDeletable
    {
        public bool IsDeleted { get; set; }
    }
}