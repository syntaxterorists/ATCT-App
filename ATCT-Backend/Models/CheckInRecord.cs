namespace ATCT_Backend.Models
{
    public class CheckInRecord
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int SessionId { get; set; }
        public Session? Session { get; set; }

        public DateTime CheckInTime { get; set; }
    }
}
