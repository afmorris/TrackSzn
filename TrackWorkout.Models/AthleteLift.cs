using System;

namespace TrackWorkout.Models
{
    public class AthleteLift : BaseModel
    {
        public Guid AthleteId { get; set; }
        public Guid LiftId { get; set; }
        public int SetNumber { get; set; }
        public int Repetitions { get; set; }
        public float Weight { get; set; }
        public DateTimeOffset Date { get; set; }

        public virtual Athlete Athlete { get; set; }
        public virtual Lift Lift { get; set; }
    }
}