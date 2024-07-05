using Application.Abstractions.Token;
using CacheNQueue.Application.Abstractions.RabitMQ;
using CacheNQueue.Infrastructure.RabitMQ;
using CacheNQueue.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddTransient<IRabitMQService, RabitMQPublisherService>();


        }
    }
}
