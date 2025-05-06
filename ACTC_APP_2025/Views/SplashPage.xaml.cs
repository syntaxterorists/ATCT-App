using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace ATCT2025App.Views
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            //UpdateButtonText();
        }
        /*
        private void UpdateButtonText()
        {
            int currentIndex = slidesCarousel.CurrentItem != null ?
                ((System.Collections.IList)slidesCarousel.ItemsSource).IndexOf(slidesCarousel.CurrentItem) : 0;

            bool isLastSlide = currentIndex == slidesCarousel.ItemsSource.Count - 1;
            nextButton.Text = isLastSlide ? "Get Started" : "Next";
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            int currentIndex = slidesCarousel.CurrentItem != null ?
                ((System.Collections.IList)slidesCarousel.ItemsSource).IndexOf(slidesCarousel.CurrentItem) : 0;

            if (currentIndex < slidesCarousel.ItemsSource.Count - 1)
            {
                // Move to the next slide
                slidesCarousel.CurrentItem = slidesCarousel.ItemsSource[currentIndex + 1];
                UpdateButtonText();
            }
            else
            {
                // This is the last slide, navigate to the home page
                GoToHomePage();
            }
        }
        */
        private void OnSkipClicked(object sender, EventArgs e)
        {
            GoToHomePage();
        }

        private async void GoToHomePage()
        {
            // Store that onboarding is complete
            Preferences.Default.Set("OnboardingComplete", true);

            // Navigate to HomePage
            await Shell.Current.GoToAsync("///HomePage");
        }

        // Fix for the event handler issue
        private EventHandler<CurrentItemChangedEventArgs> carouselItemChangedHandler;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Create a single instance of the event handler
           // carouselItemChangedHandler = (s, e) => UpdateButtonText();

            // Attach the handler
            slidesCarousel.CurrentItemChanged += carouselItemChangedHandler;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Detach the handler
            if (carouselItemChangedHandler != null)
            {
                slidesCarousel.CurrentItemChanged -= carouselItemChangedHandler;
            }
        }
    }
}