using System;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void OnEyeTapped(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        }

        private async void OnQrTapped(object sender, EventArgs e)
        {
            await DisplayAlert("QR Scanner", "Opening camera…", "OK");
        }
    }
}
