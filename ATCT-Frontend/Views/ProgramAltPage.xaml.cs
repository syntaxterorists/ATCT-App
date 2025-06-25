using System;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class ProgramAltPage : ContentPage
    {
        public ProgramAltPage()
        {
            InitializeComponent();
        }

        private void OnBackTapped(object sender, EventArgs e)
        {
            // fade-out + pop
            this.FadeTo(0, 10)
                .ContinueWith(_ => Navigation.PopAsync(false),
                              TaskScheduler.FromCurrentSynchronizationContext())
                .ContinueWith(_ => this.Opacity = 1,
                              TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void OnOpeningTapped(object sender, EventArgs e)
        {
            // fade-out + navigate
            await this.FadeTo(0, 10);
            await Navigation.PushAsync(new OpeningAltAltPage(), animated: false);
            this.Opacity = 1;
        }
    }
}
