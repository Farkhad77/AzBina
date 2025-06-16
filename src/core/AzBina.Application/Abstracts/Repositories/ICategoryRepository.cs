using AzBina.Domain.Entities;
using AzBina.Persistance.Repositories;

namespace AzBina.Application.Abstracts.Repositories;

public interface ICategoryRepository:IRepository<Domain.Entities.Category>
{
    Task<List<Category>> GetByNameSearchAsync(string namePart);
}
