using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Constants;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ProductRatingController : Controller
    {
        private readonly IProductRatingService _productRatingService;
        public ProductRatingController(IProductRatingService productRatingService)
        {
            _productRatingService = productRatingService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductRatingDto>> CreateAsync([FromBody] ProductRatingDto productRatingDto)
        {
            Ensure.Any.IsNotNull(productRatingDto, nameof(productRatingDto));
            var asset = await _productRatingService.AddAsync(productRatingDto);
            return Created(Endpoints.ProductRating, asset);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ProductRatingDto productRatingDto)
        {
            Ensure.Any.IsNotNull(productRatingDto, nameof(productRatingDto));
            await _productRatingService.UpdateAsync(productRatingDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssetAsync([FromRoute] Guid id)
        {
            var productRatingDto = await _productRatingService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(productRatingDto, nameof(productRatingDto));
            await _productRatingService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ProductRatingDto> GetByIdAsync(Guid id)
            => await _productRatingService.GetByIdAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ProductRatingDto>> GetAsync()
            => await _productRatingService.GetAllAsync();

        [HttpGet("find")]
        public async Task<PagedResponseModel<ProductRatingDto>>
            FindAsync(string name, int page = 1, int limit = 10)
            => await _productRatingService.PagedQueryAsync(/*name,*/ page, limit);
    }
}
