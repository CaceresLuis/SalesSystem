﻿namespace SalesSystem.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}