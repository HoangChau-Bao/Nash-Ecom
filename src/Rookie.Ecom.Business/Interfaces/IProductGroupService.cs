using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
