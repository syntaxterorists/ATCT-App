using System;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        // fade & go back
        private async void OnBackTapped(object sender, EventArgs e)
        {
            await this.FadeTo(0, 10);
            await Navigation.PopAsync(animated: false);
            this.Opacity = 1;
        }

        // fade & navigate to LoginPage
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await this.FadeTo(0, 10);
            // after registering, go to the login screen
            await Navigation.PushAsync(new HomeScreen(), animated: false);
            this.Opacity = 1;
        }
    }
}
