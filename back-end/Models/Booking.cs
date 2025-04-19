namespace TourismBookingAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookingDate { get; set; }

        // ✅ Add this:
        public int PackageId { get; set; }

        // Navigation property (optional, but recommended)
        public Package Package { get; set; }
    }
}
