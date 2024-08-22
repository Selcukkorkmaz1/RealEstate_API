﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.ProductRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult>ProductList()
        {
           var values=await _productRepository.GetAllProductAsync(); 
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
		[HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
		public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
		{
			_productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
			return Ok("İlan Günün Fırsatları Arasına Eklendi");
		}

		[HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
		public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
		{
			_productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
			return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
		}
        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertListByEmployeeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }
    }
}
