using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWebApi.DTOs;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Repositories;

namespace RecipeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentReposetory _commentReposetory;

        public CommentsController(ICommentReposetory commentReposetory)
        {
            this._commentReposetory = commentReposetory;
        }

        [HttpGet]
        public async Task<ActionResult <CommentsDto>> Get(string id)
        {
            var comments = await _commentReposetory.GetAllComments(id);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CommentsDto comments)
        {
            var commentResult = await _commentReposetory.Add(comments);
            return Ok(commentResult);
        }


    }
}
