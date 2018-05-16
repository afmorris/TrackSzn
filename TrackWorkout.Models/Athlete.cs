using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace TrackWorkout.Models
{
    public class Athlete : BaseModel
    {
        public string Name { get; set; }
        public int GraduationYear { get; set; }

        [Reference]
        public IList<AthleteLift> AthleteLifts { get; set; }

        [Reference]
        public IList<AthletePerformance> AthletePerformances { get; set; }
    }
}