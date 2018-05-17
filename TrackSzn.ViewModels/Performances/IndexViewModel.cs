using System.Linq;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Performances
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