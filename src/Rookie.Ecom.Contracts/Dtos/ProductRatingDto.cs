using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductRatingDto
    {
        public Guid? UserID { get; set; }

        public UserDto User { get; set; }

        public Guid? ProductID { get; set; }

        public ProductDto product { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }
    }
}
