using ATCT_Backend.Models;

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
    }
}
