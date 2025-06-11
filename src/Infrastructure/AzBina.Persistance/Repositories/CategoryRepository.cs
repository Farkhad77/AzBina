using AzBina.Application.Abstracts.Repositories;
using AzBina.Persistance.Contexts;

namespace AzBina.Persistance.Repositories;

public class CategoryRepository:Repository<Domain.Entities.Category>,ICategoryRepository
{
    public CategoryRepository(AzBinaDbContext context) : base(context)
    {
    }
}
