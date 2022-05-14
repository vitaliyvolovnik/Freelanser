﻿using System.Linq.Expressions;

namespace DLL.Repository.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task<IReadOnlyCollection<TEntity>> FindByConditioAsync(Expression<Func<TEntity, bool>> predicat);

    }
}
