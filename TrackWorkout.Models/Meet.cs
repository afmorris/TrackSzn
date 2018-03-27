using System;

namespace TrackWorkout.Models
{
    public class Meet : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}