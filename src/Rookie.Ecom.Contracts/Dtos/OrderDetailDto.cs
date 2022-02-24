using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderDetailDto : BaseDto
    {
        public Guid? OrderID { get; set; }

        public int UnitPrice { get; set; }

        public int ProductQuantity { get; set; }

        public int Total { get; set; }

        public string ShippingAddress { get; set; }

        public Guid? ProductID { get; set; }

        public ProductDto Product { get; set; }

    }
}
