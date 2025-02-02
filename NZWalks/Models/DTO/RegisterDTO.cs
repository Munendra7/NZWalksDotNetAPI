using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class RegisterDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public required string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        public required string[] Roles { get; set; }
    }
}
