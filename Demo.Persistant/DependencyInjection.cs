using AutoMapper.Configuration;
using Demo.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Persistant
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var conStr = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            if (string.IsNullOrEmpty(conStr))
            {
                conStr = configuration.GetConnectionString("DevConnection");
            }

            services.AddDbContext<OIGDbContext>(options =>
                options.UseSqlServer(conStr));

            services.AddScoped<IOIGDbContext>(provider => provider.GetService<OIGDbContext>());

            return services;
        }
    }
}
