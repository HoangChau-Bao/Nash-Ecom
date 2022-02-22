using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Order:BaseEntity
    {
        public Guid? UserID { get; set; }

        public User User { get; set; }

        public int OrderTotal { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }

        public OrderItem OrderItem { get; set; }

    }
}
