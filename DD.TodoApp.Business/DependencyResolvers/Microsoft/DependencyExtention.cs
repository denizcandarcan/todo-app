using AutoMapper;
using DD.TodoApp.Business.Interfaces;
using DD.TodoApp.Business.Mappings.AutoMapperMappings;
using DD.TodoApp.Business.Services;
using DD.TodoApp.Business.ValidationRules;
using DD.TodoApp.DataAccess.Contexts;
using DD.TodoApp.DataAccess.UnitofWork;
using DD.TodoApp.Dtos.WorkDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DD.TodoApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtention
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("Connstring");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
        }
    }
}
