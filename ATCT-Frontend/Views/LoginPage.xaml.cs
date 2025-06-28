using ATCT_Frontend.ViewModels;

namespace ATCT_Frontend.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }
    private async void OnBackTapped(object sender, EventArgs e)
    {
        await this.FadeTo(0, 10);
        await Navigation.PopAsync(animated: false);
        this.Opacity = 1;
    }

    
    private async void OnSignInClicked(object sender, EventArgs e)
    {

        //await this.FadeTo(0, 10);
       // await Navigation.PushAsync(new HomeScreen(), animated: false);
        //this.Opacity = 1;
    } 
}