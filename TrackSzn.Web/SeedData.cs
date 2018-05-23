using System;
using System.Collections.Generic;
using TrackSzn.Models;
// ReSharper disable InconsistentNaming

namespace TrackSzn.Web
{
    public static class SeedData
    {
        private static class UserIds
        {
            internal static readonly string TonyMorris = "google-oauth2|115575258463837209989";
        }

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
            new Athlete {Name = "Nate Clingan", GraduationYear = 2019, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Jake Kemp", GraduationYear = 2019, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Cory Starman", GraduationYear = 2019, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Logan Stewart", GraduationYear = 2020, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Nathan Szymczak", GraduationYear = 2019, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Dillon Defibaugh", GraduationYear = 2019, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Trevor Murray", GraduationYear = 2020, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Andy Vasel", GraduationYear = 2020, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Tommy Sword", GraduationYear = 2021, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Lexi Rhoads", GraduationYear = 2018, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Lisa Wangler", GraduationYear = 2018, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Meagan Scheck", GraduationYear = 2019, UserId = UserIds.TonyMorris },
            new Athlete {Name = "Evan Allen", GraduationYear = 2021, UserId = UserIds.TonyMorris },
        };

        public static List<Event> Events => new List<Event>
        {
            new Event {Name = "Shot Put", UserId = UserIds.TonyMorris },
            new Event {Name = "Discus", UserId = UserIds.TonyMorris }
        };

        public static List<Lift> Lifts => new List<Lift>
        {
            new Lift {Name = "Hang Clean", UserId = UserIds.TonyMorris },
            new Lift {Name = "Bench Press", UserId = UserIds.TonyMorris },
            new Lift {Name = "Back Squat", UserId = UserIds.TonyMorris },
            new Lift {Name = "Jerk", UserId = UserIds.TonyMorris },
            new Lift {Name = "Pull Ups", UserId = UserIds.TonyMorris },
            new Lift {Name = "Shoulder Press", UserId = UserIds.TonyMorris },
            new Lift {Name = "Step Ups", UserId = UserIds.TonyMorris },
            new Lift {Name = "Lat Pull Down", UserId = UserIds.TonyMorris },
            new Lift {Name = "Deadlift", UserId = UserIds.TonyMorris },
            new Lift {Name = "Standing Row", UserId = UserIds.TonyMorris },
        };

        public static List<Meet> Meets => new List<Meet>
        {
            new Meet { Name = "Dual vs. Woodridge", Date = new DateTime(2018, 4, 24), UserId = UserIds.TonyMorris },
            new Meet { Name = "Orange Relays", Date = new DateTime(2018, 4, 27), UserId = UserIds.TonyMorris },
            new Meet { Name = "Smithville 9th/10th Grade Invitational", Date = new DateTime(2018, 5, 7), UserId = UserIds.TonyMorris },
            new Meet { Name = "PTC Track and Field Championships", Date = new DateTime(2018, 5, 9), UserId = UserIds.TonyMorris },
        };

        public static List<AthleteLift> AthleteLifts => new List<AthleteLift>
        {
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.HangClean, SetNumber = 1, Repetitions = 5, Weight = 95, Date = new DateTime(2018, 4, 17), UserId = UserIds.TonyMorris },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.HangClean, SetNumber = 2, Repetitions = 5, Weight = 95, Date = new DateTime(2018, 4, 17), UserId = UserIds.TonyMorris },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.HangClean, SetNumber = 3, Repetitions = 5, Weight = 95, Date = new DateTime(2018, 4, 17), UserId = UserIds.TonyMorris },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.BenchPress, SetNumber = 1, Repetitions = 5, Weight = 115, Date = new DateTime(2018, 4, 17), UserId = UserIds.TonyMorris },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.BenchPress, SetNumber = 2, Repetitions = 5, Weight = 115, Date = new DateTime(2018, 4, 17), UserId = UserIds.TonyMorris },
            new AthleteLift { AthleteId = AthleteIds.EvanAllen, LiftId = LiftIds.BenchPress, SetNumber = 3, Repetitions = 5, Weight = 115, Date = new DateTime(2018, 4, 17), UserId = UserIds.TonyMorris },
        };

        public static List<AthletePerformance> AthletePerformances => new List<AthletePerformance>
        {
            new AthletePerformance { AthleteId = AthleteIds.NateClingan, EventId = EventIds.ShotPut, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 582, UserId = UserIds.TonyMorris },
            new AthletePerformance { AthleteId = AthleteIds.JakeKemp, EventId = EventIds.ShotPut, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 476, UserId = UserIds.TonyMorris },
            new AthletePerformance { AthleteId = AthleteIds.NateClingan, EventId = EventIds.Discus, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 1693, UserId = UserIds.TonyMorris },
            new AthletePerformance { AthleteId = AthleteIds.JakeKemp, EventId = EventIds.Discus, MeetId = MeetIds.PTCTrackAndFieldChampionships, Performance = 1212, UserId = UserIds.TonyMorris },
        };
    }
}