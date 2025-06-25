using System;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class OpeningAltAltPage : ContentPage
    {
        public OpeningAltAltPage()
        {
            InitializeComponent();
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await this.FadeTo(0, 10);
            await Navigation.PopAsync(animated: false);
            this.Opacity = 1;
        }
    }
}
