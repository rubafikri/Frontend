﻿using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace BooksApiExample.Mapping
{
    public static class DependencyInjection 
    {

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    
}
}