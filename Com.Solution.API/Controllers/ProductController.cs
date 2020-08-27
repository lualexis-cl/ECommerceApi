using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Com.Solution.API.Dtos;
using Com.Solution.API.Errors;
using Com.Solution.Core.Entities;
using Com.Solution.Core.Interfaces;
using Com.Solution.Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Solution.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productRepository.GetEntityWithSpec(new ProductWithDetailSpecification(id));

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var productDto = _mapper.Map<Product, ProductDto>(product);

            return Ok(productDto);
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductList()
        {
            var spec = new ProductWithDetailSpecification();
            var productList = await _productRepository.ListAsync(spec);
            var productDtoList = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(productList);
            return Ok(productDtoList);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrandList()
        {
            var productBrandList = await _productBrandRepository.GetAllListAsync();

            return Ok(new List<string>());
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypeList()
        {
            var productTypeList = await _productTypeRepository.GetAllListAsync();

            return Ok(productTypeList);
        }
    }
}
