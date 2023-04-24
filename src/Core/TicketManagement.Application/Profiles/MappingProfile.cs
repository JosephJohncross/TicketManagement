using TicketManagement.Application.Features.Events;
using TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.Application.Features.Categories.Queries.GetCategoryListWithEvents;
using TicketManagement.Application.Features.Categories.Queries.GetCategoryList;

namespace TicketManagement.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<TicketManagement.Domain.Entities.Category, CategoryDto>();
            CreateMap<TicketManagement.Domain.Entities.Category, CategoryEventListVm>();
            CreateMap<TicketManagement.Domain.Entities.Category, CategoryListVm>();
        }
    }
}