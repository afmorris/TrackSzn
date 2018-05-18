using System.Linq;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Athletes
{
    public class LiftsViewModel
    {
        public LiftsViewModel(IOrderedEnumerable<IGrouping<int, Athlete>> athletesByGraduationYear)
        {
            this.AthletesByGraduationYear = athletesByGraduationYear;
        }

        public IOrderedEnumerable<IGrouping<int, Athlete>> AthletesByGraduationYear { get; }
    }
}