using System.Collections.Generic;

namespace TourismBookingAPI.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // ✅ Add this:
        public string ImageUrl { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }

}