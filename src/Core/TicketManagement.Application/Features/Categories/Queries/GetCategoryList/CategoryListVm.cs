namespace TicketManagement.Application.Features.Categories.Queries.GetCategoryList
{
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}