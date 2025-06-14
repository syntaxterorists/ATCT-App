

// This file is part of ATCT-Backend project.
// Used to divide the code into smaller files for better organization and maintainability, clean the code sent to the backend. 


using System.ComponentModel.DataAnnotations;

namespace ATCT_Backend.Models.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
