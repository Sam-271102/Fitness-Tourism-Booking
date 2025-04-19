namespace TourismBookingAPI.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        // ✅ Add this:
        public string ImageUrl { get; set; }

        public ICollection<Package> Packages { get; set; }
    }

}
