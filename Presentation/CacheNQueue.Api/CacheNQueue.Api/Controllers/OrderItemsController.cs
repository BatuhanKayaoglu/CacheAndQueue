using CacheNQueue.Application.Features.OrderItemsMed;
using CacheNQueue.Application.Features.OrderMed.Add;
using CacheNQueue.Application.Med.ProductMed.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CacheNQueue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        readonly IMediator mediator;

        public OrderItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetOrderItemsByOrderIdQueryRequest request = new() { Id = id };
            List<GetOrderItemsByOrderIdQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
