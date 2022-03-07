using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ProductGroupController : Controller
    {
        private readonly IProductGroupService _productGroupService;
        public ProductGroupController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductGroupDto>> CreateAsync([FromBody] ProductGroupDto productGroupDto)
        {
            Ensure.Any.IsNotNull(productGroupDto, nameof(productGroupDto));
            var asset = await _productGroupService.AddAsync(productGroupDto);
            return Created(Endpoints.ProductGroup, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductGroupDto productGroupDto)
        {
            Ensure.Any.IsNotNull(productGroupDto, nameof(productGroupDto));
            await _productGroupService.UpdateAsync(productGroupDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var productGroupDto = await _productGroupService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(productGroupDto, nameof(productGroupDto));
            await _productGroupService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductGroupDto> GetByIdAsync(Guid id)
            => await _productGroupService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductGroupDto>> GetAsync()
            => await _productGroupService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductGroupDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _productGroupService.PagedQueryAsync(name, page, limit);
    }
}
