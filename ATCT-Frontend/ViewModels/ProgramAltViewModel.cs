using ATCT_Frontend.Models;
using ATCT_Frontend.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ATCT_Frontend.ViewModels
{
    public class ProgramAltViewModel
    {
        public ObservableCollection<Session> Sessions { get; set; } = new();
        private readonly ApiService _apiService = new();

        public async Task LoadSessionsAsync()
        {
            var list = await _apiService.GetSessionsAsync();
            Sessions.Clear();
            foreach (var s in list)
            {
                s.AttendeeDisplay = $"{s.CurrentAttendees} / {s.MaxAttendees}";
                Sessions.Add(s);
            }
        }
    }
}
