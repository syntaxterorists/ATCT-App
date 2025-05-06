using Microsoft.Maui.Controls;
using System;

namespace ATCT2025App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation
            Routing.RegisterRoute(nameof(ATCT2025App.Views.HomePage), typeof(ATCT2025App.Views.HomePage));
            Routing.RegisterRoute(nameof(ATCT2025App.Views.SplashPage), typeof(ATCT2025App.Views.SplashPage));
            /*
            Routing.RegisterRoute(nameof(ATCT2025App.Views.LocationsPage), typeof(ATCT2025App.Views.LocationsPage));
            Routing.RegisterRoute(nameof(ATCT2025App.Views.ProgramPage), typeof(ATCT2025App.Views.ProgramPage));
            Routing.RegisterRoute(nameof(ATCT2025App.Views.SpeakersPage), typeof(ATCT2025App.Views.SpeakersPage));
            Routing.RegisterRoute(nameof(ATCT2025App.Views.AboutPage), typeof(ATCT2025App.Views.AboutPage));
            Routing.RegisterRoute(nameof(ATCT2025App.Views.ProfilePage), typeof(ATCT2025App.Views.ProfilePage));*/
        }
    }
}