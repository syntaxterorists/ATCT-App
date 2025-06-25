namespace ATCT_Frontend.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void OnBackTapped(object sender, EventArgs e)
    {
        // same fade?out + pop logic you used elsewhere
        await this.FadeTo(0, 10);
        await Navigation.PopAsync(animated: false);
        this.Opacity = 1;
    }

    // If you also need a sign?in button code?behind handler:
    //private async void OnSignInClicked(object sender, EventArgs e)
    //{
        //await this.FadeTo(0, 10);
        // navigate to next page, e.g. MainPage
        //await Navigation.PushAsync(new MainPage(), animated: false);
        //this.Opacity = 1;
    //}
}