using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Application.Med.ProductMed.Delete;
using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Application.Med.ProductMed.GetById;
using CacheNQueue.Application.Med.ProductMed.Update;
using CacheNQueue.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace CacheNQueue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductController : ControllerBase
    {
        readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandReques reques)
        {
            CreateProductCommandResponse response = await mediator.Send(reques);
            return Ok(response);
        }


        [HttpDelete("DeleteId")]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("UpdateId")]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            ProductUpdateCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GettAllProductQueryRequest request = new GettAllProductQueryRequest();
            return Ok(await mediator.Send(request));
        }


        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdProductQueryRequest request1 = new() { Id = id };
            GetByIdProductQueryResponse response = await mediator.Send(request1);
            return Ok(response);
        }




    }
}
