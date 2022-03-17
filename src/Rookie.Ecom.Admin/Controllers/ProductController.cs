using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        //private object _baseRepository;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateAsync([FromBody] ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            var asset = await _productService.AddAsync(productDto);
            return Created(Endpoints.Product, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            await _productService.UpdateAsync(productDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var productDto = await _productService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            await _productService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(Guid id)
            => await _productService.GetByIdAsync(id);

/*        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAllByAsync()
            => await _productService.GetAllByAsync(null, "");

        [HttpGet]
        public async Task<ProductDto> GetByAsync()
            => await _productService.GetByAsync(null, "");*/

        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductDto>>
            FindAsync(int page = 1, int limit = 10)
            => await _productService.PagedQueryAsync(null, page, limit, null);
    }
}
