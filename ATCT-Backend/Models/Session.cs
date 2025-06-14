



// Creating the Session class to represent a session in the conference
// Defining the properties of the Session class

namespace ATCT_Backend.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
        public string Location { get; set; } = string.Empty;
        public int MaxAttendees { get; set; }
        public int CurrentAttendees { get; set; }
        public ICollection<UserSession>? UserSessions { get; set; }
    }
}
