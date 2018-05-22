using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Lifts
{
    public class DeleteViewModel
    {
        public Lift Lift { get; set; }
        public IList<AthleteLift> AthleteLifts { get; set; } = new List<AthleteLift>();
    }
}