using AzBina.Application.Abstracts.Repositories;
using AzBina.Domain.Entities;
using AzBina.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace AzBina.Persistance.Repositories;

public class CategoryRepository:Repository<Domain.Entities.Category>,ICategoryRepository
{
    public CategoryRepository(AzBinaDbContext context) : base(context)
    {
    }
    private readonly AzBinaDbContext _context;
    public async Task<List<Category>> GetByNameSearchAsync(string namePart)
    {
        return await _context.Categories
            .Where(c => c.Name.Contains(namePart))
            .ToListAsync();
    }
}
