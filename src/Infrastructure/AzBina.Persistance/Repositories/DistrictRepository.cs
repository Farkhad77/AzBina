using AzBina.Application.Abstracts.Repositories;
using AzBina.Domain.Entities;
using AzBina.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Repositories;

public class DistrictRepository : Repository<District> , IDistrictRepository
{
    public DistrictRepository(AzBinaDbContext context) : base(context)
    {
    }
    private readonly AzBinaDbContext _context;
    public async Task<List<District>> GetByNameSearchAsync(string namePart)
    {
        return await _context.Districts
            .Where(c => c.Name.Contains(namePart))
            .ToListAsync();
    }
    // Additional methods specific to District can be added here
}
