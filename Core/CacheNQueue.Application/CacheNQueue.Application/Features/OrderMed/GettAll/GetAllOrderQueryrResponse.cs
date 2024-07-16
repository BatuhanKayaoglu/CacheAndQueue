using CacheNQueue.Application.Med.ProductMed.GetById;
using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed
{
    public class GetAllOrderQueryrResponse
    {
        public Order order { get; set; }

        public static GetAllOrderQueryrResponse Map(Order order)
        {
            return new GetAllOrderQueryrResponse
            {
                order = order,
            };
        }
    }
}
