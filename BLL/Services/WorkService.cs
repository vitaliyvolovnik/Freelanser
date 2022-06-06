using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WorkService : IWorkService, ICommentService
    {
        private readonly WorkRepository _workRepository;
        private readonly CommentRepository _commentRepository;

        public WorkService(WorkRepository workRepository, CommentRepository commentRepository)
        {
            this._workRepository = workRepository;

            this._commentRepository = commentRepository;
        }

        public async Task<Work> GetWorkByIdAsync(int id)
        {
            var works = await _workRepository.FindByConditioWithUsersAsync(x => x.Id == id);
            if (works.Count() == 0) return null;
            return works.First();

        }
        public async Task<IReadOnlyCollection<Work>> GetWorksAsync()
        {
            return await _workRepository.GetAllAsync();
        }
        public async Task<List<Work>> GetWorksByCategorysAsync(Category category)
        {
            return (await _workRepository.FindByConditioWithUsersAsync(x => x.Category.Name == category.Name)).ToList();
        }
        public async Task<List<Work>> GetWorksWithUsersAsync()
        {
            return (await _workRepository.GetAllWithUsersAsync()).ToList();
        }
        public async Task<IReadOnlyCollection<Work>> FindByConditiom(Expression<Func<Work, bool>> prediacte)
        => await _workRepository.FindByConditioAsync(prediacte);
        public async Task<IReadOnlyCollection<Work>> FindByConditionAsync(Expression<Func<Work, bool>> prediacte)
        => await _workRepository.FindByConditioAsync(prediacte);
        public async Task<bool> AddComentAsync(Comment comment, int WorkId)
        => await _workRepository.AddComentAsync(WorkId, comment);
        public async Task<List<Work>> GetWorksByValidStateAsync(ValidateState state)
        => (await _workRepository.FindByConditioAsync(x => x.Validation == state)).ToList();
        public async Task AddSubCommentAsync(int CommentId, Comment SubComment)
        => await _commentRepository.AddSubCooment(CommentId, SubComment);
    }
}
