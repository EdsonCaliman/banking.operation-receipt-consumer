﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IRepository, Repository>();
        }
    }
}
