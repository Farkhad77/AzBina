using AzBina.Application.Abstracts.Repositories;
using AzBina.Application.Abstracts.Services;
using AzBina.Application.Validations;
using AzBina.Persistance.Repositories;
using AzBina.Persistance.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace AzBina.Persistance;

public static class ServiceRegistration
{
    public static void RegisterService(this IServiceCollection services)
    {
        #region Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();   
        services.AddScoped<ICityRepository, CityRepository>();
        #endregion

        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFileUpload, FileUploadService>();
        services.AddScoped<ICityService, CityService>();
        #endregion

    }
}
