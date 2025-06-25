 namespace ATCT_Frontend.Views;

 public partial class OnboardingPage1 : ContentPage
 {
     public OnboardingPage1()
     {
         InitializeComponent();
     }

     private async void OnBackTapped(object sender, EventArgs e)
     {
         await Navigation.PopAsync();
     }

     private async void OnNextClicked(object sender, EventArgs e)
     {
        //Navigacija na sljedecu stranicu dok je nevidljiva
        var next = new OnboardingPage2 { Opacity = 0 };

        // pa animacija
        await Navigation.PushAsync(next, animated: false);

        // pa fade
        await next.FadeTo(1, 300);  // 300ms fade
    }
 }