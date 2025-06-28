using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCT_Frontend.Models
{
    class RegisterRequest
    {
        public string FullName { get; set; }  // ili samo "Name", zavisi od backend API-a
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
