using System.ComponentModel.DataAnnotations;

namespace API.DTO.AccountDTO
{
    public class UserDTO
    {
        [Required]
        public string DisplayName { get; set; }
        
        [Required]
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}