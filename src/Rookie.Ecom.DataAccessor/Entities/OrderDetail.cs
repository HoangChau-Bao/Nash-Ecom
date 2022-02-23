using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class OrderDetail:BaseEntity
    {

        public Guid? OrderID { get; set; }

        public int UnitPrice { get; set; }

        public int ProductQuantity { get; set; }

        public int Total { get; set; }

        public string ShippingAddress { get; set; }

        public Guid? ProductID { get; set; }

        public Product Product { get; set; }

    }
}
