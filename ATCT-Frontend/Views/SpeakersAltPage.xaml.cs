using System;
using Microsoft.Maui.Controls;
using ATCT_Frontend.ViewModels;

namespace ATCT_Frontend.Views
{
    public partial class SpeakersAltPage : ContentPage
    {
        private readonly SpeakersViewModel viewModel = new();

        public SpeakersAltPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadSpeakers();
        }

        private async void OnBackTapped(object sender, EventArgs e)
        {
            await this.FadeTo(0, 10);
            await Navigation.PopAsync(animated: false);
            this.Opacity = 1;
        }
    }
}
