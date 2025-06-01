using AzBina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AzBina.Persistance.Repositories
{
    public interface IRepository<T> where T : BaseEntity , new()
    {
        Task<T> GetByIdAsync(Guid id);
        IQueryable<T> GetByFiltered(Expression<Func<T, bool>>? predicate = null,
            Expression<Func<T, object>>[]? include = null,
            bool isTracking= false);
        IQueryable<T> GetAllFiltered(bool isTracking= false);

        IQueryable<T> GetAllFiltered(Expression<Func<T, bool>>? predicate= null ,
            Expression<Func<T, object>>[]? include=null,
            Expression<Func<T, bool>>? orderBy = null,
            bool isOrderByAsc=true,
            bool isTracking = false);
        Task<T> SaveChangeAsync();
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
