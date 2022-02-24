using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderDto : BaseDto
    {
        //public Guid? UserID { get; set; }

        //public UserDto User { get; set; }

        public int OrderTotal { get; set; }

        //public ICollection<OrderDetailDto> OrderDetail { get; set; }
    }
}
