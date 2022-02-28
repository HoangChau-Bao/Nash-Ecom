using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductRatingService
    {
        Task<IEnumerable<ProductRatingDto>> GetAllAsync();

        Task<PagedResponseModel<ProductRatingDto>> PagedQueryAsync(/*string name, */int page, int limit);

        Task<ProductRatingDto> GetByIdAsync(Guid id);

        //Task<ProductRatingDto> GetByNameAsync(string name);

        Task<ProductRatingDto> AddAsync(ProductRatingDto productRatingDto);

        Task DeleteAsync(Guid id)
;
        Task UpdateAsync(ProductRatingDto productRatingDto);
    }
}
