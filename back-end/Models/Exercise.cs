using System.Collections.Generic;

namespace TourismBookingAPI.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }

        // ✅ Add this:
        public string ImageUrl { get; set; }

        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }

}
