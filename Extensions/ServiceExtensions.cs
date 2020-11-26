﻿using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using Motiv.Interfaces;
using Motiv.Datastores;
using System;
using System.Net.Http;

namespace Motiv.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, string baseAddress)
        {
            services.AddHttpClient(baseAddress);
            services.AddLocalStorage();
            services.AddDatastores();
        }

        private static void AddHttpClient(this IServiceCollection services, string baseAddress)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
        }

        private static void AddLocalStorage(this IServiceCollection services)
        {
            services.AddBlazoredLocalStorage(config =>
             config.JsonSerializerOptions.WriteIndented = true);
        }

        private static void AddDatastores(this IServiceCollection services)
        {
            services.AddScoped<ITaskDatastore, TaskDatastore>();
        }
    }
}
