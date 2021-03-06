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
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var item = await _baseRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(item);
        }

        public async Task<ProductInfoDto> AddAsync1(ProductInfoDto productInfoDto)
        {
            var product = _mapper.Map<Product>(productInfoDto);
            var item = await _baseRepository.AddAsync(product);
            return _mapper.Map<ProductInfoDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(ProductInfoDto productInfoDto)
        {
            var product = _mapper.Map<Product>(productInfoDto);
            await _baseRepository.UpdateAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var product = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetByNameAsync(string name)
        {
            var product = await _baseRepository.GetByAsync(x => x.Name == name);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<PagedResponseModel<ProductDto>> PagedQueryAsync(Expression<Func<Product, bool>> filter, int page, int limit, string includeProperties = "")
        {
            var query = _baseRepository.Entities;

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(','))
                {
                    query = query.Include(property);
                }
            }

            //query = query.Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name));

            query = query.Where(filter);

            query = query.OrderBy(x => x.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductDto>>(assets.Items)
            };
        }

        public async Task<ProductDto> GetByAsync(Expression<Func<Product, bool>> filter, string includeProperties = "")
        {
            var product = await _baseRepository.GetByAsync(filter, includeProperties);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllByAsync(Expression<Func<Product, bool>> filter, string includeProperties = "")
        {
            var product = await _baseRepository.GetAllByAsync(filter, includeProperties);
            return _mapper.Map<List<ProductDto>>(product);
        }

        public async Task<PagedResponseModel<ProductDto>> PagedQueryAsyncDefaul(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name));

            query = query.OrderBy(x => x.Name);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductDto>>(assets.Items)
            };
        }
    }
}
