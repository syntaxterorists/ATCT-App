using Microsoft.Maui.Controls;
using ATCT_Frontend.Models;
using System.Net.Http.Json;

namespace ATCT_Frontend.Views
{
    public partial class VenuePage : ContentPage
    {
        public VenuePage()
        {
            InitializeComponent();
            LoadVenues();
        }

        private async void LoadVenues()
        {
            try
            {
                var client = new HttpClient();
                var venues = await client.GetFromJsonAsync<List<Models.Location>>("http://10.0.2.2:5279/api/Locations");

                if (venues != null && venues.Count >= 2)
                {
                    
                    Venue1Desc.Text = venues[0].Description;
                    VenueImage.Source = venues[0].ImageSource;


                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
