using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Net.Http.Json;
using ATCT_Frontend.Models;
using ATCT_Frontend.Helpers;

namespace ATCT_Frontend.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;

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

        public ICommand SignInCommand { get; }

        public LoginViewModel()
        {
            SignInCommand = new Command(async () => await SignIn());
        }

        private async Task SignIn()
        {
            var client = new HttpClient();

            var loginRequest = new LoginRequest
            {
                Email = Email,
                Password = Password
            };

            var response = await client.PostAsJsonAsync("http://10.0.2.2:5279/api/Auth/login", loginRequest);
            if (response.IsSuccessStatusCode)
            {
                // ✳️ Uspješan login – povuci sve podatke o korisniku GET-om
                var userDetails = await client.GetFromJsonAsync<LoginResponse>($"http://10.0.2.2:5279/api/User/by-email?email={Email}");

                if (userDetails != null)
                {
                    UserSession.SetUser(userDetails.FullName, userDetails.Email, userDetails.Location ?? "Unknown");
                    Console.WriteLine($"Ime: {userDetails.FullName}, Email: {userDetails.Email}, Lokacija: {userDetails.Location}");

                    await Shell.Current.GoToAsync("//HomeScreen");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Failed to fetch user details", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Login Failed", "Invalid credentials", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
