using Application.Abstractions.Token;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application
{
    public static class ServiceRegistrations
    {
        public static void AddAplicationService(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddFluentValidation(p => p.RegisterValidatorsFromAssembly(assm));
            services.AddMediatR(assm);
            services.AddAutoMapper(assm);


        }
    }
}
