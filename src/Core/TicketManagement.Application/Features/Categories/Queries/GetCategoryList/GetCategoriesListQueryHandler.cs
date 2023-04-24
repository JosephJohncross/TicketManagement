// using TicketManagement.Application.Features.Categories.Queries.GetCategoryList;
using TicketManagement.Domain;
namespace TicketManagement.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<TicketManagement.Domain.Entities.Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(IAsyncRepository<TicketManagement.Domain.Entities.Category> categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.ListAllAsync())
            .OrderBy(x => x.Name);
            return _mapper.Map<List<CategoryListVm>>(allCategories);
        }
    }
}