using AzBina.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AzBina.Persistance.Repositories;

public class TownshipRepository: Repository<Domain.Entities.Township>, Application.Abstracts.Repositories.ITownshipRepository
{
    public TownshipRepository(AzBinaDbContext context) : base(context)
    {
    }
    private readonly AzBinaDbContext _context;
    public async Task<List<Domain.Entities.Township>> GetByDistrictIdAsync(Guid districtId)
    {
        return await _context.Townships
            .Where(t => t.DistrictId == districtId)
            .ToListAsync();
    }
    public async Task<bool> IsExistAsync(string name, Guid districtId)
    {
        return await _context.Townships
            .AnyAsync(t => t.Name == name && t.DistrictId == districtId);
    }
    public async Task<List<Domain.Entities.Township?>> GetByNameAsync(string name, Guid districtId)
    {
        return await _context.Townships
            .Where(t => t.Name == name && t.DistrictId == districtId)
            .ToListAsync();
    }
}
