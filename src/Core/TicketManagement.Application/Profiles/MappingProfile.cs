using TicketManagement.Application.Features.Events;
using TicketManagement.Application.Features.Events.Dto;

namespace TicketManagement.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
        }
    }
}