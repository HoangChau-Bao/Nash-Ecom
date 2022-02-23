using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class UserAddress : BaseEntity
    {
        public Guid? UserID { get; set; }

        public User User { get; set; }

        public string Address { get; set; }

    }
}
