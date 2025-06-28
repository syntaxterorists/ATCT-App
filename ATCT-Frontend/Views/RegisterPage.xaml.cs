using System;
using ATCT_Frontend.ViewModels;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
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
           /* await this.FadeTo(0, 10);
            // after registering, go to the login screen
            await Navigation.PushAsync(new HomeScreen(), animated: false);
            this.Opacity = 1;*/
        }
    }
}
