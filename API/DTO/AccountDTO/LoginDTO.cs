using System.ComponentModel.DataAnnotations;

namespace API.DTO.AccountDTO
{
    public class loginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}