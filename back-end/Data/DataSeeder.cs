using TourismBookingAPI.Models;

namespace TourismBookingAPI.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Destinations.Any())
            {
                var hawaii = new Destination
                {
                    Name = "Hawaii Adventure",
                    Location = "Hawaii",
                    Description = "A tropical surfing and yoga paradise.",
                    ImageUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e"
                };
                var swiss = new Destination
                {
                    Name = "Swiss Alps Retreat",
                    Location = "Switzerland",
                    Description = "Breathtaking alpine hikes and snow workouts.",
                    ImageUrl = "https://images.unsplash.com/photo-1501785888041-af3ef285b470"
                };
                var bali = new Destination
                {
                    Name = "Bali Wellness Escape",
                    Location = "Bali",
                    Description = "Serene yoga, meditation, and spiritual healing.",
                    ImageUrl = "https://images.unsplash.com/photo-1518684079-55e3ad937233"
                };

                context.Destinations.AddRange(hawaii, swiss, bali);
                context.SaveChanges();
            }

            if (!context.Packages.Any())
            {
                context.Packages.AddRange(
                    new Package { Name = "Sunrise Yoga", Location = "Bali" },
                    new Package { Name = "Mountain Hiking Pass", Location = "Switzerland" },
                    new Package { Name = "Surf & Relax", Location = "Hawaii" }
                );
                context.SaveChanges();
            }

            if (!context.Exercises.Any())
            {
                context.Exercises.AddRange(
                    new Exercise
                    {
                        Name = "Sun Salutation",
                        VideoUrl = "https://example.com/sunsalutation.mp4",
                        ImageUrl = "https://images.unsplash.com/photo-1594737625785-c92a51c178d9"
                    },
                    new Exercise
                    {
                        Name = "Mountain Climbers",
                        VideoUrl = "https://example.com/mountainclimbers.mp4",
                        ImageUrl = "https://images.unsplash.com/photo-1599058917212-d750089bc07c"
                    },
                    new Exercise
                    {
                        Name = "Deep Breathing",
                        VideoUrl = "https://example.com/breathing.mp4",
                        ImageUrl = "https://images.unsplash.com/photo-1607672566237-233342a8d1f4"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Workouts.Any())
            {
                var surf = context.Packages.First(p => p.Name == "Surf & Relax");
                var hike = context.Packages.First(p => p.Name == "Mountain Hiking Pass");
                var yoga = context.Packages.First(p => p.Name == "Sunrise Yoga");

                var w1 = new Workout
                {
                    Name = "Beach Yoga",
                    Description = "Morning yoga session at sunrise on the beach.",
                    ImageUrl = "https://images.unsplash.com/photo-1554295387-0b429f0a45c5",
                    PackageId = surf.Id
                };
                var w2 = new Workout
                {
                    Name = "Alpine Hike",
                    Description = "Endurance-focused hiking in the Alps.",
                    ImageUrl = "https://images.unsplash.com/photo-1508253578933-e60e3dd38c99",
                    PackageId = hike.Id
                };
                var w3 = new Workout
                {
                    Name = "Mindful Meditation",
                    Description = "Breath-focused seated meditation and relaxation.",
                    ImageUrl = "https://images.unsplash.com/photo-1524492412937-4961b06b38e4",
                    PackageId = yoga.Id
                };

                context.Workouts.AddRange(w1, w2, w3);
                context.SaveChanges();

                // Link workouts to exercises
                w1.Exercises.Add(context.Exercises.First(e => e.Name == "Sun Salutation"));
                w2.Exercises.Add(context.Exercises.First(e => e.Name == "Mountain Climbers"));
                w3.Exercises.Add(context.Exercises.First(e => e.Name == "Deep Breathing"));
                context.SaveChanges();
            }
        }
    }
}
