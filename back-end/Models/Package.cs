using System.Collections.Generic;

namespace TourismBookingAPI.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Workout> Workouts { get; set; } = new List<Workout>();
    }
}