using AzBina.Domain.Entities;
using AzBina.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Repositories;

public class CityRepository : Repository<Domain.Entities.City>, Application.Abstracts.Repositories.ICityRepository
{
    public CityRepository(AzBinaDbContext context) : base(context)
    {
    }
    private readonly AzBinaDbContext _context;
    public async Task<List<City>> GetByNameSearchAsync(string namePart)
    {
        return await _context.Cities
            .Where(c => c.Name.Contains(namePart))
            .ToListAsync();
    }
}
