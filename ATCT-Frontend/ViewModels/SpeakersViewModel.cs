using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ATCT_Frontend.Models;

namespace ATCT_Frontend.ViewModels
{
    public class SpeakersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Speaker> Speakers { get; set; } = new();

        public async Task LoadSpeakers()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://10.0.2.2:5279/api/Speakers");
            if (response.IsSuccessStatusCode)
            {
                var speakers = await response.Content.ReadFromJsonAsync<List<Speaker>>();
                Speakers.Clear();
                foreach (var s in speakers)
                    Speakers.Add(s);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
