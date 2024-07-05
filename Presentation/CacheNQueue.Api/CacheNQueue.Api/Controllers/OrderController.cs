using CacheNQueue.Application.Features.OrderMed;
using CacheNQueue.Application.Features.OrderMed.Add;
using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Application.Med.ProductMed.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CacheNQueue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Add(CreateOrderCommandRequest reques)
        {
            CreateOrderCommandResponse response = await mediator.Send(reques);
            return Ok(response);

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GettById()
        {
            GetAllOrderQueryRequest request = new GetAllOrderQueryRequest();
            List<GetAllOrderQueryrResponse> response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
