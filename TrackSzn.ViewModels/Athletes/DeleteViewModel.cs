using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Athletes
{
    public class DeleteViewModel
    {
        public Athlete Athlete { get; set; }
        public IList<AthletePerformance> AthletePerformances { get; set; } = new List<AthletePerformance>();
        public IList<AthleteLift> AthleteLifts { get; set; } = new List<AthleteLift>();
    }
}