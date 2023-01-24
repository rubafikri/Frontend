using Mapster;
using Microsoft.EntityFrameworkCore;
using RecipeWebApi.Data;
using RecipeWebApi.DTOs;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Models;

namespace RecipeWebApi.Repositories
{
    public class CommentRepository : ICommentReposetory
    {
        private readonly RecipesDbContext _context;
        public CommentRepository(RecipesDbContext context)
        {
            _context = context;
        }
        public async Task<Comments> Add(CommentsDto Comments)
        {
            var commentNew = Comments.Adapt<Comments>();
            await _context.comments.AddAsync(commentNew);
            await _context.SaveChangesAsync();
            return commentNew;
        }

        public async Task<List<CommentsDto>> GetAllComments(string Id)
        {
            return await _context.comments.ProjectToType<CommentsDto>().Where(x => x.Recipe.Id == Id).ToListAsync();
            



        }
    }
}
