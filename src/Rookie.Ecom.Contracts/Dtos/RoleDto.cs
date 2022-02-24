using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class RoleDto : BaseDto
    {
        public Guid? UserID { get; set; }

        public UserDto User { get; set; }

        public string RoleName { get; set; }

        public int RoleValue { get; set; }
    }
}
