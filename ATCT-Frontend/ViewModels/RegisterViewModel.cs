using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ATCT_Frontend.Models;
using System.Net.Http.Json;

namespace ATCT_Frontend.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _email;
        private string _password;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterAsync());
        }

        private async Task RegisterAsync()
        {
            var client = new HttpClient();
            var request = new RegisterRequest
            {
                FullName = Name,
                Email = Email,
                Password = Password
            };

            var response = await client.PostAsJsonAsync("http://10.0.2.2:5279/api/Auth/register", request);

            if (response.IsSuccessStatusCode)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Registration successful!", "OK");
                await Shell.Current.GoToAsync("//LoginPage"); // ili pushaj LoginPage ručno
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Registration failed.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
