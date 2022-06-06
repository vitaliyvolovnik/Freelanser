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
                .Include(x => x.Skill)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Category>> FindByConditioAsync(Expression<Func<Category, bool>> predicat)
        {
            return await Entities
                .Include(x => x.SubCategory)
                .Where(predicat)
                .Include(x=>x.Skill)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task AddSubCategory(int id, List<Category> subCategories)
        {
            var category = Entities.Find(id);
            foreach (var item in subCategories)
                category.SubCategory.Add(item);


            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
