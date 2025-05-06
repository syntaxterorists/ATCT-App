using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Storage;
using System;

namespace ATCT2025App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            // Check if this is the first run
            bool onboardingComplete = Preferences.Default.Get("OnboardingComplete", false);

            if (!onboardingComplete)
            {
                // First run, show splash/onboarding
                await Shell.Current.GoToAsync("///SplashPage");
            }
            else
            {
                // Not first run, go to home page
                await Shell.Current.GoToAsync("///HomePage");
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}