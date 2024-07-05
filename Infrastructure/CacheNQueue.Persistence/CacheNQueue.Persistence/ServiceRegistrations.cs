using CacheNQueue.Application.Abstractions.Cache;
using CacheNQueue.Application.Cache;
using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using CacheNQueue.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Persistence
{
    public static class ServiceRegistrations
    {
        public static void AddPersistanceService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CacheNQueueDbContext>();

            service.AddStackExchangeRedisCache(Options => Options.Configuration = (configuration["Redis:RedisHost"]));
            service.AddDbContextPool<CacheNQueueDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sql")));
            service.AddScoped<IOrderItemRepository, OrderItemRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IRedisCacheService, RedisCacheService>();
        }
    }
}
