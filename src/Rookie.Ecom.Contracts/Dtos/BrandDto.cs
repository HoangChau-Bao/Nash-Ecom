using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class BrandDto : BaseDto
    {
        public string Name { get; set; }

        public string Decription { get; set; }

        public ICollection<ProductDto> Product { get; set; }
    }
}
