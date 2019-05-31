using CQ.Note.Core.Providers;
using CQ.Note.Core.Providers.Impl;
using CQ.Note.Core.Repositories;
using CQ.Note.Core.Repositories.Impl;
using CQ.Note.Core.Services;
using CQ.Note.Core.Services.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CQ.Note.Core
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddNoteCore(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Models.Note, Guid>, Repository<Models.Note, Guid>>();
            services.AddScoped<IService<Models.Note, Guid>, Service<Models.Note, Guid>>();
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}
