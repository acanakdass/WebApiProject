using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Core.Dtos;
using WebApiProject.Core.Entities;
using WebApiProject.Core.Services;

namespace WebApiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetByIdWithProducts(int id)
        {
            var category = await _categoryService.GetByIdWithProducts(id);
            var categoryWithProductDto = _mapper.Map<CategoryWithProductsDto>(category);
            return Ok(categoryWithProductDto);

        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var categoryToCreate = _mapper.Map<Category>(categoryDto);
            await _categoryService.AddAsync(categoryToCreate);

            return Created(string.Empty, categoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            var categoryToUpdate = _mapper.Map<Category>(categoryDto);
            var categoryUpdated = await _categoryService.UpdateAsync(categoryToUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoryToDelete = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(categoryToDelete);
            return NoContent();
        }
    }
}
