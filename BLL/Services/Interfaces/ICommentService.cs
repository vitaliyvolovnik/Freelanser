using Domain.Models;
namespace BLL.Services.Interfaces
{
    public interface ICommentService
    {
        Task AddSubCommentAsync(int CommentId, Comment SubComment);
    }
}
