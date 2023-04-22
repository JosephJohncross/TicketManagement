namespace TicketManagement.Domain.Common
{
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastNodifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}