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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetByIdWithCategory(int id)
        {
            var product = await _productService.GetByIdWithCategories(id);
            var productWithCategoryDto = _mapper.Map<ProductWithCategoryDto>(product);
            return Ok(productWithCategoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var productToAdd = _mapper.Map<Product>(productDto);
            await _productService.AddAsync(productToAdd);
            var addedProduct = _mapper.Map<ProductDto>(productToAdd);
            return Created(string.Empty, addedProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            var productToUpdate = _mapper.Map<Product>(productDto);
            await _productService.UpdateAsync(productToUpdate);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productToDelete = _productService.GetByIdAsync(id).Result;
            _productService.Remove(productToDelete);
            return Ok();
        }


    }
}
