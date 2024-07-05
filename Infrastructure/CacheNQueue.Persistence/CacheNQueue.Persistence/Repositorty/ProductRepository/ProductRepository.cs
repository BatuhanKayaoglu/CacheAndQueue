using CacheNQueue.Domain.Entities;
using CacheNQueue.Persistence.Context;
using CacheNQueue.Persistence.Repositorty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Repositories.ProductRepository
{
    public class ProductRepository : EfCoreRepositoryAsync<Product>, IProductRepository
    {
        public ProductRepository(CacheNQueueDbContext context) : base(context)
        {
        }
    }
}
