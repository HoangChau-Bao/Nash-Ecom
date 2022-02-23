using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public bool Gender { get; set; }

        public ICollection<ProductRatingDto> ProductRating { get; set; }

        public ICollection<RoleDto> Role { get; set; }

        public ICollection<UserAddressDto> UserAddress { get; set; }
    }
}
