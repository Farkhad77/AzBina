using AzBina.Domain.Entities;
using AzBina.Persistance.Repositories;

namespace AzBina.Application.Abstracts.Repositories;

public interface ITownshipRepository : IRepository<Township>
{
    Task<List<Township>> GetByDistrictIdAsync(Guid districtId);
    Task<bool> IsExistAsync(string name, Guid districtId);
    Task<List<Township?>> GetByNameAsync(string name, Guid districtId);
}
