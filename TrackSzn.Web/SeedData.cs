using System;
using System.Collections.Generic;
using TrackSzn.Models;
// ReSharper disable InconsistentNaming

namespace TrackSzn.Web
{
    public static class SeedData
    {
        private static class AthleteIds
        {
            internal static readonly int NateClingan = 1;
            internal static readonly int JakeKemp = 2;
            internal static readonly int CoryStarman = 3;
            internal static readonly int LoganStewart = 4;
            internal static readonly int NathanSzymczak = 5;
            internal static readonly int DillonDefibaugh = 6;
            internal static readonly int TrevorMurray = 7;
            internal static readonly int AndyVasel = 8;
            internal static readonly int TommySword = 9;
            internal static readonly int LexiRhoads = 10;
            internal static readonly int LisaWangler = 11;
            internal static readonly int MeaganScheck = 12;
            internal static readonly int EvanAllen = 13;
        }

        private static class EventIds
        {
            internal static readonly int ShotPut = 1;
            internal static readonly int Discus = 2;
        }

        private static class LiftIds
        {
            internal static readonly int HangClean = 1;
            internal static readonly int BenchPress = 2;
            internal static readonly int BackSquat = 3;
            internal static readonly int Jerk = 4;
            internal static readonly int PullUps = 5;
            internal static readonly int ShoulderPress = 6;
            internal static readonly int StepUps = 7;
            internal static readonly int LatPullDown = 8;
            internal static readonly int Deadlift = 9;
            internal static readonly int StandingRow = 10;
        }

        private static class MeetIds
        {
            internal static readonly int DualvsWoodridge = 1;
            internal static readonly int OrangeRelays = 2;
            internal static readonly int Smithville9th10thGradeInvitational = 3;
            internal static readonly int PTCTrackAndFieldChampionships = 4;
        }

        public static List<Athlete> Athletes => new List<Athlete>
        {
            new Athlete {Name = "Nate Clingan", GraduationYear = 2019},
            new Athlete {Name = "Jake Kemp", GraduationYear = 2019},
            new Athlete {Name = "Cory Starman", GraduationYear = 2019},
            new Athlete {Name = "Logan Stewart", GraduationYear = 2020},
            new Athlete {Name = "Nathan Szymczak", GraduationYear = 2019},
            new Athlete {Name = "Dillon Defibaugh", GraduationYear = 2019},
            new Athlete {Name = "Trevor Murray", GraduationYear = 2020},
            new Athlete {Name = "Andy Vasel", GraduationYear = 2020},
            new Athlete {Name = "Tommy Sword", GraduationYear = 2021},
            new Athlete {Name = "Lexi Rhoads", GraduationYear = 2018},
            new Athlete {Name = "Lisa Wangler", GraduationYear = 2018},
            new Athlete {Name = "Meagan Scheck", GraduationYear = 2019},
            new Athlete {Name = "Evan Allen", GraduationYear = 2021},
        };

        public static List<Event> Events => new List<Event>
        {
            new Event {Name = "Shot Put"},
            new Event {Name = "Discus"}
        };

        public static List<Lift> Lifts => new List<Lift>
        {
            new Lift {Name = "Hang Clean"},
            new Lift {Name = "Bench Press"},
            new Lift {Name = "Back Squat"},
            new Lift {Name = "Jerk"},
            new Lift {Name = "Pull Ups"},
            new Lift {Name = "Shoulder Press"},
            new Lift {Name = "Step Ups"},
            new Lift {Name = "Lat Pull Down"},
            new Lift {Name = "Deadlift"},
            new Lift {Name = "Standing Row"},
        };

        public static List<Meet> Meets => new List<Meet>
        {
            new Meet { Name = "Dual vs. Woodridge", Date = new DateTimeOffset(2018, 4, 24, 0, 0, 0, TimeSpan.Zero) },
            new Meet { Name = "Orange Relays", Date = new DateTimeOffset(2018, 4, 27, 0, 0, 0, TimeSpan.Zero) },
            new Meet { Name = "Smithville 9th/10th Grade Invitational", Date = new DateTimeOffset(2018, 5, 7, 0, 0, 0, TimeSpan.Zero) },
            new Meet { Name = "PTC Track and Field Championships", Date = new DateTimeOffset(2018, 5, 9, 0, 0, 0, TimeSpan.Zero) },
        };

        public static List<AthleteLift> AthleteLifts => new List<AthleteLift>
        {
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.HangClean, SetNumber = 1, Repetitions = 5, Weight = 95, Date = new DateTimeOffset(2018, 4, 17, 0, 0, 0, TimeSpan.Zero) },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.HangClean, SetNumber = 2, Repetitions = 5, Weight = 95, Date = new DateTimeOffset(2018, 4, 17, 0, 0, 0, TimeSpan.Zero) },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.HangClean, SetNumber = 3, Repetitions = 5, Weight = 95, Date = new DateTimeOffset(2018, 4, 17, 0, 0, 0, TimeSpan.Zero) },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.BenchPress, SetNumber = 1, Repetitions = 5, Weight = 115, Date = new DateTimeOffset(2018, 4, 17, 0, 0, 0, TimeSpan.Zero) },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.BenchPress, SetNumber = 2, Repetitions = 5, Weight = 115, Date = new DateTimeOffset(2018, 4, 17, 0, 0, 0, TimeSpan.Zero) },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.BenchPress, SetNumber = 3, Repetitions = 5, Weight = 115, Date = new DateTimeOffset(2018, 4, 17, 0, 0, 0, TimeSpan.Zero) },
        };

        public static List<AthletePerformance> AthletePerformances => new List<AthletePerformance>
        {
            new AthletePerformance { AthleteId = AthleteIds.NateClingan, EventId = EventIds.ShotPut, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 582 },
            new AthletePerformance { AthleteId = AthleteIds.JakeKemp, EventId = EventIds.ShotPut, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 476 },
            new AthletePerformance { AthleteId = AthleteIds.NateClingan, EventId = EventIds.Discus, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 1693 },
            new AthletePerformance { AthleteId = AthleteIds.JakeKemp, EventId = EventIds.Discus, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 1212 },
        };
    }
}