using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DLL.Repository
{
    public class WorkRepository : BaseRepository<Work>, IWorkRepository
    {
        public WorkRepository(FreelanserContext context) : base(context)
        {

        }
        public override async Task<IReadOnlyCollection<Work>> FindByConditioAsync(Expression<Func<Work, bool>> predicat)
        {
            return await Entities
                .Include(x => x.Files)
                .Include(x => x.Coments)
                .Include(x => x.Category)
                .Include(x => x.Skills)
                .Include(x => x.ProgectFiles)
                .Include(x => x.Review)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task<IReadOnlyCollection<Work>> FindByConditioWithUsersAsync(Expression<Func<Work, bool>> predicat)
        {
            return await Entities
                .Include(x => x.Customer)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Worker)
                .ThenInclude(x => x.User)
                .ThenInclude(x => x.UserInfo)
                .Include(x => x.Files)
                .Include(x => x.Coments)
                .Include(x => x.Category)
                .Include(x => x.Skills)
                .Include(x => x.ProgectFiles)
                .Include(x => x.Review)
                .Where(predicat)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Work>> GetAllAsync()
        {
            return await Entities
                .Include(x => x.Files)
                .Include(x => x.Coments)
                .Include(x => x.Category)
                .Include(x => x.Skills)
                .Include(x => x.ProgectFiles)
                .Include(x => x.Review)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task<IReadOnlyCollection<Work>> GetAllWithUsersAsync()
        {
            return await Entities
                .Include(x => x.Files)
                .Include(x => x.Coments)
                .Include(x => x.Category)
                .Include(x => x.Skills)
                .Include(x => x.ProgectFiles)
                .Include(x=>x.Review)
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task UpdateAsync(int OldWorkId, Work NewWork)
        {
            var works = Entities.Where(x => x.Id == OldWorkId);
            if (works.Count() == 0) return;
            var work = works.First();
            work.Files = NewWork.Files;
            work.Context = NewWork.Context;
            work.Category = NewWork.Category;
            work.Skills = NewWork.Skills;
            work.IsFinished = NewWork.IsFinished;
            work.Name = NewWork.Name;
            work.Price = NewWork.Price;
            base._context.Entry(work).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);

        }
        public async Task<bool> TakeWorkAsync(int workId, int EmployeeId)
        {
            try
            {


                var work = await Entities.FirstAsync(x => x.Id == workId).ConfigureAwait(false);
                work.Validation = ValidateState.IsTaken;
                work.WorkerId = EmployeeId;
                base._context.Entry(work).State = EntityState.Modified;
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch
            {
                return false;
            }


            return true;
        }
        public async Task<bool> CanselWorkAsync(int CustomerId, int WorkId)
        {
            var works = Entities.Where(x => x.Id == WorkId && x.Customer.Id == CustomerId);
            if (works.Count() == 0) return false;
            var work = works.First();
            work.IsPublicshed = false;
            base._context.Entry(work).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        public async Task<bool> AddComentAsync(int WorkId, Comment comment)
        {
            try
            {
                var work = await Entities.FirstAsync(x => x.Id == WorkId).ConfigureAwait(false);
                work.Coments.Add(comment);
                _context.Entry(work).State = EntityState.Modified;
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;

            }


        }
        public async Task ChangeValidState(int WorkId, ValidateState state)
        {
            var Work = await Entities.FindAsync(WorkId).ConfigureAwait(false);
            Work.Validation = state;
            base._context.Entry(Work).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task UploadFile(int WorkId, List<Domain.Models.File> files)
        {
            var work = await Entities.FindAsync(WorkId).ConfigureAwait(false);
            work.ProgectFiles = files;
            base._context.Entry(work).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task FinishWork(int WorkId)
        {
            var Work = await Entities.FindAsync(WorkId).ConfigureAwait(false);
            Work.IsFinished = true;
            base._context.Entry(Work).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
