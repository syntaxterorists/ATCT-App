namespace ATCT_Frontend.Views;

public partial class OnboardingPage4 : ContentPage
{
	public OnboardingPage4()
	{
		InitializeComponent();
	}
    private async void OnBackTapped(object sender, EventArgs e)
    {
        await this.FadeTo(0, 10);
        await Navigation.PopAsync(animated: false);
        this.Opacity = 1;
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        var next = new AccountCreationPage { Opacity = 0 };
        await Navigation.PushAsync(next, animated: false);
        await next.FadeTo(1, 300);
    }
}