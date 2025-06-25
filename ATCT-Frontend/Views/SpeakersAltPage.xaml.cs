using System;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class SpeakersAltPage : ContentPage
    {
        public SpeakersAltPage()
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
