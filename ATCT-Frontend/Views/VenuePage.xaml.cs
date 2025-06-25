using Microsoft.Maui.Controls;

namespace ATCT_Frontend.Views
{
    public partial class VenuePage : ContentPage
    {
        bool showingText = false;

        public VenuePage()
        {
            InitializeComponent();
        }

        private void OnContentSwiped(object sender, SwipedEventArgs e)
        {
            if (!showingText && e.Direction == SwipeDirection.Right)
            {
                // Show the description text
                VenueImage.IsVisible = false;
                VenueText.IsVisible = true;
                SwipeInstruction.Text = "Swipe left to see the picture ??";
                showingText = true;
            }
            else if (showingText && e.Direction == SwipeDirection.Left)
            {
                // Restore the image
                VenueText.IsVisible = false;
                VenueImage.IsVisible = true;
                SwipeInstruction.Text = "Swipe right on the picture for more info ??";
                showingText = false;
            }
        }
    }
}
