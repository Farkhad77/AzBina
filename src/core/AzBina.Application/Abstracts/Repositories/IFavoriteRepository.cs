using AzBina.Domain.Entities;
using AzBina.Persistance.Repositories;

namespace AzBina.Application.Abstracts.Repositories;

public interface IFavoriteRepository:IRepository<Favorite>
{
    Task<List<Favorite>> GetByAdIdAsync(Guid adId);
    Task<bool> IsExistAsync(Guid adId);
    Task RemoveByAdIdAsync(Guid adId);
}
