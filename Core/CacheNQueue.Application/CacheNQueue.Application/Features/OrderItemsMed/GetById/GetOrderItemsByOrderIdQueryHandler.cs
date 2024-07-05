using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderItemsMed
{
    public class GetOrderItemsByOrderIdQueryHandler : IRequestHandler<GetOrderItemsByOrderIdQueryRequest, List<GetOrderItemsByOrderIdQueryResponse>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public GetOrderItemsByOrderIdQueryHandler(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<List<GetOrderItemsByOrderIdQueryResponse>> Handle(GetOrderItemsByOrderIdQueryRequest request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync(request.Id, cancellationToken);
            var productDtos = orderItems.Select(x => GetOrderItemsByOrderIdQueryResponse.Map(x));


            return new List<GetOrderItemsByOrderIdQueryResponse>(productDtos);
        }
    }
}