using System.Linq;
using TrackWorkout.Models;

namespace TrackWorkout.ViewModels.Performances
{
    public class IndexViewModel
    {
        public IndexViewModel(IOrderedEnumerable<IGrouping<int, Athlete>> athletesByGraduationYear)
        {
            this.AthletesByGraduationYear = athletesByGraduationYear;
        }

        public IOrderedEnumerable<IGrouping<int, Athlete>> AthletesByGraduationYear { get; }
    }
}