using System;
using ServiceStack.DataAnnotations;

namespace TrackSzn.Models
{
    public class AthletePerformance : BaseModel
    {
        public int AthleteId { get; set; }
        public int MeetId { get; set; }
        public int EventId { get; set; }
        public float Performance { get; set; }

        [Reference]
        public Athlete Athlete { get; set; }

        [Reference]
        public Meet Meet { get; set; }

        [Reference]
        public Event Event { get; set; }
    }
}