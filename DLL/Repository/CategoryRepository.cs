using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(FreelanserContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<Category>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.SubCategory)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Category>> FindByConditioAsync(Expression<Func<Category, bool>> predicat)
        {
            return await Entities
                .Include(x => x.SubCategory)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
