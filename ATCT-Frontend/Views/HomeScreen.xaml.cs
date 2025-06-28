using System;
using ATCT_Frontend.ViewModels;

namespace ATCT_Frontend.Views;

public partial class HomeScreen : ContentPage
{
    private readonly SpeakersViewModel viewModel = new();

    public HomeScreen()
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.LoadSpeakers();
    }
}