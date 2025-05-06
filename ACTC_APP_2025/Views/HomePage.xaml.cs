using Microsoft.Maui.Controls;
using System;

namespace ATCT2025App.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }
    /*
    private async void OnViewScheduleClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProgramPage));
    }

    private async void OnProgramTileTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProgramPage));
    }

    private async void OnSpeakersTileTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SpeakersPage));
    }

    private async void OnLocationsTileTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LocationsPage));
    }

    private async void OnProfileTileTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }*/

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // You can load dynamic data here when the page appears
        // For example, fetch the next upcoming session from your data service
        LoadUpcomingSession();
    }

    private void LoadUpcomingSession()
    {
        // In a real app, you would fetch this data from a service
        // For now, we're using hardcoded data in the XAML

        // Example of how you might update it dynamically:
        // nextSessionTitle.Text = upcomingSession.Title;
        // nextSessionLocation.Text = upcomingSession.Location;
        // nextSessionSpeaker.Text = upcomingSession.SpeakerName;
        // nextSessionTime.Text = upcomingSession.StartTime.ToString("h:mm tt");
    }
}