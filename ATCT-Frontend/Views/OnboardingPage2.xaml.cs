namespace ATCT_Frontend.Views;

public partial class OnboardingPage2 : ContentPage
{
	public OnboardingPage2()
	{
		InitializeComponent();
	}
    private async void OnBackTapped(object sender, EventArgs e)
    {
        // fade i pop
        await this.FadeTo(0, 10);
        await Navigation.PopAsync(animated: false);
        this.Opacity = 1;
    }
    private async void OnNextClicked(object sender, EventArgs e)
    {
        //Navigacija na sljedecu stranicu dok je nevidljiva
        var next = new OnboardingPage3 { Opacity = 0 };

        // pa animacija
        await Navigation.PushAsync(next, animated: false);

        // pa fade
        await next.FadeTo(1, 300);  // 300ms fade
    }
}

