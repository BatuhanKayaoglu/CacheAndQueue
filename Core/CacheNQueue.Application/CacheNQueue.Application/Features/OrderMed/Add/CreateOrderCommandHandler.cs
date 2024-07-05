using AutoMapper;
using CacheNQueue.Application.Abstractions.RabitMQ;
using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using Pipelines.Sockets.Unofficial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed.Add
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IRabitMQService _rabbitMQService;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IRabitMQService rabbitMQService)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _rabbitMQService = rabbitMQService;
        }



        async Task<CreateOrderCommandResponse> IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>.Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {


            var orderMap = CreateOrderCommandRequest.Map(request);


            await _orderRepository.AddAsync(orderMap, cancellationToken);

            var user = await _orderRepository.GetUserAsync(request.UserId);
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            OrderItem orderItem = new()
            {
                Order = orderMap,
                appUser = user,
                Product = product,
            };
            //await _orderItemRepository.AddAsync(orderItem, cancellationToken);

            await _rabbitMQService.Message(Convert.ToString(orderItem), "Order");


            return new()
            {
                Message = "Başarılı"
            };
        }
    }
}