using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderItemsMed
{
    public class GetOrderItemsByOrderIdQueryRequest : IRequest<List<GetOrderItemsByOrderIdQueryResponse>>
    {
        public Guid Id { get; set; }


    }
}