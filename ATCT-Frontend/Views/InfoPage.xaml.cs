using System;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private async void OnAboutTapped(object sender, EventArgs e)
        {
            await this.FadeTo(0, 10);
            await Navigation.PushAsync(new AboutAltPage(), animated: false);
            this.Opacity = 1;
        }

        private async void OnProgramTapped(object sender, EventArgs e)
        {
            await this.FadeTo(0, 10);
            await Navigation.PushAsync(new ProgramAltPage(), animated: false);
            this.Opacity = 1;
        }

        private async void OnSpeakersTapped(object sender, EventArgs e)
        {
            await this.FadeTo(0, 10);
            await Navigation.PushAsync(new SpeakersAltPage(), animated: false);
            this.Opacity = 1;
        }
    }
}
