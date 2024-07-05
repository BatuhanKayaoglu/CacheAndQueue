using AutoMapper;
using CacheNQueue.Application.Abstractions.Cache;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CacheNQueue.Application.Med.ProductMed.GetAll
{
    public class GettAllProductQueryHandler : IRequestHandler<GettAllProductQueryRequest, List<GettAllProductQueryResponse>>
    {
        readonly IProductRepository _productRepository;
        readonly IRedisCacheService _cacheService;


        public GettAllProductQueryHandler(IProductRepository productRepository, IRedisCacheService cacheService = null)
        {
            _productRepository = productRepository;
            _cacheService = cacheService;
        }


        async Task<List<GettAllProductQueryResponse>> IRequestHandler<GettAllProductQueryRequest, List<GettAllProductQueryResponse>>.Handle(GettAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _cacheService.GetAllAsync(cancellationToken);
            var productDtos = products.Select(x => GettAllProductQueryResponse.Map(x));
            return new List<GettAllProductQueryResponse>(productDtos);
        }
    }
}
