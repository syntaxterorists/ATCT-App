namespace ATCT_Frontend.Views;

public partial class FeedbackPage : ContentPage
{
    private int id;

    public FeedbackPage()
    {
        InitializeComponent();
    }

    public FeedbackPage(int id)
    {
        this.id = id;
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {

        DisplayAlert("Feedback Submitted",
            $"Thank you!",
             "OK");
    }

}