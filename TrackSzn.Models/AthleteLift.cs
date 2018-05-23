using System;
using ServiceStack.DataAnnotations;

namespace TrackSzn.Models
{
    public class AthleteLift : BaseModel
    {
        public int AthleteId { get; set; }
        public int LiftId { get; set; }
        public int SetNumber { get; set; }
        public int Repetitions { get; set; }
        public float Weight { get; set; }
        public DateTime Date { get; set; }

        [Reference]
        public Athlete Athlete { get; set; }

        [Reference]
        public Lift Lift { get; set; }
    }
}