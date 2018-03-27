using System;

namespace TrackWorkout.Models
{
    public class AthletePerformance : BaseModel
    {
        public Guid AthleteId { get; set; }
        public Guid MeetId { get; set; }
        public Guid EventId { get; set; }
        public float Performance { get; set; }
    }
}