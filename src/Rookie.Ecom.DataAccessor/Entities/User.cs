using System;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class User : BaseEntity
    {
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        public int Age { get; set; }

        [StringLength(maximumLength: 10)]
        public string Phone { get; set; }

        public bool Gender { get; set; }



        //public Guid? ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
