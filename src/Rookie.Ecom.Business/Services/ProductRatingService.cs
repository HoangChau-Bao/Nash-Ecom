using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.Business.Extensions;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class ProductRatingService : IProductRatingService
    {
        private readonly IBaseRepository<ProductRating> _baseRepository;
        private readonly IMapper _mapper;

        public ProductRatingService(IBaseRepository<ProductRating> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductRatingDto> AddAsync(ProductRatingDto productRatingDto)
        {
            var productRating = _mapper.Map<ProductRating>(productRatingDto);
            var item = await _baseRepository.AddAsync(productRating);
            return _mapper.Map<ProductRatingDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(ProductRatingDto productRatingDto)
        {
            var productRating = _mapper.Map<ProductRating>(productRatingDto);
            await _baseRepository.UpdateAsync(productRating);
        }

        public async Task<IEnumerable<ProductRatingDto>> GetAllAsync()
        {
            var productRatings = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductRatingDto>>(productRatings);
        }

        public async Task<ProductRatingDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var productRating = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductRatingDto>(productRating);
        }

        /*public async Task<ProductRatingDto> GetByNameAsync(string name)
        {
            var productRating = await _baseRepository.GetByAsync(x => x.Name == name);
            return _mapper.Map<ProductRatingDto>(productRating);
        }*/

        public async Task<PagedResponseModel<ProductRatingDto>> PagedQueryAsync(/*string name,*/ int page, int limit)
        {
            var query = _baseRepository.Entities;

            // query = query.Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name));

            query = query.OrderBy(x => x.Id);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductRatingDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductRatingDto>>(assets.Items)
            };
        }
    }
}
