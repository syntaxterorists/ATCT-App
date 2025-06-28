
namespace ATCT_Frontend.Models

{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SpeakerId { get; set; }
        public string Location { get; set; }
        public int MaxAttendees { get; set; }
        public int CurrentAttendees { get; set; }
        public string AttendeeDisplay { get; set; }


        // Dodatno (nije obavezno)
        public Speaker? Speaker { get; set; }
    }

   
}
