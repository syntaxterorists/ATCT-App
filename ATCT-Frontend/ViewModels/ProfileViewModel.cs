using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ATCT_Frontend.Helpers;

namespace ATCT_Frontend.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private string _fullName;
        private string _email;
        private string _location;

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged(); }
        }

        public ProfileViewModel()
        {
            FullName = UserSession.FullName;
            Email = UserSession.Email;
            Location = UserSession.Location;

            UserSession.OnUserChanged += () =>
            {
                FullName = UserSession.FullName;
                Email = UserSession.Email;
                Location = UserSession.Location;
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
