
// This file is part of ATCT-Backend project.
// Used to divide the code into smaller files for better organization and maintainability, clean the code sent to the backend. 


namespace ATCT_Backend.Models.Dtos
{
    public class LoginDto
    {

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
