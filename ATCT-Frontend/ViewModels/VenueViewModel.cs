using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using ATCT_Frontend.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ATCT_Frontend.ViewModels
{
    public class VenueViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Models.Location> Locations { get; set; } = new();
        private int currentIndex = 0;

        private string _name;
        private string _address;
        private string _description;
        private string _imageSource;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public string Address { get => _address; set { _address = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public string ImageSource { get => _imageSource; set { _imageSource = value; OnPropertyChanged(); } }

        public async Task LoadLocationsAsync()
        {
            try
            {
                var client = new HttpClient();
                var result = await client.GetFromJsonAsync<List<Models.Location>>("http://10.0.2.2:5279/api/Locations");
                if (result != null && result.Count > 0)
                {
                    Locations.Clear();
                    foreach (var loc in result)
                        Locations.Add(loc);

                    ShowLocation(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void ShowLocation(int index)
        {
            if (index >= 0 && index < Locations.Count)
            {
                var loc = Locations[index];
                Name = loc.Name;
                Address = loc.Address;
                Description = loc.Description;

                // Image mapping by name or id (hardcoded for now)
                if (loc.Name.Contains("Gazi"))
                    ImageSource = "ghb";
                else
                    ImageSource = "fsk";

                currentIndex = index;
            }
        }

        public void NextLocation()
        {
            var next = (currentIndex + 1) % Locations.Count;
            ShowLocation(next);
        }

        public void PreviousLocation()
        {
            var prev = (currentIndex - 1 + Locations.Count) % Locations.Count;
            ShowLocation(prev);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
