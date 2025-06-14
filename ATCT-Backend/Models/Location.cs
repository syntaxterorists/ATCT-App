


// Creating the Location class and defining all the properties


namespace ATCT_Backend.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
