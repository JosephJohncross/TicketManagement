using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Features.Orders.Queries.GetOrdersForMonth;

namespace TicketManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getpagedordersformonth", Name ="GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonhQuery = new GetOrdersForMonthQuery() {
                Date = date,
                Page = page,
            };
            var dtos = await _mediator.Send(getOrdersForMonhQuery);

            return Ok(dtos);
        }
    }
}