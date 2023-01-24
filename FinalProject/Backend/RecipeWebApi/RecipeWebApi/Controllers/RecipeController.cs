using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWebApi.DTOs;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Models;

namespace RecipeWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            this._recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            return Ok(await _recipeRepository.GetAllRecipes());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recipe>> Get(string id)
        {
            var recipe = await _recipeRepository.GetById(id);
            if (recipe == null)
                return NotFound();
            else
                return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Post( RecipeDto recipe)
        {
           var recipeResult = await _recipeRepository.Add(recipe) ;
           return Ok(recipeResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, RecipeDto recipe)
        {
            var result = await _recipeRepository.Update(id, recipe);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _recipeRepository.Delete(id);
            if (result == true)
                return Ok("Recipe has been Deleted");
            else
                return BadRequest();
        }
    }
}
