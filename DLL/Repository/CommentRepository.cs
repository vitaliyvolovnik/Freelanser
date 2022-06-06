﻿using DLL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(FreelanserContext context) : base(context)
        {

        }
        public async override Task<IReadOnlyCollection<Comment>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.User)
                .Include(x => x.Comments)
                .Include(x => x.Work)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async override Task<IReadOnlyCollection<Comment>> FindByConditioAsync(Expression<Func<Comment, bool>> predicat)
        {
            return await Entities
                 .Include(x => x.User)
                 .Include(x => x.Comments)
                 .Include(x => x.Work)
                 .Where(predicat)
                 .ToListAsync()
                 .ConfigureAwait(false);
        }
        public async Task AddSubCooment(int CommentId,Comment Subcomment)
        {
            var comment = await Entities.Include(x=>x.Work).FirstOrDefaultAsync(x=>x.Id==CommentId);
            comment.Comments.Add(Subcomment);
            Subcomment.Work = comment.Work;
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
