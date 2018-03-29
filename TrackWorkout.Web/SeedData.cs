using System;
using System.Collections.Generic;
using TrackWorkout.Models;

namespace TrackWorkout.Web
{
    public static class SeedData
    {
        public static List<Athlete> Athletes => new List<Athlete>
        {
            new Athlete {Id = Guid.NewGuid(), ClusterId = 1, Name = "Nate Clingan", GraduationYear = 2019},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 2, Name = "Jake Kemp", GraduationYear = 2019},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 3, Name = "Cory Starman", GraduationYear = 2019},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 4, Name = "Logan Stewart", GraduationYear = 2020},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 5, Name = "Nathan Szymczak", GraduationYear = 2019},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 6, Name = "Dillon Defibaugh", GraduationYear = 2019},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 7, Name = "Trevor Murray", GraduationYear = 2020},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 8, Name = "Andy Vasel", GraduationYear = 2020},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 9, Name = "Thomas Vince", GraduationYear = 2021},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 10, Name = "Tommy Sword", GraduationYear = 2021},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 11, Name = "Lexi Rhoads", GraduationYear = 2018},
            new Athlete {Id = Guid.NewGuid(), ClusterId = 12, Name = "Lisa Wangler", GraduationYear = 2018}
        };

        public static List<Event> Events => new List<Event>
        {
            new Event {Id = Guid.NewGuid(), ClusterId = 1, Name = "Shot Put"},
            new Event {Id = Guid.NewGuid(), ClusterId = 2, Name = "Discus"}
        };

        public static List<Lift> Lifts => new List<Lift>
        {
            new Lift {Id = Guid.NewGuid(), ClusterId = 1, Name = "Hang Clean"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 2, Name = "Bench Press"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 3, Name = "Back Squat"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 4, Name = "Jerk"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 5, Name = "Pull Ups"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 6, Name = "Shoulder Press"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 7, Name = "Step Ups"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 8, Name = "Lat Pull Down"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 9, Name = "Deadlift"},
            new Lift {Id = Guid.NewGuid(), ClusterId = 10, Name = "Standing Row"},
        };
    }
}