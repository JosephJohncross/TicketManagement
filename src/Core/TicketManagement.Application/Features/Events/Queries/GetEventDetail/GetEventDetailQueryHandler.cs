using TicketManagement.Application.Contracts.Persistence;


namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {

        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<TicketManagement.Domain.Entities.Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<TicketManagement.Domain.Entities.Category> categoryRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            var eventDetailsDto = _mapper.Map<EventDetailVm>(@event);

            var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

            eventDetailsDto.Category = _mapper.Map<CategoryDto>(category);
            return eventDetailsDto;
        }
    }
}