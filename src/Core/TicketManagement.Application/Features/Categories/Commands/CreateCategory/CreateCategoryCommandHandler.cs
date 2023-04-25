namespace TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TicketManagement.Domain.Entities.Category> _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<TicketManagement.Domain.Entities.Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidaionErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidaionErrors.Add(error.ErrorMessage);
                }
            }
            if (createCategoryCommandResponse.Success)
            {
                var category = new TicketManagement.Domain.Entities.Category() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
            }

            return createCategoryCommandResponse;
        }
    }
}