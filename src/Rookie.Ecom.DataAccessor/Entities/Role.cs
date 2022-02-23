using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Role:BaseEntity
    {
        public Guid? UserID { get; set; }

        public User User { get; set; }

        public string RoleName { get; set; }

        public int RoleValue { get; set; }

    }
}
