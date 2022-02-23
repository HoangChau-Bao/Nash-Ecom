using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Brand:BaseEntity
    {
        public string Name { get; set; }

        public string Decription { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
