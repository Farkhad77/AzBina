using AzBina.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AzBina.Persistance.Repositories;

public class FavoriteRepository: Repository<Domain.Entities.Favorite>, Application.Abstracts.Repositories.IFavoriteRepository
{
    public FavoriteRepository(AzBinaDbContext context) : base(context)
    {
    }
    private readonly AzBinaDbContext _context;
    public async Task<List<Domain.Entities.Favorite>> GetByAdIdAsync(Guid adId)
    {
        return await _context.Favorites
            .Where(f => f.AdId == adId)
            .ToListAsync();
    }
    public async Task<bool> IsExistAsync(Guid adId)
    {
        return await _context.Favorites
            .AnyAsync(f => f.AdId == adId);
    }
    public async Task RemoveByAdIdAsync(Guid adId)
    {
        var favorite = await _context.Favorites
            .FirstOrDefaultAsync(f => f.AdId == adId);
        
        if (favorite != null)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }
    }
}
