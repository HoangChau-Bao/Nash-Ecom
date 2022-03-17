using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class ProductRating:BaseEntity
    {
        public Guid? UserID { get; set; }

        //public User User { get; set; }

        public Guid? ProductID { get; set; }

        public Product product { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

    }
}
