using DLL.Context;
using DLL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly FreelanserContext _context;
        public BaseRepository(FreelanserContext context)
        {
            this._context = context;
        }

        private DbSet<TEntity> _entities;
        protected DbSet<TEntity> Entities => this._entities ??= _context.Set<TEntity>();


        public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditioAsync(Expression<Func<TEntity, bool>> predicat)
            => await Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() => await Entities.ToListAsync().ConfigureAwait(false);
        public async Task<OperationDetail> CreateAsync(TEntity entity)
        {
            try
            {
                await _entities.AddAsync(entity).ConfigureAwait(false);
                return new OperationDetail() { IsCompleted = true, Message = "Created" };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Create fatal error");
                return new OperationDetail() { IsCompleted = false, Message = "Create fatal error" };
            }
        }
    }
}
