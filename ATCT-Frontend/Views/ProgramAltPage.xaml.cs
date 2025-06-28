using System;
using Microsoft.Maui.Controls;
using ATCT_Frontend.ViewModels;
using ATCT_Frontend.Models;
using ATCT_Frontend.Services;

namespace ATCT_Frontend.Views
{
    public partial class ProgramAltPage : ContentPage
    {
        private readonly ProgramAltViewModel viewModel = new();

        public ProgramAltPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadSessionsAsync();
        }

        private void OnBackTapped(object sender, EventArgs e)
        {
            this.FadeTo(0, 10)
                .ContinueWith(_ => Navigation.PopAsync(false),
                              TaskScheduler.FromCurrentSynchronizationContext())
                .ContinueWith(_ => this.Opacity = 1,
                              TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Session session)
            {
                int userId = Preferences.Get("userId", 1007);
                if (userId == 0)
                {
                    await DisplayAlert("Greška", "Korisnik nije prijavljen.", "OK");
                    return;
                }
                var apiService = new ApiService();
                var response = await apiService.RegisterToSessionAsync(session.Id, userId);
                await DisplayAlert("Prijava", response, "OK");

                // Osvježi AttendeeDisplay (privremeno, ne povlačimo sve iznova)
                session.CurrentAttendees += 1;
                session.AttendeeDisplay = $"{session.CurrentAttendees} / {session.MaxAttendees}";
            }
        }

        private async void OnReviewClicked(object sender, EventArgs e)
        {



            if (sender is Button button && button.BindingContext is Session session)
            {
                await DisplayAlert("Recenzija", $"Otvaranje recenzije za: {session.Title}", "OK");

                // Kada napraviš ReviewPage, koristi:
                // await Navigation.PushAsync(new ReviewPage(session.Id));
            }
        }


    }
}
