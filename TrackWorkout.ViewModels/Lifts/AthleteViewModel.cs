using System.Collections.Generic;
using TrackWorkout.Models;

namespace TrackWorkout.ViewModels.Lifts
{
    public class AthleteViewModel
    {
        public AthleteViewModel(Athlete athlete, List<AthleteLift> athleteLifts)
        {
            this.Athlete = athlete;
            this.AthleteLifts = athleteLifts;
        }

        public Athlete Athlete { get; }
        public List<AthleteLift> AthleteLifts { get; }
    }
}