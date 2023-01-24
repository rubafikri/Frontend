using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/translators")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {
        private readonly ITranslatorRepository _translatorRepository;
        public TranslatorController(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTranslatorDto createTranslatorDto)
        {
            var newTranslator = createTranslatorDto.Adapt<Translators>();
            var translator = await _translatorRepository.Create(newTranslator);
            return Ok(translator);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateTranslatorDto updateTranslatorDto)
        {
            var newTranslator = updateTranslatorDto.Adapt<Translators>();
            var translator = await _translatorRepository.Update(newTranslator);
            return Ok(translator);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var translators = await _translatorRepository.GetAll();
            return Ok(translators);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var result =  await _translatorRepository.Delete(id);
            
            return Ok(result);
        }

    }
}
