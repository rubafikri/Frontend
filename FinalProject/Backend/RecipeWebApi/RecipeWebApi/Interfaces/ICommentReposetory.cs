using RecipeWebApi.DTOs;
using RecipeWebApi.Models;

namespace RecipeWebApi.Interfaces
{
    public interface ICommentReposetory
    {
        Task<List<CommentsDto>> GetAllComments(string id);
        Task<Comments> Add(CommentsDto Comments);
       

    }
}
