using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductGroupService
    {
        Task<IEnumerable<ProductGroupDto>> GetAllAsync();

        Task<PagedResponseModel<ProductGroupDto>> PagedQueryAsync(string name, int page, int limit);

        Task<ProductGroupDto> GetByIdAsync(Guid id);

        Task<ProductGroupDto> GetByNameAsync(string name);

        Task<ProductGroupDto> AddAsync(ProductGroupDto productGroupDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductGroupDto productGroupDto);

        Task<ProductGroupDto> GetByAsync(Expression<Func<ProductGroup, bool>> filter, string includeProperties = "");
    }
}
