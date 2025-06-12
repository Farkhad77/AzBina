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
        #endregion
        
        #region Services
        services.AddScoped<ICategoryService, CategoryService>();
        #endregion
        
    }
}
