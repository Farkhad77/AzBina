using AzBina.Domain.Entities;
using AzBina.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Application.Abstracts.Repositories;

public interface ICityRepository:IRepository<Domain.Entities.City>
{
    Task<List<City>> GetByNameSearchAsync(string namePart);
}
