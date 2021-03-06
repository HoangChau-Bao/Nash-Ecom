using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IUserService
    {

        Task<PagedResponseModel<UserDto>> PagedQueryAsync(string name, int page, int limit);

    }
}
