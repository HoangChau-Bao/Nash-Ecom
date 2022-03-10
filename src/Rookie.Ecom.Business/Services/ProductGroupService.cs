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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IBaseRepository<ProductGroup> _baseRepository;
        private readonly IMapper _mapper;

        public ProductGroupService(IBaseRepository<ProductGroup> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductGroupDto> AddAsync(ProductGroupDto productGroupDto)
        {
            var productGroup = _mapper.Map<ProductGroup>(productGroupDto);
            var item = await _baseRepository.AddAsync(productGroup);
            return _mapper.Map<ProductGroupDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(ProductGroupDto productGroupDto)
        {
            var productGroup = _mapper.Map<ProductGroup>(productGroupDto);
            await _baseRepository.UpdateAsync(productGroup);
        }

        public async Task<IEnumerable<ProductGroupDto>> GetAllAsync()
        {
            var productGroup = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductGroupDto>>(productGroup);
        }

        public async Task<ProductGroupDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var productGroup = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductGroupDto>(productGroup);
        }

        public async Task<ProductGroupDto> GetByNameAsync(string name)
        {
            var productGroup = await _baseRepository.GetByAsync(x => x.Name == name);
            return _mapper.Map<ProductGroupDto>(productGroup);
        }

        public async Task<PagedResponseModel<ProductGroupDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name));

            query = query.OrderBy(x => x.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductGroupDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductGroupDto>>(assets.Items)
            };
        }

        public async Task<ProductGroupDto> GetByAsync(Expression<Func<ProductGroup, bool>> filter, string includeProperties = "")
        {
            var productGroup = await _baseRepository.GetByAsync(filter, includeProperties);
            return _mapper.Map<ProductGroupDto>(productGroup);
        }
    }
}
