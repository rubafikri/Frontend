using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookStore.API.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly IImageUploaderService _uploaderService;

        public PublisherController(IPublisherRepository publisherRepository,IMapper mapper, IImageUploaderService uploaderService)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _uploaderService = uploaderService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePublisherDto createPublisherDto)
        {
            var newPublisher = _mapper.Map<Publishers>(createPublisherDto);
            newPublisher.Logo = await _uploaderService.UploadImageAsync(createPublisherDto.Image);
            return Ok(await _publisherRepository.Create(newPublisher));

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdatePublisherDto updatePublisherDto)
        {
            var newPublisher = updatePublisherDto.Adapt<Publishers>();
            newPublisher.Logo = await _uploaderService.UploadImageAsync(updatePublisherDto.Logo);

            var publisher = await _publisherRepository.Update(newPublisher);
            return Ok(publisher);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? serachKey)
        {
            var publishers = await _publisherRepository.GetAll(serachKey);
            return Ok(publishers);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _publisherRepository.Delete(id);
            return Ok(result);
        }
    }
}
