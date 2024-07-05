using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed.Add
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Address { get; set; }
        public string OrderStatus { get; set; }
        public int UnitPrice { get; set; }


        public static Order Map(CreateOrderCommandRequest request)
        {
            return new Order()
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Address = request.Address,
                OrderStatus = "Şipariş alındı",
                UnitPrice = request.UnitPrice,

            };
        }
    }

}