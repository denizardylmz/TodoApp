using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Todo.Business.Interfaces;
using Todo.Business.Mappings;
using Todo.Business.Services;
using Todo.Business.ValidationRules;
using TodoApp.DTOs.WorkDtos;

namespace Todo.Business.Registrations;

public static class BusinessRegistration
{
    public static void AddBusinessRegistration(this IServiceCollection provider)
    {
        provider.AddScoped<IWorkService, WorkService>();

        var configurations = new MapperConfiguration(opt =>
            opt.AddProfile(new WorkProfile()));

        var mapper = configurations.CreateMapper();

        provider.AddSingleton(mapper);

        provider.AddScoped<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
        provider.AddScoped<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
    }
}