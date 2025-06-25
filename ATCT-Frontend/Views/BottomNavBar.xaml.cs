using System;
using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class BottomNavBar : ContentView
    {
        public BottomNavBar()
        {
            InitializeComponent();
        }

        private async void OnHomeTapped(object sender, EventArgs e)
        {
            // Navigate to HomeScreen
            await Application.Current.MainPage
                .Navigation
                .PushAsync(new HomeScreen(), animated: false);
        }

        private async void OnVenuesTapped(object sender, EventArgs e)
        {
            // Navigate to VenuePage
            await Application.Current.MainPage
                .Navigation
                .PushAsync(new VenuePage(), animated: false);
        }

        private async void OnInfoTapped(object sender, EventArgs e)
        {
            // Navigate to InfoPage
            await Application.Current.MainPage
                .Navigation
                .PushAsync(new InfoPage(), animated: false);
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            // Navigate to ProfilePage
            await Application.Current.MainPage
                .Navigation
                .PushAsync(new ProfilePage(), animated: false);
        }
    }
}
