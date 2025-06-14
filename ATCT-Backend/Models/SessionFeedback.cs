namespace ATCT_Backend.Models
{
    public class SessionFeedback
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int SessionId { get; set; }
        public Session? Session { get; set; }

        public int Rating { get; set; } // od 1 do 5
        public string Comment { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; }
    }
}
