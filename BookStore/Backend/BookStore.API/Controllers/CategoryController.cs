using BookStore.API.DTOs;
using BookStore.API.Interface;
using BookStore.API.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<AppUser> _userManager;

        public CategoryController(ICategoryRepository categoryRepository, UserManager<AppUser> userManager)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto createCategoryDto)
        {
            var newCategory = createCategoryDto.Adapt<Categories>();
            var category = await _categoryRepository.Create(newCategory);
            return Ok(category);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateCategoryDto updateCategoryDto)
        {
            var newCategory = updateCategoryDto.Adapt<Categories>();
            var category = await _categoryRepository.Update(newCategory);
            return Ok(category);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
      
            var category = await _categoryRepository.GetAll();
         return   Ok( category);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var result = await _categoryRepository.Delete(id);
            return Ok(result);
        }

    }
}
