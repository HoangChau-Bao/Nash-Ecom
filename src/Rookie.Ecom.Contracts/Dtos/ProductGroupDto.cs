using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductGroupDto : BaseDto
    {
        public string Name { get; set; }

        public ICollection<ProductDto> Products { get; set; }

    }
}
