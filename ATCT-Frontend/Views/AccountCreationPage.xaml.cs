namespace ATCT_Frontend.Views;

public partial class AccountCreationPage : ContentPage
{
	public AccountCreationPage()
	{
		InitializeComponent();
	}
    private async void OnBackTapped(object sender, EventArgs e)
    {
        // same fade-out and pop logic you used on OnboardingPage4
        await this.FadeTo(0, 10);
        await Navigation.PopAsync(animated: false);
        this.Opacity = 1;
    }
    private async void OnSignInClicked(object sender, EventArgs e)
    {
        // Fade out this page
        await this.FadeTo(0, 10);

        // Push the LoginPage without its own default animation
        await Navigation.PushAsync(new LoginPage(), animated: false);

        // Reset opacity in case it was changed
        this.Opacity = 1;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // fade out current page
        await this.FadeTo(0, 10);

        // navigate to the RegisterPage
        await Navigation.PushAsync(new RegisterPage(), animated: false);

        // restore opacity
        this.Opacity = 1;
    }

    private async void OnGuestClicked(object sender, EventArgs e)
    {
        // fade out current page
        await this.FadeTo(0, 10);

        // navigate to the RegisterPage
        await Navigation.PushAsync(new HomeScreen(), animated: false);

        // restore opacity
        this.Opacity = 1;
    }
}