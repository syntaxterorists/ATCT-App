namespace ATCT_Frontend.Views;

public partial class Splashscreen1 : ContentPage
{
    public Splashscreen1()
    {
        InitializeComponent();
    }

    private async void OnGetStartedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage()); // Or replace with your next page
    }
}
