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
}