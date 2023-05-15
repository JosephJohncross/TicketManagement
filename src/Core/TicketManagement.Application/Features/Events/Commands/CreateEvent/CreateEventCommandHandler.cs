using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Logging;
namespace TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService, ILogger<CreateEventCommandHandler> logger)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            @event = await _eventRepository.AddAsync(@event);

            // Sending email notification to admin address
            var email = new Email()
            {
                To = "josephibochi@gmail.com",
                Body = $"A new event was created:  {request}",
                Subject = "A new event was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
                // This should't stop the API from doing anything else , so this can be logged
            }
            return @event.EventId;
        }
    }
}