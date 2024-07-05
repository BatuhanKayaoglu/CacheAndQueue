using AutoMapper;
using CacheNQueue.Application.Abstractions.Cache;
using CacheNQueue.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductRepository productRepository;
        readonly IRedisCacheService _cacheService;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IRedisCacheService cacheService = null)
        {
            this.productRepository = productRepository;
            _cacheService = cacheService;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _cacheService.GetByıdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
            }
            if (product != null)
            {
                return GetByIdProductQueryResponse.Map(product);
            }

            throw new Exception("Böyle bir veri bulunmamakta");
        }
    }
}
