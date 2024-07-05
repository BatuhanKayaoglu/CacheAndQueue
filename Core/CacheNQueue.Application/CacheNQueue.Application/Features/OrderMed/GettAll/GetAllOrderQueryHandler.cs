using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryrResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<GetAllOrderQueryrResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAllAsync(cancellationToken);
            var orderList = order.Select(x => GetAllOrderQueryrResponse.Map(x));
            return new List<GetAllOrderQueryrResponse>(orderList);


        }
    }
}