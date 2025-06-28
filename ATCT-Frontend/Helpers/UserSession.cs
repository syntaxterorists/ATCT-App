using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCT_Frontend.Helpers
{
    class UserSession
    {
        public static string FullName { get; set; }
        public static string Email { get; set; }
        public static string Location { get; set; }

        public static event Action OnUserChanged;

        public static void SetUser(string fullName, string email, string location)
        {
            FullName = fullName;
            Email = email;
            Location = location;
            
            OnUserChanged?.Invoke();
        }

    }
}
