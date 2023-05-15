using TicketManagement.Application.Features.Events.Queries.GetEventList;
using TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.Application.Features.Events.Commands.CreateEvent;
using TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using TicketManagement.Application.Features.Categories.Queries.GetCategoryListWithEvents;
using TicketManagement.Application.Features.Categories.Queries.GetCategoryList;
using TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;
using TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace TicketManagement.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<TicketManagement.Domain.Entities.Category, CategoryDto>();
            CreateMap<TicketManagement.Domain.Entities.Category, CategoryEventListVm>();
            CreateMap<TicketManagement.Domain.Entities.Category, CategoryListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}