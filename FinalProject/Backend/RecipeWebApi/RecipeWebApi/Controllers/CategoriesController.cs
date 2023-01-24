using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeWebApi.DTOs;
using RecipeWebApi.Interfaces;
using RecipeWebApi.Models;
using RecipeWebApi.Repositories;

namespace RecipeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryRepository.GetAllCategories());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
                return NotFound();
            else
                return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto category)
        {
            var categoryResult = await _categoryRepository.Add(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CategoryDto category)
        {
            var result = await _categoryRepository.Update(id, category);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _categoryRepository.Delete(id);
            if (result == true)
                return Ok("Category has been Deleted");
            else
                return BadRequest();
        }
    }
}
