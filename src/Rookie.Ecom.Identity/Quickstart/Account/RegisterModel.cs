using System.ComponentModel.DataAnnotations;

namespace IdentityServerHost.Quickstart.UI
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression("([A-Za-z1-9]).{4,}")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("([A-Za-z1-9]).{4,}")]
        public string Password { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string ReturnUrl { get; set; }

    }
}