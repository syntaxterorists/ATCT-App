

// Creating the Speaker class with properties for Id, Name, and Description


namespace ATCT_Backend.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
