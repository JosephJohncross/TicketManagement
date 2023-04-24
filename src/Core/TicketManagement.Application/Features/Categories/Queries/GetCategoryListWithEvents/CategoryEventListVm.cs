namespace TicketManagement.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class CategoryEventListVm
    {
        public Guid CateoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}