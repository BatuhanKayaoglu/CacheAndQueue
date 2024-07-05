using CacheNQueue.Application.Features.OrderMed;
using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order = CacheNQueue.Domain.Entities.Order;

namespace CacheNQueue.Application.Features.OrderItemsMed
{
    public class GetOrderItemsByOrderIdQueryResponse
    {
        public string Name { get; set; } // Ürün adı 
        public string Description { get; set; } // Ürün açıklaması  
        public decimal Price { get; set; } // Ürün fiyatı 
        public string Address { get; set; }
        public string OrderStatus { get; set; }
        public int UnitPrice { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public static GetOrderItemsByOrderIdQueryResponse Map(OrderItem orderItem)
        {
            return new GetOrderItemsByOrderIdQueryResponse
            {

                Surname = orderItem.appUser.Surname,
                Email = orderItem.appUser.Email,
                Address = orderItem.Order.Address,
                Name = $"Ürün ismi:{orderItem.Product.Name}",
                Description = orderItem.Product.Description,
                Price = orderItem.Product.Price,
                OrderStatus = orderItem.Order.OrderStatus,
                UnitPrice = orderItem.Order.UnitPrice,


            };




        }

    }
}
