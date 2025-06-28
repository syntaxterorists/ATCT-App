using System;
using Microsoft.Maui.Controls;
using ATCT_Frontend.Helpers;
using ATCT_Frontend.ViewModels;


namespace ATCT_Frontend.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
            DisplayAlert("DEBUG", "Profile page loaded", "OK");
        }

        /*
        private void OnEyeTapped(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        }
        */

        private async void OnQrTapped(object sender, EventArgs e)
        {
            var email = UserSession.Email;
            var client = new HttpClient();

            try
            {
                var imageBytes = await client.GetByteArrayAsync($"http://10.0.2.2:5279/api/User/qrcode-by-email?email={email}");
                var imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                await App.Current.MainPage.DisplayAlert("QR Code", "Your QR code has been loaded.", "OK");

                // Prikaz QR koda u novom prozoru
                await Shell.Current.Navigation.PushModalAsync(new ContentPage
                {
                    Content = new Image
                    {
                        Source = imageSource,
                        WidthRequest = 250,
                        HeightRequest = 250,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    },
                    BackgroundColor = Colors.White
                });
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to load QR code: {ex.Message}", "OK");
            }
        }
    }
}
